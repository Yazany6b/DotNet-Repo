using System;
using System.Collections.Generic;
using System.Text;

namespace Development.Utilities.Statics
{
    /// <summary>
    /// IOs class containes the most needed operations for files and directorys
    /// </summary>
    public static class IOs
    {
        /// <summary>
        /// Print a list of values to a file
        /// </summary>
        /// <param name="list">List to be saved</param>
        /// <param name="fileName">the filename to save the list to it</param>
        public static void WriteToFile<T>(System.Collections.Generic.List<T> list , string fileName)
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fileName);
            for (int i = 0; i < list.Count; i++)
                sw.WriteLine(list[i].ToString());
            sw.Close();
        }

        /// <summary>
        /// Print a list of arrays to a file
        /// </summary>
        /// <param name="list">List to be saved</param>
        /// <param name="lineValuesSeparator">The charater thats separate values of the array in each line</param>
        /// <param name="fileName">a file to save values to</param>
        public static void WriteToFile<T>(System.Collections.Generic.List<T[]> list, char lineValuesSeparator, string fileName)
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fileName);
            for (int i = 0; i < list.Count; i++)
            {

                for (int ii = 0; ii < list[i].Length; ii++)
                {
                    sw.Write(list[i][ii]);
                    sw.Write(lineValuesSeparator);
                }

                sw.WriteLine();
            }

            sw.Close();
        }


        /// <summary>
        /// Read saved values from file
        /// </summary>
        /// <param name="count">how many lines to read</param>
        /// <param name="offset">the index of the start line to begin reading from</param>
        /// <param name="lineValuesSeparator">character thats separate the values in ecah line</param>
        /// <param name="fileName">the file path to read the files from</param>
        /// <returns>return a list of string arrays that each one stores a line values</returns>
        public static List<string[]> ReadFromFile(int count, int offset, char lineValuesSeparator, string fileName)
        {
            List<string[]> values = new List<string[]>();
            System.IO.StreamReader reader = new System.IO.StreamReader(fileName);

            string line = "";
            int currentLine = 0;
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                if (currentLine >= offset && offset + count <= currentLine)
                {
                    values.Add(line.Split(lineValuesSeparator));
                }

                currentLine++;
            }

            reader.Close();

            return values;
        }

        /// <summary>
        /// Read saved values from file
        /// </summary>
        /// <param name="lineValuesSeparator">character thats separate the values in ecah line</param>
        /// <param name="fileName">the file path to read the files from</param>
        /// <returns>return a list of string arrays that each one stores a line values</returns>
        public static List<string[]> ReadFromFile(char lineValuesSeparator, string fileName)
        {
            List<string[]> values = new List<string[]>();
            System.IO.StreamReader reader = new System.IO.StreamReader(fileName);

            string line = "";
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                values.Add(line.Split(lineValuesSeparator));
            }

            reader.Close();

            return values;
        }

        /// <summary>
        /// Read a file an store it in an array of lines
        /// </summary>
        /// <param name="fileName">the file path ro read values from</param>
        /// <returns>an array of the lines that they were in the file</returns>
        public static string [] ReadFromFile(string fileName)
        {
            List<string> values = new List<string>();
            System.IO.StreamReader reader = new System.IO.StreamReader(fileName);

            while (!reader.EndOfStream)
            {
                values.Add(reader.ReadLine());
            }

            reader.Close();

            return values.ToArray();
        }
        
        /// <summary>
        /// Gets all directory contents both files and folders
        /// </summary>
        /// <param name="dicPath">the directory path</param>
        /// <returns>string array containes files and folders</returns>
        public static string[] GetDirectoryContent(string dicPath)
        {

            List<string> content = new List<string>();

            content.AddRange(System.IO.Directory.GetDirectories(dicPath));
            content.AddRange(System.IO.Directory.GetFiles(dicPath));

            return content.ToArray();
        }

        /// <summary>
        /// Gets wither the current path is a file path
        /// </summary>
        /// <param name="path">the path to be checked</param>
        /// <returns>true if its a file</returns>
        public static bool IsFile(string path)
        {
            return System.IO.File.Exists(path);
        }

        /// <summary>
        /// Gets wither the current path is a folder path
        /// </summary>
        /// <param name="path">the path to be checked</param>
        /// <returns>true if its a folder</returns>
        public static bool IsFolder(string path)
        {
            return System.IO.Directory.Exists(path);
        }

        /// <summary>
        /// Gets wither the current path is realy exists
        /// </summary>
        /// <param name="path">the path to be checked</param>
        /// <returns>true if its exist</returns>
        public static bool IsExist(string path)
        {
            return System.IO.File.Exists(path) || System.IO.Directory.Exists(path);
        }

        /// <summary>
        /// Get all connected usb floppy disks or usb flashs
        /// </summary>
        /// <returns>String array of all the devices names</returns>
        public static string[] GetAllUSBStorgeDevices()
        {
            List<string> usbs = new List<string>();

            System.IO.DriveInfo[] infos = System.IO.DriveInfo.GetDrives();

            foreach (System.IO.DriveInfo info in infos)
            {
                if (info.DriveType == System.IO.DriveType.Removable)
                {
                    usbs.Add(info.Name);
                }
            }

            return usbs.ToArray();
        }

        /// <summary>
        /// Join Files into one file
        /// </summary>
        /// <param name="files">string array of the files paths</param>
        /// <param name="destinationFile">the destiantion file that will containes all the files</param>
        /// <param name="destinationWritingMode">the mode of writting on destination</param>
        public static void JoinFiles(string[] files, string destinationFile , System.IO.FileMode destinationWritingMode)
        {
            const int READ_PER_TIME = 5 * 1024;

            byte [] buffer = new byte[READ_PER_TIME];
            System.IO.FileStream writer = new System.IO.FileStream(destinationFile,destinationWritingMode);

            foreach (string file in files)
            {

                System.IO.FileStream reader = new System.IO.FileStream(file,System.IO.FileMode.Open);

                int read = reader.Read(buffer, 0, READ_PER_TIME);
                while (read != 0)
                {
                    writer.Write(buffer, 0, read);
                    read = reader.Read(buffer, 0, READ_PER_TIME);
                }

                reader.Close();
            }

            writer.Close();
        }


        /// <summary>
        /// Join Files into one file
        /// </summary>
        /// <param name="files">string array of the files paths</param>
        /// <param name="destinationFile">the destiantion file that will containes all the files</param>
        /// <remarks> if destination file is exist it will be overwritten</remarks>
        public static void JoinFiles(string[] files, string destinationFile)
        {
            const int READ_PER_TIME = 5 * 1024;

            byte[] buffer = new byte[READ_PER_TIME];
            System.IO.FileStream writer = new System.IO.FileStream(destinationFile,System.IO.FileMode.OpenOrCreate);

            foreach (string file in files)
            {

                System.IO.FileStream reader = new System.IO.FileStream(file, System.IO.FileMode.Open);

                int read = reader.Read(buffer, 0, READ_PER_TIME);
                while (read != 0)
                {
                    writer.Write(buffer, 0, read);
                    read = reader.Read(buffer, 0, READ_PER_TIME);
                }

                reader.Close();
            }

            writer.Close();
        }


    }
}
