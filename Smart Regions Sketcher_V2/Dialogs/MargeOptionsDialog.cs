using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Smart_Regions_Sketcher.Dialogs
{
    public partial class MargeOptionsDialog : Form
    {
        public static readonly MargeOptionsDialog Dialog = new MargeOptionsDialog();

        private MargeOptionsDialog()
        {
            InitializeComponent();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;

            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }

        private void ResetOptions(){
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
        }

        public bool MargeAsNew { get { return radioButton1.Checked; } }
        public bool MargeWithOld { get { return radioButton2.Checked; } }
        public bool AppendToSelected { get { return radioButton3.Checked; } }

        public static new DialogResult Show()
        {
            Dialog.ResetOptions();
            return Dialog.ShowDialog();
        }
    }
}
