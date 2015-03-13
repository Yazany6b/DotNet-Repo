using System;
using System.Collections.Generic;
using System.Text;

namespace Development.Utilities.Statics
{
    /// <summary>
    /// Serializtion class conatines the serializtion needed operations to serialize or deserialize objects
    /// </summary>
    public static class Serializtion
    {
        /// <summary>
        /// Serialize an object to a file
        /// </summary>
        /// <param name="soures">the object to be serialized</param>
        /// <param name="fileName">the file to serialize to</param>
        /// <remarks>the soures object must be marked with the attribute System.Serializable</remarks>
        public static void Serialize(object soures, string fileName)
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            System.IO.Stream stream = System.IO.File.Open(fileName,System.IO.FileMode.OpenOrCreate);

            bf.Serialize(stream,soures);

            stream.Close();
        }

        /// <summary>
        /// Serialize an object from a file
        /// </summary>
        /// <param name="fileName">The file to be deserialized</param>
        /// <returns>the deserialized object</returns>
        public static object Deserialize(string fileName)
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            System.IO.Stream stream = System.IO.File.Open(fileName,System.IO.FileMode.Open);

            object dest = bf.Deserialize(stream);

            stream.Close();

            return dest;
        }

        /// <summary>
        /// Serialize an object to a file
        /// </summary>
        /// <param name="soures">the object to be serialized</param>
        /// <param name="stream">the stream to serialize the object to</param>
        /// <remarks>the soures object must be marked with the attribute System.Serializable</remarks>
        public static void Serialize(object soures, System.IO.Stream stream)
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            bf.Serialize(stream,soures);

            stream.Close();
        }

        /// <summary>
        /// Serialize an object from a file
        /// </summary>
        /// <param name="stream">The stream to be deserialized</param>
        /// <returns>the deserialized object</returns>
        public static object Deserialize(System.IO.Stream stream)
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            object dest = bf.Deserialize(stream);

            stream.Close();

            return dest;
        }
    }
}
