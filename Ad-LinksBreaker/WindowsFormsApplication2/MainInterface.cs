using CefSharp;
using CefSharp.WinForms;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class MainInterface : Form
    {

        private List<ILinkBreaker> breakers = new List<ILinkBreaker>();

        public MainInterface()
        {
            InitializeComponent();

            breakers.Add(new LinkbucksBreaker());
            breakers.Add(new ZimkBreaker());
            breakers.Add(new AdFlyBreaker(panel1));
            breakers.Add(new GulfUpBreaker());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
                return;

            textBox2.Text = "";
            string url = textBox1.Text;

            listBox1.Items.Clear();
            if (progressBar1.Style == ProgressBarStyle.Marquee)
                return;

            progressBar1.Style = ProgressBarStyle.Marquee;
            new Task(() =>
            {
                string result = StartDownload(url);

                this.Invoke(new MethodInvoker(() =>
                {
                    OpenInBrowser(result);
                    textBox2.Text = result;
                    label1.Text = "Done :)";
                    progressBar1.Style = ProgressBarStyle.Blocks;
                }));

            }).Start();
            
        }

        private string StartDownload(string url)
        {
            return ParseUrl(url);
        }

        private string ParseUrl(string url)
        {
            string nextUrl = null;

            for (int i = 0; i < breakers.Count; i++)
            {
                ILinkBreaker item = breakers[i];
                if (item.CanBreake(url))
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        label1.Text = "Accessing " + item.GetName() + " ....";
                        listBox1.Items.Add(url);
                    }));

                    try
                    {
                        nextUrl = item.BreakUrl(url);
                    }
                    catch
                    {
                        return url;
                    }

                    break;
                }
            }

            if (nextUrl != null)
            {
                return ParseUrl(nextUrl);
            }

            return url;
        }

        public void OpenInBrowser(string url,bool anyway = false)
        {
            if(Settings.OpenWithChrome || anyway)
            {
                Process.Start("chrome", url);
            }
            else if (Settings.OpenWithIE)
            {
                Process.Start("iexplore", url);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            (new AppSettings()).ShowDialog();
        }

        protected override void OnClosed(EventArgs e)
        {
            StreamWriter writer = new StreamWriter("settings.ini");

            if (Settings.OpenWithIE)
                writer.WriteLine("OpenWith=iexplorer");
            else if(Settings.OpenWithChrome)
                writer.WriteLine("OpenWith=chrome");

            writer.Close();

            base.OnClosed(e);
        }

        protected override void OnLoad(EventArgs e)
        {

            if (File.Exists("settings.ini"))
            {
                StreamReader reader = new StreamReader("settings.ini");

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (line.Trim() == "")
                        continue;

                    if (line.ToLower().StartsWith("openwith"))
                    {
                        if (line.Trim().EndsWith("chrome"))
                            Settings.OpenWithChrome = true;
                        else if (line.Trim().EndsWith("iexplorer"))
                            Settings.OpenWithIE = true;
                    }
                }

                reader.Close();
            }

            base.OnLoad(e);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            string old = textBox1.Text;
            string clip = Clipboard.GetText();

            if (!clip.ToLower().StartsWith("http")) return;

            textBox1.Text = clip != null ? clip : "";

            if (old != textBox1.Text)
            {
                new Task(() =>
                {
                    int sleep = 40;
                    int steps = 5;
                    int redDiff = Color.Green.R - textBox1.BackColor.R;
                    int greenDiff = Color.Green.G - textBox1.BackColor.G;
                    int blueDiff = Color.Green.B - textBox1.BackColor.B;

                    int redAdd = redDiff / steps;
                    int greenAdd = greenDiff / steps;
                    int blueAdd = blueDiff / steps;

                    for (int i = 0; i < steps; i++)
                    {
                        this.Invoke(new MethodInvoker(() =>
                        {
                            textBox1.BackColor = Color.FromArgb(textBox1.BackColor.R + redAdd, textBox1.BackColor.G + greenAdd, textBox1.BackColor.B + blueAdd);
                        }));

                        Thread.Sleep(sleep);
                    }

                    for (int i = 0; i < steps; i++)
                    {
                        this.Invoke(new MethodInvoker(() =>
                        {
                            textBox1.BackColor = Color.FromArgb(textBox1.BackColor.R - redAdd, textBox1.BackColor.G - greenAdd, textBox1.BackColor.B - blueAdd);
                        }));

                        Thread.Sleep(sleep);
                    }
                }).Start();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenInBrowser(textBox2.Text, true);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
                Clipboard.SetText(listBox1.SelectedItem.ToString());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
                OpenInBrowser(listBox1.SelectedItem.ToString(),true);
        }
    }
}
