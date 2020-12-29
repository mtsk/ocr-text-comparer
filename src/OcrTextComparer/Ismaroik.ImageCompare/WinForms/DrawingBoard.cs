using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Ismaroik.ImageCompare.WinForms
{
    [System.Runtime.InteropServices.ComVisible(false)]
    public partial class DrawingBoard : INotifyPropertyChanged
    {
        public event SetScrollPositionsEventHandler SetScrollPositions;

        public delegate void SetScrollPositionsEventHandler();

        private System.Windows.Forms.MouseButtons mMouseButtons = System.Windows.Forms.MouseButtons.Left;
        private System.Drawing.Bitmap mOriginalImage;
        private System.Drawing.Point mStartPoint;
        private System.Drawing.Point mOrigin = new System.Drawing.Point(0, 0);
        private System.Drawing.Rectangle mSrcRect;
        private System.Drawing.Rectangle mDestRect;
        private bool mZoomOnMouseWheel = true;
        private double mZoomFactor = 1.0;
        private Size mApparentImageSize = new Size(0, 0);
        private int mDrawWidth;
        private int mDrawHeight;
        private Point mCenterPoint;
        private bool mPanMode = true;
        private bool mStretchImageToFit = false;
        private Rectangle mSelectRect;
        private Pen mSelectPen = new Pen(Color.Blue, 2);
        private Pen mHighlightPen = new Pen(Color.Red, 2);
        private Point mEndPoint;                                // for pan and box-zoom
        private Rectangle mHighlightRect = new Rectangle();

        public DrawingBoard()
        {
            Resize += DrawingBoard_Resize;
            MouseWheel += DrawingBoard_MouseWheel;
            MouseUp += DrawingBoard_MouseUp;
            MouseMove += DrawingBoard_MouseMove;
            MouseDown += DrawingBoard_MouseDown;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion

        #region Properties

        public System.Drawing.Image Image
        {
            get { return mOriginalImage; }
            set
            {
                ClearHighlightRect();

                if ((mOriginalImage != null))
                {
                    mOriginalImage.Dispose();
                    mSelectRect = new Rectangle();
                    mOrigin = new Point(0, 0);
                    mApparentImageSize = new Size(0, 0);
                    mZoomFactor = 1;
                    GC.Collect();
                }

                if (value == null)
                {
                    mOriginalImage = null;
                    this.Invalidate();
                    return;
                }

                Rectangle r = new Rectangle(0, 0, value.Width, value.Height);
                mOriginalImage = new Bitmap(value);
                BitmapData bmpData = new BitmapData();
                mOriginalImage = (Bitmap)mOriginalImage.Clone(r, PixelFormat.Format32bppPArgb);

                //Force a paint
                this.Invalidate();
            }
        }

        public System.Drawing.Image InitialImage
        {
            get { return mOriginalImage; }
            set
            {
                this.Image = value;
                this.ZoomFactor = 1;
            }
        }

        public new System.Drawing.Image BackgroundImage
        {
            get { return null; }
            set
            {
                this.Image = value;
                this.ZoomFactor = 1;
            }
        }

        public double ZoomFactor
        {
            get { return mZoomFactor; }
            set
            {
                mZoomFactor = value;
                if (mZoomFactor > 15)
                    mZoomFactor = 15;
                if (mZoomFactor < 0.05)
                    mZoomFactor = 0.05;
                if ((mOriginalImage != null))
                {
                    mApparentImageSize.Height = (int)(mOriginalImage.Height * mZoomFactor);
                    mApparentImageSize.Width = (int)(mOriginalImage.Width * mZoomFactor);
                    ComputeDrawingArea();
                    CheckBounds();
                }
                this.Invalidate();

                OnPropertyChanged("ZoomFactor");
            }
        }

        public System.Windows.Forms.MouseButtons PanButton
        {
            get { return mMouseButtons; }
            set { mMouseButtons = value; }
        }

        public bool ZoomOnMouseWheel
        {
            get { return mZoomOnMouseWheel; }
            set { mZoomOnMouseWheel = value; }
        }

        public System.Drawing.Point Origin
        {
            get { return mOrigin; }
            set
            {
                if (mOrigin.X != value.X || mOrigin.Y != value.Y)
                {
                    mOrigin = value;
                    this.Invalidate();
                }
            }
        }

        public System.Drawing.Size ApparentImageSize
        {
            get { return mApparentImageSize; }
        }

        public bool PanMode
        {
            get { return mPanMode; }
            set { mPanMode = value; }
        }

        public bool StretchImageToFit
        {
            get { return mStretchImageToFit; }
            set
            {
                mStretchImageToFit = value;
                this.Invalidate();
            }
        }

        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            DrawImage(e.Graphics);
            base.OnPaint(e);
        }

        private void DrawImage(Graphics g)
        {
            if (mOriginalImage == null)
                return;

            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            if (mStretchImageToFit)
            {
                mSrcRect = new System.Drawing.Rectangle(0, 0, mOriginalImage.Width, mOriginalImage.Height);
            }
            else
            {
                mSrcRect = new System.Drawing.Rectangle(mOrigin.X, mOrigin.Y, mDrawWidth, mDrawHeight);
            }

            g.DrawImage(mOriginalImage, mDestRect, mSrcRect, GraphicsUnit.Pixel);

            if (!PanMode)
            {
                g.DrawRectangle(mSelectPen, mSelectRect);
            }

            if (!mHighlightRect.IsEmpty)
            {
                g.DrawRectangle(mHighlightPen, 
                    (float)((mHighlightRect.X - mOrigin.X) * ZoomFactor), 
                    (float)((mHighlightRect.Y - mOrigin.Y) * ZoomFactor), 
                    (float)(mHighlightRect.Width * ZoomFactor),
                    (float)(mHighlightRect.Height * ZoomFactor));
            }

            if (SetScrollPositions != null)
            {
                SetScrollPositions();
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            mDestRect = new System.Drawing.Rectangle(0, 0, ClientSize.Width, ClientSize.Height);
            ComputeDrawingArea();
            base.OnSizeChanged(e);
        }

        private void ComputeDrawingArea()
        {
            mDrawHeight = (int)(this.Height / mZoomFactor);
            mDrawWidth = (int)(this.Width / mZoomFactor);
        }

        public void ZoomIn()
        {
            ZoomImage(true);
        }

        public void ZoomOut()
        {
            ZoomImage(false);
        }

        private void ZoomImage(bool ZoomIn)
        {
            // Get center point
            mCenterPoint.X = mOrigin.X + mSrcRect.Width / 2;
            mCenterPoint.Y = mOrigin.Y + mSrcRect.Height / 2;

            //set new zoomfactor
            if (ZoomIn)
            {
                ZoomFactor = Math.Round(ZoomFactor * 1.1, 2);
            }
            else
            {
                ZoomFactor = Math.Round(ZoomFactor * 0.9, 2);
            }

            // Reset the origin to maintain center point
            mOrigin.X = mCenterPoint.X - (int)(ClientSize.Width / mZoomFactor / 2);
            mOrigin.Y = mCenterPoint.Y - (int)(ClientSize.Height / mZoomFactor / 2);

            CheckBounds();
        }

        public void InvertColors()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (mOriginalImage == null)
                    return;

                // This is the color matrix to invert the image colors.
                ColorMatrix cm = new ColorMatrix(new float[][] {
                    new float[] {-1,0,0,0,0},
                    new float[] {0,-1,0,0,0},
                    new float[] {0,0,-1,0,0},
                    new float[] {0,0,0,1,0},
                    new float[] {1,1,1,1,1}});

                var imageAttributes = new ImageAttributes();
                imageAttributes.SetColorMatrix(cm);

                Graphics g = default(Graphics);
                g = Graphics.FromImage(mOriginalImage);

                Rectangle rc = new Rectangle(0, 0, mOriginalImage.Width, mOriginalImage.Height);
                g.DrawImage(mOriginalImage, rc, 0, 0, mOriginalImage.Width, mOriginalImage.Height, GraphicsUnit.Pixel, imageAttributes);

                this.Invalidate();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        public void FitToScreen()
        {
            this.StretchImageToFit = false;
            this.Origin = new Point(0, 0);
            if (mOriginalImage == null)
                return;
            ZoomFactor = Math.Min((float)ClientSize.Width / (float)mOriginalImage.Width, (float)ClientSize.Height / (float)mOriginalImage.Height);
        }

        private void Draw_Rectangle(System.Windows.Forms.MouseEventArgs e)
        {
            if ((new Rectangle(0, 0, this.Width, this.Height)).Contains(PointToClient(System.Windows.Forms.Cursor.Position)))
            {
                int Width = System.Math.Abs(mStartPoint.X - e.X);
                int Height = System.Math.Abs(mStartPoint.Y - e.Y);
                Point UpperLeft = default(Point);
                //need to determine the  upper left corner of the rectangel regardless of whether it's 
                //the start point or the end point, or other.
                UpperLeft = new Point(System.Math.Min(mStartPoint.X, e.X), System.Math.Min(mStartPoint.Y, e.Y));
                mSelectRect = new Rectangle(UpperLeft.X, UpperLeft.Y, Width, Height);
                this.Invalidate();
            }
        }

        private void DrawingBoard_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (mOriginalImage == null)
                return;
            ClearEndPoint();
            ClearSelectionRect();

            // Set the start point. This is used for panning and zooming so we always set it.
            mStartPoint = new Point(e.X, e.Y);
            this.Focus();
        }

        private void ClearSelectionRect()
        {
            mSelectRect.Height = 0;
            mSelectRect.Width = 0;
        }

        private void ClearHighlightRect()
        {
            mHighlightRect.Height = 0;
            mHighlightRect.Width = 0;
        }

        private void ClearEndPoint()
        {
            mEndPoint.X = 0;
            mEndPoint.Y = 0;
        }

        private void DrawingBoard_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (mOriginalImage == null)
                return;

            if (e.Button == mMouseButtons)
            {
                int DeltaX = mStartPoint.X - e.X;
                int DeltaY = mStartPoint.Y - e.Y;

                if (PanMode)
                {
                    //Set the origin of the new image
                    mOrigin.X = (int)(mOrigin.X + (DeltaX / mZoomFactor));
                    mOrigin.Y = (int)(mOrigin.Y + (DeltaY / mZoomFactor));

                    CheckBounds();

                    //reset the startpoints
                    mStartPoint.X = e.X;
                    mStartPoint.Y = e.Y;

                    //Force a paint
                    this.Invalidate();
                }
                else
                {
                    Draw_Rectangle(e);
                }
            }
        }

        private void CheckBounds()
        {
            if (mOriginalImage == null)
                return;

            // Make sure we don't go out of bounds
            if (mOrigin.X < 0)
                mOrigin.X = 0;
            if (mOrigin.Y < 0)
                mOrigin.Y = 0;
            if (mOrigin.X > mOriginalImage.Width - (ClientSize.Width / mZoomFactor))
            {
                mOrigin.X = (int)(mOriginalImage.Width - (ClientSize.Width / mZoomFactor));
            }
            if (mOrigin.Y > mOriginalImage.Height - (ClientSize.Height / mZoomFactor))
            {
                mOrigin.Y = (int)(mOriginalImage.Height - (ClientSize.Height / mZoomFactor));
            }

            if (mOrigin.X < 0)
                mOrigin.X = 0;
            if (mOrigin.Y < 0)
                mOrigin.Y = 0;
        }

        private void DrawingBoard_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (mOriginalImage == null)
                return;
            if (!PanMode)
            {
                mEndPoint = new Point(e.X, e.Y);
                if (mSelectRect.IsEmpty)
                    return;
                ZoomSelection();
            }
        }

        private void ZoomSelection()
        {
            if (mOriginalImage == null)
                return;
            
            Point NewOrigin = new Point(
                (int)(this.Origin.X + (mSelectRect.X / ZoomFactor)),
                (int)(this.Origin.Y + (mSelectRect.Y / ZoomFactor)));

            double NewFactor = 0;
            if (mSelectRect.Width > mSelectRect.Height)
            {
                NewFactor = (ClientSize.Width / (mSelectRect.Width / ZoomFactor));
            }
            else
            {
                NewFactor = (ClientSize.Height / (mSelectRect.Height / ZoomFactor));
            }

            this.Origin = NewOrigin;
            this.ZoomFactor = NewFactor;

            ClearSelectionRect();
        }

        public void NavigateTo(Rectangle rectInOriginalPic)
        {
            if (!rectInOriginalPic.IsEmpty)
            {
                Rectangle tmp = new Rectangle(rectInOriginalPic.Location, rectInOriginalPic.Size);

                // padding + origin offset
                tmp.Inflate(10, 10);
                tmp.Offset(-mOrigin.X, -mOrigin.Y);

                mSelectRect.X = (int)(tmp.X * ZoomFactor);
                mSelectRect.Y = (int)(tmp.Y * ZoomFactor);
                mSelectRect.Width = (int)(tmp.Width * ZoomFactor);
                mSelectRect.Height = (int)(tmp.Height * ZoomFactor);

                ZoomSelection();

                // center horizontal position
                int centeredZommArea_originY = rectInOriginalPic.Y - ((mDrawHeight - rectInOriginalPic.Height) / 2);
                if (centeredZommArea_originY < 0) centeredZommArea_originY = 0;

                mOrigin.Y = centeredZommArea_originY;
            }
        }

        public void DrawRect(Rectangle rectInOriginalPic)
        {
            if (!rectInOriginalPic.IsEmpty)
            {
                mHighlightRect.Location = rectInOriginalPic.Location;
                mHighlightRect.Size = rectInOriginalPic.Size;
                mHighlightRect.Inflate(5, 5);
            }
        }

        private void DrawingBoard_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!ZoomOnMouseWheel)
                return;

            // set new zoomfactor
            if (e.Delta > 0)
            {
                ZoomImage(true);
            }
            else if (e.Delta < 0)
            {
                ZoomImage(false);
            }
        }

        public void RotateFlip(System.Drawing.RotateFlipType RotateFlipType)
        {
            if (mOriginalImage == null)
                return;
            mOriginalImage.RotateFlip(RotateFlipType);
            this.Invalidate();
        }

        private void DrawingBoard_Resize(object sender, System.EventArgs e)
        {
            this.ComputeDrawingArea();
            if (this.StretchImageToFit)
                this.Invalidate();
        }
    }
}