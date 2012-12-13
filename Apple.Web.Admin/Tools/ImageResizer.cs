using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Data;
using System.Configuration;

namespace Apple.Web.Admin.Tools
{
    public static class ImageResizer
    {
        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream stream = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(stream);
            }
        }

        public static byte[] ImageToByteArray(Image imageIn, ImageFormat format)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                imageIn.Save(stream, format);
                return stream.ToArray();
            }
        }

        public static byte[] ResizeByMax(byte[] imageBytes, ImageFormat format, int maxSide)
        {
            return ImageToByteArray(ResizeByMax(ByteArrayToImage(imageBytes), maxSide), format);
        }
        public static byte[] ResizeByMax(byte[] imageBytes, int maxSide)
        {
            return ResizeByMax(imageBytes, ImageFormat.Jpeg, maxSide);
        }
        public static byte[] ResizeByWidth(byte[] imageBytes, ImageFormat format, int maxSide)
        {
            return ImageToByteArray(ResizeByWidth(ByteArrayToImage(imageBytes), maxSide), format);
        }
        public static byte[] ResizeByWidth(byte[] imageBytes, int maxSide)
        {
            return ResizeByWidth(imageBytes, ImageFormat.Jpeg, maxSide);
        }
        public static byte[] ResizeByHeight(byte[] imageBytes, ImageFormat format, int maxSide)
        {
            return ImageToByteArray(ResizeByHeight(ByteArrayToImage(imageBytes), maxSide), format);
        }
        public static byte[] ResizeByHeight(byte[] imageBytes, int maxSide)
        {
            return ResizeByHeight(imageBytes, ImageFormat.Jpeg, maxSide);
        }

        private static Image MakeImage(Image original, int h, int w)
        {
            Image image = new Bitmap(w, h);
            using (Graphics graphics = Graphics.FromImage(image))
            {
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.InterpolationMode = InterpolationMode.High;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.DrawImage(original, 0, 0, w, h);
            }
            return image;
        }

        public static Image ResizeByMax(Image original, int maxSide)
        {
            int height = original.Height;
            int width = original.Width;
            int num3 = Math.Max(height, width);
            if (num3 > maxSide)
            {
                double num4 = ((double)maxSide) / ((double)num3);
                int h = Convert.ToInt32((double)(height * num4));
                int w = Convert.ToInt32((double)(width * num4));
                return MakeImage(original, h, w);
            }
            return new Bitmap(original);
        }
        public static Image ResizeByWidth(Image original, int size)
        {
            int height = original.Height;
            int width = original.Width;
            if (width > size)
            {
                double num4 = ((double)size) / ((double)width);
                int h = Convert.ToInt32((double)(height * num4));
                int w = Convert.ToInt32((double)(width * num4));
                return MakeImage(original, h, w);
            }
            return new Bitmap(original);
        }
        public static Image ResizeByHeight(Image original, int size)
        {
            int height = original.Height;
            int width = original.Width;
            if (height > size)
            {
                double num4 = ((double)size) / ((double)height);
                int h = Convert.ToInt32((double)(height * num4));
                int w = Convert.ToInt32((double)(width * num4));
                return MakeImage(original, h, w);
            }
            return new Bitmap(original);
        }
    }


}