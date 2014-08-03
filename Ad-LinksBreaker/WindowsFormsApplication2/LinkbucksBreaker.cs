using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class LinkbucksBreaker : ILinkBreaker
    {

        public bool CanBreake(string url)
        {
            return url.StartsWith("http://www.linkbucks.com");
        }

        public string BreakUrl(string url)
        {
            int start = url.IndexOf("/url/");

            if (start == -1) return null;

            return url.Substring(start + 5);
        }

        public string GetName()
        {
            return "linkbucks.com";
        }
    }
}
