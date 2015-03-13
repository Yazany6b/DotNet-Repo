using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Student_Assistant_Application
{
    /// <summary>
    /// Class Get Password Form
    /// </summary>
    public partial class GetPasswordForm : Form
    {
        private string password = "";
        /// <summary>
        /// Create an instance of type GetPasswordForm
        /// </summary>
        /// <param name="password">the right password</param>
        public GetPasswordForm(string password)
        {
            InitializeComponent();
            Text = "Input Password";
            this.password = password;
            try
            {
                PrepareLanguage();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.StackTrace, e.Message);
            }
            this.Focus();
            textBox1.Focus();
            
        }

        private void PrepareLanguage()
        {
            if (Statics.EnglishLanguage)
                return;
            if(Statics.Language.ContainsKey("getpasswordform_title"))
            this.Text = Statics.Translate("getpasswordform_title");
            foreach (Control x in this.Controls)
                    x.Text = Statics.Translate(x.Text.Trim());

        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            switch(((Button)sender).TabIndex)
            {
                case 0:
                    if (textBox1.Text == password)//the right password
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        Text = textBox1.Text;  
                        this.Close();
                    }
                    else
                    {
                        //wrong password
                        System.Windows.Forms.MessageBox.Show(Statics.Translate("Please Enter The Right Password"),Statics.Translate("Wrong Password"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox1.Focus();
                        textBox1.SelectAll();
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

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                ButtonClicked(this.okButton, null);
            }
        }
    }
}
