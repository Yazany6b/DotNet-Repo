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
        CefSharp.WinForms.WebView web_view;
        System.Windows.Forms.Timer timer;

        public MainInterface()
        {
            InitializeComponent();

            /*web_view = new WebView("file:///C:/Users/Yazan/Documents/Visual%20Studio%202012/Projects/WindowsFormsApplication2/WindowsFormsApplication2/bin/Debug/tmp.html", new BrowserSettings());
            web_view.Dock = DockStyle.Fill;
            panel1.Controls.Add(web_view);

            panel1.Invalidate();
            panel1.Refresh();*/
        }

        void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                string url = web_view.EvaluateScript("document.getElementById(\"skip_button\").href").ToString();

                if (url != "")
                {
                    timer.Stop();
                    flyResult = url;
                    flyLoaded = true;
                }
            }
            catch (Exception)
            {
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (progressBar1.Style == ProgressBarStyle.Marquee)
                return;

            progressBar1.Style = ProgressBarStyle.Marquee;
            new Task(() =>
            {
                string result = StartDownload("file:///C:/Users/Yazan/Documents/Visual%20Studio%202012/Projects/WindowsFormsApplication2/WindowsFormsApplication2/bin/Debug/tmp.html");

                this.Invoke(new MethodInvoker(() =>
                {
                    if (Settings.OpenWithChrome)
                    {
                        Process.Start("chrome", result);
                    }
                    else if (Settings.OpenWithIE)
                    {
                        Process.Start("iexplore", result);
                    }
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
            if (url.StartsWith("http://www.linkbucks.com"))
            {
                return ParseUrl(GetLinkbucksDownloadPage(url));
            }

            if (url.StartsWith("http://zi-m.biz/"))
            {
                return ParseUrl(GetZmDownloadPage(url));
            }

            if (url.StartsWith("http://adf.ly/"))
            {
                return ParseUrl(GetFlyDownloadPage(url));
            }

            if (url.StartsWith("file:///C:/Users"))
            {
                return ParseUrl(GetZmDownloadPage(url));
            }

            return url;
        }

        private bool flyLoaded = false;
        private string flyResult = "";
        private string GetFlyDownloadPage(string url)
        {

            this.Invoke(new MethodInvoker(() =>{
                label1.Text = "Accessing Fly.fl ....";
                listBox1.Items.Add(url);
            }));

            flyLoaded = false;

            this.Invoke(new MethodInvoker(() =>
            {
                web_view = new WebView(url, new BrowserSettings());
                web_view.Dock = DockStyle.Fill;
                panel1.Controls.Add(web_view);

                timer = new System.Windows.Forms.Timer();
                
                timer.Interval = 1000;
                timer.Tick += timer_Tick;

                timer.Start();
            }));


            while (!flyLoaded) { Thread.Sleep(1000); }

            this.Invoke(new MethodInvoker(() =>
            {
                web_view.Dispose();
                timer.Dispose();
            }));

            return flyResult;
        }

        private string GetZmDownloadPage(string url)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                label1.Text = "Accessing zi-m.biz ....";
                listBox1.Items.Add(url);
            }));

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
           
            WebClient webClient = new WebClient();

            string html = webClient.DownloadString(url);
            
            doc.LoadHtml(html);

            int index = html.IndexOf("<p class=\"download\">			");

            int index2 = html.IndexOf("/p>", index);

            string data = html.Substring(index, index2 - index);

            data.Replace("<p class=\"download\">			", "");

            data = data.Replace(" ", "");
            data = data.Replace("   ", "");

            index = data.IndexOf("href=\"");
            index2 = data.IndexOf('"',index + 6);

            data = data.Substring(index + 6, index2 - (index+6));

            return data;
        }

        private string GetLinkbucksDownloadPage(string url)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                label1.Text = "Accessing linkbucks.com ....";
                listBox1.Items.Add(url);
            }));

            int start = url.IndexOf("/url/");

            return url.Substring(start + 5);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
        }

        private void webBrowser1_FileDownload(object sender, EventArgs e)
        {
            string u = GetZmDownloadPage("");
        }

        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            (new AppSettings()).ShowDialog();
        }
    }
}
