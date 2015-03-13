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
    public partial class SettingForm : Form
    {
        public event EventHandler DataChanged;
        public SettingForm()
        {
            InitializeComponent();

            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                button1.ForeColor = colorDialog1.Color;

                if (DataChanged != null)
                    DataChanged(this, new EventArgs());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                button1.BackColor = colorDialog1.Color;
                button2.BackColor = colorDialog1.Color;

                if (DataChanged != null)
                    DataChanged(this, new EventArgs());
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value + "%";

            if (DataChanged != null)
                DataChanged(this, new EventArgs());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        public Color SketchColor { get { return button1.ForeColor; } }
        public Color SketchBackColor { get { return button2.BackColor; } }
        public double SketchOpacity { get { return (double)trackBar1.Value / 100.0; } } 
    }
}
