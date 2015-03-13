using System;
using System.Collections.Generic;
using System.Text;

namespace Development.Utilities.Statics
{
    /// <summary>
    /// Containes needed operation to deal with images and colors
    /// </summary>
    /// <remarks>this class contains unsafe code to ensure fast performance when applying the various effects</remarks>
    public static class Imaging
    {

        /// <summary>
        /// Gets the negative of a color
        /// </summary>
        /// <param name="sourceColor">a color to be negative</param>
        /// <returns>an new color that's represent the negative value of the source color</returns>
        public static System.Drawing.Color NegativeColor(System.Drawing.Color sourceColor)
        {
            return System.Drawing.Color.FromArgb(System.Math.Abs(255 - sourceColor.R), System.Math.Abs(255 - sourceColor.G), System.Math.Abs(255 - sourceColor.B));
        }

        /// <summary>
        /// Apply the negative effects on an image
        /// </summary>
        /// <param name="img">the source image to be negative</param>
        /// <returns>the result image of the operation</returns>
        public static unsafe System.Drawing.Image Negative(System.Drawing.Image img)
        {
            System.Drawing.Bitmap map = new System.Drawing.Bitmap(img);
            System.Drawing.Imaging.BitmapData bdata = map.LockBits(new System.Drawing.Rectangle(0, 0, map.Width, map.Height),
                                                                  System.Drawing.Imaging.ImageLockMode.ReadWrite,
                                                                  System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            int psize = 3;

            for (int y = 0; y < map.Height; y++)
            {
                byte* row = (byte*)bdata.Scan0 + (y * bdata.Stride);

                for (int x = 0; x < map.Width; x++)
                {
                    row[x * psize] = (byte)(255 - row[x * psize]);
                    row[x * psize + 1] = (byte)(255 - row[x * psize + 1]);
                    row[x * psize + 2] = (byte)(255 - row[x * psize + 2]);
                }

            }

            map.UnlockBits(bdata);

            return map;
        }

        /// <summary>
        /// Apply the negative effects on an image
        /// </summary>
        /// <param name="img">the source image to be negative</param>
        /// <param name="rect">a rectangle from the image to apply the negative effects to it</param>
        /// <returns>the result image of the operation</returns>
        public static unsafe System.Drawing.Image Negative(System.Drawing.Image img, System.Drawing.Rectangle rect)
        {
            if (rect == System.Drawing.Rectangle.Empty)
                return img;

            System.Drawing.Bitmap map = new System.Drawing.Bitmap(img);
            System.Drawing.Imaging.BitmapData bdata = map.LockBits(rect,
                                                                  System.Drawing.Imaging.ImageLockMode.ReadWrite,
                                                                  System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            int psize = 3;

            for (int y = 0; y < rect.Height; y++)
            {
                byte* row = (byte*)bdata.Scan0 + (y * bdata.Stride);

                for (int x = 0; x < rect.Width; x++)
                {
                    row[x * psize] = (byte)(255 - row[x * psize]);
                    row[x * psize + 1] = (byte)(255 - row[x * psize + 1]);
                    row[x * psize + 2] = (byte)(255 - row[x * psize + 2]);
                }

            }

            map.UnlockBits(bdata);

            return map;
        }

        /// <summary>
        /// Apply the shade effects to spacific color
        /// </summary>
        /// <param name="c"> color to be shaded</param>
        /// <param name="shadeValue">the shade value to be applied which it should be from 130 - 240 and it must be from 0 - 255</param>
        /// <returns>the new shaded color</returns>
        public static System.Drawing.Color ShadeColor(System.Drawing.Color c, int shadeValue)
        {
            return System.Drawing.Color.FromArgb(shadeValue, c.R, c.G, c.B);
        }

        /// <summary>
        /// Remove the shade effects from spacific color
        /// </summary>
        /// <param name="c"> color to be unshaded</param>
        /// <returns>the new unshaded color</returns>
        public static System.Drawing.Color UnShadeColor(System.Drawing.Color c)
        {
            return System.Drawing.Color.FromArgb(255, c.R, c.G, c.B);
        }

        /// <summary>
        /// Apply the grayscale effect on spacific color
        /// </summary>
        /// <param name="color">the color to be grayscaled</param>
        /// <returns>the new grayscaled color</returns>
        public static System.Drawing.Color GrayscaleColor(System.Drawing.Color color)
        {
            int avg = (color.R + color.G + color.G) / 3;
            return System.Drawing.Color.FromArgb(avg, avg, avg);
        }

        /// <summary>
        /// Apply the shade effects to a rectangle from an image
        /// </summary>
        /// <param name="img">the source image</param>
        /// <param name="rect">a rectangle from the image to a apply the shade effect to it</param>
        /// <param name="shadeValue">the shade value to be applied which it should be from 130 - 240 and it must be from 0 - 255</param>
        /// <returns>the result image of the operation</returns>
        public static unsafe System.Drawing.Image ShadeImage(System.Drawing.Image img, System.Drawing.Rectangle rect, int shadeValue)
        {
            if (rect == System.Drawing.Rectangle.Empty)
                return img;

            System.Drawing.Bitmap map = new System.Drawing.Bitmap(img);

            int pixelSize = 4;

            System.Drawing.Imaging.BitmapData bData = map.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            for (int y = 0; y < rect.Height; y++)
            {
                byte* nRow = (byte*)bData.Scan0 + (y * bData.Stride);

                for (int x = 0; x < rect.Width; x++)
                {
                    nRow[x * pixelSize + 3] = (byte)shadeValue;
                }
            }

            map.UnlockBits(bData);

            return map;
        }

        /// <summary>
        /// Apply the shade effects to an image
        /// </summary>
        /// <param name="img">the source image</param>
        /// <param name="shadeValue">the shade value to be applied which it should be from 130 - 240 and it must be from 0 - 255</param>
        /// <returns>the result image of the operation</returns>
        public static unsafe System.Drawing.Image ShadeImage(System.Drawing.Image img, int shadeValue)
        {

            System.Drawing.Bitmap map = new System.Drawing.Bitmap(img);

            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, map.Width, map.Height);

            int pixelSize = 4;

            System.Drawing.Imaging.BitmapData bData = map.LockBits(rect,
                System.Drawing.Imaging.ImageLockMode.ReadWrite,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            for (int y = 0; y < rect.Height; y++)
            {
                byte* nRow = (byte*)bData.Scan0 + (y * bData.Stride);

                for (int x = 0; x < rect.Width; x++)
                {
                    nRow[x * pixelSize + 3] = (byte)shadeValue;
                }
            }

            map.UnlockBits(bData);

            return map;
        }

        /// <summary>
        /// Apply the grayscale effects to an image
        /// </summary>
        /// <param name="img">the source image</param>
        /// <returns>the result image of the operation</returns>
        public static unsafe System.Drawing.Image Grayscale(System.Drawing.Image img)
        {
            System.Drawing.Bitmap map = new System.Drawing.Bitmap(img);
            System.Drawing.Imaging.BitmapData bdata = map.LockBits(new System.Drawing.Rectangle(0, 0, map.Width, map.Height),
                                                                  System.Drawing.Imaging.ImageLockMode.ReadWrite,
                                                                  System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            int psize = 3;

            for (int y = 0; y < map.Height; y++)
            {
                byte* row = (byte*)bdata.Scan0 + (y * bdata.Stride);

                for (int x = 0; x < map.Width; x++)
                {
                    byte gray = (byte)((row[x * psize + 2] * .3) + (row[x * psize + 1] * .59) + (row[x * psize] * .11));
                    row[x * psize] = gray;
                    row[x * psize + 1] = gray;
                    row[x * psize + 2] = gray;
                }

            }

            map.UnlockBits(bdata);

            return map;
        }

        /// <summary>
        /// Apply the grayscale effects to a rectangle of an image
        /// </summary>
        /// <param name="img">the source image</param>
        /// <param name="rect">a rectangle from the image to a apply the grayscale effect to</param>
        /// <returns>the result image of the operation</returns>
        public static unsafe System.Drawing.Image Grayscale(System.Drawing.Image img, System.Drawing.Rectangle rect)
        {
            if (rect == System.Drawing.Rectangle.Empty)
                return img;

            System.Drawing.Bitmap map = new System.Drawing.Bitmap(img);
            System.Drawing.Imaging.BitmapData bdata = map.LockBits(rect,
                                                                  System.Drawing.Imaging.ImageLockMode.ReadWrite,
                                                                  System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            int psize = 3;

            for (int y = 0; y < rect.Height; y++)
            {
                byte* row = (byte*)bdata.Scan0 + (y * bdata.Stride);

                for (int x = 0; x < rect.Width; x++)
                {
                    byte gray = (byte)((row[x * psize + 2] * .3) + (row[x * psize + 1] * .59) + (row[x * psize] * .11));
                    row[x * psize] = gray;
                    row[x * psize + 1] = gray;
                    row[x * psize + 2] = gray;
                }

            }

            map.UnlockBits(bdata);

            return map;
        }

        /// <summary>
        /// Apply the sepia effects ot an image
        /// </summary>
        /// <param name="img">the image to apply sepia effects to it</param>
        /// <param name="depth">the depth of the colors in the image recommended between 10 - 60</param>
        /// <returns>the result image of the operation</returns>
        public static unsafe System.Drawing.Image SepiaImage(System.Drawing.Image img , int depth)
        {

            System.Drawing.Bitmap map = new System.Drawing.Bitmap(img);
            System.Drawing.Imaging.BitmapData bdata = map.LockBits(new System.Drawing.Rectangle(0, 0, map.Width, map.Height),
                                                                  System.Drawing.Imaging.ImageLockMode.ReadWrite,
                                                                  System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            int psize = 3;

            for (int y = 0; y < map.Height; y++)
            {
                byte* row = (byte*)bdata.Scan0 + (y * bdata.Stride);

                for (int x = 0; x < map.Width; x++)
                {
                    byte sepia = (byte)((row[x * psize + 2] * .299) + (row[x * psize + 1] * .587) + (row[x * psize] * .114));
                    row[x * psize] = sepia;
                    row[x * psize + 1] = (byte)((sepia + (depth)) > 255 ? 255 : (sepia + (depth)));
                    row[x * psize + 2] = (byte)((sepia + (depth * 2)) > 255 ? 255 : (sepia + (depth * 2)));
                }

            }

            map.UnlockBits(bdata);

            return map;
        }


        /// <summary>
        /// Apply the sepia effects ot an image
        /// </summary>
        /// <param name="img">the image to apply sepia effects to it</param>
        /// <param name="depth">the depth of the colors in the image recommended between 10 - 60</param>
        /// <param name="rect">a rectangle from the image to a apply the sepia effect to it</param>
        /// <returns>the result image of the operation</returns>
   
        public static unsafe System.Drawing.Image SepiaImage(System.Drawing.Image img, System.Drawing.Rectangle rect,int depth)
        {
            if (rect == System.Drawing.Rectangle.Empty)
                return img;

            System.Drawing.Bitmap map = new System.Drawing.Bitmap(img);
            System.Drawing.Imaging.BitmapData bdata = map.LockBits(rect,
                                                                  System.Drawing.Imaging.ImageLockMode.ReadWrite,
                                                                  System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            int psize = 3;

            for (int y = 0; y < rect.Height; y++)
            {
                byte* row = (byte*)bdata.Scan0 + (y * bdata.Stride);

                for (int x = 0; x < rect.Width; x++)
                {
                    byte sepia = (byte)((row[x * psize + 2] * .299) + (row[x * psize + 1] * .587) + (row[x * psize] * .114));
                    row[x * psize] = sepia;
                    row[x * psize + 1] = (byte)((sepia + (depth)) > 255 ? 255 : (sepia + (depth)));
                    row[x * psize + 2] = (byte)((sepia + (depth * 2)) > 255 ? 255 : (sepia + (depth * 2)));
                }

            }

            map.UnlockBits(bdata);

            return map;
        }



        /// <summary>
        /// Filp an image by 180 degree
        /// </summary>
        /// <param name="img">an image to be flipped</param>
        /// <returns>the new flipped image</returns>
        public static System.Drawing.Image Flip(System.Drawing.Image img)
        {
            System.Drawing.Bitmap map = new System.Drawing.Bitmap(img);

            map.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);

            return map;
        }

        /// <summary>
        /// Rotate an image by 90 degree
        /// </summary>
        /// <param name="img">the new rotated image</param>
        /// <returns>rotated image</returns>
        public static System.Drawing.Image Rotate90Degree(System.Drawing.Image img)
        {
            System.Drawing.Bitmap map = new System.Drawing.Bitmap(img);

            map.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipY);

            return map;
        }


    }
}
