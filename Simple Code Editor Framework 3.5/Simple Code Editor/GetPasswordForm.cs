using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Simple_Code_Editor
{
    public partial class GetPasswordForm : Form
    {
        private string path = "";
        private bool getpass = true;
        public GetPasswordForm(string path,bool getPass)
        {
            InitializeComponent();
            Text = "Input Password";
            this.path = path;
            getpass = getPass;
            if (!getPass)
                exitButton.Visible = false;
        }
        public void ResetAll(string path, bool getPass)
        {
            Text = "Input Password";
            this.path = path;
            getpass = getPass;
            textBox1.Text = "";
            if (!getPass)
                exitButton.Visible = false;
        }
        private void ButtonClicked(object sender, EventArgs e)
        {
            switch(((Button)sender).TabIndex)
            {
                case 0:
                    if (getpass)
                    {
                        if (textBox1.Text == SecureCodeFormat.GetPassword(path))
                        {
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            Text = textBox1.Text;  
                            this.Close();
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("Please Enter The Right Password", "Wrong Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox1.Focus();
                            textBox1.SelectAll();
                        }
                    }
                    else
                    {
                        this.Text = textBox1.Text;
                        this.Close();
                    }
                    break;
                case 1:
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    this.Close();
                    break;
                case 2:
                    textBox1.Text = "";
                    textBox1.Focus();
                    break;
            }
        }
    }
}
