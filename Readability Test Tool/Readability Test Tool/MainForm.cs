using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;

namespace Readability_Test_Tool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            wights = new WightUpdate();
            wights.FillArray();
        }
        private void StartLoadingFile()
        {
            if (fromFile)
            {
                try
                {
                    CurrentFilePath.Text = GetFile.FileName;
                }
                catch
                {
                }
                //  if (System.Windows.Forms.MessageBox.Show("Error During reading the file", "Error", System.Windows.Forms.MessageBoxButtons.RetryCancel, System.Windows.Forms.MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.Retry)
                //      StartLoadingFile();
                //  else
                //      return;
                TextReader tr = new StreamReader(GetFile.FileName);
                try
                {
                    TextArea.Text = tr.ReadToEnd();
                }
                catch
                {
                }
                try
                {
                    File = TextArea.Text.Split('\n');
                }
                catch
                {
                }
                tr.Close();
            }
            else
            {
                try
                {
                    File = TextArea.Text.Split('\n');
                }
                catch
                {
                }
            }
            functions = new CodeDetails(File);
            Report.Enabled = true;
            try
            {
                TextArea.ForeColor = Color.Black;
                SFDetails.Enabled = true;
                TextArea.ForeColor = Color.Black;
            }
            catch
            {
            }
            
        }
        private void ColorArea()
        {
            int start = 0;
            string [] keyword = {"class","extends","public","private","protected"};

            for (int i = 0; i < keyword.Length; i++)
            {
                start = 0;
                while (TextArea.Text.IndexOf(keyword[i], start) != -1)
                {
                    start = TextArea.Text.IndexOf(keyword[i], start);
                    TextArea.SelectionStart = start;
                    TextArea.SelectionLength = keyword[i].Length;
                    start = TextArea.Text.IndexOf(keyword[i], start) + keyword[i].Length;
                    TextArea.SelectionColor = Color.Blue;
                    TextArea.SelectionStart = 0;
                    TextArea.SelectionLength = 0;
                }
            }
            while (TextArea.Text.IndexOf("//", start) != -1)
            {
                start = TextArea.Text.IndexOf("//", start);
                TextArea.SelectionStart = start;
                TextArea.SelectionLength = TextArea.Text.IndexOf("\n", start) - start;
                start = TextArea.Text.IndexOf("\n", start);
                TextArea.SelectionColor = Color.Green;
                TextArea.SelectionStart = 0;
                TextArea.SelectionLength = 0;
            }
        }
        private void Import_Click(object sender, EventArgs e)
        {

            GetFile = new OpenFileDialog();
            GetFile.Filter = "Java File(*.Java;)|*.Java;|All files (*.*)|*.*";
            if (GetFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fromFile = true;
                //TextArea.Text = string.Empty;
                File = null;
                ReadingLabel.Text = "Reading File . . .";
                ErrorsList.Items.Clear();
                task = System.Threading.Tasks.Task.Factory.StartNew(StartLoadingFile);
                this.UseWaitCursor = true;
                ReadingLabel.Visible = true;
                try
                {
                    task.Wait();
                }
                catch
                {
                }
                this.UseWaitCursor = false;
                ReadingLabel.Visible = false;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ScopeAndFunctions f = new ScopeAndFunctions("The File : ( " + CurrentFilePath.Text + " ) Scope And Functions Details",functions.FunctionsAndScopes);
            f.ShowDialog();
          
        }
        ReportForm reportForm;
        private void button3_Click(object sender, EventArgs e)
        {
            if (reportForm != null)
                reportForm.Close();
            reportForm = new ReportForm(CurrentFilePath.Text, wights.Wights, ref functions);
            reportForm.Show(this);
        }
        private void button4_Click(object sender, EventArgs e)
        {
        }
        private void About_Click(object sender, EventArgs e)
        {
            AboutForm form = new AboutForm();
            form.ShowDialog();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            TextArea.Size = new Size(this.Width - 45, this.Size.Height - ErrorsList.Size.Height - 150);
            ErrorsList.Location = new Point(ErrorsList.Location.X, TextArea.Location.Y + TextArea.Height + 20);
            ErrorsList.Width = TextArea.Width;
        }

        private void GetSrarted()
        {
            this.Height += 20;
            for (int i = 0; i < 1000000; i++) ;
            this.Height += 30;
            for (int i = 0; i < 1000000; i++) ;
            this.Height += 30;
            ShowButton.Location = new Point(this.Width - ShowButton.Width - 6, this.Height - 29 - ShowButton.Height);
        }
        private void GetSrartedHide()
        {
            this.Height -= 20;
            for (int i = 0; i < 1000000; i++) ;
            this.Height -= 30;
            for (int i = 0; i < 1000000; i++) ;
            this.Height -= 30;
            ShowButton.Location = old;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!showed)
            {
                old = ShowButton.Location;
                showed = true;
                ShowButton.Text = "Hide";
                showHide = System.Threading.Tasks.Task.Factory.StartNew(GetSrarted);
                showHide.Wait();
            }
            else
            {
                showed = false;
                ShowButton.Text = "Settings";
                showHide = System.Threading.Tasks.Task.Factory.StartNew(GetSrartedHide);
                showHide.Wait();
            }
        }

        private void TextArea_TextChanged(object sender, EventArgs e)
        {
            if (TextArea.Text.Length > 4)
            {
                FromText.Enabled = true;
            }
            else
            {
                FromText.Enabled = false;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (TextArea.Text.Length > 4)
            {
                fromFile = false;
                File = null;
                ReadingLabel.Text = "Checking Text Readability . . .";
                ErrorsList.Items.Clear();
                task = System.Threading.Tasks.Task.Factory.StartNew(StartLoadingFile);
                ReadingLabel.Visible = true;
                task.Wait();
                ReadingLabel.Visible = false;
            }
        }

        private void TextArea_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void TextArea_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                TextArea.SelectionLength = 0;
                TextArea.SelectedText = "  ";
            }
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            wights.ShowDialog();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            TextArea.Size = new Size(this.Width - 49,this.Height - (TextArea.Location.Y+(this.Height - (TextArea.Location.Y + TextArea.Height))));
            ErrorsList.Size = new Size(TextArea.Width, this.Height - (ErrorsList.Location.Y + (this.Height - (ErrorsList.Location.Y + ErrorsList.Height))));
            Buttons.Size = new Size(this.Width - Buttons.Location.X, Buttons.Height);
            SettingGroup.Size = new Size(TextArea.Width, SettingGroup.Height);

            SettingGroup.Location = new Point(TextArea.Location.X, this.Height + 5);
        }

        private void Import_MouseHover(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = global::Readability_Test_Tool.Properties.Resources.Button_Hover;
        }
    }
}