using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Subtitles_Files_Time_Modifier
{
    public partial class MainInterface : Form
    {

        private bool inBack = false;
        public MainInterface()
        {
            InitializeComponent();
            Log.EnableLog = false;
            unitComboBox.SelectedIndex = 1;
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader reader = new System.IO.StreamReader(openFileDialog1.FileName, Encoding.GetEncoding(1256));

                subtitleRichTextBox.Text = reader.ReadToEnd();

                reader.Close();

                performButton.Enabled = true;

                
                endLineNumericUpDown.Maximum = subtitleRichTextBox.Lines.Length;
                endLineNumericUpDown.Value = subtitleRichTextBox.Lines.Length;

                startLineNumericUpDown.Minimum = 1;
                startNumericUpDown.Value = 1;
                

                goNumericUpDown.Maximum = subtitleRichTextBox.Lines.Length;
                goNumericUpDown.Value = 1;
                goNumericUpDown.Minimum = 1;

                label7.Text = "/" + endLineNumericUpDown.Value;

                this.Text = "The Subtitles Modifier : " + System.IO.Path.GetFileName(openFileDialog1.FileName);
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamWriter writer = new System.IO.StreamWriter(saveFileDialog1.FileName, false,Encoding.GetEncoding(1256));

                writer.Write(subtitleRichTextBox.Text);

                writer.Close();
            }
        }

        private int getCount(string source , char des)
        {
            int count = 0;
            for(int i =0;i<source.Length;i++)
                if(source[i] ==des)
                    count++;
            return count;
        }

        private bool isTimingLine(string line)
        {
            return line.Contains("-->") && line.Contains(":") && getCount(line,':') == 4;
        }

        private Time getLineStartTimeInfo(string line)
        {
            string time = line.Substring(0, line.IndexOf(','));

            time = time.Trim().Trim(',');

            return Time.FromString(time);
        }

        private Time getLineEndTimeInfo(string line)
        {
            Log.log("\n"); Log.log("\n");
            Log.log("&&&&&&&&&&&&&&&&&&&&&&\n"); Log.log("\n");
            int start = line.IndexOf("-->");
            Log.log("--> index is = {0}\n",start);

            start = line.IndexOf('>', start) + 1;

            Log.log("> index is = {0}\n",start);
            Log.log("substr form {0} until {1}\n" , start , line.IndexOf(',',start));

            string time = SubStr(line,start, line.IndexOf(',',start));

            Log.log("triming....\n");
            time = time.Trim().Trim(',');
            Log.log("the result time = {0}\n",time);

            Log.log("getting the time...\n");
            Log.log("\n");
            Log.log("&&&&&&&&&&&&&&&&&&&&&&&\n");
            Log.log("\n"); Log.log("\n");

            return Time.FromString(time);
        }

        private string modifyStartTime(Time newTime,string line)
        {
            line = line.Trim();

            int start = line.IndexOf(',');

            string temp = SubStr(line, start, line.Length);

            return newTime.ToString()+temp;
        }

        private string modifyEndTime(Time newTime, string line)
        {
            line = line.Trim();

            int start = line.IndexOf("-->");
            start = line.IndexOf(">") + 1;

            string temp = SubStr(line, 0, start+1);

            string temp2 = SubStr(line, line.IndexOf(',', start), line.Length);

            return temp + newTime.ToString() + temp2;
        }

        System.Threading.Tasks.Task task;

        private void startTask()
        {
            int start = (int)startNumericUpDown.Value;

            int end = (int)endNumericUpDown.Value;

            string[] lines = subtitleRichTextBox.Lines;

            for (int i = (int)startLineNumericUpDown.Value - 1; i < (int)endLineNumericUpDown.Value; i++)
            {
                string line = subtitleRichTextBox.Lines[i];
                if (isTimingLine(line))
                {
                    //Log.EnableLog = true;
                    Log.log("-----------------------------------------------------\n");
                    Log.log("\n");
                    Log.log("timing line = {0}\n",line);
                    Log.log("getting line start time\n");

                    Time t = getLineStartTimeInfo(line);

                    Log.log("the start time = {0}\n",t.ToString());
                    Log.log("adding seconds\n");

                    t.AddSeconds(start);

                    Log.log("after adding {0} seconds = {1}\n",start,t.ToString());
                    Log.log("modifing line\n");

                    line = modifyStartTime(t, line);

                    Log.log("line after modification = {0}\n",line);
                    Log.log("\n");
                    Log.log("\n");
                    Log.log("timing line = {0}\n", line);
                    Log.log("getting line end time\n");

                    t = getLineEndTimeInfo(line);

                    Log.log("the end time = {0}\n", t.ToString());
                    Log.log("adding seconds\n");

                    t.AddSeconds(end);

                    Log.log("after adding {0} seconds = {1}\n", end,t.ToString());
                    Log.log("modifing line\n");

                    line = modifyEndTime(t, line);

                    Log.log("line after modification = {0}\n", line);
                    lines[i] = line;

                    if (allRadioButton.Checked)
                    {
                        subtitleRichTextBox.Lines = lines;
                    }

                    Log.log("\n");
                    Log.log("-----------------------------------------------------\n");
                }
                
                if(!backRadioButton.Checked)
                    progressBar1.Value = i;
                try
                {

                    int pers = ((i + 1) / (subtitleRichTextBox.Lines.Length / 100));
                    this.Text = "The Subtitles Modifier Done : " + (pers > 100 ? 100+"" : pers+"") + "%";
                }catch{}

                //Log.EnableLog = true;
                Log.log("done {0} of {1} Lines\n",i+1,subtitleRichTextBox.Lines.Length);
                //Log.EnableLog = false;
            }


            goButton.Enabled = true;
            performButton.Enabled = true;
            importButton.Enabled = true;
            exportButton.Enabled = true;

            subtitleRichTextBox.Lines = lines;

            subtitleRichTextBox.Refresh();

            progressBar1.Value = 0;

            System.Media.SystemSounds.Exclamation.Play();

            List<Color> colors = new List<Color>();

            colors.Add(this.BackColor);//Original Color
            colors.Add(Color.FromArgb(this.BackColor.R - 50, this.BackColor.G - 50, this.BackColor.B - 50));
            colors.Add(Color.FromArgb(this.BackColor.R - 45, this.BackColor.G - 45, this.BackColor.B - 45));
            colors.Add(Color.FromArgb(this.BackColor.R - 40, this.BackColor.G - 40, this.BackColor.B - 40));
            colors.Add(Color.FromArgb(this.BackColor.R - 35, this.BackColor.G - 35, this.BackColor.B - 35));
            colors.Add(Color.FromArgb(this.BackColor.R - 30, this.BackColor.G - 30, this.BackColor.B - 30));
            colors.Add(Color.FromArgb(this.BackColor.R - 25, this.BackColor.G - 25, this.BackColor.B - 25));
            colors.Add(Color.FromArgb(this.BackColor.R - 20, this.BackColor.G - 20, this.BackColor.B - 20));
            colors.Add(Color.FromArgb(this.BackColor.R - 15, this.BackColor.G - 15, this.BackColor.B - 15));
            colors.Add(Color.FromArgb(this.BackColor.R - 10, this.BackColor.G - 10, this.BackColor.B - 10));

            this.Text = "The Subtitles Modifier";

            this.Activate();

            int late = 200;
            new System.Threading.Tasks.Task(() =>
                {
                    int ticks = 0;
                    //Start Animation Cycle
                    for (int x = 0; x < 4; x++)
                    {
                        colors.Reverse();
                        for (int i = colors.Count - 1; i >= 0; i--)
                        {

                            this.BackColor = colors[i];

                            ticks = Environment.TickCount;

                            while (Environment.TickCount - ticks < late) ;
                        } 
                    }
                    //End Animation Cycle
                }).Start();
        }

        private void performButton_Click(object sender, EventArgs e)
        {
            if (startNumericUpDown.Value == 0 && endLineNumericUpDown.Value == 0)
                return;
            goButton.Enabled = false;
            performButton.Enabled = false;
            importButton.Enabled = false;
            exportButton.Enabled = false;

            progressBar1.Minimum = 0;
            progressBar1.Maximum = subtitleRichTextBox.Lines.Length;
            progressBar1.Value = 0;

            task = new System.Threading.Tasks.Task(startTask);

            task.Start();
        }

        private string SubStr(string str,int start,int end)
        {
            string temp="";
            for (int i = start; i < end; i++)
            {
                temp += str[i];
            }

            return temp;
        }

        private void bgButton_Click(object sender, EventArgs e)
        {
            inBack = !inBack;
        }

        private void subtitleRichTextBox_HScroll(object sender, EventArgs e)
        {
            label3.Text = subtitleRichTextBox.AutoScrollOffset.ToString();
        }

        private void subtitleRichTextBox_VScroll(object sender, EventArgs e)
        {    
            //label3.Text = subtitleRichTextBox.AutoScrollOffset.ToString();

            //currline++;

            //l.Text = currline.ToString();

            //l.Location = new Point(0, subtitleRichTextBox.GetPositionFromCharIndex(subtitleRichTextBox.GetFirstCharIndexOfCurrentLine()).Y);

            
        }

        //Label l = null;
        int currline;
        private void subtitleRichTextBox_SelectionChanged(object sender, EventArgs e)
        {
            

          /*8  if(l == null)
            {
                linesPanel.Controls.Clear();
                l = new Label();
                linesPanel.Controls.Add(l);
            }
            */
            currline = subtitleRichTextBox.GetLineFromCharIndex(subtitleRichTextBox.GetFirstCharIndexOfCurrentLine());

            label4.Text = "Line : " + (currline+1).ToString(); 

            label4.Location = new Point(subtitleRichTextBox.Width - 190 , subtitleRichTextBox.GetPositionFromCharIndex(subtitleRichTextBox.GetFirstCharIndexOfCurrentLine()).Y + subtitleRichTextBox.Location.Y);

            label4.Visible = true;

        }

        private void endLineNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            startLineNumericUpDown.Maximum = endLineNumericUpDown.Value;
        }

        private void startLineNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            endLineNumericUpDown.Minimum = startLineNumericUpDown.Value;
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            currline = (int)goNumericUpDown.Value - 1;

            subtitleRichTextBox.SelectionStart = subtitleRichTextBox.GetFirstCharIndexFromLine(currline);
            subtitleRichTextBox.SelectionLength = 0;

            subtitleRichTextBox.ScrollToCaret();
            subtitleRichTextBox.Refresh();

            subtitleRichTextBox.Focus();

            subtitleRichTextBox_SelectionChanged(null, null);
        }

        long lastResult = 0;

        private void FillResult(Time t)
        {
            lastResult = t.ToSeconds();

            if (timeFilterRadioButton.Checked)
                resultTextBox.Text = t.ToString();
            else
                if (secondsFilterRadioButton.Checked)
                    resultTextBox.Text = lastResult.ToString();
                else
                    if (minutesFilterRadioButton.Checked)
                        resultTextBox.Text = t.ToMinutes().ToString();
                    else
                        if (hoursFilterRadioButton.Checked)
                            resultTextBox.Text = t.ToHours().ToString();
        }

        private void Tool_Cal_Opera_Clicked(object sender, EventArgs e)
        {
            string op1 = operand1MaskedTextBox.Text.Replace(' ', '0');

            if (op1.Trim().EndsWith(":"))
                op1 += "00";

            string op2 = operand2MaskedTextBox.Text.Replace(' ', '0');

            if (op2.Trim().EndsWith(":"))
                op2 += "00";

            Time time1 = Time.FromString(op1);
            Time time2 = Time.FromString(op2);

            //subtitleRichTextBox.Text += time1.ToString() + "  ---  " + time2.ToString();

            switch (((Button)sender).TabIndex)
            {
                case 0 :
                    FillResult(Time.AddTime(time1, time2));
                    break;

                case 1:
                    FillResult(Time.SubtractTime(time1, time2));
                    break;

                case 2:
                    FillResult(Time.MultiplayTime(time1, time2));
                    break;

                case 3:
                    FillResult(Time.DivideTime(time1, time2));
                    break;

                case 4:
                    resultTextBox.Text = "";
                    break;

                case 5:
                    resultTextBox.Text = "";
                    operand1MaskedTextBox.Text = "00:00:00";
                    operand2MaskedTextBox.Text = "00:00:00";

                    break;

                case 6:
                    resultTextBox.Text = "";
                    
                    operand1MaskedTextBox.Text = time2.ToString();
                    operand2MaskedTextBox.Text = time1.ToString();

                    lastResult = 0;

                    break;

                case 7:

                    startNumericUpDown.Value = lastResult;
                    endNumericUpDown.Value = lastResult;

                    break;
            }
        }

        private void setLabelBestLocation()
        {
            int MidX = toolsGroupBox.Width / 2;

            int RealX = MidX - (aboutLabel.Width / 2);

            aboutLabel.Location = new Point(RealX, aboutLabel.Location.Y);
        }

        private bool InAnimation = false;

        private void aboutLabel_Click(object sender, EventArgs e)
        {
            if (InAnimation)
                return;

            InAnimation = !InAnimation;

            Color back = aboutLabel.BackColor;
            Color fore = aboutLabel.ForeColor;

            int addRed = fore.R - back.R;
            int addGreen = fore.G - back.G;
            int addBlue = fore.B - back.B;

            int loops = 6;
            int loopDuration = 150;

            int ratioR = addRed / loops;
            int ratioG = addGreen / loops;
            int ratioB = addBlue / loops;

            new Task(() =>
                {
                    
                    int ticks = 0;

                    for (int i = 0; i < loops; i++)
                    {
                        aboutLabel.ForeColor = Color.FromArgb(aboutLabel.ForeColor.R - ratioR,
                            aboutLabel.ForeColor.G - ratioG, aboutLabel.ForeColor.B - ratioB);

                        aboutLabel.Refresh();

                        ticks = Environment.TickCount;
                        while (Environment.TickCount - ticks < loopDuration) ;
                    }

                    aboutLabel.ForeColor = back;

                    while (Environment.TickCount - ticks < loopDuration) ;
                    aboutLabel.Text = aboutLabel.Text.Equals("By Yazan Baniyounes", StringComparison.OrdinalIgnoreCase) ? "About" : "By Yazan Baniyounes";
                    aboutLabel.Refresh();
                    aboutLabel.ResumeLayout();
                    setLabelBestLocation();

                    for (int i = 0; i < loops; i++)
                    {
                        aboutLabel.ForeColor = Color.FromArgb(aboutLabel.ForeColor.R + ratioR,
                            aboutLabel.ForeColor.G + ratioG, aboutLabel.ForeColor.B + ratioB);
                        aboutLabel.Refresh();

                        ticks = Environment.TickCount;
                        while (Environment.TickCount - ticks < loopDuration) ;
                    }

                    aboutLabel.ForeColor = fore;

                    InAnimation = !InAnimation;
                }).Start() ;
        }

        int lastIndex = 0;

        int lastStart = 0;

        private void findNextButton_Click(object sender, EventArgs e)
        {
            if (findTextBox.Text == string.Empty)
                return;

            lastIndex = subtitleRichTextBox.Find(findTextBox.Text , lastStart , RichTextBoxFinds.None);

            if (lastIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("No More Matches");
                subtitleRichTextBox.SelectionLength = 0;
                lastStart = 0;
                return;
            }
            else
            {
                lastStart = lastIndex < subtitleRichTextBox.Text.Length ? lastIndex + 1 : lastIndex - 1;

                subtitleRichTextBox.SelectionStart = lastIndex;
                subtitleRichTextBox.SelectionLength = findTextBox.Text.Length;

                subtitleRichTextBox.ScrollToCaret();
                subtitleRichTextBox.Refresh();

                subtitleRichTextBox.Focus();

                subtitleRichTextBox_SelectionChanged(null, null);
            }
        }
    }
}
