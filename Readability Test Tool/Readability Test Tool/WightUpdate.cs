using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Readability_Test_Tool
{
    public partial class WightUpdate : Form
    {
        public WightUpdate()
        {
            InitializeComponent();
        }
        int ValuesSum;
        public void FillArray()
        {
            _wights = new double[22];
            double sum = 0.0;
            foreach (Control x in this.groupBox1.Controls)
            {
                if (x is TextBox)
                {
                    double.TryParse(x.Text, out _wights[x.TabIndex-1]);
                    sum += _wights[x.TabIndex - 1];
                }
            }
            ValuesSum = (int)Math.Ceiling(sum);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FillArray();
            bool exit = true;
            if (ValuesSum != 22)
            {
                exit = (System.Windows.Forms.MessageBox.Show(string.Format("The sum of all waighs to get an accurate test should be {0}\n\rthe current sum is {1} Are you sure you want to confirm ?",_wights.Length,ValuesSum), "Worning", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes);
            }
            if(exit)
                this.Close();
        }

        public double [] Wights
        {
            get { return _wights; }
            set { _wights = value; }
        }
    }
}
