

namespace Smart_Regions_Sketcher
{
    public class PolygonSketcher : ISketcher
    {
        private System.Collections.Generic.List<System.Drawing.Point> _sketchPoints = new System.Collections.Generic.List<System.Drawing.Point>();
        private System.Collections.Generic.List<AnimationFream> animation = new System.Collections.Generic.List<AnimationFream>();

        private System.Drawing.Point startPoint = System.Drawing.Point.Empty;
        private System.Drawing.Point previousPoint = System.Drawing.Point.Empty;

        private System.Drawing.Pen sketchPen;
        private System.Drawing.Pen unsketchPen;

        private System.Drawing.Color _sketchColor;
        private System.Drawing.Color _unsketchColor;

        public PolygonSketcher(System.Drawing.Graphics graphics)
        {
            Graphics = graphics;

            sketchPen = new System.Drawing.Pen(_sketchColor);
            unsketchPen = new System.Drawing.Pen(_unsketchColor);
        }

        public PolygonSketcher(System.Drawing.Graphics graphics, System.Drawing.Color sketchColor, System.Drawing.Color unSketchColor)
        {
            Graphics = graphics;
            _sketchColor = sketchColor;
            _unsketchColor = unSketchColor;

            sketchPen = new System.Drawing.Pen(_sketchColor);
            unsketchPen = new System.Drawing.Pen(_unsketchColor);
        }

        public void Sketch()
        {
            try
            {
                Graphics.DrawPolygon(sketchPen, _sketchPoints.ToArray());
            }
            catch { }
        }

        public void UnSketch()
        {
            try
            {
                Graphics.DrawPolygon(unsketchPen, _sketchPoints.ToArray());
            }
            catch { }
        }

        public void Sketch(System.Drawing.Graphics g)
        {
            try
            {
                g.DrawPolygon(sketchPen, _sketchPoints.ToArray());
            }
            catch { }
        }

        public void UnSketch(System.Drawing.Graphics g)
        {
            try
            {
                g.DrawPolygon(unsketchPen, _sketchPoints.ToArray());
            }
            catch { }
        }

        public void Sketch(System.Drawing.Graphics g, System.Drawing.Color sketchColor, System.Collections.Generic.List<System.Drawing.Point> points)
        {
            try
            {
                g.DrawPolygon(new System.Drawing.Pen(sketchColor), points.ToArray());
            }
            catch { }
        }

        public void UnSketch(System.Drawing.Graphics g, System.Drawing.Color unSketchColor, System.Collections.Generic.List<System.Drawing.Point> points)
        {
            try
            {
                g.DrawPolygon(new System.Drawing.Pen(unSketchColor), points.ToArray());
            }
            catch { }
        }

        public void Sketch(System.Drawing.Graphics g, System.Drawing.Color sketchColor)
        {
            try
            {
                g.DrawPolygon(new System.Drawing.Pen(sketchColor), _sketchPoints.ToArray());
            }
            catch { }
        }

        public void UnSketch(System.Drawing.Graphics g, System.Drawing.Color unSketchColor)
        {
            try
            {
                g.DrawPolygon(new System.Drawing.Pen(unSketchColor), _sketchPoints.ToArray());
            }
            catch { }
        }

        public void SketchMouseMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (_sketchPoints.Count <= 0)
                {
                    _sketchPoints.Add(e.Location);
                    return;
                }

                UnSketch();

                _sketchPoints.Remove(_sketchPoints[_sketchPoints.Count - 1]);

                _sketchPoints.Add(e.Location);

                Sketch();
            }
        }

        public void Clear()
        {
            UnSketch();

            _sketchPoints.Clear();
        }

        public void AddAnimationFream(AnimationFream fream)
        {
            
        }
        

        public void SketchMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (_sketchPoints.Count % 2 == 0 && _sketchPoints.Count > 0)
            {
                _sketchPoints.Add(_sketchPoints[_sketchPoints.Count - 1]);
                _sketchPoints.Add(e.Location);
            }
            else
            {
                _sketchPoints.Add(e.Location);
            }

            startPoint = e.Location;
            previousPoint = e.Location;
        }

        public System.Drawing.Drawing2D.GraphicsPath CreateGraphicsPath()
        {
            if (_sketchPoints.Count <= 2)
                return null;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            
            path.AddPolygon(SketchPoints.ToArray());

            return path;
        }

        public System.Drawing.Drawing2D.GraphicsPath CreateGraphicsPath(System.Collections.Generic.List<System.Drawing.Point> points)
        {
            if (_sketchPoints.Count < 2)
                return null;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

            path.AddPolygon(points.ToArray());

            return path;
        }

        public void DrawToBitmap(System.Drawing.Bitmap bitmap)
        {
            System.Drawing.Graphics graph = System.Drawing.Graphics.FromImage(bitmap);

            Sketch(graph);
            graph.Flush();
        }

        public object Clone()
        {
            ISketcher poly = new PolygonSketcher(Graphics, SketchColor, UnSketchColor);
            poly.SketchPoints = new System.Collections.Generic.List<System.Drawing.Point>();

            foreach (var item in SketchPoints)
            {
                poly.SketchPoints.Add(item);
            }

            return poly;
        }

        public System.Drawing.Graphics Graphics { get; set; }
        public System.Drawing.Color SketchColor { get { return _sketchColor; } set { _sketchColor = value; sketchPen.Color = value; } }
        public System.Drawing.Color UnSketchColor { get { return _unsketchColor; } set { _unsketchColor = value; unsketchPen.Color = value; } }
        public System.Collections.Generic.List<System.Drawing.Point> SketchPoints { get { return _sketchPoints; } set { _sketchPoints = value; } }
        public System.Collections.Generic.List<AnimationFream> Animation { get { return animation; } set { animation = value; } }
        public string Type { get { return "Polygons"; } }

        public static PolygonSketcher FromLinesSketcher(LinesSketcher sketcher)
        {
            return SketchersConverter.ConvertToPolygons(sketcher);
        }

    }
}
