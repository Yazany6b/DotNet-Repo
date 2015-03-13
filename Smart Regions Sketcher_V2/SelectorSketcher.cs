using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart_Regions_Sketcher
{
    public class SelectorSketcher
    {
        private System.Collections.Generic.List<System.Drawing.Point> _sketchPoints = new System.Collections.Generic.List<System.Drawing.Point>();
        private System.Collections.Generic.Dictionary<System.Drawing.Point, System.Drawing.Color> _unSketchColors = new System.Collections.Generic.Dictionary<System.Drawing.Point, System.Drawing.Color>();

        System.Drawing.Point lastPoint = System.Drawing.Point.Empty;
        System.Drawing.Size lastSize = System.Drawing.Size.Empty;

        public void Sketch(ISketcher sketcher, System.Drawing.Point startPoint, System.Drawing.Size size)
        {
            //try
            //{
                _sketchPoints.Clear();

                for (int i = 0; i < size.Width; i += 2)
                    _sketchPoints.Add(new System.Drawing.Point(startPoint.X + i, startPoint.Y));

                for (int i = 0; i < size.Height; i += 2)
                    _sketchPoints.Add(new System.Drawing.Point(startPoint.X + (size.Width-1), startPoint.Y + i));

                for (int i = 0; i < size.Width; i += 2)
                    _sketchPoints.Add(new System.Drawing.Point(startPoint.X + i, startPoint.Y + (size.Height-1)));

                for (int i = 0; i < size.Height; i += 2)
                    _sketchPoints.Add(new System.Drawing.Point(startPoint.X, startPoint.Y + i));

                for (int i = 0; i < _sketchPoints.Count; i++)
                {
                    sketcher.Graphics.DrawLine(new System.Drawing.Pen(sketcher.SketchColor), _sketchPoints[i], new System.Drawing.Point(_sketchPoints[i].X + 1, _sketchPoints[i].Y + 1));
                }
            //}
            //catch { }
        }

        public void UnSketch(System.Drawing.Graphics g,System.Drawing.Bitmap map,System.Drawing.Color defColor)
        {
            //try
           // {
                for (int i = 0; i < _sketchPoints.Count; i++)
                {
                    g.DrawLine(new System.Drawing.Pen(map.GetPixel(_sketchPoints[i].X, _sketchPoints[i].Y)), _sketchPoints[i], new System.Drawing.Point(_sketchPoints[i].X + 1, _sketchPoints[i].Y + 1));
                }
            //}
           // catch { }
        }

        public void Restore()
        {
            lastPoint = System.Drawing.Point.Empty;
            lastSize = System.Drawing.Size.Empty;
        }

        public System.Drawing.Drawing2D.GraphicsPath CreateGraphicsPath()
        {
            if (_sketchPoints.Count < 2)
                return null;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

            for (int i = 0; i < _sketchPoints.Count; i++)
                path.AddLine(_sketchPoints[i], new System.Drawing.Point(_sketchPoints[i].X + 1, _sketchPoints[i].Y + 1));

            return path;
        }
        
        public System.Collections.Generic.List<System.Drawing.Point> SketchPoints { get { return _sketchPoints; } set { _sketchPoints = value; } }
    }
}
