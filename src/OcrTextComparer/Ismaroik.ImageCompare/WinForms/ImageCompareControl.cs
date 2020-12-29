using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Tesseract;

namespace Ismaroik.ImageCompare.WinForms
{
    public partial class ImageCompareControl : UserControl
    {
        private string mIm1FilePath_Original;
        private string mIm2FilePath_Original;
        private string mIm1FilePath_WorkingCopy;
        private string mIm2FilePath_WorkingCopy;

        private string mWorkingFolder;

        private string mScan1DetectedText;
        private string mScan2DetectedText;
        private Dictionary<string, List<Rect>> mScan1Lines = new Dictionary<string, List<Rect>>();
        private Dictionary<string, List<Rect>> mScan2Lines = new Dictionary<string, List<Rect>>();
        
        private bool mRTB_HandleEvents = false;

        public ImageCompareControl()
        {
            InitializeComponent();
        }

        #region Properties

        public string TextComparePercentage
        { get; private set; }

        public int CountOfConsecutiveDiffs
        { get; private set; }

        public List<Diff> TextDiffs
        { get; private set; }

        public int ImagesTextSplitterDistance
        {
            get
            {
                return splitContainer2.SplitterDistance;
            }
            set
            {
                splitContainer2.SplitterDistance = value;
            }
        }

        public bool SynchronizeImagePanZoom
        {
            get
            {
                return iccScanImages.SynchronizeImagePanZoom;
            }
            set
            {
                iccScanImages.SynchronizeImagePanZoom = value;
            }
        }

        private Color mTextDeleteColor = Color.Red;
        public Color TextDeleteColor
        {
            get
            {
                return mTextDeleteColor;
            }
            set
            {
                mTextDeleteColor = value;
            }
        }

        private Color mInsertColor = Color.Green;
        public Color TextInsertColor
        {
            get
            {
                return mInsertColor;
            }
            set
            {
                mInsertColor = value;
            }
        }

        #endregion

        public void LoadImages(string im1Path, string im2Path, string workingFolder, bool preprocessImages)
        {
            mIm1FilePath_Original = im1Path;
            mIm2FilePath_Original = im2Path;
            mWorkingFolder = workingFolder;

            InitImages(preprocessImages);
            InitImageCompareControl();
        }

        private void InitImages(bool preprocess)
        {
            if (preprocess)
            {
                mIm1FilePath_WorkingCopy = Path.Combine(mWorkingFolder, "im1" + ".tif");
                mIm2FilePath_WorkingCopy = Path.Combine(mWorkingFolder, "im2" + ".tif");

                ImagePreprocess.PreprocessImage(mIm1FilePath_Original, mIm1FilePath_WorkingCopy);
                ImagePreprocess.PreprocessImage(mIm2FilePath_Original, mIm2FilePath_WorkingCopy);
            }
            else
            {
                mIm1FilePath_WorkingCopy = mIm1FilePath_Original;
                mIm2FilePath_WorkingCopy = mIm2FilePath_Original;
            }
        }

        private void InitImageCompareControl()
        {
            iccScanImages.Image1 = Image.FromFile(mIm1FilePath_WorkingCopy);
            iccScanImages.Image2 = Image.FromFile(mIm2FilePath_WorkingCopy);
            iccScanImages.FitToScreen();
        }

        public void PerformOcr_Tes(string tesseractDataPath, string languageCode)
        {
            using (var engine = new TesseractEngine(tesseractDataPath, languageCode, EngineMode.Default))
            {
                mScan1DetectedText = GetTextFromImage_Tes(engine, mIm1FilePath_WorkingCopy, mScan1Lines);
            }

            using (var engine = new TesseractEngine(tesseractDataPath, languageCode, EngineMode.Default))
            {
                mScan2DetectedText = GetTextFromImage_Tes(engine, mIm2FilePath_WorkingCopy, mScan2Lines);
            }

            CompareTexts_FillRTB();
        }

