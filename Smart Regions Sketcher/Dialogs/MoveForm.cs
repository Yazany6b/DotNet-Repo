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
    public partial class MoveForm : Form
    {
        public int XValue { get; private set; }
        public int YValue { get; private set; }

        public MoveForm(Point max)
        {

            InitializeComponent();

            numericUpDown1.Maximum = max.X;
            numericUpDown2.Maximum = max.Y;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            XValue = (int)numericUpDown1.Value;
            YValue = (int)numericUpDown2.Value;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
