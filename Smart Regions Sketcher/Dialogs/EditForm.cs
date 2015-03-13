using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Smart_Regions_Sketcher
{
    public partial class EditForm : Form
    {
        public event EventHandler ChangeHappend;
        public event EventHandler SelectClicked;
        public List<Point> Points { get;set;}
        public EditForm(List<Point> p,System.Drawing.Size formSize)
        {
            InitializeComponent();
            Points = new List<Point>();

            foreach (Point x in p)
            {
                Points.Add(new Point(x.X, x.Y));
            }

            int location = 0;

            for (int i = 0; i < Points.Count;i++ )
            {
                NumericUpDown xNum = new NumericUpDown();
                xNum.Location = new Point(0, location);
                xNum.Size = new Size(100, 10);
                xNum.Maximum = formSize.Width - 1;
                xNum.ValueChanged += new EventHandler(XNumericValueChanged);
                xNum.TabIndex = i;
                xNum.Value = Points[i].X;

                NumericUpDown yNum = new NumericUpDown();
                yNum.Location = new Point(xNum.Width + 5, location);
                yNum.Size = new Size(100, 10);
                yNum.Maximum = formSize.Height - 1;
                yNum.ValueChanged += new EventHandler(YNumericValueChanged);
                yNum.TabIndex = i;
                yNum.Value = Points[i].Y;

                Button show = new Button();
                show.Text = "Show";
                show.Location = new Point(yNum.Width + yNum.Location.X + 5, location);
                show.Click += new EventHandler(ButtonClick);
                show.TabIndex = i;

                location += show.Height + 3;

                viewPanel.Controls.Add(xNum);
                viewPanel.Controls.Add(yNum);
                viewPanel.Controls.Add(show);


            }
        }

        protected virtual void OnChangeHappand()
        {
            if (ChangeHappend != null)
                ChangeHappend(select, new EventArgs());
        }

        Point select;

        private void ButtonClick(object sender, EventArgs e)
        {
            select = Points[((Button)sender).TabIndex];
            if (SelectClicked != null)
                SelectClicked(select, e);

        }

        private void XNumericValueChanged(object sender, EventArgs e)
        {
            
            Points[((NumericUpDown)sender).TabIndex] = new Point((int)((NumericUpDown)sender).Value,Points[((NumericUpDown)sender).TabIndex].Y);
            OnChangeHappand();
        }

        private void YNumericValueChanged(object sender, EventArgs e)
        {
            
            Points[((NumericUpDown)sender).TabIndex] = new Point(Points[((NumericUpDown)sender).TabIndex].X, (int)((NumericUpDown)sender).Value);
            OnChangeHappand();
        }

    }
}
