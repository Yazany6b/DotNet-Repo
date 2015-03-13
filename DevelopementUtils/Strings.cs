using System;
using System.Collections.Generic;
using System.Text;

namespace Development.Utilities.Statics
{
    /// <summary>
    /// Containes operations needed when dealing with strings
    /// </summary>
    public static class Strings
    {
        /// <summary>
        /// Get a string between to indexes
        /// </summary>
        /// <param name="text">the sub string source</param>
        /// <param name="start">the start index</param>
        /// <param name="end">the end index</param>
        /// <returns>the sub string</returns>
        public static string SubString(string text, int start, int end)
        {
            string temp = "";

            for (int i = start; i <= end; i++)
            {
                temp += text[i];
            }

            return temp;
        }

        /// <summary>
        /// Get a string from index to the end of the source text
        /// </summary>
        /// <param name="text">the sub string source</param>
        /// <param name="start">the start index</param>
        /// <returns>the sub string</returns>
        public static string SubString(string text, int start)
        {
            string temp = "";
            int end = text.Length - 1;

            for (int i = start; i <= end; i++)
            {
                temp += text[i];
            }

            return temp;
        }

        /// <summary>
        /// Get a string between to characters
        /// </summary>
        /// <param name="text">the sub string source</param>
        /// <param name="startChar">the start character</param>
        /// <param name="endChar">the end character</param>
        /// <returns>the sub string</returns>
        public static string SubString(char startChar, char endChar, string text)
        {
            string temp = "";
            bool skip = true;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == startChar || text[i] == endChar)
                {
                    skip = !skip;
                    continue;
                }
                if (skip)
                    continue;
                temp += text[i];
            }
            return temp;
        }


        /// <summary>
        /// gets the opposite of any brace
        /// </summary>
        /// <param name="brace">the brace to find it's opposite</param>
        /// <returns> Character </returns>
        public static char GetBraceOpposite(char brace)
        {
            if (brace == ')')
                return '(';
            else
                if (brace == '(')
                    return ')';

            if (brace == '}')
                return '{';
            else
                if (brace == '{')
                    return '}';

            if (brace == ']')
                return '[';
            else
                if (brace == '[')
                    return ']';
            return ' ';
        }

        /// <summary>
        /// Gets the close brace index in the source text
        /// </summary>
        /// <param name="brace">the open brace character</param>
        /// <param name="openBraceIndex">the brace index in the source text</param>
        /// <param name="text">the source text that will be searched</param>
        /// <returns>integer that conatines the close brace index of -1 if not exist</returns>
        public static int GetCloseBraceIndex(char brace, int openBraceIndex, string text)
        {
            int exist = 0;//close not found
            char ops = GetBraceOpposite(brace);

            for (int ii = openBraceIndex + 1; ii < text.Length; ii++)//each character in every line
            {
                if (text[ii] == brace)//another opened brace found
                    exist--;
                else
                    if (text[ii] == ops)//an close brace found
                        exist++;
                if (exist == 1)//the close brace has been found
                {
                    return ii;
                }
            }

            return -1;//no close
        }

        /// <summary>
        /// Gets the open brace index in the source text
        /// </summary>
        /// <param name="brace">the close brace character</param>
        /// <param name="closeBraceIndex">the brace index in the source text</param>
        /// <param name="text">the source text that will be searched</param>
        /// <returns>integer that conatines the open brace index of -1 if not exist</returns>
        public static int GetOpenBraceIndex(char brace, int closeBraceIndex, string text)
        {
            int exist = 0;//close not found
            char ops = GetBraceOpposite(brace);

            for (int ii = closeBraceIndex - 1; ii >= 0; ii--)//each character in every line
            {
                if (text[ii] == brace)//another opened brace found
                    exist--;
                else
                    if (text[ii] == ops)//an close brace found
                        exist++;
                if (exist == 1)//the close brace has been found
                {
                    return ii;
                }
            }

            return -1;//no close
        }
    }
}
