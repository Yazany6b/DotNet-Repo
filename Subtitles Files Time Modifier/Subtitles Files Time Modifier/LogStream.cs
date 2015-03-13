using System;
using System.Collections.Generic;
using System.Text;

namespace Subtitles_Files_Time_Modifier
{
    public interface LogStream
    {
        void write(string msg, params object[] args);
        void write(string msg);
    }
}
