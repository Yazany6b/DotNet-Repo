

namespace YazanLib.Media
{
    [System.Serializable]
    public class RegionData
    {
        public string Type { get; set; }
        public int WaitMs { get; set; }
        public System.Collections.Generic.List<System.Drawing.Point> Points { get; set; }

        public int Width { get; private set; }
        public int Heigth { get; private set; }

        public int MinimumX { get; private set; }
        public int MinimumY { get; private set; }

        public int MaximumX { get; private set; }
        public int MaximumY { get; private set; }
    
        public RegionData(string type, System.Collections.Generic.List<System.Drawing.Point> points)
        {
            Type = type;
            Points = points;

            CalculateValues();
        }

        private void CalculateValues()
        {
            if (Points.Count != 0)
            {
                int small_x = Points[0].X;
                int small_y = Points[0].Y;

                int big_x = Points[0].X;
                int big_y = Points[0].Y;

                foreach (var point in Points)
                {
                    if (point.X < small_x)
                        small_x = point.X;

                    if (point.Y < small_y)
                        small_y = point.Y;

                    if (point.X > big_x)
                        big_x = point.X;

                    if (point.Y > big_y)
                        big_y = point.Y;
                }

                Width = big_x - small_x;
                Heigth = big_y - small_y;

                MinimumX = small_x;
                MinimumY = small_y;

                MaximumX = big_x;
                MaximumY = big_y;
            }
        }

        public System.Drawing.Region CreateRegion()
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

            if (Type == "Lines")
                path.AddLines(Points.ToArray());
            else
                if (Type == "Polygons")
                    path.AddPolygon(Points.ToArray());

            return new System.Drawing.Region(path);
        }

        public void StartAtLocation(System.Drawing.Point point)
        {

            if (Points.Count <= 0)
                return;

            int xratio = MinimumY - point.X;
            int yratio = MinimumX - point.Y; ;


            for (int i = 0; i < Points.Count; i++)
            {
                Points[i] = new System.Drawing.Point(Points[i].X - xratio, Points[i].Y - yratio);
            }

            CalculateValues();
        }

        public System.Drawing.Region CreateRegion(System.Drawing.Point startPoints)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

            if (Type == "Lines")
                path.AddLines(Points.ToArray());
            else
                if (Type == "Polygons")
                    path.AddPolygon(Points.ToArray());

            return new System.Drawing.Region(path);
        }

        public void DrawToBitmap(System.Drawing.Bitmap bitmap,System.Drawing.Pen pen)
        {
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            if (Type == "Lines")
                g.DrawLines(pen,Points.ToArray());
            else
                if (Type == "Polygons")
                    g.DrawPolygon(pen, Points.ToArray());

            g.Flush();
        }

        public unsafe System.Drawing.Bitmap CreateBitmap(System.Drawing.Color bitmapColor)
        {
            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(MaximumX + 10, MaximumY + 10);
            System.Drawing.Color penColor = System.Drawing.Color.Black;
            DrawToBitmap(bitmap,new System.Drawing.Pen(penColor,1));

            System.Drawing.Imaging.BitmapData data = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height)
            , System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            bool getIn = false;
            int pixel_Size = 4;

            for (int y = 0; y < bitmap.Height; y++)
            {
                getIn = false;
                byte* row = (byte*)data.Scan0 + (y * data.Stride);

                for (int x = 0; x < bitmap.Width; x++)
                {
                    if (!getIn)
                    {
                        if (row[x * pixel_Size + 0] == penColor.R && row[x * pixel_Size + 1] == penColor.G
                            && row[x * pixel_Size + 2] == penColor.B && row[x * pixel_Size + 3] == penColor.A)
                        {
                            getIn = !getIn;
                        }
                    }
                    else
                    {
                        row[x * pixel_Size + 0] = bitmapColor.R;
                        row[x * pixel_Size + 1] = bitmapColor.G;
                        row[x * pixel_Size + 2] = bitmapColor.B;
                        row[x * pixel_Size + 3] = bitmapColor.A;

                        if (row[x * pixel_Size + 0] == penColor.R && row[x * pixel_Size + 1] == penColor.G
                            && row[x * pixel_Size + 2] == penColor.B && row[x * pixel_Size + 3] == penColor.A)
                        {
                            break;
                        }
                    }
                }
            }
            bitmap.UnlockBits(data);
            return bitmap;
        }
    }
}
