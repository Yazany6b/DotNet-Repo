using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public class AdFlyBreaker : ILinkBreaker
    {
        private Panel container;
        private WebView web_view;
        private Timer timer;

        public AdFlyBreaker(Panel container)
        {
            this.container = container;
        }

        private bool flyLoaded = false;
        private string flyResult = "";
        public bool CanBreake(string url)
        {
            return url.StartsWith("http://adf.ly/");
        }

        public string BreakUrl(string url)
        {
            flyLoaded = false;

            container.Invoke(new MethodInvoker(() =>
            {
                web_view = new WebView(url, new BrowserSettings());
                web_view.Dock = DockStyle.Fill;
                container.Controls.Add(web_view);

                timer = new System.Windows.Forms.Timer();

                timer.Interval = 1000;
                timer.Tick += timer_Tick;

                timer.Start();
            }));


            while (!flyLoaded) { System.Threading.Thread.Sleep(1000); }

            container.Invoke(new MethodInvoker(() =>
            {
                web_view.Dispose();
                timer.Dispose();
            }));

            return flyResult;
        }

        private void timer_Tick(object sender, EventArgs e)
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

        public string GetName()
        {
            return "adf.fly";
        }
    }
}
