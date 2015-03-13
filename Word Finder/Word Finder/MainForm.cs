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
    public partial class MainForm : Form
    {
        MatchDialogForm mdf;
        public MainForm()
        {
            InitializeComponent();
            folderBrowserDialog.SelectedPath = string.Empty;
            folderBrowserDialog.SelectedPath = @"C:\Program Files\Counter Strike Source Full\";
            pathTextBox.Text = folderBrowserDialog.SelectedPath;
            thierdSizeUnitComboBox.SelectedIndex = 0;
            secondSizeUnitComboBox.SelectedIndex = 0;
            firstSizeUnitComboBox.SelectedIndex = 0;

            byRangeCheckBox.Checked = false;
            bySizeCheckBox.Checked = false;
            byWordCheckBox.Checked = true;

            byRangeCheckBox_CheckedChanged(null, null);
            bySizeCheckBox_CheckedChanged(null, null);
            //pictureBox1.Image = new Bitmap(this.Icon.ToBitmap(),50,50);
        }

        System.Threading.Tasks.Task task;
        bool abort = false;
        bool pause = false;
        bool ignore = false;
        System.Collections.Generic.List<string> files = new List<string>();
        int startfile = 0;

        private void StartTask()
        {
            if (wordTextBox.Text == string.Empty && byWordCheckBox.Checked)
                return;
            string[] list = System.IO.Directory.GetFiles(folderBrowserDialog.SelectedPath);
            dicLabel.Text = folderBrowserDialog.SelectedPath;
            if (list.Length == 0)
            {
                progressBar1.Value = 0;
                simpleLookingButton.Enabled = true;
                superLookingButton.Enabled = true;
            }
            totalLabel.Text = list.Length.ToString();
            superLookingButton.Enabled = false; ;
            progressBar1.Maximum = list.Length;
            progressBar1.Step = 1;
            System.IO.StreamReader stream;
            foreach(string file in list)
            {
                if (abort)
                {
                    currentLabel.Text = totalLabel.Text;
                    abort = false;
                    break;
                }
                try
                {
                    stream = new System.IO.StreamReader(file);
                    string text = stream.ReadToEnd();
                    bool[] res = new bool[3]{false,false,false};
                    long fileSize = stream.BaseStream.Length;
                    stream.Close();
                    int indexof = 0;
                    if (byWordCheckBox.Checked && wordTextBox.Text.Trim() != string.Empty)
                    {
                        indexof = text.IndexOf(wordTextBox.Text);
                        if (indexof != -1)
                        {
                            res[0] = true;
                        }
                    }
                    else
                        res[0] = true;
                    if (bySizeCheckBox.Checked)
                    {
                        if (fileSize == ToUnit((Int64)firstSizeNumericUpDown.Value, firstSizeUnitComboBox.SelectedText.Trim()))
                            res[1] = true;
                    }
                    else
                        res[1] = true;
                    if (byRangeCheckBox.Checked)
                    {
                        if (fileSize >= ToUnit((Int64)secondSizeNumericUpDown.Value, secondSizeUnitComboBox.SelectedText.Trim()) && fileSize <= ToUnit((Int64)thierdSizeNumericUpDown.Value, thierdSizeUnitComboBox.SelectedText.Trim()))
                            res[2] = true;
                    }
                    else
                        res[2] = true;
                    if(res[0] && res[1] && res[2])
                    {
                        System.Windows.Forms.DialogResult rest = System.Windows.Forms.DialogResult.None;
                        if (byWordCheckBox.Checked)
                        {
                            mdf = new MatchDialogForm(dicLabel.Text, System.IO.Path.GetFileName(file), indexof, false, text, wordTextBox.Text.Trim());
                            rest = mdf.ShowDialog();
                        }
                        else
                        {
                            mdf = new MatchDialogForm(dicLabel.Text, System.IO.Path.GetFileName(file), indexof);
                            rest = mdf.ShowDialog();
                        }
                        if (rest == System.Windows.Forms.DialogResult.Abort)
                        {
                            progressBar1.Value = 0;
                            simpleLookingButton.Enabled = true;
                            superLookingButton.Enabled = true;
                            currentLabel.Text = totalLabel.Text;
                            break;
                        }
                    }
                    progressBar1.PerformStep();
                    currentLabel.Text = progressBar1.Value.ToString();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Could not read the file " + System.IO.Path.GetFileName(file) + "\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    progressBar1.PerformStep();
                    currentLabel.Text = progressBar1.Value.ToString();
                    continue;
                }

            }
            task.Wait();
            progressBar1.Value = 0;
            simpleLookingButton.Enabled = true;
            superLookingButton.Enabled = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                simpleLookingButton.Enabled = true;
                superLookingButton.Enabled = true;
                progressBar1.Value = 0;
                pathTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void startLookingButton_Click(object sender, EventArgs e)
        {
            task = new System.Threading.Tasks.Task(StartTask);
            simpleLookingButton.Enabled = false;
            superLookingButton.Enabled = false;
            browseButton.Enabled = false;
            abortButton.Enabled = true;
            pathTextBox.ReadOnly = true;
            wordTextBox.ReadOnly = true;
            task.Start();
        }

        private void wordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (folderBrowserDialog.SelectedPath != string.Empty)
            {
                simpleLookingButton.Enabled = true;
                superLookingButton.Enabled = true;
                progressBar1.Value = 0;
            }
        }
        private void StartSuperLooking()
        {
            if (wordTextBox.Text == string.Empty)
                return;
            if (files.Count == 0)
            {
                this.UseWaitCursor = true;
                FillAllDicFiles(ref files, folderBrowserDialog.SelectedPath);
                this.UseWaitCursor = false;
                ignoreButton.Enabled = true;
                abortButton.Enabled = true;
                pauseContinueButton.Enabled = true;
                startfile = 0;
            }
            if (files.Count == 0)
            {
                progressBar1.Value = 0;
                simpleLookingButton.Enabled = true;
                superLookingButton.Enabled = true;
            }
            statLabel.Text = "Search In";
            totalLabel.Text = files.Count.ToString();
            progressBar1.Maximum = files.Count;
            progressBar1.Step = 1;
            System.IO.StreamReader stream;
            string last = "";
            for (int i = startfile; i < files.Count;i++)
            {
                string file = files[i];
                if (ignore)
                {
                    if (last == "")
                    {
                        last = file;
                        continue;
                    }
                    if (System.IO.Path.GetDirectoryName(file) == System.IO.Path.GetDirectoryName(last))
                    {
                        last = file;
                        progressBar1.PerformStep();
                        currentLabel.Text = progressBar1.Value.ToString();
                        continue;
                    }
                    else
                    {
                        last = "";
                        ignore = false;
                    }
                }
                if (abort)
                {
                    currentLabel.Text = totalLabel.Text;
                    abort = false;
                    break;
                }
                if (pause)
                {
                    startfile = i;
                    break;
                }
                try
                {
                    dicLabel.Text = System.IO.Path.GetDirectoryName(file);
                    stream = new System.IO.StreamReader(file);
                    string text = stream.ReadToEnd();
                    stream.Close();
                    bool[] res = new bool[3] { false, false, false };
                    int indexof = 0;
                    if (byWordCheckBox.Checked)
                    {
                        indexof = text.IndexOf(wordTextBox.Text);
                        if (indexof != -1)
                        {
                            res[0] = true;
                        }
                    }
                    else
                        res[0] = true;
                    if (bySizeCheckBox.Checked)
                    {
                        if (stream.BaseStream.Length == ToUnit((Int64)firstSizeNumericUpDown.Value, firstSizeUnitComboBox.SelectedText.Trim()))
                            res[1] = true;
                    }
                    else
                        res[1] = true;
                    if (byRangeCheckBox.Checked)
                    {
                        if (stream.BaseStream.Length >= ToUnit((Int64)secondSizeNumericUpDown.Value, secondSizeUnitComboBox.SelectedText.Trim()) && stream.BaseStream.Length <= ToUnit((Int64)thierdSizeNumericUpDown.Value, thierdSizeUnitComboBox.SelectedText.Trim()))
                            res[2] = true;
                    }
                    else
                        res[2] = true;
                    if (res[0] && res[1] && res[2])
                    {
                        System.Windows.Forms.DialogResult rest = System.Windows.Forms.DialogResult.None;
                        if (byWordCheckBox.Checked)
                        {
                            mdf = new MatchDialogForm(dicLabel.Text, System.IO.Path.GetFileName(file), indexof, false, text, wordTextBox.Text.Trim());
                            rest = mdf.ShowDialog();
                        }
                        else
                        {
                            mdf = new MatchDialogForm(dicLabel.Text, System.IO.Path.GetFileName(file), indexof);
                            rest = mdf.ShowDialog();
                        }
                        if (rest == System.Windows.Forms.DialogResult.Abort)
                        {
                            progressBar1.Value = 0;
                            simpleLookingButton.Enabled = true;
                            superLookingButton.Enabled = true;
                            currentLabel.Text = totalLabel.Text;
                            break;
                        }
                        else
                            if (rest == System.Windows.Forms.DialogResult.Ignore)
                            {
                                ignore = true;
                                last = file;
                            }
                    }
                    progressBar1.PerformStep();
                    currentLabel.Text = progressBar1.Value.ToString();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Could not read the file " + System.IO.Path.GetFileName(file) + "\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    progressBar1.PerformStep();
                    currentLabel.Text = progressBar1.Value.ToString();
                    continue;
                }

            }
            task.Wait();
            progressBar1.Value = 0;
            simpleLookingButton.Enabled = true;
        }
        private void FillAllDicFiles(ref System.Collections.Generic.List<string> files,string startDic)
        {
            statLabel.Text = "Collecting";
            foreach (string file in System.IO.Directory.GetFiles(startDic))
                files.Add(file);
            foreach (string dic in System.IO.Directory.GetDirectories(startDic))
            {
                dicLabel.Text = dic;
                FillAllDicFiles(ref files,dic);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists(pathTextBox.Text))
            {
                folderBrowserDialog.SelectedPath = pathTextBox.Text;
                simpleLookingButton.Enabled = true;
                superLookingButton.Enabled = true;
            }
            else
            {
                simpleLookingButton.Enabled = false;
                superLookingButton.Enabled = false;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            simpleLookingButton.Enabled = false;
            superLookingButton.Enabled = false;
            browseButton.Enabled = false;

            pathTextBox.ReadOnly = true;
            wordTextBox.ReadOnly = true;

            task = new System.Threading.Tasks.Task(StartSuperLooking);
            task.Start();
        }

        private void currentLabel_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(currentLabel.Text) == int.Parse(totalLabel.Text))
            {
                pathTextBox.ReadOnly = false;
                wordTextBox.ReadOnly = false;
                progressBar1.Value = 0;

                browseButton.Enabled = true;
                simpleLookingButton.Enabled = true;
                superLookingButton.Enabled = true;

                ignoreButton.Enabled = false;
                abortButton.Enabled = false;
                pauseContinueButton.Enabled = false;

                totalLabel.Text = "2";
                currentLabel.Text = "0";
                totalLabel.Text = "0";
                dicLabel.Text = "XX";
                files.Clear();

                pause = false;
                ignore = false;
                abort = false;

                System.Windows.Forms.MessageBox.Show("The Whole Process Done");
            }
        }

        private void abortButton_Click(object sender, EventArgs e)
        {
            if(pause)
            {
                currentLabel.Text = totalLabel.Text;
            }else
                abort = true;
        }

        private void pauseContinueButton_Click(object sender, EventArgs e)
        {
            if (pause)
            {
                pauseContinueButton.Text = "Pause";
                task = new System.Threading.Tasks.Task(StartSuperLooking);
                task.Start();
            }
            else
                pauseContinueButton.Text = "Continue";

            pause = !pause;

        }

        private void ignoreButton_Click(object sender, EventArgs e)
        {
            ignore = true;
        }

        private void byWordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            wordTextBox.Enabled = byWordCheckBox.Checked;
        }

        private void bySizeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (bySizeCheckBox.Checked)
                byRangeCheckBox.Checked = false;
            firstSizeNumericUpDown.Enabled = bySizeCheckBox.Checked;
            firstSizeUnitComboBox.Enabled = firstSizeNumericUpDown.Enabled;
        }

        private void byRangeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (byRangeCheckBox.Checked)
                bySizeCheckBox.Checked = false;
            secondSizeNumericUpDown.Enabled = byRangeCheckBox.Checked;
            secondSizeUnitComboBox.Enabled = byRangeCheckBox.Checked;
            thierdSizeNumericUpDown.Enabled = byRangeCheckBox.Checked;
            thierdSizeUnitComboBox.Enabled = byRangeCheckBox.Checked;
        }

        private static Int64 ToUnit(Int64 size, string unit)
        {
            switch(unit)
            {
                case "MB":
                    return ToMB(size);
                case "KB":
                    return ToKB(size);
                case "GB":
                    return ToGB(size);
            }
            return size;
        }
        private static Int64 ToKB(Int64 size)
        {
            return size / 1024;
        }
        private static Int64 ToMB(Int64 size)
        {
            return (size / 1024)/1024;
        }
        private static Int64 ToGB(Int64 size)
        {
            return ((size / 1024) / 1024)/1024;
        }
    }
}