        private string GetTextFromImage_Tes(TesseractEngine engine, string imageFilePath, Dictionary<string, List<Rect>> lines)
        {
            lines.Clear();
            var scanDetectedTextSB = new StringBuilder();
            using (var img = Pix.LoadFromFile(imageFilePath))
            {
                engine.SetVariable("tessedit_write_images", true);
                //engine.DefaultPageSegMode = PageSegMode.;

                using (var page = engine.Process(img))
                {
                    using (var iter = page.GetIterator())
                    {
                        var lastBlockTextLineRect = new Rect();
                        bool recentlyAddedEmptyLine = false;
                        iter.Begin();
                        do
                        {
                            var line = iter.GetText(PageIteratorLevel.TextLine);
                            if (string.IsNullOrEmpty(line)) line = string.Empty;

                            // remove any spaces
                            line = line.Trim();

                            // remove line breaks from string produced by tesseract
                            line = Regex.Replace(line, @"\t|\n|\r", "");

                            if (iter.IsAtBeginningOf(PageIteratorLevel.Block))
                            {
                                // check if it is new column, if yes add one more empty line
                                if (lastBlockTextLineRect.Width > 0 && !string.IsNullOrEmpty(line))
                                {
                                    Rect currentBlockTextLineRect = new Rect();
                                    if (iter.TryGetBoundingBox(PageIteratorLevel.Block, out currentBlockTextLineRect))
                                    {
                                        if (lastBlockTextLineRect.X1 > currentBlockTextLineRect.X2 || lastBlockTextLineRect.X2 < currentBlockTextLineRect.X1)
                                        {
                                            //// x coordinates of blocks does not overlap ==> mark as next column
                                            //scanDetectedTextSB.AppendLine("<".PadRight(100,'-') + ">");
                                            //scanDetectedTextSB.AppendLine();
                                        }
                                    }
                                }
                            }

                            // allow only one subsequent empty lines
                            if (!string.IsNullOrEmpty(line))
                            {
                                scanDetectedTextSB.AppendLine(line);

                                Rect boundingBox;
                                if (iter.TryGetBoundingBox(PageIteratorLevel.TextLine, out boundingBox))
                                {
                                    if (lines.ContainsKey(line))
                                    {
                                        lines[line].Add(boundingBox);
                                    }
                                    else
                                    {
                                        lines.Add(line, new List<Rect>() { boundingBox });
                                    }
                                }

                                recentlyAddedEmptyLine = false;
                            }
                            else if (!recentlyAddedEmptyLine)
                            {
                                scanDetectedTextSB.AppendLine();
                                recentlyAddedEmptyLine = true;
                            }

                            if (iter.IsAtFinalOf(PageIteratorLevel.Block, PageIteratorLevel.TextLine))
                            {
                                if (!string.IsNullOrEmpty(line))
                                {
                                    iter.TryGetBoundingBox(PageIteratorLevel.Block, out lastBlockTextLineRect);
                                }

                                if (!recentlyAddedEmptyLine)
                                {
                                    scanDetectedTextSB.AppendLine();
                                    recentlyAddedEmptyLine = true;
                                }
                            }
                        }
                        while (iter.Next(PageIteratorLevel.TextLine));

                        // remove last newline
                        if (recentlyAddedEmptyLine)
                        {
                            scanDetectedTextSB.Remove(scanDetectedTextSB.Length - Environment.NewLine.Length, Environment.NewLine.Length);
                        }
                    }
                }
            }

            return scanDetectedTextSB.ToString();
        }

