using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Word_Finder
{
    public partial class MatchDialogForm : Form
    {
        public MatchDialogForm(string dic,string file,int index)
        {
            InitializeComponent();
            dicTextBox.Text = dic;
            fileTextBox.Text = file;
            indexLabel.Text = index.ToString();
        }

        public MatchDialogForm(string dic, string file, int index,string text,string word)
        {
            InitializeComponent();
            dicTextBox.Text = dic;
            fileTextBox.Text = file;
            indexLabel.Text = index.ToString();
            FormatTextBox(text, word, index);
        }

        public MatchDialogForm(string dic, string file, int index,bool enable, string text, string word)
        {
            InitializeComponent();
            dicTextBox.Text = dic;
            fileTextBox.Text = file;
            indexLabel.Text = index.ToString();
            FormatTextBox(text, word, index);
            ignoreButton.Enabled = enable;
        }
        public MatchDialogForm(string dic, string file, int index,bool enableIgnore)
        {
            InitializeComponent();
            dicTextBox.Text = dic;
            fileTextBox.Text = file;
            indexLabel.Text = index.ToString();
            ignoreButton.Enabled = enableIgnore;
        }

        private void FormatTextBox(string text, string word, int index)
        {
            if (text.Length < 200)
                richTextBox1.Text = text;
            else
                if (index < 100)
                    richTextBox1.Text = text.Substring(0, 190);
                else
                {
                    if(index + 100 >= text.Length)
                        richTextBox1.Text = text.Substring(index - 100,100 + (text.Length - index - 1));
                    else
                        richTextBox1.Text = text.Substring(index - 100, 200);
                }

            richTextBox1.Find(word);
            richTextBox1.SelectionColor = System.Drawing.Color.Red;
            richTextBox1.SelectionLength = 0;
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            switch (((Button)sender).TabIndex)
            {
                case 0:
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    break;
                case 1:
                    DialogResult = System.Windows.Forms.DialogResult.Abort;
                    break;
                case 2:
                    DialogResult = System.Windows.Forms.DialogResult.Ignore;
                    break;
            }
            this.Close();
        }
    }
}
