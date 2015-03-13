using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Subtitles_Files_Time_Modifier
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Log.EnableLog = true;
            Log.Stream = new ConsoleLogStream();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainInterface());
        }
    }
}
