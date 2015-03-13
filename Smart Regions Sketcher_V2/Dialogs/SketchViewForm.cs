using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Smart_Regions_Sketcher
{
    public partial class TestRegionForm : Form
    {
        Region def;
        bool native = false;
        List<Point> lastPoints;
        System.Drawing.Color drawColor = System.Drawing.Color.Red;
        SettingForm settingsForm;

        public ISketcher Sketcher { get;set;}
        public bool ConnectPaths { get; set; }
        public List<FreamsList> AllFreamsList { get; set; }
        private List<ISketcher> sketchers;
        public TestRegionForm()
        {
            InitializeComponent();
            def = Region;
            this.ForeColor = Color.Red;
            label1.ForeColor = System.Drawing.Color.Black;
            settingsForm = new SettingForm();
            settingsForm.DataChanged += new EventHandler(settingsForm_DataChanged);
            sketchers = new List<ISketcher>();
            ConnectPaths = false;
        }

        void settingsForm_DataChanged(object sender, EventArgs e)
        {
            this.BackColor = settingsForm.SketchBackColor;
            drawColor = settingsForm.SketchColor;
            this.Opacity = settingsForm.SketchOpacity;

            Refresh();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= 0x00020000;
                return base.CreateParams;
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            titleBarPanel.Width = this.Width - 4;

            base.OnSizeChanged(e);
        }

        public void ResetRegion()
        {
            Region = def;
        }

        public void ResetGraphics()
        {
            this.CreateGraphics().Clear(BackColor);
        }

        public void SetRegion(ISketcher sketcher)
        {
            Sketcher = sketcher;

            if (!native)
            {
                System.Drawing.Drawing2D.GraphicsPath path = Sketcher.CreateGraphicsPath();
                if(path!=null)
                    this.Region = new Region(path);
            }
            else
            {
                if (lastPoints != null)
                    Sketcher.UnSketch(this.CreateGraphics(), this.BackColor, lastPoints);

                lastPoints = Statics.ClonePointsList(sketcher.SketchPoints);

                Sketcher.Sketch(this.CreateGraphics(),drawColor);

            }

        }

        public void SetRegions(ISketcher sketcher)
        {
            Sketcher = sketcher;

            if (!native)
            {
                System.Drawing.Drawing2D.GraphicsPath path = Sketcher.CreateGraphicsPath();
                if (path != null)
                    this.Region = new Region(path);
            }
            else
            {
                if (lastPoints != null)
                    Sketcher.UnSketch(this.CreateGraphics(), this.BackColor, lastPoints);

                lastPoints = Statics.ClonePointsList(sketcher.SketchPoints);

                Sketcher.Sketch(this.CreateGraphics(), drawColor);

            }

        }

        public void UpdateRegion()
        {
            if (!native)
            {
                GraphicsPath container = null;
                foreach (var item in AllFreamsList)
                {
                    //if(item.ActiveSketcher != null)
                    GraphicsPath p = item.ActiveSketcher.CreateGraphicsPath();
                    if (p != null)
                    {
                        if (container == null)
                            container = p;
                        else
                            container.AddPath(p, ConnectPaths);
                    }
                }

                if(container != null)
                    this.Region = new Region(container);
            }
            else
            {
                Graphics g = this.CreateGraphics();
                g.Clear(this.BackColor);
                foreach (var item in AllFreamsList)
                {
                    if (item.ActiveSketcher != null)
                        item.ActiveSketcher.Sketch(g, drawColor);
                }
            }
        }

        public void AddSketcher(ISketcher sketcher)
        {
            sketchers.Add(sketcher);
        }

        public void ReplaceSketcher(ISketcher oldsketcher, ISketcher newsketcher)
        {
            int index = sketchers.IndexOf(oldsketcher);
            if (index < 0)
                return;
            sketchers.RemoveAt(index);
            sketchers.Insert(index, newsketcher);
        }

        public bool IsSketcherExist(ISketcher sketcher)
        {
            return sketchers.IndexOf(sketcher) > -1;
        }

        bool downAfterRelease = true;
        Point old = new Point();
        protected override void OnMouseMove(MouseEventArgs e)
        {

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (downAfterRelease)
                {
                        downAfterRelease = false;
                        old = e.Location;
                }
                else
                {
                    this.Location = new Point(this.Location.X + (e.X - old.X), this.Location.Y + (e.Y - old.Y));
                }
            }
        }

        private void titleBarPanel_MouseUp(object sender, MouseEventArgs e)
        {
            downAfterRelease = true;
        }

        Point last = Point.Empty;

        private void RegionApplyForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (last != Point.Empty)
                this.CreateGraphics().DrawEllipse(new Pen(BackColor), new Rectangle(e.Location, new Size(6, 6)));

            this.CreateGraphics().DrawEllipse(new Pen(BackColor == System.Drawing.Color.Black ? Color.Red : Color.Black), new Rectangle(e.Location, new Size(6, 6)));
            last = e.Location;
        }
        
        private void RegionApplyForm_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = e.Location.ToString();
        }

        private void RegionApplyForm_Load(object sender, EventArgs e)
        {
            
        }

        private void RegionApplyForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                native = !native;

                UpdateRegion();

                if (!native)
                {

                    //if (lastPoints != null)
                    //{
                    /*if (Sketcher != null)
                    {
                        System.Drawing.Drawing2D.GraphicsPath path = Sketcher.CreateGraphicsPath();
                        
                        if (path != null)
                            this.Region = new Region(path);
                    }*/
                    //}
                    titleBarPanel.Visible = false;
                }
                else
                {   
                    this.Region = def;
                    titleBarPanel.Visible = true;
                    //if(Sketcher != null)
                    //    Sketcher.Sketch(this.CreateGraphics(),drawColor);
                }

            }
        }

        private void TestRegionForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.X)
            {
                //System.Windows.Forms.MessageBox.Show(this.Opacity.ToString());
                if (this.Opacity == settingsForm.SketchOpacity)
                {
                    Opacity = 1.0;
                    Update();
                }
                else
                {
                    Opacity = settingsForm.SketchOpacity;
                    Update();
                }
            }else
                if (e.Alt && e.KeyCode == Keys.S)
                {
                    if (settingsForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        BackColor = settingsForm.SketchBackColor;
                        drawColor = settingsForm.SketchColor;
                        Opacity = settingsForm.SketchOpacity;
                        Update();
                    }
                }
        }

        private void TestRegionForm_Paint(object sender, PaintEventArgs e)
        {
            UpdateRegion();
            /*
            if (Sketcher != null)
            {
                if (!titleBarPanel.Visible)
                {
                    System.Drawing.Drawing2D.GraphicsPath gp = Sketcher.CreateGraphicsPath();

                    if (gp != null)
                        Region = new Region(gp);
                }
                else
                {
                    if(lastPoints != null)
                        Sketcher.Sketch(this.CreateGraphics(), drawColor, lastPoints);
                }
            }*/
        }
    }

}
