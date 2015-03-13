
namespace Development.Utilities.Logging
{
    /// <summary>
    /// An interface should be implemeted for developing a new log stream
    /// </summary>
    public interface LogStream
    {
        /// <summary>
        /// log a format message
        /// </summary>
        /// <param name="msg">the format message</param>
        /// <param name="args">the args that the message containes</param>
        void Write(string msg, params object[] args);


        /// <summary>
        /// log a normal message without any args
        /// </summary>
        /// <param name="msg">the message to be logged</param>
        void Write(string msg);

        /// <summary>
        /// log a format message ending the message by the new line character
        /// </summary>
        /// <param name="msg">the format message</param>
        /// <param name="args">the args that the message containes</param>
        void WriteLine(string msg, params object[] args);

        /// <summary>
        /// log a normal message without any args ending the message by the new line character
        /// </summary>
        /// <param name="msg">the message to be logged</param>
        void WriteLine(string msg);
    }
}
