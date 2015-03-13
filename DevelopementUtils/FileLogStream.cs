
namespace Development.Utilities.Logging
{
    /// <summary>
    /// FileLogStream a stream that writes logs to a spacific file
    /// </summary>
    public class FileLogStream : LogStream
    {
        private System.IO.StreamWriter writer;

        /// <summary>
        /// Instantiat a new FileLogStream object with the file path
        /// </summary>
        /// <param name="filename">a file path to write the logs to</param>
        public FileLogStream(string filename)
        {
            writer = new System.IO.StreamWriter(filename);
        }

        /// <summary>
        /// print a log message from format
        /// </summary>
        /// <param name="msg">string format</param>
        /// <param name="args">the args that the message containes</param>
        public void Write(string msg, params object[] args)
        {
            writer.Write(msg, args);
        }

        /// <summary>
        /// log a normal message without any args
        /// </summary>
        /// <param name="msg">the message to be logged</param>
        public void Write(string msg)
        {
            writer.Write(msg);
        }

        /// <summary>
        /// log a format message ending the message by the new line character
        /// </summary>
        /// <param name="msg">the format message</param>
        /// <param name="args">the args that the message containes</param>
        public void WriteLine(string msg, params object[] args)
        {
            writer.WriteLine(msg, args);
        }

        /// <summary>
        /// log a normal message without any args ending the message by the new line character
        /// </summary>
        /// <param name="msg">the message to be logged</param>
        public void WriteLine(string msg)
        {
            writer.WriteLine(msg);
        }


    }
}
