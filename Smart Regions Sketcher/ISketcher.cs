

namespace Smart_Regions_Sketcher
{
    public interface ISketcher : System.ICloneable
    {
        void Sketch();
        void UnSketch();
        void Sketch(System.Drawing.Graphics g);
        void UnSketch(System.Drawing.Graphics g);
        void Sketch(System.Drawing.Graphics g, System.Drawing.Color sketchColor);
        void UnSketch(System.Drawing.Graphics g, System.Drawing.Color unSketchColor);
        void Sketch(System.Drawing.Graphics g, System.Drawing.Color sketchColor, System.Collections.Generic.List<System.Drawing.Point> points);
        void UnSketch(System.Drawing.Graphics g, System.Drawing.Color unSketchColor, System.Collections.Generic.List<System.Drawing.Point> points);
        void Clear();
        void SketchMouseMoved(object sender, System.Windows.Forms.MouseEventArgs e);
        void SketchMouseUp(object sender, System.Windows.Forms.MouseEventArgs e);
        void DrawToBitmap(System.Drawing.Bitmap bitmap);
        void AddAnimationFream(AnimationFream fream);
        System.Drawing.Drawing2D.GraphicsPath CreateGraphicsPath();
        System.Drawing.Drawing2D.GraphicsPath CreateGraphicsPath(System.Collections.Generic.List<System.Drawing.Point> points);
        

        System.Collections.Generic.List<System.Drawing.Point> SketchPoints { get; set; }
        System.Drawing.Graphics Graphics { get; set; }
        System.Drawing.Color SketchColor { get; set; }
        System.Drawing.Color UnSketchColor { get; set; }
        string Type { get; }
    }
}
