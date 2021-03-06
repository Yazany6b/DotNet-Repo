﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class GulfUpBreaker : ILinkBreaker
    {
        public bool CanBreake(string url)
        {
            return url.StartsWith("http://www.gulfup.com/");
        }

        public string BreakUrl(string url)
        {
            WebClient webClient = new WebClient();

            string html = webClient.DownloadString(url);

            int index = html.IndexOf("<p class=\"download\">");

            if (index == -1) return null;

            int index2 = html.IndexOf("/p>", index);

            if (index2 == -1) return null;

            string data = html.Substring(index, index2 - index);

            data.Replace("<p class=\"download\">", "");

            data = data.Replace(" ", "");
            data = data.Replace("   ", "");

            index = data.IndexOf("href=\"");
            if (index == -1) return null;

            index2 = data.IndexOf('"', index + 6);
            if (index2 == -1) return null;

            data = data.Substring(index + 6, index2 - (index + 6));

            return data;
        }

        public string GetName()
        {
            return "gulfup.com";
        }
    }
}
