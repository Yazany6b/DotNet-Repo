using System;
using System.Collections.Generic;
using System.Text;

namespace Subtitles_Files_Time_Modifier
{
    public class ConsoleLogStream : LogStream
    {
        public void write(string msg, params object[] args)
        {
            System.Console.Write(msg,args);
        }

        public void write(string msg)
        {
            System.Console.Write(msg);
        }
    }
}
