using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Readability_Test_Tool
{
    /// <summary>
    /// Findes all loops in a certian code
    /// </summary>
    public class LoopsFinder
    {
        
        System.Collections.Generic.Dictionary<int, LoopDetails> _loops;//stors all loops
        List<SwitchDetails> _switchs = new List<SwitchDetails>();
        List<IfDetails> _ifs = new List<IfDetails>();
        int _numberOfArrays = 0;
        string[] LinesWithComments;
        string[] Lines;//the code lines
        public LoopsFinder(String[] code,string [] linesWithComment)
        {
            _loops = new Dictionary<int, LoopDetails>();//initialize the list
            LinesWithComments = linesWithComment;
            Lines = code;
            try
            {
                for (int i = 0; i < Lines.Length; i++)
                    if (Lines[i].Contains('"'))
                        Lines[i] = Statics.ClearLineQuotations(Lines[i]);//remove any thing between quotations
                StartFinding();//start looking for any loops
                FindSwitchs();//find all switchs and ifs
                StartLookingForIFs();
            }
            catch (Exception e){ System.Windows.Forms.MessageBox.Show(e.StackTrace); }//the process code throw any exceptions 
        }


        private void FindIfs()
        {
            for (int i = 0; i < Lines.Length; i++)
            {
                if (Statics.HasIf(Lines[i]))
                {
                    IfDetails det = new IfDetails();
                    det.Code = Statics.Cut(i, GetIfEnd(i), ref LinesWithComments);
                    _ifs.Add(det);
                }
            }
        }
        private void FindSwitchs()
        {
            _numberOfArrays = 0;
            for (int i = 0; i < Lines.Length; i++)
            {
                if (Statics.HasSwitch(Lines[i]))
                {
                    SwitchDetails det = new SwitchDetails();
                    det.SwitchCode = Statics.Cut(i, GetSwitchEnd(i), ref LinesWithComments);
                    _switchs.Add(det);
                }
                if (Statics.HasArray(Lines[i]))
                {
                    _numberOfArrays++;
                }

            }
        }

        /// <summary>
        /// Start looking for loops
        /// </summary>
        private void StartFinding()
        {
            int num = 0;
            for (int i = 0; i < Lines.Length; i++)
            {
                if (Lines[i].Trim() != string.Empty)
                    if (Statics.HasFor(Lines[i]) || Statics.HasWhile(Lines[i]) || Statics.HasDo(Lines[i]))
                    {
                        LoopDetails loop = new LoopDetails();
                        num++;
                        int end = GetLoopEndLine(i);
                        loop.LoopCode = Statics.Cut(i, end, ref LinesWithComments);
                        i = end;
                        _loops.Add(num, loop);
                    }
            }
        }
        //The end of a do while
        private int GetDoWhileEnd(int doLine)
        {
            int exist = 0;
            for (int i = doLine; i < Lines.Length; i++)
            {
                if (Statics.HasDo(Lines[i]))
                {
                    exist--;
                }
                if (Statics.HasWhile(Lines[i]))
                {
                    exist++;
                }
                if (exist == 1)
                    return i;
            }
            return -1;
        }
        //the end of a loop
        private int GetLoopEndLine(int startLine)
        {
            int end = -1;
            for (int i = startLine; i < Lines.Length; i++)
            {
                string search = "";
                if (Statics.HasFor(Lines[i]))
                    search = "for";
                if (Statics.HasWhile(Lines[i]))
                    search = "while";
                if (Statics.HasFor(Lines[i]) || Statics.HasWhile(Lines[i]))
                {
                    int line = i;
                    int index = Statics.GetCloseBraceIndex('(', Lines[i].IndexOf('(', Lines[i].IndexOf(search) + (search.Length-1)), ref line,ref Lines);
                    char after = Statics.GetFirstCharacterAfterIndex(index, line, out line, out index,ref Lines);
                    if (after == '{')
                    {
                        index = Statics.GetCloseBraceIndex('{', index, ref line,ref Lines);
                        return line;
                    }
                    else
                    {
                        if (Statics.HasFor(Lines[i]) || Statics.HasWhile(Lines[i]))
                        {
                            if (Statics.HasWhile(Lines[i]))
                            {
                                int l = i;
                                int x = Statics.GetCloseBraceIndex('(', Lines[i].IndexOf('(', Lines[i].IndexOf("while")), ref l,ref Lines);
                                if (Statics.GetFirstCharacterAfterIndex(x, l, Lines) == ';')
                                    return l;
                            }
                            end = GetLoopEndLine(line);
                            break;
                        }
                        else
                            if (Statics.HasDo(Lines[i]))
                            {
                                end = GetDoWhileEnd(line);
                                break;
                            }
                            else
                                if (Statics.HasIf(Lines[i]))
                                {
                                    end = GetIfEnd(line);
                                    break;
                                }
                                else
                                    if (Statics.HasSwitch(Lines[i]))
                                    {
                                        end = GetSwitchEnd(line);
                                        break;
                                    }
                                    else
                                    {
                                        end = line;
                                        break;
                                    }
                    }
                }
                else
                    if (Statics.HasDo(Lines[i]))
                    {
                        if (Statics.HasWhile(Lines[i]))
                        {
                            return i;
                        }
                        else
                        {
                            end = GetDoWhileEnd(i + 1);
                        }
                        break;
                    }
            }
            return end;
        }
        //get else line of an if statement
        private int GetIfElseLine(int ifLine)
        {
            // System.Windows.Forms.MessageBox.Show("The Pairnt If " + Lines[ifLine], ifLine.ToString());
            int exist = 0;
            bool start = true;
            for (int i = ifLine; i < Lines.Length; i++)
            {
                if (Statics.HasIf(Lines[i]) && start && !(Statics.HasElse(Lines[i])))
                {
                    start = false;
                    continue;
                }
                if (Statics.HasIf(Lines[i]) && (Statics.HasElse(Lines[i])))
                {
                    if (start & Lines[i].IndexOf("else") > Lines[i].IndexOf("if"))
                    {
                        exist++;
                        if (exist == 1)
                            return i;
                        start = false;
                    }
                    else
                        if (Lines[i].IndexOf("else") < Lines[i].IndexOf("if") && !start)
                        {
                            exist++;
                            if (exist == 1)
                                return i;
                        }
                        else
                            if (Lines[i].IndexOf("else") < Lines[i].IndexOf("if") && start)
                            {
                                start = false;
                                continue;
                            }
                }
                else
                    if (Statics.HasElse(Lines[i]))
                        exist++;
                    else
                        if ((Statics.HasIf(Lines[i]) && !start))
                            exist--;
                if (exist == 1)
                    return i;
            }
            return -1;
        }
        //if end

        private bool isIfHasElse(int ifLine)
        {
            return (GetIfElseLine(ifLine) != -1);
        }
        private int GetIfEnd(int ifLine)
        {
            if (!isIfHasElse(ifLine))
            {
                int index, line = ifLine;
                index = Statics.GetCloseBraceIndex('(', Lines[ifLine].IndexOf('('), ref line,ref Lines);
                char after = Statics.GetFirstCharacterAfterIndex(index, line, out line, out index,ref Lines);
                if (after == '{')
                {
                    Statics.GetCloseBraceIndex('{', index, ref line,ref Lines);
                    return line;
                }
                else
                {
                    if (Statics.HasFor(Lines[line]) || Statics.HasDo(Lines[line]) || Statics.HasWhile(Lines[line]))
                    {
                        return GetLoopEndLine(line);
                    }
                    else
                        if (Statics.HasIf(Lines[line]))
                        {
                            return GetIfEnd(line);
                        }
                        else
                            if (Statics.HasSwitch(Lines[line]))
                            {
                                return GetSwitchEnd(line);
                            }
                            else
                            {
                                return GetColonIndexOfStatement(line);
                            }
                }

            }
            else
                return GetElseEndLine(ifLine);
        }
        private int GetElseIndex(int ifLine)
        {
            int elseIndex = -1;
            for (int i = ifLine + 1; i < Lines.Length; i++)
                if (Statics.HasElse(Lines[i]))
                {
                    elseIndex = i;
                    break;
                }
            return elseIndex;
        }
        private int GetElseEndLine(int ifLine)
        {
            int elseIndex = GetElseIndex(ifLine);
            if (elseIndex == -1)
                return ifLine;
            int index, line = elseIndex;
            index = Lines[elseIndex].IndexOf("else") + 3;
            char after = Statics.GetFirstCharacterAfterIndex(index, line, out line, out index,ref Lines);
            if (after == '{')
            {
                Statics.GetCloseBraceIndex('{', index, ref line,ref Lines);
                return line;
            }
            else
            {
                if (Statics.HasFor(Lines[line]) || Statics.HasDo(Lines[line]) || Statics.HasWhile(Lines[line]))
                {
                    return GetLoopEndLine(line);
                }
                else
                    if (Statics.HasIf(Lines[line]))
                    {
                        return GetIfEnd(line);
                    }
                    else
                        if (Statics.HasSwitch(Lines[line]))
                        {
                            return GetSwitchEnd(line);
                        }
                        else
                        {
                            return GetColonIndexOfStatement(line);
                        }
            }
        }
        private int GetColonIndexOfStatement(int statementLine)
        {
            if (Lines.Length == statementLine)
                return -1;
            if (Lines[statementLine].IndexOf(';') != -1)
                return statementLine;
            else
                return GetColonIndexOfStatement(statementLine + 1);
        }
        private void StartLookingForIFs()
        {
            for (int i = 0; i < Lines.Length; i++)
                Lines[i] = Lines[i].Trim();
            for (int i = 0; i < Lines.Length; i++)
            {
                if (Statics.HasIf(Lines[i]))
                {
                    IfDetails det = new IfDetails();
                    int end = GetIfEnd(i);
                    det.Code = Statics.Cut(i,end, ref LinesWithComments);
                    _ifs.Add(det);
                    i = end-1;
                    continue;
                }
            }
        }

        //
        //get switch end
        private int GetSwitchEnd(int switchLine)
        {
            int open = Lines[switchLine].IndexOf('(', Lines[switchLine].IndexOf("switch"));
            int cline = switchLine;
            int close = Statics.GetCloseBraceIndex('(', open, ref cline,ref Lines);
            Statics.GetFirstCharacterAfterIndex(close, cline, out cline, out close,ref Lines);
            close = Statics.GetCloseBraceIndex('{', close, ref cline,ref Lines);
            return cline;//the switch end line
        }

        private void GetLoopCode(ref LoopDetails loop)
        {
            string[] code = null;//the code of the is null at the start
            if (loop.ScopeStartLine == loop.ScopeEndLine)//the loop code only one line
            {
                code = new string[1];//one line code
                code[0] = Lines[loop.ScopeStartLine].Substring(loop.StartBraceIndex, loop.EndBraceIndex - loop.StartBraceIndex + 1);
            }
            else
            {
                if (loop.ScopeEndLine > loop.ScopeStartLine)//multiline code
                {
                    code = new string[(loop.ScopeEndLine - loop.ScopeStartLine + 1)];//set code lines length
                    int index = 0;
                    for (int i = loop.ScopeStartLine; i <= loop.ScopeEndLine; i++, index++)//fill each line with code
                    {
                        if (i == loop.ScopeStartLine)//set the first line code from the start index in the lint to the end of the line
                            code[index] = Lines[i].Substring(loop.StartBraceIndex + 1, Lines[i].Length - (loop.StartBraceIndex + 1));
                        else
                            if (i == loop.ScopeEndLine)//set the last line code from index 0 to the end index
                                code[index] = Lines[i].Substring(0, loop.EndBraceIndex);
                            else
                                code[index] = Lines[i];//set the whole line as a code
                    }
                }
                else//the end index is list the start index and this only happend if the close brace of a loop that has
                //an opened prace is not exist
                {
                    //aware the user to the error
                    System.Windows.Forms.MessageBox.Show("The Close Brace Of The Function ( " + loop.ScopeStartLine.ToString() + " ) Are Not Fount \nPlease Fix The Error And Reimport The File", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                    code = null;//no code will be filled
                }
            }
            loop.LoopCode = code;//the sent loop code
        }

        //gets the index and the line index that contains a comment close characher
        private int GetCommentCloseIndex(int atLine, out int line, string[] arr)
        {
            for (int i = atLine; i < arr.Length; i++)
            {
                if (arr[i].Contains("*/"))//containes the close
                {
                    line = i;
                    return arr[i].IndexOf("*/");//return the index
                }
            }
            line = 0;
            return 0;
        }

        private void ClearLongComments()
        {
            for (int i = 0; i < Lines.Length; i++)
            {
                if (Lines[i].Contains("/*") && !Lines[i].Contains("*/"))
                {
                    int close;
                    int index = GetCommentCloseIndex(i, out close, Lines);
                    if (index == -1)
                        return;
                    for (int x = i; x < close; x++)
                        Lines[x] = string.Empty;
                    i = close + 1;
                }
                else
                {
                    if (Lines[i].Contains("/*") && Lines[i].Contains("*/"))
                    {
                        string temp = Lines[i];
                        string com = "";
                        while (temp.Contains("/*") && temp.Contains("*/"))
                        {
                            com += Statics.SubString(temp.IndexOf("/*") + 2, temp.IndexOf("*/") - 1, temp) + " ";
                            temp = Statics.SubString(0, temp.IndexOf("/*") - 1, temp) + Statics.SubString(temp.IndexOf("*/") + 2, temp.Length - 1, temp);
                        }

                        Lines[i] = temp;
                    }
                }
            }
        }
        //remove all comments and keep only code lines
        private void ClearComments(string[] lines)
        {
            Lines = new string[lines.Length];//set the lines of code in the memory
            for (int i = 0; i < Lines.Length; i++)
            {
                Lines[i] = lines[i].Trim();//remove tail spaces
                if (Lines[i].Trim().StartsWith("//"))//line start with //
                {
                    Lines[i] = string.Empty;//remove line
                }
                else
                    if (Lines[i].Contains("//") && !Lines[i].Trim().EndsWith("//"))//line containes //
                    {
                        Lines[i] = Statics.SubString(0, lines[i].IndexOf("//") - 1, lines[i]);//removr every thing after //
                    }
            }
            ClearLongComments();
        }

        //this only for the code developer to check if the code is performing normally
        public string Report()
        {
            string Text = "";
            int c = 0;
            for (int i = 0; i < _loops.Count; i++)
            {
                if (_loops[i + 1].LoopCode != null)
                {
                    if (_loops[i + 1].NestedLoop)
                        c++;
                    for (int ii = 0; ii < _loops[i + 1].LoopCode.Length; ii++)
                    {
                        Text += _loops[i + 1].LoopCode[ii] + "\r\n";
                    }
                    Text += "\r\n{{{LoopType " + _loops[i + 1].LoopType.ToString() + "   And   " + _loops[i + 1].NestedLoop.ToString() + "}}}\r\n";
                    Text += "---------------------------------------\r\n";
                }

            }
            return Text;
        }


        public int ComputeNumberOfIFS()
        {
            int count = 0;
            for (int i = 0; i < _ifs.Count; i++)
                count += _ifs[i].NumberOfIfs;
            return count;
        }

        private int MaxNestedIfCode()
        {
            List<IfDetails> temp = new List<IfDetails>();
            for (int i = 0; i < _ifs.Count; i++)
                if (_ifs[i].IsNested)
                {
                    temp.Add(_ifs[i]);
                }
            if (temp.Count > 0)
            {
                int max = 0;
                int count = 0;
                for (int i = 0; i < temp.Count; i++)
                {
                    count = temp[i].NumberOfIfs;
                    if (max < count)
                        max = count;
                }
                return max-1;
            }
            return 0;
        }
        /// <summary>
        /// Gets the readability result of the code nested loops
        /// </summary>
        public LoopsReport ReadabilityOfTheNestedLoops
        {
            get { return LoopDetails.ReadabilityResulte(_loops); }
        }

        public Dictionary<int, LoopDetails> Loops
        {
            get { return _loops; }
        }

        public List<SwitchDetails> Switchs
        {
            get { return _switchs; }
        }

        public int NumberOfArrays
        {
            get { return _numberOfArrays; }
        }
        public int NumberOfIfElse
        {
            get { return ComputeNumberOfIFS(); }
        }
        public List<IfDetails> IfElse
        {
            get { return _ifs; }
        }

        public int MaxNested
        {
            get { return MaxNestedIfCode() ; }
        }

    }
}
