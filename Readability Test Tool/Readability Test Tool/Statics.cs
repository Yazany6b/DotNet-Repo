using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Readability_Test_Tool
{
    public static class Statics
    {


        #region Messages


        private static Dictionary<int, string> _messages = new Dictionary<int, string>();
        public static void FromulateMassege(int key, string value)
        {
            _messages.Add(key, value);
        }

        public static bool EnableMessages
        {
            get;
            set;
        }

        public static Dictionary<int, string> Messages
        {
            get { return _messages; }
        }

        #endregion

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

        public static int ComputeAllCodeLines(string[] code)
        {
            int count = 0;
            for (int i = 1; i < code.Length - 1; i++)
            {
                if (code[i].Trim() != "{" && code[i].Trim() != string.Empty && code[i].Trim() != "}")
                    count++;
            }
            return count;
        }

        public static List<type> RemovedDuplicate<type>(List<type> list)
        {
            List<type> temp = new List<type>();
            for (int i = 0; i < list.Count; i++)
                if (!temp.Contains(list[i]))
                    temp.Add(list[i]);
            return temp;
        }


        /// <summary>
        /// cut a part of code
        /// </summary>
        /// <param name="start"> start index</param>
        /// <param name="end">end index</param>
        /// <param name="lines">An array of code to cut from</param>
        /// <returns>the cut code</returns>
        public static string[] Cut(int start, int end, ref string[] lines)
        {
            string[] arr = new string[(end - start) + 1];
            int index = 0;
            for (int i = start; i <= end; i++, index++)
            {
                arr[i - start] = lines[i];
            }
            return arr;
        }

        public static int NumberOfRepation(List<string> words, string word)
        {
            int count = 0;
            for (int i = 0; i < words.Count; i++)
                if (words[i] == word)
                    count++;
            return count;
        }

        public static int HowMuchExist(string keyword, string text)
        {
            int count = 0;
            int startIndex = 0;
            int index = text.IndexOf(keyword, startIndex);
            bool validBefore = false;
            bool validAfter = false;
            while (index != -1)
            {
                if (index == 0)
                    validBefore = true;
                else
                {
                    if (Statics.isAttachableIdentifierSymbol(text[index - 1]))
                        validBefore = true;
                    else
                        validBefore = false;
                }
                if (index + keyword.Length == text.Length)
                    validAfter = true;
                else
                {
                    if (Statics.isAttachableIdentifierSymbol(text[index + keyword.Length]))
                        validAfter = true;
                    else
                        validAfter = false;
                }
                if (validAfter && validBefore)
                    count++;
                if (index + 1 == text.Length)
                    break;
                startIndex = index + 1;
                index = text.IndexOf(keyword, startIndex);
            }
            return count;
        }


        public static bool AnyCharactersBetween(int first, int second, string line, char forbiddenCharacter)
        {
            bool any = false;
            for (int i = first; i < second; i++)
            {
                if (line[i] != ' ' && line[i] != forbiddenCharacter)
                {
                    any = true;
                    break;
                }
                else
                    any = false;
                if (line[i] == forbiddenCharacter)
                    break;
            }
            return any;
        }

        public static int FirstChatacter(string line)
        {
            for (int i = 0; i < line.Length; i++)
                if (!char.IsWhiteSpace(line[i]))
                {
                    return i;
                }
            return -1;
        }
        public static int IndexOfLoop(string[] code, int start)
        {
            for (int i = start; i < code.Length; i++)
                if (Statics.HasFor(code[i]) || Statics.HasWhile(code[i]) || Statics.HasDo(code[i]))
                {
                    return i;
                }
            return -1;
        }
        public static int IndexOfIF(string[] code, int start)
        {
            for (int i = start; i < code.Length; i++)
                if (Statics.HasIf(code[i]) || Statics.HasElse(code[i]))
                {
                    return i;
                }
            return -1;
        }
        public static bool HasIndent(string line)
        {
            if (line.Length > line.TrimStart(new char[] { ' ' }).Length)
                return true;
            return false;
        }
        public static bool isSymbol(char sym)
        {
            if (sym == '[')
                return true;
            if (sym == ']')
                return true;
            if (sym == '(')
                return true;
            if (sym == ')')
                return true;
            if (sym == '}')
                return true;
            if (sym == '{')
                return true;
            if (sym == '.')
                return true;
            if (sym == '*')
                return true;
            if (sym == '+')
                return true;
            if (sym == '-')
                return true;
            if (sym == '/')
                return true;
            if (sym == '&')
                return true;
            if (sym == '!')
                return true;
            if (sym == '#')
                return true;
            if (sym == '^')
                return true;
            if (sym == '@')
                return true;
            if (sym == '~')
                return true;
            if (sym == '%')
                return true;
            if (sym == '>')
                return true;
            if (sym == '<')
                return true;
            if (sym == '"')
                return true;
            if (sym == '\'')
                return true;
            return false;
        }
        public static bool IsAcceptableName(string name)
        {
            name = name.Trim();
            for (int i = 0; i < name.Length; i++)
                if (isSymbol(name[i]))
                    return false;
            if (ResevedWord(name))
                return false;
            if (name.Length == 0)
                return false;
            return true;
        }
        public static bool isAttachableIdentifierSymbol(char sym)
        {
            if (sym == '[')
                return true;
            if (sym == ']')
                return true;
            if (sym == '(')
                return true;
            if (sym == ')')
                return true;
            if (sym == '}')
                return true;
            if (sym == '{')
                return true;
            if (sym == '.')
                return true;
            if (sym == '*')
                return true;
            if (sym == '+')
                return true;
            if (sym == '-')
                return true;
            if (sym == '/')
                return true;
            if (sym == '&')
                return true;
            if (sym == '!')
                return true;
            if (sym == '=')
                return true;
            if (sym == ';')
                return true;
            if (sym == ',')
                return true;
            if (sym == '>')
                return true;
            if (sym == '<')
                return true;
            if (sym == ' ')
                return true;
            return false;
        }
        //datatype any name do not containes symbols
        public static bool isUserDataType(string type)
        {
            if (type.Contains(' '))
                return false;
            if (type.Contains('.'))
                return false;
            if (type.Contains('*'))
                return false;
            if (type.Contains('-'))
                return false;
            if (type.Contains('/'))
                return false;
            if (type.Contains('+'))
                return false;
            if (type.Contains('"'))
                return false;
            if (type.Contains('('))
                return false;
            if (type.Contains(')'))
                return false;
            if (type.Contains('{'))
                return false;
            if (type.Contains('}'))
                return false;
            return true;
        }
        //words could added to any function
        public static bool isFunctionModifier(string word)
        {
            word = word.Trim();
            return (word == "static" || word == "virtual" || word == "override");
        }
        public static bool isAccessModifier(string word)
        {
            word = word.Trim();
            return (word == "private" || word == "public" || word == "protected");
        }
        public static bool ResevedWord(string word)
        {
            word = word.Trim();
            if (word == "void" || word == "this" || word == "false" || word == "true" || word == "while" || word == "for" || word == "import" || word == "if" || word == "else" || word == "do" || word == "class" || word == "return" || word == "new" || isAccessModifier(word))
                return true;
            else
                return false;
        }
        public static bool isDataType(string word)
        {
            word = word.Trim();
            return (word == "void" || word == "int" || word == "char" || word == "float" || word == "double" || word == "var" || isUserDataType(word));
        }

        public static bool isIdentifierDatatype(string word)
        {
            word = word.Trim();
            if (word == string.Empty)
                return false;
            if (ResevedWord(word))
                return false;
            return (word == "int" || word == "char" || word == "float" || word == "double" || word == "var" || isUserDataType(word));
        }


        /// <summary>
        /// gets the opposite of any brace
        /// </summary>
        /// <param name="brace"></param>
        /// <returns> Character </returns>
        public static char GetBraceOps(char brace)
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
        //get the close index of an opened brace
        public static int GetCloseBraceIndex(char brace, int openBraceIndex, string line)
        {
            int exist = 0;//close not found
            int index = openBraceIndex;//start index
            for (int ii = index + 1; ii < line.Length; ii++)//each character in every line
            {
                if (line[ii] == brace)//another opened brace found
                    exist--;
                else
                    if (line[ii] == GetBraceOps(brace))//an close brace found
                        exist++;
                if (exist == 1)//the close brace has been found
                {
                    return ii;
                }
            }
            return -1;//no close
        }
        //get the close index of an opend brace
        public static int GetCloseBraceIndex(char brace, int openBraceIndex, ref int openBraceLine, ref string[] array)
        {
            int exist = 0;//close not found
            int index = openBraceIndex+1;//start index
            for (int i = openBraceLine; i < array.Length; i++)//all lines
            {
                for (int ii = index; ii < array[i].Length; ii++)//each character in every line
                {
                    if (array[i][ii] == brace)//another opened brace found
                        exist--;
                    else
                        if (array[i][ii] == GetBraceOps(brace))//an close brace found
                            exist++;
                    if (exist == 1)//the close brace has been found
                    {
                        openBraceLine = i;
                        return ii;
                    }
                }
                index = 0;
            }
            return -1;//no close
        }

        // get the function name from the function header
        public static int GetCommentCloseIndex(int atLine, out int line, string[] arr)
        {
            for (int i = atLine; i < arr.Length; i++)
            {
                if (arr[i].Contains("*/"))
                {
                    line = i;
                    return arr[i].IndexOf("*/");
                }
            }
            line = 0;
            return 0;
        }
        public static bool IsMeaningfulList(List<string> words)
        {
            foreach (string x in words)
                if (!Search.isWordMeaningfull(x))
                    return false;
            return true;
        }
        public static string RemoveNamingStaff(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                try
                {
                    if (text[i] == '[')
                        text = SubString(0, i - 1, text) + SubString(i + 1, text.Length, text);
                    if (text[i] == ']')
                        text = SubString(0, i - 1, text) + SubString(i + 1, text.Length, text);
                    if (text[i] == '_')
                        text = SubString(0, i - 1, text) + SubString(i + 1, text.Length, text);
                }
                catch { }

            }
            return text;
        }

        public static string SubString(int from, int to, string text)
        {
            string temp = string.Empty;
            if (to >= text.Length)
                to = text.Length - 1;
            if (to == -1 || from == -1)
                return string.Empty;
            for (int i = from; i <= to; i++)
            {
                temp += text[i];
            }
            return temp;
        }
        public static char GetFirstCharacterAfterIndex(int index, string line)
        {
            index++;
            for (int ii = index; ii < line.Length; ii++)
            {
                if (line[ii] != ' ')
                {
                    return line[ii];
                }
            }
            index = 0;
            return ' ';//no character exist
        }


        /// <summary>
        /// gets the first chartacter that comes after a certine index
        /// </summary>
        /// <param name="index">the index of character to get the first character after it</param>
        /// 
        /// <param name="line">the code line that containes the index</param>
        /// 
        /// <param name="characterLine">the character after code line</param>
        /// <param name="characterIndex">the found character index</param>
        /// <returns>returns the found character</returns>
        public static char GetFirstCharacterAfterIndex(int index, int line, out int characterLine, out int characterIndex,ref string [] Lines)
        {
            characterLine = 0;
            characterIndex = 0;
            index++;//start from the next index
            for (int i = line; i < Lines.Length; i++)
            {
                for (int ii = index; ii < Lines[i].Length; ii++)
                {
                    if (Lines[i][ii] != ' ')//if first next thing after the index is not space the it's a target
                    {
                        characterIndex = ii;
                        characterLine = i;
                        return Lines[i][ii];//return the non-space character
                    }
                }
                index = 0;//the first index of any line except the first one
            }
            return ' ';//no character exist
        }


        /// <summary>
        /// gets the first chartacter that comes after a certine index
        /// </summary>
        /// <param name="index">the index of character to get the first character after it</param>
        /// 
        /// <param name="line">the code line that containes the index</param>
        /// <param name="array">The array that contains the code</param>
        /// <returns>returns the found character</returns>
        public static char GetFirstCharacterAfterIndex(int index, int line, string[] array)
        {
            index++;
            for (int i = line; i < array.Length; i++)
            {
                for (int ii = index; ii < array[i].Length; ii++)
                {
                    if (array[i][ii] != ' ')
                    {
                        return array[i][ii];
                    }
                }
                index = 0;
            }
            return ' ';//no character exist
        }

        public static char GetFirstCharacterBeforeIndex(int index, int line, string[] array)
        {
            index--;
            for (int i = line; i < array.Length; i++)
            {
                for (int ii = index; ii > -1; ii--)
                {
                    if (array[i][ii] != ' ')
                    {
                        return array[i][ii];
                    }
                }
                index = 0;
            }
            return ' ';//no character exist
        }

        public static int[] SortAscending(int[] array)
        {
            var sorter = from a in array orderby a ascending select a;
            return sorter.ToArray<int>();
        }

        public static double Median(int[] list)
        {
            double median = 0.0;
            list = SortAscending(list);
            if (list.Length % 2 == 0)
            {
                median = (double)(list[list.Length / 2] + list[(list.Length / 2) - 1]) / 2.0;
            }
            else
            {
                median = (double)(list[(list.Length / 2)]);
            }
            return median;
        }

        //remove all quotation from code
        public static string ClearLineQuotations(string line)
        {
            int index;
            int index2;
            for (; ; )
            {
                if (line.Contains('"'))//line hase quotations
                {
                    index = line.IndexOf('"');
                    index2 = Statics.GetCloseQuotationIndex(index, line);
                    if (index == 0 && index2 == line.Length - 1)
                        line = string.Empty;
                    else
                        if (index2 != 0)
                            line = line.Substring(0, index - 1) + line.Substring(index2 + 1);
                        else
                            break;
                    //MessageBox.Show(line);
                }
                else
                    break;//no quotation still
            }
            return line;//return the line without any quotations
        }

        //get the end of the quotation
        public static int GetCloseQuotationIndex(int openIndex, string line)
        {
            for (int ii = openIndex + 1; ii < line.Length; ii++)
                if (line[ii] == '"')
                {
                    return ii;
                }
            return 0;
        }

        public static List<string> NameContant(string name)
        {

            List<string> temp = new List<string>();
            if (name.Contains('_'))
            {
                string[] arr = name.Split('_');
                for (int i = 0; i < arr.Length; i++)
                    if (!temp.Contains(arr[i]))
                        temp.Add(RemoveNamingStaff(arr[i]));
                return temp;
            }
            bool hasupper = false;
            if (name.Contains('[') || name.Contains(']'))
                name = RemoveNamingStaff(name).Trim();
            for (int i = 0; i < name.Length; i++)
            {
                if (char.IsUpper(name[i]))
                {
                    hasupper = true;
                    if (!temp.Contains(SubString(0, i, name)) && i != 0)
                        temp.Add(SubString(0, i - 1, name));
                    name = SubString(i, name.Length - 1, name).Trim();
                }
            }
            if (!hasupper)
                temp.Add(name.Trim());
            return temp;
        }
        public static void PrintList<type>(List<type> list)
        {
            string tem = "";
            for (int i = 0; i < list.Count; i++)
            {
                tem += list[i] + "\r\n";
            }
            System.Windows.Forms.MessageBox.Show(tem, "list");
        }
        public static string StringList<type>(List<type> list)
        {
            if (list.Count == 0)
                return "Nothing Exist";
            string tem = "";
            for (int i = 0; i < list.Count; i++)
            {
                tem += list[i] + "\r\n";
            }
            return tem;
        }
        public static void PrintListArray<type>(List<type[]> list)
        {
            string tem = "";
            for (int i = 0; i < list.Count; i++)
            {
                tem += "----------------------------------" + "\r\n";
                for (int ii = 0; ii < list[i].Length; ii++)
                {

                    tem += list[i][ii] + "\r\n";

                }
                tem += "----------------------------------" + "\r\n";
            }
            System.Windows.Forms.MessageBox.Show(tem, "list");
        }
        public static void PrintArray<type>(type[] list)
        {
            string tem = "";
            for (int i = 0; i < list.Length; i++)
            {
                tem += list[i] + "\r\n";
            }
            System.Windows.Forms.MessageBox.Show(tem, "list");
        }
        public static string StringArray<type>(type[] list)
        {
            if (list.Length == 0)
                return "Nothing Exist";
            string tem = "";
            for (int i = 0; i < list.Length; i++)
            {
                tem += list[i] + "\r\n";
            }
            return tem;
        }
        public static void PrintDictionary<keyType, valueType>(Dictionary<keyType, valueType> dic)
        {
            string tem = "";
            for (int i = 0; i < dic.Count; i++)
            {
                tem += dic.ElementAt(i).Key + "   -   " + dic.ElementAt(i).Value.ToString() + "\r\n";
            }
            System.Windows.Forms.MessageBox.Show(tem, "Dictionary");
        }


        public static bool HasFor(string line)//the line has for statement
        {
            return (line.Contains("for ") || line.Contains("for("));
        }
        public static bool HasWhile(string line)
        {
            return ((line.Contains("while ") || line.Contains("while(")));
        }
        public static bool HasDo(string line)
        {
            return (line.Contains("do ") || line.Contains("do{") || (line.Contains("do") && line.Length == line.IndexOf("do") + 2) || (line.IndexOf("do") == 0 && line.Length == 2));
        }
        public static bool HasIf(string line)
        {
            return ((line.Contains("if ") && line.Trim().StartsWith("if")) || (line.Contains("if(") && line.Trim().StartsWith("if")) || line.Trim().Contains(" if ") || line.Trim().Contains(" if("));
        }
        public static bool HasElse(string line)
        {
            return (line.Contains("else ") || line.Contains("else{") || (line.Contains("else") && line.Length == line.IndexOf("else") + 4));
        }
        public static bool HasElse(string line,int startIndex)
        {
            return ((line.IndexOf("else ", startIndex) != -1) || (line.IndexOf("else{", startIndex) != -1) || ((line.IndexOf("else", startIndex) != -1) && line.Length == line.IndexOf("else") + 4));
        }
        public static bool HasSwitch(string line)
        {
            return (line.Contains("switch ") || line.Contains("switch("));
        }

        public static bool HasArray(string line)
        {
            if (line.Contains("[]"))
            {
                return true;
            }
            if (line.Contains('['))
                if (Statics.GetFirstCharacterAfterIndex(line.IndexOf('['), line) == ']')
                    return true;

            return false;
        }

        public static bool HasClass(string line)
        {
            line = line.Trim();
            return (line.Contains(" class ") || (line.Contains("class ") && line.IndexOf("class") == 0));
        }


        public static string Remove(char startChar, char endChar, string text)
        {
            string temp = "";
            bool skip = false;
            for (int i = 0; i < text.Length; i++)
            {
                if ((text[i] == startChar && !skip) || text[i] == endChar)
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

        public static string Remove(int start, int end, string text)
        {
            string temp = "";
            bool skip = false;
            for (int i = 0; i < text.Length; i++)
            {
                if (i == start || i == end)
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

        private static bool Equal(string keyword, int start, string text)
        {
            if (start + keyword.Length + 1 >= text.Length)
                return false;
            for (int i = start; i < (keyword.Length + start); i++)
                if (keyword[i - start] != text[i])
                    return false;
            return true;
        }


        public static string Remove(string start, string text)
        {
            string temp = "";
            bool skip = false;
            for (int i = 0; i < text.Length; i++)
            {
                if (start[0] == text[i] || text[i] == '\n')
                    if ((Equal(start, i, text) && !skip) || text[i] == '\n')
                    {
                        if (text[i] == '\n' && !skip)
                        {
                            //do nothing
                        }
                        else
                        {
                            if (skip)
                                temp += "\r\n";
                            skip = !skip;
                            continue;
                        }
                    }
                if (skip)
                    continue;
                temp += text[i];
            }
            return temp;
        }

        public static string Remove(string start, string end, string text)
        {
            string temp = "";
            bool skip = false;
            for (int i = 0; i < text.Length; i++)
            {
                if (start[0] == text[i] || end[0] == text[i])
                    if ((Equal(start, i, text) && !skip) || Equal(end, i, text))
                    {
                        skip = !skip;
                        if (Equal(end, i, text))
                        {
                            i--;
                            i += end.Length;
                        }
                        continue;
                    }
                if (skip)
                    continue;
                temp += text[i];
            }
            return temp;
        }

        public static string Remove(string start, string end, string addAfterEachRemove, string text)
        {
            string temp = "";
            bool skip = false;
            for (int i = 0; i < text.Length; i++)
            {
                if (start[0] == text[i] || end[0] == text[i])
                    if ((Equal(start, i, text) && !skip) || Equal(end, i, text))
                    {
                        skip = !skip;
                        if (Equal(end, i, text))
                        {
                            i--;
                            i += end.Length;
                            temp += addAfterEachRemove;
                        }
                        continue;
                    }
                if (skip)
                    continue;
                temp += text[i];
            }
            return temp;
        }


        public static void SetColor(char startChar, char endChar, ref System.Windows.Forms.RichTextBox textArea, System.Drawing.Color color)
        {

            int start = 0;
            int length = 0;
            bool skip = false;
            for (int i = 0; i < textArea.Text.Length; i++)
            {
                if ((textArea.Text[i] == startChar && !skip) || textArea.Text[i] == endChar)
                {
                    if (!skip)
                        start = i;
                    length++;
                    skip = !skip;
                    continue;
                }
                if (skip)
                {
                    length++;
                    continue;
                }
                textArea.SelectionStart = start;
                textArea.SelectionLength = length;
                textArea.SelectionColor = color;
                start = 0;
                length = 0;
            }
        }
        
        public static void SetColor(string start, string end, ref System.Windows.Forms.RichTextBox textArea, System.Drawing.Color color)
        {
            int st = 0;
            int length = 0;
            bool skip = false;
            for (int i = 0; i < textArea.Text.Length; i++)
            {
                if (start[0] == textArea.Text[i] || end[0] == textArea.Text[i])
                    if ((Equal(start, i, textArea.Text) && !skip) || Equal(end, i, textArea.Text))
                    {
                        if (!skip)
                            st = i;
                        if (skip)
                        {
                            i--;
                            i += end.Length;
                            length--;
                            length += end.Length;
                        }
                        skip = !skip;
                        continue;
                    }
                if (skip)
                {
                    length++;
                    continue;
                }
                textArea.SelectionStart = st;
                textArea.SelectionLength = length;
                textArea.SelectionColor = color;
                st = 0;
                length = 0;
            }
        }

    }
}
