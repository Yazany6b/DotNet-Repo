using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Smart_Regions_Sketcher
{
    public class LocationDrawer
    {
        public Graphics Graphics { get; set; }
        public Size AreaSize { get; set; }
        public Pen DrawPen { get; set; }
        public Pen ErasePen { get; set; }
        private Point last_point = Point.Empty;
        private bool erased = true;
        public LocationDrawer(Graphics g, Size area_size)
        {
            this.Graphics = g;
            this.AreaSize = area_size;
            DrawPen = new Pen(Color.Black);
            ErasePen = new Pen(Color.White);
        }

        public void Draw(Point p)
        {
            last_point = p;
            erased = false;
            Graphics.DrawLine(DrawPen, new Point(0, p.Y), new Point(AreaSize.Width, p.Y));
            Graphics.DrawLine(DrawPen, new Point(p.X,0), new Point(p.X,AreaSize.Height));
        }

        public void Erase()
        {
            if (erased)
                return;

            Graphics.DrawLine(ErasePen, new Point(0, last_point.Y), new Point(AreaSize.Width, last_point.Y));
            Graphics.DrawLine(ErasePen, new Point(last_point.X, 0), new Point(last_point.X, AreaSize.Height));
            erased = true;
        }

        public void UpdateDraw(Point p){
            Erase();
            Draw(p);
        }

        public void UpdateDraw()
        {
            Erase();
            Draw(last_point);
        }

    }
}
