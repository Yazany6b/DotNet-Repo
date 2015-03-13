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
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        System.Threading.Tasks.Task task;
        bool showed = false;
        private void label9_Click(object sender, EventArgs e)
        {
            if (showed)
            {
                showed = false;
                task = System.Threading.Tasks.Task.Factory.StartNew(GetSrartedHide);
                //task.Wait();
            }
            else
            {
                showed = true;
                task = System.Threading.Tasks.Task.Factory.StartNew(GetSrartedShow);
                //task.Wait();
            }
        }

        private void label9_MouseEnter(object sender, EventArgs e)
        {
            label9.ForeColor = System.Drawing.Color.Maroon;
        }

        private void label9_MouseLeave(object sender, EventArgs e)
        {
            label9.ForeColor = System.Drawing.Color.Black;
        }
        private void GetSrartedShow()
        {
            this.Height += 50;
            for (int i = 0; i < 100000; i++) ;
            this.Height += 50;
            for (int i = 0; i < 1000000; i++) ;
            this.Height += 50;
            for (int i = 0; i < 100000; i++) ;
            this.Height += 50;
            for (int i = 0; i < 100000; i++) ;
            this.Height += 50;
            for (int i = 0; i < 100000; i++) ;
            this.Height += 50;
            for (int i = 0; i < 100000; i++) ;
            this.Height += 50;
            label9.Text = "<-<-";
        }
        private void GetSrartedHide()
        {
            this.Height -= 50;
            for (int i = 0; i < 100000; i++) ;
            this.Height -= 50;
            for (int i = 0; i < 1000000; i++) ;
            this.Height -= 50;
            for (int i = 0; i < 100000; i++) ;
            this.Height -= 50;
            for (int i = 0; i < 100000; i++) ;
            this.Height -= 50;
            for (int i = 0; i < 100000; i++) ;
            this.Height -= 50;
            for (int i = 0; i < 100000; i++) ;
            this.Height -= 50;
            label9.Text = "->->";
        }
    }
}
