using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Subtitles_Creator
{
    public partial class ExistFileForm : Form
    {
        public ExistFileForm()
        {
            InitializeComponent();
        }

        public static ExistFileForm Form = new ExistFileForm();

        public new System.Windows.Forms.DialogResult DialogResult { get { return base.DialogResult; } private set { base.DialogResult = value; } }

        public new DialogResult ShowDialog()
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;

            return base.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            DialogResult = System.Windows.Forms.DialogResult.Retry;

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Ignore;

            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Abort;

            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;

            this.Close();
        }
    }
}
