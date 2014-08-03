using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public interface ILinkBreaker
    {
        bool CanBreake(string url);
        string BreakUrl(string url);
        string GetName();
    }
}
