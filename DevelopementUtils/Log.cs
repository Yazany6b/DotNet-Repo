
namespace Development.Utilities.Logging
{
    /// <summary>
    /// The log class used to log the developer message to spacific streams
    /// </summary>
    public static class Log
    {
        /// <summary>
        /// The log stream that all log message will be right to it
        /// </summary>
        public static LogStream Stream { get; set; }

        /// <summary>
        /// allow log message to be prinetd
        /// </summary>
        public static bool EnableLog { get; set; }

        /// <summary>
        /// print a log message from format
        /// </summary>
        /// <param name="msg">string format</param>
        /// <param name="args">the args that the message containes</param>
        public static void log(string msg,params object [] args)
        {
            if (!EnableLog)
                return;

            Stream.Write(msg,args);
        }

        /// <summary>
        /// log a normal message without any args
        /// </summary>
        /// <param name="msg">the message to be logged</param>
        public static void log(string msg)
        {
            if (!EnableLog)
                return;

            Stream.Write(msg);
        }

        /// <summary>
        /// print a log message from format ending with new line character
        /// </summary>
        /// <param name="msg">string format</param>
        /// <param name="args">the args that the message containes</param>
        public static void logln(string msg, params object[] args)
        {
            if (!EnableLog)
                return;

            Stream.WriteLine(msg, args);
        }

        /// <summary>
        /// log a normal message without any args ending with new line character
        /// </summary>
        /// <param name="msg">the message to be logged</param>
        public static void logln(string msg)
        {
            if (!EnableLog)
                return;

            Stream.WriteLine(msg);
        }

    }
}
