
namespace Development.Utilities.Logging
{
    /// <summary>
    /// ConsoleLogStream a stream that writes logs to the application console
    /// </summary>
    public class ConsoleLogStream : LogStream
    {
        /// <summary>
        /// print a log message from format
        /// </summary>
        /// <param name="msg">string format</param>
        /// <param name="args">the args that the message containes</param>
        public void Write(string msg, params object[] args)
        {
            System.Console.Write(msg,args);
        }

        /// <summary>
        /// log a normal message without any args
        /// </summary>
        /// <param name="msg">the message to be logged</param>
        public void Write(string msg)
        {
            System.Console.Write(msg);
        }

        /// <summary>
        /// log a format message ending the message by the new line character
        /// </summary>
        /// <param name="msg">the format message</param>
        /// <param name="args">the args that the message containes</param>
        public void WriteLine(string msg, params object[] args)
        {
            System.Console.WriteLine(msg, args);
        }

        /// <summary>
        /// log a normal message without any args ending the message by the new line character
        /// </summary>
        /// <param name="msg">the message to be logged</param>
        public void WriteLine(string msg)
        {
            System.Console.WriteLine(msg);
        }
    }
}