        private void CompareTexts_FillRTB()
        {
            mRTB_HandleEvents = false;

            rtbDiffText.Clear();

            var dmp = new diff_match_patch();
            var diffs = dmp.diff_main(mScan1DetectedText, mScan2DetectedText);
            TextDiffs = diffs;

            int countOfConsecutiveDiffs = 0;
            bool lastDiff_WasEqual = true;
            foreach (var diff in diffs)
            {
                switch (diff.operation)
                {
                    case Operation.INSERT:
                        rtbDiffText.AppendText(diff.text, mInsertColor);

                        if (lastDiff_WasEqual) countOfConsecutiveDiffs++;
                        lastDiff_WasEqual = false;
                        break;
                    case Operation.DELETE:
                        rtbDiffText.AppendText(diff.text, mTextDeleteColor);

                        if (lastDiff_WasEqual) countOfConsecutiveDiffs++;
                        lastDiff_WasEqual = false;
                        break;
                    case Operation.EQUAL:
                        rtbDiffText.AppendText(diff.text);
                        lastDiff_WasEqual = true;
                        break;
                }
            }

            int diff_levenshtein = dmp.diff_levenshtein(diffs);
            double dsimilarity = 100 - ((double)diff_levenshtein / Math.Max(mScan1DetectedText.Length, mScan2DetectedText.Length) * 100);
            TextComparePercentage = Math.Round(dsimilarity, 2) + " %";

            CountOfConsecutiveDiffs = countOfConsecutiveDiffs;

            mRTB_HandleEvents = true;
        }

        private void rtbDiffText_SelectionChanged(object sender, EventArgs e)
        {
            if (mRTB_HandleEvents)
            {
                string[] originalLineTexts = GetDetectedLineTextsOnCurrentCursor();

                if (mScan1Lines.ContainsKey(originalLineTexts[0]))
                {
                    var highLightRect = mScan1Lines[originalLineTexts[0]][0];
                    iccScanImages.Image1_Highlight(new Rectangle(highLightRect.X1, highLightRect.Y1, highLightRect.Width, highLightRect.Height));
                }

                if (mScan2Lines.ContainsKey(originalLineTexts[1]))
                {
                    var highLightRect = mScan2Lines[originalLineTexts[1]][0];
                    iccScanImages.Image2_Highlight(new Rectangle(highLightRect.X1, highLightRect.Y1, highLightRect.Width, highLightRect.Height));
                }
            }
        }

        // result[0] - scan1 detected line text
        // result[1] - scan2 detected line text
        private string[] GetDetectedLineTextsOnCurrentCursor()
        {
            mRTB_HandleEvents = false;
            string[] result = new string[2] { string.Empty, string.Empty };

            try
            {
                int currentSelStart = rtbDiffText.SelectionStart;
                int currentSelLength = rtbDiffText.SelectionLength;

                int lineIndex = rtbDiffText.GetLineFromCharIndex(currentSelStart);
                if (rtbDiffText.Lines.Length > lineIndex)
                {
                    // find original texts from rtb based on background colors
                    int firstCharIndex = rtbDiffText.GetFirstCharIndexFromLine(lineIndex);
                    int lastCharIndex = firstCharIndex + rtbDiffText.Lines[lineIndex].Length;

                    var scan1LineText = new StringBuilder();
                    var scan2LineText = new StringBuilder();

                    for (int i = firstCharIndex; i < lastCharIndex; i++)
                    {
                        rtbDiffText.SelectionStart = i;
                        rtbDiffText.SelectionLength = 1;
                        var color = rtbDiffText.SelectionBackColor;

                        if (color == Color.White || color == mTextDeleteColor)
                        {
                            scan1LineText.Append(rtbDiffText.SelectedText);
                        }

                        if (color == Color.White || color == mInsertColor)
                        {
                            scan2LineText.Append(rtbDiffText.SelectedText);
                        }
                    }

                    // reset back selection
                    rtbDiffText.SelectionStart = currentSelStart;
                    rtbDiffText.SelectionLength = currentSelLength;


                    result[0] = scan1LineText.ToString();
                    result[1] = scan2LineText.ToString();
                }
            }
            finally
            {
                mRTB_HandleEvents = true;
            }

            return result;
        }

        private void toolStripButton100_Click(object sender, EventArgs e)
        {
            rtbDiffText.ZoomFactor = 1;
        }

        private void toolStripButtonMinus_Click(object sender, EventArgs e)
        {
            rtbDiffText.ZoomFactor -= 0.1f;
        }

        private void toolStripButtonPlus_Click(object sender, EventArgs e)
        {
            rtbDiffText.ZoomFactor += 0.1f;
        }

        public void CleanUp()
        {
            iccScanImages.Image1 = null;
            iccScanImages.Image2 = null;
        }
    }
}
