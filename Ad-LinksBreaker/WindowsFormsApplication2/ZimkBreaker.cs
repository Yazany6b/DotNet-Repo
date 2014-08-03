using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class ZimkBreaker : ILinkBreaker
    {
        public bool CanBreake(string url)
        {
            return url.StartsWith("http://zi-m.biz/");
        }

        public string BreakUrl(string url)
        {
            WebClient webClient = new WebClient();

            string html = webClient.DownloadString(url);

            int index = html.IndexOf("<p class=\"download\">			");

            int index2 = html.IndexOf("/p>", index);

            string data = html.Substring(index, index2 - index);

            data.Replace("<p class=\"download\">			", "");

            data = data.Replace(" ", "");
            data = data.Replace("   ", "");

            index = data.IndexOf("href=\"");
            index2 = data.IndexOf('"', index + 6);

            data = data.Substring(index + 6, index2 - (index + 6));

            return data;
        }

        public string GetName()
        {
            return "zi-m.biz";
        }
    }
}
