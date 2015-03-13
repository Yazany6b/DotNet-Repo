
namespace Subtitles_Files_Time_Modifier
{
    public static class Log
    {
        public static LogStream Stream { get; set; }

        public static bool EnableLog { get; set; }

        public static void log(string msg,params object [] args)
        {
            if (!EnableLog)
                return;

            Stream.write(msg,args);
        }

        public static void log(string msg)
        {
            if (!EnableLog)
                return;

            Stream.write(msg);
        }

    }
}
