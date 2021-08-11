using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using ImageMagick;
using System.Drawing;

namespace ImageCompare
{
    public static class ImagePreprocess
    {
        public static void PreprocessImage(string imPath, string imTargetPath)
        {
            MagickImage image = PreprocessImage(imPath);
            image.Write(imTargetPath);
            image.Dispose();
        }

        private static MagickImage PreprocessImage(string imPath)
        {
            Rectangle cropRectangle = CropToContent(imPath);
            MagickImage image = new MagickImage(imPath);

            image.Crop(cropRectangle.X, cropRectangle.Y, cropRectangle.Width, cropRectangle.Height);

            // density fix - tesseract works best in range 300-500
            if (image.Density.X < 300 || image.Density.Y < 300 || image.Density.X > 500 || image.Density.Y > 500)
            {
                image.Density = new Density(300);
            }

            //image.Grayscale(PixelIntensityMethod.RMS);

            image.BorderColor = MagickColors.White;
            image.Border(100);

            return image;
        }

        private static Rectangle CropToContent(string image_path)
        {
            Mat grayIm = CvInvoke.Imread(image_path, LoadImageType.Grayscale);
            Mat processed = new Mat();

            CvInvoke.Blur(grayIm, processed, new Size(8, 8), new Point(-1, -1));

            CvInvoke.Canny(processed, processed, 110, 220);

            CvInvoke.BitwiseNot(processed, processed);

            int erosion_size = 15;
            Mat element = CvInvoke.GetStructuringElement(ElementShape.Rectangle,
                new Size(2 * erosion_size + 1, 2 * erosion_size + 1),
                new Point(erosion_size, erosion_size));
            CvInvoke.Erode(processed, processed, element, new Point(-1, -1), 1, BorderType.Constant, CvInvoke.MorphologyDefaultBorderValue);

            CvInvoke.BitwiseNot(processed, processed);

            // Find contours
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            Mat hierarchy = new Mat();
            CvInvoke.FindContours(processed, contours, hierarchy, RetrType.Tree, ChainApproxMethod.ChainApproxSimple);

            // find boundary points
            Size s = grayIm.Size;
            int top_max = s.Height;
            int bottom_max = 0;
            int left_max = s.Width;
            int rigt_max = 0;
            for (int i = 0; i < contours.Size; i++)
            {
                for (int j = 0; j < contours[i].Size; j++)
                {
                    Point p = contours[i][j];

                    if (top_max > p.Y)
                        top_max = p.Y;
                    if (bottom_max < p.Y)
                        bottom_max = p.Y;
                    if (left_max > p.X)
                        left_max = p.X;
                    if (rigt_max < p.X)
                        rigt_max = p.X;
                }
            }

            ///// Draw contours
            ////Rect bounding_rect;
            //Mat drawing = new Mat(processed.Size, DepthType.Cv8U, 3);
            //for (int i = 0; i < contours.Size; i++)
            //{
            //    MCvScalar color = new MCvScalar(125, 125, 125);
            //    CvInvoke.DrawContours(drawing, contours, i, color, 2);
            //}
            //CvInvoke.Imshow("im", drawing);

            var cropRectangle = new Rectangle(left_max, top_max, rigt_max - left_max, bottom_max - top_max);
            return cropRectangle;
        }
    }
}
