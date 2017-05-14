using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wohnungstausch24.Core
{
    public static class ImageEditor
    {
        private static int prodThumbnailX = 180;
        private static int prodThumbnailY = 180;
        private const string thumbnailConvention = "_t{0}";
        private const int thumbnailY = 80;
        private const int thumbnailX = 120;

        public static void DeleteImage(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public static string Resize(string filePath, int x, int y)
        {
            Image resized;
            using (var imgFinal = Image.FromFile(filePath))
            {
                resized = Resize(imgFinal, x, y);
            }

            //  GC.Collect();
            DeleteImage(filePath);
            resized.SaveJpeg(filePath, 80);

            resized.Dispose();

            return filePath;
        }

        public static byte[] Resize(byte[] image, int x, int y)
        {
            var imgFinal = Image.FromStream(new MemoryStream(image));
            var resized = Resize(imgFinal, x, y);
            return ToByteArray(resized);
        }

        public static byte[] ToByteArray(this Image imageIn)
        {
            var ms = new MemoryStream();
            imageIn.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public static Image FromByteArray(this byte[] content)
        {
            var ms = new MemoryStream(content);
            var image = Image.FromStream(ms);
            return image;
        }

        public static string ConvertToJpeg(this string filePath, int quality)
        {
            Image imgFinal = Image.FromFile(filePath);

            var finalPath = Path.ChangeExtension(filePath, ".jpg");

            imgFinal.SaveJpeg(finalPath, quality);
            DeleteImage(filePath);
            return finalPath;
        }

        /// <summary>
        /// Resizes and rotates an image, keeping the original aspect ratio. Does not dispose the original
        /// Image instance.
        /// </summary>
        /// <param name="image">Image instance</param>
        /// <param name="width">desired width</param>
        /// <param name="height">desired height</param>
        /// <returns>new resized/rotated Image instance</returns>
        public static Image Resize(Image image, int width, int height)
        {
            // clone the Image instance, since we don't want to resize the original Image instance
            var rotatedImage = image.DeepClone() as Image;
            image.Dispose();
            image = null;
            var newSize = CalculateResizedDimensions(rotatedImage, width, height);

            var resizedImage = new Bitmap(newSize.Width, newSize.Height, PixelFormat.Format32bppArgb);
            resizedImage.SetResolution(72, 72);

            using (var graphics = Graphics.FromImage(resizedImage))
            {
                // set parameters to create a high-quality thumbnail
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                // use an image attribute in order to remove the black/gray border around image after resize
                // (most obvious on white images), see this post for more information:
                // http://www.codeproject.com/KB/GDI-plus/imgresizoutperfgdiplus.aspx
                using (var attribute = new ImageAttributes())
                {
                    attribute.SetWrapMode(WrapMode.TileFlipXY);

                    // draws the resized image to the bitmap
                    graphics.DrawImage(rotatedImage, new Rectangle(new Point(0, 0), newSize), 0, 0, rotatedImage.Width, rotatedImage.Height, GraphicsUnit.Pixel, attribute);
                }
                graphics.Dispose();

            }

            return resizedImage;
        }

        /// <summary>
        /// Calculates resized dimensions for an image, preserving the aspect ratio.
        /// </summary>
        /// <param name="image">Image instance</param>
        /// <param name="desiredWidth">desired width</param>
        /// <param name="desiredHeight">desired height</param>
        /// <returns>Size instance with the resized dimensions</returns>
        private static Size CalculateResizedDimensions(Image image, int desiredWidth, int desiredHeight)
        {
            var widthScale = (double)desiredWidth / image.Width;
            var heightScale = (double)desiredHeight / image.Height;

            // scale to whichever ratio is smaller, this works for both scaling up and scaling down
            var scale = widthScale < heightScale ? widthScale : heightScale;

            return new Size
            {
                Width = (int)(scale * image.Width),
                Height = (int)(scale * image.Height)
            };
        }

        public static string EditImage(List<Point> finalPoints, string filePath, string polygonColor, int quality)
        {
            var color = ColorTranslator.FromHtml("#" + polygonColor);
            Image imgFinal = Image.FromFile(filePath);

            using (MemoryStream msGetFinal = new MemoryStream())
            {
                imgFinal.Save(msGetFinal, ImageFormat.Jpeg);
                Image img = Image.FromStream(msGetFinal);

                Graphics image = Graphics.FromImage(img);

                image.FillPolygon(new SolidBrush(color), finalPoints.ToArray());

                if (imgFinal != null) imgFinal.Dispose();
                if (image != null) image.Dispose();

                GC.Collect();

                string saveFilePath = Path.ChangeExtension(filePath, ".jpg");
                img.SaveJpeg(saveFilePath, quality);
                if (img != null) img.Dispose();
                return saveFilePath;
            }
        }

        public static byte[] EditWebImage(List<Point> finalPoints, string filePath, string polygonColor, int quality)
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            byte[] bytes = wc.DownloadData(filePath);

            var color = ColorTranslator.FromHtml("#" + polygonColor);

            using (MemoryStream msGetFinal = new MemoryStream(bytes))
            {
                Image img = Image.FromStream(msGetFinal);
                Graphics image = Graphics.FromImage(img);
                image.FillPolygon(new SolidBrush(color), finalPoints.ToArray());
                if (image != null) image.Dispose();
                GC.Collect();
                return img.ToByteArray();
            }
        }

        private static void SaveJpeg(this Image img, string filename, int quality)
        {
            EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)quality);
            ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;
            img.Save(filename, jpegCodec, encoderParams);
        }

        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType) return encoders[j];
            }
            return null;
        }


        public static string CreateThumbnail(string filePath)
        {
            string newThumbnailPath = Resize(filePath, thumbnailX, thumbnailY);
            return Path.GetFileName(newThumbnailPath);
        }


        public static byte[] CreateThumbnail(byte[] imageContent)
        {
            return Resize(imageContent, prodThumbnailX, prodThumbnailY);
        }
    }
}
