using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class AppSettings : Form
    {
        public AppSettings()
        {
            InitializeComponent();

            if (Settings.OpenWithChrome)
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }

            if (Settings.OpenWithIE)
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Settings.OpenWithChrome = ((RadioButton)sender).Checked;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Settings.OpenWithIE = ((RadioButton)sender).Checked;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Settings.OpenWithIE = false;
            Settings.OpenWithChrome = false;
        }
    }
}
