using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Smart_Regions_Sketcher
{
    public class DiscreteLinesSketcher : ISketcher
    {
        #region ISketcher Members

        //private Pen _sketchPen;
        //private Pen _unsketchPen;

        public DiscreteLinesSketcher(Graphics grapichs)
        {
            Graphics = grapichs;
        }

        public DiscreteLinesSketcher(Graphics grapichs,Color sketchColor , Color unsketchColor)
        {
            Graphics = grapichs;
        }

        public void Sketch()
        {
            try
            {
                //Graphics.DrawLines(
            }
            catch { }
        }

        public void UnSketch()
        {
            throw new NotImplementedException();
        }

        public void Sketch(System.Drawing.Graphics g)
        {
            throw new NotImplementedException();
        }

        public void UnSketch(System.Drawing.Graphics g)
        {
            throw new NotImplementedException();
        }

        public void Sketch(System.Drawing.Graphics g, System.Drawing.Color sketchColor)
        {
            throw new NotImplementedException();
        }

        public void UnSketch(System.Drawing.Graphics g, System.Drawing.Color unSketchColor)
        {
            throw new NotImplementedException();
        }

        public void Sketch(System.Drawing.Graphics g, System.Drawing.Color sketchColor, List<System.Drawing.Point> points)
        {
            throw new NotImplementedException();
        }

        public void UnSketch(System.Drawing.Graphics g, System.Drawing.Color unSketchColor, List<System.Drawing.Point> points)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void AddAnimationFream(AnimationFream fream)
        {

        }

        public void SketchMouseMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void SketchMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public System.Drawing.Drawing2D.GraphicsPath CreateGraphicsPath()
        {
            throw new NotImplementedException();
        }

        public System.Drawing.Drawing2D.GraphicsPath CreateGraphicsPath(List<System.Drawing.Point> points)
        {
            throw new NotImplementedException();
        }

        public void DrawToBitmap(System.Drawing.Bitmap bitmap)
        {
            throw new NotImplementedException();
        }

        public List<System.Drawing.Point> SketchPoints
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public List<AnimationFream> Animation
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public System.Drawing.Graphics Graphics
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public System.Drawing.Color SketchColor
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public System.Drawing.Color UnSketchColor
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Type
        {
            get { throw new NotImplementedException(); }
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
