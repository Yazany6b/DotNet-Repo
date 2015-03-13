using System;
using System.Collections.Generic;
using System.Text;

namespace Development.Utilities.Statics
{
    /// <summary>
    /// Containes needed when we dealing with units
    /// </summary>
    public static class Units
    {

        /// <summary>
        /// Represent the different sizes of to measure data 
        /// </summary>
        public enum Unit : long {
            /// <summary>
            /// Represents Kilo Byte Unit
            /// </summary>
            KB = 1024,
            /// <summary>
            /// Represents Mega Byte Unit
            /// </summary>
            MB = 1024 * 1024,
            /// <summary>
            /// Represents Giga Byte Unit
            /// </summary>
            GB = 1024 * 1024 * 1024
        };


        /// <summary>
        /// Converting from bytes to spacific unit
        /// </summary>
        /// <param name="bytes">the total count of bytes</param>
        /// <param name="unit">the unit to convert to</param>
        /// <returns>the new converted value</returns>
        public static long ToSize(long bytes,Unit unit)
        {
            return bytes / (long)unit;
        }

        /// <summary>
        /// Get the best string represention to thge current bytes;
        /// </summary>
        /// <param name="bytes">the total count of bytes</param>
        /// <returns>string represention of the bytes</returns>
        public static string ToString(long bytes)
        {
            if (IsKB(bytes))
                return (bytes / (long)Unit.KB) + "KB";

            if (IsMB(bytes))
                return (bytes / (long)Unit.MB) + "MB";

            if (IsGB(bytes))
                return (bytes / (long)Unit.GB ) + "GB";

            return bytes + "Byte";
        }

        /// <summary>
        /// Identify weather the current bytes is best measured by Mega Bytes (MB)
        /// </summary>
        /// <param name="bytes">the total count of bytes</param>
        /// <returns>weather is best to measure by MB</returns>
        public static bool IsMB(long bytes)
        {
            return (long)(bytes / (long)Unit.MB) > 0 && (long)(bytes / (long)Unit.MB) <= 1024;
        }

        /// <summary>
        /// Identify weather the current bytes is best measured by Kilo Bytes (KB)
        /// </summary>
        /// <param name="bytes">the total count of bytes</param>
        /// <returns>weather is best to measure by KB</returns>
        public static bool IsKB(long bytes)
        {
            return (long)(bytes / (long)Unit.KB) > 0 && (long)(bytes / (long)Unit.KB) <= 1024;
        }

        /// <summary>
        /// Identify weather the current bytes is best measured by Gega Bytes (GB)
        /// </summary>
        /// <param name="bytes">the total count of bytes</param>
        /// <returns>weather is best to measure by GB</returns>
        public static bool IsGB(long bytes)
        {
            return (long)(bytes / (long)Unit.GB) > 0 && (long)(bytes / (long)Unit.GB) <= 1024;
        }

        /// <summary>
        /// Convert the given seconds to the format of h:m:s
        /// </summary>
        /// <param name="seconds">the total count of seconds to convert</param>
        /// <returns>the represention of the seconds</returns>
        public static string TimeFromSeconds(long seconds)
        {
            int minutes = 0;
            int hours = 0;

            while (seconds > 59)
            {
                minutes++;
                seconds -= 60;

                while (minutes > 59)
                {
                    hours++;
                    minutes -= 60;
                }

            }

            return hours + ":" + minutes + ":" + seconds;
        }

        /// <summary>
        /// Convert the given minutes to the format of h:m:00
        /// </summary>
        /// <param name="minutes">the total count of minutes to convert</param>
        /// <returns>the represention of the minutes</returns>
        public static string TimeFromMinutes(long minutes)
        {
            int hours = 0;

            while (minutes > 59)
            {
                    hours++;
                    minutes -= 60;
            }

            return hours + ":" + minutes + ":00";
        }

        /// <summary>
        /// Splite a number of bytes into many splites
        /// </summary>
        /// <param name="bytes">the total bytes count</param>
        /// <param name="splites">the number of wanted splites</param>
        /// <returns>return each splite length</returns>
        public static long [] SplitUnit(long bytes, int splites)
        {
            List<long> sizes = new List<long>();

            long div = bytes / splites;

            while (splites > 0)
            {
                if (splites != 1)
                    bytes -= div;
                else
                {
                    div = bytes;
                    bytes = 0;
                }

                sizes.Add(div);

                splites--;
            }

            return sizes.ToArray();
        }

    }
}
