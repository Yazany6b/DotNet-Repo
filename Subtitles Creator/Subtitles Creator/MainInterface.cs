using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Development.Utilities.Logging;
using Development.Utilities.Statics;

namespace Subtitles_Creator
{
    public partial class MainInterface : Form
    {
        private Microsoft.DirectX.AudioVideoPlayback.Video video;
        private string duration;

        private System.Threading.Thread thread;

        private Log console = new Log(new ConsoleLogStream());

        private string filename = "";
        public MainInterface()
        {

            InitializeComponent();

            videoPanel.Size = new System.Drawing.Size(632, 363);

            old = this.ClientSize;

            console.EnableLog = false;

            console.WriteLine("ClientSize = {0} , OpenBTN = {1} ", old, openButton.ClientSize);

            long[] splites = Development.Utilities.Statics.Units.SplitUnit(1000, 6);
            foreach(long sp in splites)
                console.WriteLine(sp + "");

            console.WriteLine("");
            console.WriteLine("The Persent of 700 , 100 = {0}" , Development.Utilities.Statics.XMath.ToPercentage(700,600));


            //old = this.Size;
        }

        void video_Stopping(object sender, EventArgs e)
        {
            thread.Abort();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (video != null)
            {
                if (video.Playing || video.Paused)
                {
                    if (thread != null)
                        if (thread.IsAlive)
                            thread.Abort();
                    if (video != null)
                        video.Stop();
                }
            }

            base.OnClosing(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            OnSizeChanged(new EventArgs());
            base.OnLoad(e);
        }

        private void threadStart()
        {
            while (video.Playing)
            {
                trackBar1.Value = (int)video.CurrentPosition;
                label1.Text = Units.TimeFromSeconds((long)video.CurrentPosition) + " / " + duration;
            }
        }

        public static void ResizeComponent(Form form, Size oldSize, Size newSize)
        {
            //int widthDiff = newSize.Width - oldSize.Width;
            //int heightDiff = newSize.Height - oldSize.Height;

            

            foreach (Control control in form.Controls)
            {
                //int currentWidth = control.Width;
                Log.ConsoleLog.WriteLine("Sent Value of {0} is contW = {1} , old = {2} , new = {3}",control
                    .Text, control.ClientSize.Width, oldSize.Width, newSize.Width);
                double width = XMath.
                    FindNumeratorByMutualMultiplication(control.ClientSize.Width , oldSize.Width , newSize.Width);

                double height = XMath.
                    FindNumeratorByMutualMultiplication(control.ClientSize.Height, oldSize.Height, newSize.Height);

                //width -= width * (control.ClientSize.Width / newSize.Width);
                //height -= height * (control.ClientSize.Height / newSize.Height);



                Log.ConsoleLog.WriteLine(control.Text + " W : " + (int)width);
                Log.ConsoleLog.WriteLine(control.Text + " H : " + (int)height);



                control.Width = (int)width;// (System.Math.Ceiling(width));
                control.Height = (int)height;// System.Math.Ceiling(height);
            }

        }

        void video_Ending(object sender, EventArgs e)
        {
            thread.Abort();
            trackBar1.Value = 0;
            label1.Text = "0/0";
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
        }

        Size old;
        protected override void OnSizeChanged(EventArgs e)
        {
            //
            
            subtitleRichTextBox.Width = this.Width / 3;
            subtitleRichTextBox.Height = this.Height - subtitleRichTextBox.Location.Y - 45;

            subtitleRichTextBox.Location = new Point(this.ClientSize.Width - subtitleRichTextBox.ClientSize.Width - 20, subtitleRichTextBox.Location.Y);

            videoPanel.Width = (this.ClientSize.Width - subtitleRichTextBox.ClientSize.Width - 35);

            trackBar1.Width = videoPanel.Width;

            controlsPanel.Width = videoPanel.Width;

            buttonsPanel.Location = new Point(Math.Abs(controlsPanel.Width - buttonsPanel.Width) / 2,buttonsPanel.Location.Y);

            controlsPanel.Location = new Point(controlsPanel.Location.X, this.Height - controlsPanel.Height - 40);

            subtitleTextBox.Width = controlsPanel.Width - 10;

            videoPanel.Height = this.Height - controlsPanel.Height - 50 - trackBar1.Height;

           
            trackBar1.Location = new Point(trackBar1.Location.X, videoPanel.Height + videoPanel.Location.Y + 5);

            //System.Windows.Forms.MessageBox.Show(trackBar1.Location.Y.ToString());

            if (video != null)
            {
                video.Size = videoPanel.Size;
            }

            base.OnSizeChanged(e);
        }

        void video_Starting(object sender, EventArgs e)
        {
            trackBar1.Maximum = (int)video.Duration;
            video.Caption = "Yazan Is The Best";

            thread = new System.Threading.Thread(new System.Threading.ThreadStart(threadStart));

            thread.Start();
            
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if (video == null)
                return;

            video.Play();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (video == null)
                return;

            ResizeComponent(this, this.ClientSize, this.ClientSize);
            console.WriteLine("===========================================================");
            console.WriteLine("This Size = {0}" , this.ClientSize);
            console.WriteLine("===========================================================");
            //this.Width = 750;
            video.Pause();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (video == null)
                return;

            video.Stop();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.Drawing.Size size = videoPanel.Size;
                if (video == null)
                {
                    video = new Microsoft.DirectX.AudioVideoPlayback.Video(openFileDialog1.FileName);

                    video.Owner = videoPanel;

                    video.Starting += new EventHandler(video_Starting);

                    video.Ending += new EventHandler(video_Ending);

                    video.Stopping += new EventHandler(video_Stopping);


                }
                else
                {
                    if (video.Playing)
                    {
                        thread.Abort();
                        video.Stop();
                    }

                    video.Open(openFileDialog1.FileName);
                }

                video.Size = videoPanel.Size;

                duration = Units.TimeFromSeconds((long)video.Duration);

                filename = openFileDialog1.FileName;

                video.Size = size;
                videoPanel.Size = size;
            }
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            if (video == null)
                return;

            if (startTimeTextBox.Text == string.Empty)
            {
                startTimeTextBox.Text = Units.TimeFromSeconds((long)video.CurrentPosition);
            }else
                if (endTimeTextBox.Text == string.Empty)
                {
                    endTimeTextBox.Text = Units.TimeFromSeconds((long)video.CurrentPosition);
                    if (startTimeTextBox.Text.Equals(endTimeTextBox.Text))
                    {
                        if (System.Windows.Forms.MessageBox.Show("The start time equals end time are you sure about that?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) ==
                             System.Windows.Forms.DialogResult.Cancel)
                        {
                            endTimeTextBox.Text = String.Empty;
                            return;
                        }
                    }

                    
                }

            if(subtitleTextBox.Text != string.Empty && startTimeTextBox.Text != string.Empty && endTimeTextBox.Text != string.Empty)
            {
                int count = subtitleRichTextBox.Lines.Length + 1;
                subtitleRichTextBox.Text += count + Environment.NewLine;

                subtitleRichTextBox.Text += string.Format("{0},{1} --> {2},{3}" + Environment.NewLine,startTimeTextBox.Text,count * 100
                    , endTimeTextBox.Text , count * 50);

                subtitleRichTextBox.Text += subtitleTextBox.Text + Environment.NewLine;

                subtitleTextBox.Text = string.Empty;
                startTimeTextBox.Text = string.Empty;
                endTimeTextBox.Text = string.Empty;
            }
                    
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (video == null)
                return;

            string path = System.IO.Path.GetDirectoryName(filename) + System.IO.Path.DirectorySeparatorChar +
                System.IO.Path.GetFileNameWithoutExtension(filename) + ".srt";

            System.IO.StreamWriter writer;
            if (System.IO.File.Exists(path))
            {
                System.Windows.Forms.DialogResult result = ExistFileForm.Form.ShowDialog();
                switch (result)
                {
                    case System.Windows.Forms.DialogResult.Retry:

                        writer = new System.IO.StreamWriter(path);

                        foreach (string line in subtitleRichTextBox.Lines)
                            writer.WriteLine(line);

                        writer.Close();

                        break;

                    case System.Windows.Forms.DialogResult.Ignore:

                        writer = new System.IO.StreamWriter(path, true);

                        foreach (string line in subtitleRichTextBox.Lines)
                            writer.WriteLine(line);

                        writer.Close();

                        break;

                    case System.Windows.Forms.DialogResult.Abort:

                        string temp = path;
                        int index = 1;

                        while (System.IO.File.Exists(temp))
                        {
                            temp = System.IO.Path.GetDirectoryName(filename) + System.IO.Path.DirectorySeparatorChar +
                                    System.IO.Path.GetFileNameWithoutExtension(filename) + '_' + index + ".srt";
                        }

                        writer = new System.IO.StreamWriter(temp);

                        foreach (string line in subtitleRichTextBox.Lines)
                            writer.WriteLine(line);

                        writer.Close();

                        System.Windows.Forms.MessageBox.Show("The file name is : " + System.IO.Path.GetFileName(temp));

                        break;

                }
            }
            else
            {
                writer = new System.IO.StreamWriter(path);

                foreach (string line in subtitleRichTextBox.Lines)
                    writer.WriteLine(line);
                writer.Close();

                System.Windows.Forms.MessageBox.Show("The file name is : " + System.IO.Path.GetFileName(path));
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (video == null)
                return;

            if (video.Playing || video.Paused)
            {
                video.CurrentPosition = trackBar1.Value;
                label1.Text = Units.TimeFromSeconds((long)video.CurrentPosition) + " / " + duration;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void clearButtonButton_Click(object sender, EventArgs e)
        {
            subtitleTextBox.Clear();
            startTimeTextBox.Clear();
            endTimeTextBox.Clear();
        }

    }
}
