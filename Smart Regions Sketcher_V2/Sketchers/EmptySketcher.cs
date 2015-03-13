using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Smart_Regions_Sketcher
{
    public class EmptySketcher : ISketcher
    {
        private System.Collections.Generic.List<System.Drawing.Point> _sketchPoints = new System.Collections.Generic.List<System.Drawing.Point>();
        private System.Collections.Generic.List<AnimationFream> animation = new System.Collections.Generic.List<AnimationFream>();

        public void Sketch()
        {

        }

        public void UnSketch()
        {

        }

        public void Sketch(System.Drawing.Graphics g)
        {

        }

        public void UnSketch(System.Drawing.Graphics g)
        {

        }

        public void Sketch(System.Drawing.Graphics g, System.Drawing.Color sketchColor)
        {

        }

        public void UnSketch(System.Drawing.Graphics g, System.Drawing.Color unSketchColor)
        {

        }

        public void Sketch(System.Drawing.Graphics g, System.Drawing.Color sketchColor, List<System.Drawing.Point> points)
        {

        }

        public void UnSketch(System.Drawing.Graphics g, System.Drawing.Color unSketchColor, List<System.Drawing.Point> points)
        {

        }

        public void Clear()
        {

        }

        public void SketchMouseMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {

        }

        public void SketchMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {

        }

        public void DrawToBitmap(System.Drawing.Bitmap bitmap)
        {

        }

        public System.Drawing.Drawing2D.GraphicsPath CreateGraphicsPath()
        {
            return null;
        }

        public System.Drawing.Drawing2D.GraphicsPath CreateGraphicsPath(List<System.Drawing.Point> points)
        {
            return null;
        }

        public System.Collections.Generic.List<System.Drawing.Point> SketchPoints { get { return _sketchPoints; } set { _sketchPoints = value; } }
        public System.Collections.Generic.List<AnimationFream> Animation { get { return animation; } set { animation = value; } }

        public System.Drawing.Graphics Graphics
        {
            get
            {
                return null;
            }
            set
            {
    
            }
        }

        public System.Drawing.Color SketchColor
        {
            get
            {
                return Color.Empty;
            }
            set
            {
    
            }
        }

        public System.Drawing.Color UnSketchColor
        {
            get
            {
                return Color.Empty;
            }
            set
            {
    
            }
        }

        public string Type
        {
            get { return "Empty"; }
        }

        public object Clone()
        {
            return null;
        }
    }
}
