

namespace Smart_Regions_Sketcher
{
    public class LinesSketcher : ISketcher
    {
        private System.Collections.Generic.List<System.Drawing.Point> _sketchPoints = new System.Collections.Generic.List<System.Drawing.Point>();
        private System.Collections.Generic.List<AnimationFream> animation = new System.Collections.Generic.List<AnimationFream>();

        private System.Drawing.Point startPoint = System.Drawing.Point.Empty;
        private System.Drawing.Point previousPoint = System.Drawing.Point.Empty;
        private System.Drawing.Pen sketchPen;
        private System.Drawing.Pen unsketchPen;

        private System.Drawing.Color _sketchColor;
        private System.Drawing.Color _unsketchColor;

        public LinesSketcher(System.Drawing.Graphics graphics)
        {
            Graphics = graphics;

            sketchPen = new System.Drawing.Pen(_sketchColor);
            unsketchPen = new System.Drawing.Pen(_unsketchColor);

            sketchPen.Width = 1;
        }
        
        public LinesSketcher(System.Drawing.Graphics graphics, System.Drawing.Color sketchColor, System.Drawing.Color unSketchColor)
        {
            Graphics = graphics;
            _sketchColor = sketchColor;
            _unsketchColor = unSketchColor;

            sketchPen = new System.Drawing.Pen(_sketchColor);
            unsketchPen = new System.Drawing.Pen(_unsketchColor);

            sketchPen.Width = 1;
        }

        public void Sketch()
        {
            try
            {
                Graphics.DrawLines(sketchPen, _sketchPoints.ToArray());
            }
            catch { }
        }

        public void UnSketch()
        {
            try
            {
                Graphics.DrawLines(unsketchPen, _sketchPoints.ToArray());
            }
            catch { }
        }

        public void Sketch(System.Drawing.Graphics g)
        {
            try
            {
                g.DrawLines(sketchPen, _sketchPoints.ToArray());
            }
            catch { }
        }

        public void UnSketch(System.Drawing.Graphics g)
        {
            try
            {
                g.DrawLines(unsketchPen, _sketchPoints.ToArray());
            }
            catch { }
        }

        public void Sketch(System.Drawing.Graphics g,System.Drawing.Color sketchColor,System.Collections.Generic.List<System.Drawing.Point> points)
        {
            try
            {
                g.DrawLines(new System.Drawing.Pen(sketchColor), points.ToArray());
            }
            catch { }
        }

        public void UnSketch(System.Drawing.Graphics g, System.Drawing.Color unSketchColor, System.Collections.Generic.List<System.Drawing.Point> points)
        {
            try
            {
                g.DrawLines(new System.Drawing.Pen(unSketchColor), points.ToArray());
            }
            catch { }
        }

        public void Sketch(System.Drawing.Graphics g, System.Drawing.Color sketchColor)
        {
            try
            {
                g.DrawLines(new System.Drawing.Pen(sketchColor), _sketchPoints.ToArray());
            }
            catch { }
        }

        public void UnSketch(System.Drawing.Graphics g, System.Drawing.Color unSketchColor)
        {
            try
            {
                g.DrawLines(new System.Drawing.Pen(unSketchColor), _sketchPoints.ToArray());
            }
            catch { }
        }


        public void SketchMouseMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (startPoint == System.Drawing.Point.Empty)
                {
                    startPoint = e.Location;
                    _sketchPoints.Add(e.Location);
                    return;
                }

                Graphics.DrawLine(unsketchPen, startPoint, previousPoint);

                Graphics.DrawLine(sketchPen, startPoint, e.Location);

                previousPoint = e.Location;
            }
        }

        public void Clear()
        {
            UnSketch();

            _sketchPoints.Clear();

            startPoint = System.Drawing.Point.Empty;
        }

        public void SketchMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            UnSketch();

            if (_sketchPoints.Count % 2 == 0 && _sketchPoints.Count > 0)
            {
                _sketchPoints.Add(_sketchPoints[_sketchPoints.Count - 1]);
                _sketchPoints.Add(e.Location);
            }
            else
            {
                _sketchPoints.Add(e.Location);
            }


            Sketch();

            startPoint = e.Location;
            previousPoint = e.Location;
        }

        public System.Drawing.Drawing2D.GraphicsPath CreateGraphicsPath()
        {
            if (_sketchPoints.Count < 2)
                return null;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

            path.AddLines(SketchPoints.ToArray());

            return path;
        }

        public System.Drawing.Drawing2D.GraphicsPath CreateGraphicsPath(System.Collections.Generic.List<System.Drawing.Point> points)
        {
            if (_sketchPoints.Count < 2)
                return null;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

            path.AddLines(points.ToArray());

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
            ISketcher line = new LinesSketcher(Graphics,SketchColor,UnSketchColor);
            line.SketchPoints = new System.Collections.Generic.List<System.Drawing.Point>();

            foreach (var item in SketchPoints)
            {
                line.SketchPoints.Add(item);
            }

            return line;
        }

        public System.Drawing.Graphics Graphics { get; set; }
        public System.Drawing.Color SketchColor { get { return _sketchColor; } set { _sketchColor = value; sketchPen.Color = value; } }
        public System.Drawing.Color UnSketchColor { get { return _unsketchColor; } set { _unsketchColor = value; unsketchPen.Color = value; } }
        public System.Collections.Generic.List<System.Drawing.Point> SketchPoints { get { return _sketchPoints; } set { _sketchPoints = value; } }
        public System.Collections.Generic.List<AnimationFream> Animation { get { return animation; } set { animation = value; } }
        public string Type { get { return "Lines";} }


    }
}
