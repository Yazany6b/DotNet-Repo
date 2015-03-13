using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace Smart_Regions_Sketcher
{
    public static class Statics
    {
        public static string ToTime(long ms)
        {
            long seconds = ms / 1000;
            ms = ms - (seconds * 1000);

            long minutes = seconds / 60;
            seconds -= minutes * 60;

            return (minutes > 9 ? minutes + "" : "0" + minutes) + ":" + (seconds > 9 ? seconds + "" : "0" + seconds)
                + ","+ ms;
        }

        public static List<System.Drawing.Point> ClonePointsList(List<System.Drawing.Point> source)
        {
            List<System.Drawing.Point> destination = new List<System.Drawing.Point>();

            foreach (System.Drawing.Point x in source)
            {
                destination.Add(new System.Drawing.Point(x.X, x.Y));
            }

            return destination;
        }

        
        
        public unsafe static List<Point> FromBitmap(Bitmap bitmap , Color trans)
        {
            List<Point> points = new List<Point>();

            List<List<Point>> rowPoints = new List<List<Point>>();

            BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            int pixel_size = 4;
            bool noneTrans = true;
            bool afterTrans = true;
            bool inNoneTrans = false;

            for (int y = 0; y < bitmap.Height; y++)
            {

                byte* row = (byte*)data.Scan0 + (y * data.Stride);
                rowPoints.Add(new List<Point>());

                for (int x = 0; x < bitmap.Width; x++)
                {
                    if (row[x * pixel_size + 0] == trans.R && row[x * pixel_size + 1] == trans.G &&
                        row[x * pixel_size + 2] == trans.B && row[x * pixel_size + 3] == trans.A)
                    {
                        noneTrans = false;
                        afterTrans = true;

                        if (inNoneTrans)
                        {
                            inNoneTrans = false;

                            rowPoints[y].Add(new Point(x, y));
                        }
                    }
                    else
                    {
                        if (noneTrans && afterTrans)
                        {
                            rowPoints[y].Add(new Point(x, y));
                            afterTrans = false;
                            inNoneTrans = false;
                        }else
                            inNoneTrans = true;

                        
                    }
                }

            }

            return points;
        }
    }

}
