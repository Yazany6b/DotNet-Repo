using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Readability_Test_Tool
{
    /// <summary>
    /// Containes all informations of any code
    /// </summary>
    public class CodeDetails
    {

        #region Variables Decleartions


        private string[] Lines;
        private string[] LinesWithComments;
        private int[] arr;
        private int[] identifiersOccurance;
        private LoopsFinder _loops;
        private int _functionsCount = 0;
        private int _numberOfInheritance = 0;
        private int _numberOfArithmaticFormuls = 0;
        private int _numberOfRecursiveFunctions = 0;
        private int _numberOfStaticFunctions = 0;
        private int _numberOfComments = 0;
        private int _numberOfClasses = 0;
        private int _numberOfCodeWithComment = 0;
        private int _numberOfCodeWithoutComment = 0;
        private int _numberOfBlankLines = 0;
        private int _numberOfBlankLinesOfFunction = 0;
        private int _numberOfBlankLinesOfClasses = 0;
        private int _lengthOfAllLines = 0;
        private int _maxLinelength = 0;
        private int _numberOfIndents = 0;
        private int _numberOfCommas = 0;
        private int _numberOfScopes = 0;
        private int _numberOfPolymorphism = 0;
        private int _numberOfLoopsAndIfs = 0;
        private int _codeVolume = 0;

        private Dictionary<int, FunctionDetails> _functionsAndScopes = new Dictionary<int, FunctionDetails>();
        private Dictionary<string, int> _meaningfull = new Dictionary<string, int>();
        private List<string> identifiers = new List<string>();
        private List<string> identifiers_nodup = new List<string>();
        private List<string> meaningfulIdentifiers = new List<string>();
        private List<string> functions_nodup = new List<string>();
        private List<string> meaningfulFunctions = new List<string>();
        private List<string> comments = new List<string>();
        private List<string[]> _scopes = new List<string[]>();
        private List<int> eachScopeLength = new List<int>();
        private List<int> lengths = new List<int>();
        private List<int> classes = new List<int>();


        #endregion

        /// <summary>
        /// initialize an instance of type CodeDetails with a code 
        /// </summary>
        /// <param name="lines">code lines</param>
        public CodeDetails(string[] lines)
        {
            LinesWithComments = lines;
            _functionsAndScopes = new Dictionary<int, FunctionDetails>();
            //+------------------------------+
            Statics.Messages.Clear();  //    +
            Statics.EnableMessages = true ;//+
            //+------------------------------+

                try
                {
                    ComputeBlankLines(lines);
                    _numberOfCodeWithComment = lines.Length;
                    ClearComments(lines);//clear all comments
                    if (Lines != null)
                    {
                        GetFunctionsAndScopes();//get all functions and identifiers
                        GetNumberOfArithmaticFormuls();//get arithmatics formulas
                        GetNumberOfRecursiveFunctions();//compute recursive functions
                        GetAllScopes();//get all scopes
                        GetAllIndentifiersOccurrences();//compute each identifier frequency
                        ComputePolymorphism();//compute polymorphism
                        ComputeMeaningfullWords();//compute meaningful words
                        ComputeNumberOfComments();//compute number of comments
                        ComputeCodeVolume();//compute code volume
                        _loops = new LoopsFinder(Lines, LinesWithComments);//Get All loops , ifs , switchs and arrays
                        ComputeIndents();//compute indents
                    }
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("May be some errors found while reading the file");
                }
        } 


        #region Identifiers Details


        private string Identifier(string line)
        {
            line = line.Trim();
            switch (Statics.SubString(0, line.IndexOf(' '), line).Trim())
            {
                case "import":
                case "return":
                    return string.Empty;
            }
            if (line.Trim().StartsWith("while ") || line.Trim().StartsWith("while("))
                return string.Empty;
            if (isFunction(line))
            {
                try
                {
                    string type = Statics.SubString(line.IndexOf('(') + 1, Statics.GetCloseBraceIndex('(', line.IndexOf('('), line) - 1, line);
                    type = type.Trim();
                    if (type == string.Empty)
                        return string.Empty;
                    string[] temp;
                    if (type.Contains(','))
                    {
                        temp = type.Split(',');
                    }
                    else
                    {
                        temp = new string[1] { type.Trim() };
                    }
                    for (int i = 0; i < temp.Length; i++)
                    {
                        if (temp[i].Contains('='))
                            temp[i] = Statics.SubString(0, type.IndexOf('=') - 1, temp[i]);
                        temp[i] = temp[i].Trim();
                        if (temp[i].Contains(' '))
                            identifiers.Add(Statics.SubString(temp[i].IndexOf(' ') + 1, temp[i].Length - 1, temp[i]).Trim());
                        else
                            identifiers.Add(temp[i].Trim());
                    }
                    return string.Empty;
                }
                catch { return string.Empty; }
            }
            if (line.Trim().StartsWith("for ") || line.Trim().StartsWith("for("))
            {
                string type = Statics.SubString(line.IndexOf('(') + 1, line.IndexOf(';', line.IndexOf('(')) - 1, line);
                type = type.Trim();
                if (type.Contains('='))
                    type = Statics.SubString(0, type.IndexOf('=') - 1, type);
                type = type.Trim();
                if (type.Contains(' '))
                    return Statics.SubString(type.IndexOf(' ') + 1, type.Length - 1, type);
                else
                    return type;
            }
            if (Statics.isAccessModifier(Statics.SubString(0, line.IndexOf(' ') - 1, line)))
            {
                line = Statics.SubString(line.IndexOf(' '), line.Length - 1, line).Trim();
            }
            line = line.Trim();
            if(line.Contains("static final "))
            {
                line  = Statics.SubString(line.IndexOf("final")+6,line.Length-1,line).Trim();
            }
            if (Statics.SubString(0, line.IndexOf(' ') - 1, line) == "final")
                line = Statics.SubString(line.IndexOf(' '),line.Length-1,line).Trim();
            if (Statics.isIdentifierDatatype(Statics.SubString(0, line.IndexOf(' ') - 1, line)))
            {
                line = Statics.SubString(line.IndexOf(' '), line.Length - 1, line).Trim();
            }
            line = line.Trim();
            if (line.Contains('='))
            {
                if (line.Contains('('))
                {
                    if (line.IndexOf('=') < line.IndexOf('('))
                        if (!identifiers.Contains(Statics.SubString(0, line.IndexOf('=') - 1, line).Trim()))
                            return Statics.SubString(0, line.IndexOf('=') - 1, line);
                }
                else
                {
                    if (!identifiers.Contains(Statics.SubString(0, line.IndexOf('=') - 1, line)))
                        return Statics.SubString(0, line.IndexOf('=') - 1, line);
                }
            }
            else
            {
                if (line.Contains(';') && !line.Contains('('))
                {
                    if (!identifiers.Contains(Statics.SubString(0, line.IndexOf(';') - 1, line).Trim()))
                        return Statics.SubString(0, line.IndexOf(';') - 1, line);
                }
            }
            return string.Empty;
        }

        private int IndentifierOccurrences(string iden)
        {
            int count = 0;
            for (int i = 0; i < Lines.Length; i++)
            {
                count += Statics.HowMuchExist(iden, Lines[i].Trim());
            }
            return count;
        }
        private void GetAllIndentifiersOccurrences()
        {

            List<string> temp = new List<string>();
            List<int> temp2 = new List<int>();
            FromulateIndentifiersList();
            for (int i = 0; i < identifiers.Count; i++)
            {
                if (!temp.Contains(identifiers[i]))
                    temp.Add(identifiers[i]);
            }
            for (int i = 0; i < temp.Count; i++)
                temp2.Add(IndentifierOccurrences(temp[i].Trim()));
            identifiersOccurance = temp2.ToArray();
        }


        #endregion


        #region ArithmaticFormuls


        private int GetNumberOfArithmaticFormuls()
        {
            int start = 0;
            bool end = false;
            bool skip = false;
            _numberOfArithmaticFormuls = 0;
            if (_functionsAndScopes == null)
                return 0;
            for (int i = 0; i < Lines.Length; i++)
            {
                if (Lines[i].Trim().StartsWith("System.out") || Lines[i].Trim() == string.Empty)
                    continue;
                for (int ii = 0; ii < Lines[i].Length; ii++)
                {
                    if (Lines[i][ii] == '"')
                    {
                        skip = !skip;
                    }
                    if (!skip)
                    {
                        switch (Lines[i][ii])
                        {
                            case '+':
                                if (Lines.Length == ii + 1)
                                {
                                    if (Statics.GetFirstCharacterBeforeIndex(ii, i, Lines) == '"')
                                    {
                                        continue;
                                    }
                                    else
                                        _numberOfArithmaticFormuls++;
                                }
                                if (Lines[i].Length != ii + 1)
                                {
                                    if (Lines[i].Contains('"'))
                                    {
                                        if (Statics.GetFirstCharacterBeforeIndex(ii, i, Lines) == '"')
                                        {
                                            continue;
                                        }
                                        else
                                            if (Statics.GetFirstCharacterAfterIndex(ii, i, Lines) == '"')
                                            {
                                                continue;
                                            }
                                    }
                                    if (Lines[i][ii + 1] == '+')
                                    {
                                        _numberOfArithmaticFormuls++;
                                        ii++;
                                    }
                                    else
                                    {
                                        _numberOfArithmaticFormuls++;
                                    }
                                }
                                break;
                            case '*':
                                _numberOfArithmaticFormuls++;
                                break;
                            case '-':
                                if (Lines[i].Length != ii + 1)
                                {
                                    if (Lines[i][ii + 1] == '-')
                                    {
                                        _numberOfArithmaticFormuls++;
                                        ii++;
                                    }
                                    else
                                        if (Lines[i][ii + 1] == '=')
                                        {
                                            _numberOfArithmaticFormuls++;
                                            ii++;
                                        }
                                        else
                                        {
                                            if (Lines[i].Contains('='))
                                            {
                                                if (!Statics.AnyCharactersBetween(Lines[i].IndexOf('='), ii, Lines[i], '-'))
                                                {
                                                    _numberOfArithmaticFormuls++;
                                                }
                                            }
                                            else
                                                if (Lines[i].Contains('('))
                                                    _numberOfArithmaticFormuls++;
                                        }
                                }
                                break;
                            case '/':
                                if (ii < Lines[i].Length - 1)
                                {
                                    if (Lines[i][ii + 1] != '/')
                                    {
                                        _numberOfArithmaticFormuls++;
                                    }
                                    else
                                    {
                                        end = true;
                                    }
                                }
                                break;
                        }
                        if (end)
                        {
                            end = false;
                            break;
                        }
                    }

                }
                start += Lines[i].Length;
            }
            return _numberOfArithmaticFormuls;
        }

        #endregion


        #region Computers


        private double ComputeLinesLength()
        {
            lengths = new List<int>();
            for (int i = 0; i < Lines.Length; i++)
                if (Lines[i].Trim() != string.Empty)
                    lengths.Add(Lines[i].Trim().Length);
            return Statics.Median(lengths.ToArray());
        }
        private int[] ComputeIdentifiersLength()
        {
            List<int> list = new List<int>();
            identifiers_nodup = Statics.RemovedDuplicate<string>(identifiers);
            for (int i = 0; i < identifiers_nodup.Count; i++)
            {
                list.Add(identifiers_nodup[i].Length);
            }
            return list.ToArray();
        }
        private int ComputeSwitchsLines()
        {
            int sum = 0;
            for (int i = 0; i < _loops.Switchs.Count; i++)
                sum += _loops.Switchs[i].SwitchLinesCount;
            return sum;
        }

        private void ComputePolymorphism()
        {
            _numberOfPolymorphism = 0;
            List<string> temp1 = AllFunctionsList(true);
            List<string> temp2 = AllFunctionsList(false);
            if (_functionsAndScopes.Count < 2)
                return;
            for (int i = 0; i < temp1.Count; i++)
            {
                int rep = Statics.NumberOfRepation(temp2, temp1[i]);
                if (rep > 1)
                    _numberOfPolymorphism += rep;
            }
        }

        private void ComputeIndents()
        {
            _numberOfIndents = 0;
            _numberOfLoopsAndIfs = 0;
            for (int i = 0; i < _loops.Loops.Count; i++)
            {
                int loopIndex = Statics.IndexOfLoop(_loops.Loops[i + 1].LoopCode, 0);
                int nextLine = loopIndex + 1;
                while (loopIndex != -1)
                {
                    if (nextLine == _loops.Loops[i + 1].LoopCode.Length)
                        break;
                    if (_loops.Loops[i + 1].LoopCode[nextLine].Trim() == string.Empty)
                    {
                        nextLine++;
                        continue;
                    }
                    _numberOfLoopsAndIfs++;
                    if ((_loops.Loops[i + 1].LoopCode[loopIndex].Length - _loops.Loops[i + 1].LoopCode[loopIndex].TrimStart().Length) < (_loops.Loops[i + 1].LoopCode[nextLine].Length - _loops.Loops[i + 1].LoopCode[nextLine].TrimStart().Length))
                        _numberOfIndents++;
                    loopIndex = Statics.IndexOfLoop(_loops.Loops[i + 1].LoopCode, loopIndex + 1);
                    nextLine = loopIndex + 1;
                }
            }

            for (int i = 0; i < _loops.IfElse.Count; i++)
            {
                int ifIndex = Statics.IndexOfIF(_loops.IfElse[i].Code, 0);
                int nextLine = ifIndex + 1;
                while (ifIndex != -1)
                {
                    if (nextLine == _loops.IfElse[i].Code.Length)
                        break;
                    if (_loops.IfElse[i].Code[nextLine].Trim() == string.Empty)
                    {
                        nextLine++;
                        continue;
                    }
                    _numberOfLoopsAndIfs++;
                    if ((_loops.IfElse[i].Code[ifIndex].Length - _loops.IfElse[i].Code[ifIndex].TrimStart().Length) < (_loops.IfElse[i].Code[nextLine].Length - _loops.IfElse[i].Code[nextLine].TrimStart().Length))
                        _numberOfIndents++;
                    ifIndex = Statics.IndexOfLoop(_loops.IfElse[i].Code, ifIndex + 1);
                    nextLine = ifIndex + 1;
                }
            }
        }


        private void ComputeNumberOfComments()
        {
            _numberOfCodeWithoutComment = 0;
            for (int i = 0; i < Lines.Length; i++)
                if (Lines[i].Trim() != string.Empty)
                    _numberOfCodeWithoutComment++;//all comments and blink lines removed 
            _numberOfCodeWithComment = 0;
            for (int i = 0; i < LinesWithComments.Length; i++)
                if (LinesWithComments[i].Trim() != string.Empty)//all blank lines removed
                    _numberOfCodeWithComment++;

        }

        private void ComputeBlankLines(string[] lines)
        {
            _numberOfBlankLines = 0;
            try
            {
                for (int i = 0; i < lines.Length; i++)
                    if (lines[i].Trim() == string.Empty)
                        _numberOfBlankLines++;
            }
            catch
            {
            }
        }

        private void ComputeMeaningfullWords()
        {
            _meaningfull.Add("Functions", 0);
            List<string> temp = Statics.RemovedDuplicate<string>(FunctionsList());
            functions_nodup = temp;
            for (int i = 0; i < temp.Count; i++)
            {
                if (Statics.IsMeaningfulList(Statics.NameContant(temp[i])))
                {
                    _meaningfull["Functions"] += 1;
                    meaningfulFunctions.Add(temp[i]);
                }
            }

            _meaningfull.Add("Identifiers", 0);
            temp = Statics.RemovedDuplicate<string>(identifiers);
            identifiers_nodup = temp;
            for (int i = 0; i < temp.Count; i++)
            {
                if (Statics.IsMeaningfulList(Statics.NameContant(temp[i])))
                {
                    _meaningfull["Identifiers"] += 1;
                    if (!Statics.ResevedWord(temp[i].Trim()))
                        meaningfulIdentifiers.Add(temp[i]);
                }
            }
        }

        private void ComputeClassesCodes()
        {
            classes = new List<int>();
            int open = 0;
            int openBrace = -1;
            for (int i = 0; i < Lines.Length; i++)
            {
                if (Statics.HasClass(Lines[i]))
                {
                    open = i-1;
                    while (openBrace != -1)
                    {
                        open++;
                        openBrace = Lines[open].IndexOf('{');
                    }
                    int close = open;
                    int index = Statics.GetCloseBraceIndex('{',openBrace, ref close, ref Lines);
                    classes.Add(Statics.Cut(open, close, ref Lines).Length);
                }
            }
        }

        private int ComputeCommas(string line, out int scops)
        {
            int count = 0;
            scops = 0;
            for (int i = 0; i < line.Length; i++)
                if (line[i] == ';')
                    count++;
                else
                    if (line[i] == '{' && ((!line.Contains("[]") || !line.Contains("[ ]")) && !line.Contains('=') || (line.Contains("for(") || line.Contains("for "))))
                    {
                        scops++;
                    }
            return count;
        }

        private int ComputeNumberOfLoops()
        {
            int count = 0;
            for (int i = 0; i < _loops.Loops.Count; i++)
                count += _loops.Loops[i + 1].NumberOfLoops;
            return count;
        }

        private int ComputeNumberOfIfs()
        {
            int count = 0;
            for (int i = 0; i < _loops.Loops.Count; i++)
                count += _loops.IfElse[i].NumberOfIfs;
            return count;
        }


        private void ComputeCodeVolume()
        {
            _codeVolume = 0;
            for (int i = 0; i < Lines.Length; i++)
            {
                if (Lines[i].Trim() != string.Empty && LinesWithComments[i].Trim() != string.Empty)
                {
                    _codeVolume++;
                }
            }
        }

        #endregion


        #region List Fromulators


        private List<string> IdentifiersList()
        {
            List<string> temp = new List<string>();
            for (int i = 0; i < identifiers.Count; i++)
            {
                List<string> temp2 = Statics.NameContant(identifiers[i]);
                for (int ii = 0; ii < temp2.Count; ii++)
                    if (!temp.Contains(temp2[ii]))
                        temp.Add(temp2[ii]);
            }
            return temp;
        }

        private void FromulateIndentifiersList()
        {
            List<string> temp = new List<string>();
            for (int i = 0; i < identifiers.Count; i++)
            {
                if (identifiers[i].Contains(' '))
                {
                    identifiers[i] = Statics.SubString(identifiers[i].IndexOf(' '),identifiers[i].Length -1,identifiers[i]).Trim();
                    i--;
                    continue;
                }
                if (identifiers[i].Contains("[]"))
                {
                    identifiers[i] = Statics.SubString(0, identifiers[i].IndexOf("[]") - 1, identifiers[i]);
                }
                if (Statics.IsAcceptableName(identifiers[i]))
                    temp.Add(identifiers[i]);
            }
            identifiers = temp;
        }


        #endregion


        #region Scopes


        private void GetAllScopes()
        {
            List<string[]> _scopes = new List<string[]>();
            bool first = true;
            for (int i = 0; i < Lines.Length; i++)
            {
                if (Lines[i].Contains('{'))
                {
                    if (!first)
                    {
                        int open = i;
                        Statics.GetCloseBraceIndex('{', Lines[i].IndexOf('{'), ref open, ref Lines);
                        _scopes.Add(Statics.Cut(i, open, ref Lines));
                    }
                    else
                        first = false;
                }
            }
            //Statics.PrintListArray<string>(_scopes);
            try
            {
                for (int i = 0; i < _scopes.Count; i++)
                {
                    //System.Windows.Forms.MessageBox.Show(ComputeAllCodeLines(_scopes[i]).ToString(), String.Format("The Scope {0} Length is {1}", i + 1, ComputeAllCodeLines(_scopes[i])));
                    eachScopeLength.Add(Statics.ComputeAllCodeLines(_scopes[i]));
                }
            }
            catch { }
            // Statics.PrintList<int>(eachScopeLength);

        }

        #endregion


        #region Code Fromulators


        private void FormulateComment()
        {
            List<string> temp = new List<string>();
            for (int i = 0; i < comments.Count; i++)
            {
                string[] arr = comments[i].Split(' ');
                if (arr != null)
                {
                    for (int ii = 0; ii < arr.Length; ii++)
                    {
                        temp.Add(arr[ii].Trim());
                    }
                }

            }
            comments = temp;
        }

        private string[] GetCode(int startLine, int startLineIndex, int endLine, int endLineIndex)
        {
            if (endLine < startLine)
                return null;
            string[] code = new string[(endLine - startLine) + 1];
            for (int i = 0; i < code.Length; i++)
            {
                if (i == 0)
                {
                    Lines[startLine] = Lines[startLine].Trim();
                    if (Lines[startLine].Contains("/*"))
                    {
                        if (Lines[startLine].StartsWith("/*") && Lines[startLine].Length == 2)
                        {
                            Lines[startLine] = string.Empty;
                            code[i] = string.Empty;
                        }
                        else
                        {
                            if (Lines[startLine].StartsWith("/*"))
                            {
                                Lines[startLine] = string.Empty;
                                code[i] = Statics.SubString(2, Lines[startLine].Length - 1, Lines[startLine]);
                            }
                            else
                                if (Lines[startLine].EndsWith("/*"))
                                {
                                    Lines[startLine] = Statics.SubString(0, Lines[startLine].IndexOf("/*") - 1, Lines[startLine]);
                                    code[i] = string.Empty;
                                }
                                else
                                {
                                    Lines[startLine] = Statics.SubString(0, Lines[startLine].IndexOf("/*") - 1, Lines[startLine]);
                                    code[i] = Statics.SubString(Lines[startLine].IndexOf("/*") + 2, Lines[startLine].Length - 1, Lines[startLine]);

                                }
                        }
                    }
                }
                else
                    if (i + 1 == code.Length)
                    {
                        Lines[endLine] = Lines[endLine].Trim();
                        if (Lines[endLine].Contains("*/"))
                        {
                            if (Lines[endLine].StartsWith("*/") && Lines[endLine].Length == 2)
                            {
                                Lines[endLine] = string.Empty;
                                code[i] = string.Empty;
                            }
                            else
                            {
                                if (Lines[endLine].StartsWith("*/"))
                                {
                                    Lines[endLine] = Statics.SubString(2, Lines[endLine].Length - 1, Lines[endLine]);
                                    code[i] = string.Empty;
                                }
                                else
                                    if (Lines[endLine].EndsWith("*/"))
                                    {
                                        Lines[endLine] = string.Empty;
                                        code[i] = Statics.SubString(0, Lines[endLine].IndexOf("*/") - 1, Lines[endLine]);
                                    }
                                    else
                                    {
                                        Lines[endLine] = Statics.SubString(Lines[endLine].IndexOf("*/") + 2, Lines[endLine].Length - 1, Lines[endLine]);
                                        code[i] = Statics.SubString(0, Lines[endLine].IndexOf("*/") - 1, Lines[endLine]);
                                    }
                            }
                        }
                    }
                    else
                    {
                        code[i] = Lines[i + startLine];
                        Lines[startLine + i] = string.Empty;

                    }
            }
            return code;
        }
        private void ClearLongComments()
        {
            for (int i = 0; i < Lines.Length; i++)
            {
                if (Lines[i].Contains("/*") && !Lines[i].Contains("*/"))
                {
                    int close;
                    int index = Statics.GetCommentCloseIndex(i, out close, Lines);
                    if (index == -1)
                        return;
                    string[] com = new string[1];
                    try
                    {
                        com = GetCode(i, Lines[i].IndexOf("/*"), close, index);
                    }
                    catch { com = null; }
                    if (com != null)
                    {
                        for (int ii = 0; ii < com.Length; ii++)
                        {
                            comments.Add(com[ii]);
                        }
                    }
                    _numberOfComments++;
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
                        comments.Add(com.Trim());
                        Lines[i] = temp;
                        _numberOfComments++;
                    }
                }
            }
        }
        //remove all comments and keep only code lines
        private void ClearComments(string[] lines)
        {
            _numberOfComments = 0;//count number of comments
            Lines = new string[lines.Length];//set the lines of code in the memory
            for (int i = 0; i < Lines.Length; i++)
            {
                Lines[i] = lines[i];//.Trim();//remove tail spaces
                if (Lines[i].Trim().StartsWith("//"))//line start with //
                {
                    comments.Add(Statics.SubString(2, Lines[i].Length - 1, Lines[i]));
                    Lines[i] = string.Empty;//remove line
                    _numberOfCodeWithoutComment--;
                    _numberOfComments++;//increaze comments count
                }
                else
                    if (Lines[i].Contains("//") && !Lines[i].Trim().EndsWith("//"))//line containes //
                    {
                        if (Lines[i].Contains('"'))
                        {
                            if (Lines[i].IndexOf('"') < Lines[i].IndexOf("//") && Lines[i].IndexOf('"', Lines[i].IndexOf('"') + 1) > Lines[i].IndexOf("//"))
                                continue;
                        }
                        comments.Add(Statics.SubString(lines[i].IndexOf("//") + 2, lines[i].Length - 1, lines[i]));
                        Lines[i] = Statics.SubString(0, lines[i].IndexOf("//") - 1, lines[i]);//removr every thing after //
                        _numberOfComments++;
                    }
            }
            ClearLongComments();
        }

        public static string[] ClearEmptyLines(string[] code)
        {
            List<string> codeLines = new List<string>();
            for (int i = 0; i < code.Length; i++)
            {
                if (code[i].Trim() != string.Empty)
                {
                    codeLines.Add(code[i]);
                }
            }
            return codeLines.ToArray();
        }

        #endregion


        #region Functions And Scope Detailes


        private void GetNumberOfRecursiveFunctions()
        {
            _numberOfRecursiveFunctions = 0;
            _numberOfStaticFunctions = 0;
            if (_functionsAndScopes == null)
                return;
            for (int i = 0; i < _functionsAndScopes.Count; i++)
            {
                if (_functionsAndScopes[i + 1].Recursive)
                    _numberOfRecursiveFunctions++;

                if (_functionsAndScopes[i + 1].Static)
                    _numberOfStaticFunctions++;
            }
        }

        private List<string> AllFunctionsList(bool dist)
        {
            List<string> temp = new List<string>();
            for (int i = 0; i < _functionsAndScopes.Count; i++)
            {
                if (dist)
                {
                    if (!temp.Contains(_functionsAndScopes[i + 1].FunctionName))
                        temp.Add(_functionsAndScopes[i + 1].FunctionName);

                }
                else
                    temp.Add(_functionsAndScopes[i + 1].FunctionName);

            }
            return temp;
        }

        private List<string> FunctionsList()
        {
            List<string> temp = new List<string>();
            for (int i = 0; i < _functionsAndScopes.Count; i++)
            {
                //List<string> temp2 = NameContant(_functionsAndScopes[i + 1].FunctionName);
                //for (int ii = 0; ii < temp2.Count; ii++)
                if (!temp.Contains(_functionsAndScopes[i + 1].FunctionName))
                    temp.Add(_functionsAndScopes[i + 1].FunctionName);
            }
            return temp;
        }

        //get the fuction end brace index and line
        private void GetFunctionClose(ref FunctionDetails fun)
        {
            int exist = 0;//has an end
            int lineIndex = fun.StartBraceIndex;//the open brace index
            string line;//the current line
            for (int i = fun.ScopeStartLine; i < Lines.Length; i++)//start looking from the start brace 
            {
                line = Lines[i];//save current line
                for (int ii = lineIndex + 1; ii < line.Length; ii++)//read all current line characters
                {
                    if (line[ii] == '}')//a close found
                        exist++;
                    else
                        if ((line[ii] == '{'))//an open found
                            exist--;
                    if (exist == 1)//the close brace found
                    {
                        fun.EndBraceIndex = ii;
                        fun.ScopeEndLine = i;
                        return;
                    }
                }
                lineIndex = -1;//be cause we start from lineIndex+1

            }
        }

        //cut the code of the function
        private void GetFunctionCode(ref FunctionDetails fun)
        {
            string[] code = null;
            if (fun.ScopeStartLine == fun.ScopeEndLine)//the function code only one line
            {
                code = new string[1];
                code[0] = Lines[fun.ScopeStartLine].Substring(fun.StartBraceIndex, fun.EndBraceIndex - fun.StartBraceIndex);
            }
            else//multiline code
            {
                if (fun.ScopeEndLine > fun.ScopeStartLine)
                {
                    code = new string[(fun.ScopeEndLine - fun.ScopeStartLine + 1)];//set number of code lines
                    int index = 0;
                    for (int i = fun.ScopeStartLine; i <= fun.ScopeEndLine; i++, index++)//fill the code lines
                    {
                        if (i == fun.ScopeStartLine)
                            code[index] = Lines[i].Substring(fun.StartBraceIndex + 1, Lines[i].Length - (fun.StartBraceIndex + 1));
                        else
                            if (i == fun.ScopeEndLine)
                                code[index] = Lines[i].Substring(0, fun.EndBraceIndex);
                            else
                                code[index] = Lines[i];
                    }
                }
                else//the function end not exist
                {
                    System.Windows.Forms.MessageBox.Show("The Close Brace Of The Function ( " + fun.FunctionName + " ) Are Not Fount \nPlease Fix The Error And Reimport The File", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                    code = null;
                }
            }
            fun.FunctionCode = code;
        }
        //gets wheather the current code is a function
        private bool isFunction(string line)
        {
            string type = Statics.SubString(0, line.IndexOf('(') - 1, line);
            if (type.Trim().Split(' ').Length == 2 || type.Trim().Split(' ').Length == 3)
                return true;
            if (line.Contains('(')) // the line has '(' 
            {
                if (line.Contains('='))//the line has
                {
                    if (line.IndexOf('=') < line.IndexOf('(')) //the = index before the '(' index
                        // int x = (int) 4.6;//not function
                        //int x(int m = 4);//is a function
                        return false;// not function
                }
                else//not contains =
                {
                    if (line.Contains('{') && line.Contains(';') && line.Contains('['))//line has { and ; and [
                    {
                        if (line.IndexOf('[') < line.IndexOf('('))//index of [ before the index of (
                            //int [] x = myList();//not function
                            //for(int b;b<m[i].length;b++); // not function
                            //int x(int [] m){m[0]=1;}//function
                            return false;
                    }
                    else
                        if (line.Contains('{') && line.Contains(';'))//has { and ;
                        {
                            if (line.IndexOf('(') < line.IndexOf('{') && line.IndexOf('(') < line.IndexOf(';'))
                            {
                                if (line.IndexOf('{') < line.IndexOf(';'))//index of { before index of ;
                                {
                                    return true;//it's a function
                                }
                            }
                        }
                        else
                            if (line.Contains(';'))//has only ;
                                //int x;//not
                                return false;
                            else
                                if (line.Contains('{'))//has open scope not ;
                                {
                                    return true;
                                }
                }
            }

            return false;
        }
        //gets wheather the current code is a function
        private bool isFunction(string line, int lineIndex, ref FunctionDetails fun)
        {
            if (lineIndex < Lines.Length - 1)//not the unexist line
            {
                if (line.Contains('(')) // the line has '(' 
                {
                    if (line.Contains('='))//the line has
                    {
                        if (line.IndexOf('=') < line.IndexOf('(')) //the = index before the '(' index
                            // int x = (int) 4.6;//not function
                            //int x(int m = 4);//is a function
                            return false;// not function
                    }
                    else//not contains =
                    {
                        if (line.Contains('{') && line.Contains(';') && line.Contains('['))//line has { and ; and [
                        {
                            if (line.IndexOf('[') < line.IndexOf('('))//index of [ before the index of (
                                //int [] x = myList();//not function
                                //for(int b;b<m[i].length;b++); // not function
                                //int x(int [] m){m[0]=1;}//function
                                return false;
                        }
                        else
                            if (line.Contains('{') && line.Contains(';'))//has { and ;
                            {
                                if (line.IndexOf('(') < line.IndexOf('{') && line.IndexOf('(') < line.IndexOf(';'))
                                {
                                    if (line.IndexOf('{') < line.IndexOf(';'))//index of { before index of ;
                                    {
                                        fun.StartBraceIndex = line.IndexOf('{');//set the start
                                        fun.ScopeStartLine = lineIndex;//start line
                                        return true;//it's a function
                                    }
                                }
                            }
                            else
                                if (line.Contains(';'))//has only ;
                                    //int x;//not
                                    return false;
                                else
                                    if (line.Contains('{'))//has open scope not ;
                                    {
                                        fun.StartBraceIndex = line.IndexOf('{');
                                        fun.ScopeStartLine = lineIndex;
                                        return true;
                                    }
                                    else
                                        for (int i = lineIndex + 1; i < Lines.Length; i++)//check other lines
                                        {
                                            if (Lines[i].Contains('{') && !Lines[i].Contains(';'))//has { not ;
                                            {
                                                fun.StartBraceIndex = Lines[i].IndexOf('{');
                                                fun.ScopeStartLine = i;
                                                return true;
                                            }
                                            else
                                                if (!Lines[i].Contains('{') && Lines[i].Contains(';'))//has ; not {
                                                {
                                                    return false;//not function
                                                }
                                                else
                                                    if (Lines[i].Contains('{') && Lines[i].Contains(';'))//has both
                                                    {
                                                        if (Lines[i].IndexOf('{') < Lines[i].IndexOf(';'))//the { before ;
                                                        {
                                                            fun.StartBraceIndex = Lines[i].IndexOf('{');
                                                            fun.ScopeStartLine = i;
                                                            return true;
                                                        }
                                                        else
                                                            return false;
                                                    }

                                        }
                    }

                }
            }
            else
            {
                return false;//not function
            }

            return false;
        }

        private string GetFunctionName(string Head)
        {
            int brace = 0;// index op parameters
            int space = 0;//the first space before name index
            for (int i = 0; i < Head.Length; i++)
            {
                if (Head[i] == ' ')//save space index 
                    space = i;
                else
                    if (Head[i] == '(')//we find the head end
                    {
                        brace = i;
                        break;
                    }
            }
            return Head.Substring(space + 1, (brace - space) - 1);//get name
        }

        private void GetFunctionsAndScopes()
        {
            int funNumber = 1;
            _numberOfClasses = 0;
            _numberOfInheritance = 0;
            _lengthOfAllLines = 0;
            _numberOfBlankLinesOfFunction = 0;
            arr = new int[Lines.Length];
            string iden = "";
            for (int i = 0; i < Lines.Length; i++)
            {
                if (Lines[i].Trim().Contains("static ") && Lines[i].Trim().Contains(" void ") && Lines[i].Trim().Contains(" main"))
                {
                    int index = Lines[i].Trim().IndexOf("String",Lines[i].IndexOf(" main"));
                    if(index != -1)
                    {
                        int brace = Lines[i].Trim().IndexOf('(', Lines[i].Trim().IndexOf(" main"));
                        int close = Statics.GetCloseBraceIndex('(', brace, Lines[i].Trim());
                        identifiers.Add(Statics.SubString(Lines[i].Trim().IndexOf("String", brace) + 6, close - 1, Lines[i].Trim()));
                    }
                }else
                    iden = Identifier(Lines[i]);
                if (iden != string.Empty)
                {
                    if (!((iden.Contains(']') && !iden.Contains('[')) || (iden.Contains('[') && !iden.Contains(']'))))
                    {
                        if (iden.Contains(','))
                        {
                            string[] temp = iden.Split(',');
                            for (int x = 0; x < temp.Length; x++)
                                identifiers.Add(temp[x].Trim());
                        }
                        else
                            if (!iden.Contains("--") && !iden.Contains("++"))
                                identifiers.Add(iden.Trim());
                    }
                }

                arr[i] = Lines[i].Trim().Length;
                if (Lines[i].Trim() != string.Empty)
                {
                    int scops;
                    _numberOfCommas += ComputeCommas(Lines[i], out scops);
                    _numberOfScopes += scops;
                }
                if (Lines[i].Contains(" extends "))//line containes inheritance
                {
                    _numberOfInheritance++;
                }
                if (Lines[i].Contains(" implements "))
                {
                    _numberOfInheritance++;
                }

                if (Statics.HasClass(Lines[i]))
                {
                    _numberOfClasses++;
                    if (i != 0)
                    {
                        if (LinesWithComments[i - 1].Trim() == string.Empty)
                            _numberOfBlankLinesOfClasses++;
                    }
                }
            }
            //Statics.PrintList<string>(identifiers);
            //for(int i = 0;i<_scopes.Count;i++)
            //    PrintList(_scopes[i]);
            //_maxScope = (lastindex - _maxScope) - _numberOfBlankLines;
            for (int i = 0; i < Lines.Length; i++)
            {
                if (Lines[i].Trim() != string.Empty)//line not empty
                {
                    if (Lines[i].IndexOf(' ') != -1)//end of member access modifier or datatype
                    {
                        if (Statics.isDataType(Lines[i].Substring(0, Lines[i].IndexOf(' '))) || Statics.isAccessModifier(Lines[i].Substring(0, Lines[i].IndexOf(' '))))
                        {
                            FunctionDetails fun = new FunctionDetails();
                            if (isFunction(Lines[i], i, ref fun))
                            {
                                if (LinesWithComments[i - 1].Trim() == string.Empty)
                                {
                                    _numberOfBlankLinesOfFunction++;
                                }
                                if (Lines[i].Contains("static"))//the function is static
                                    fun.FunctionType = "static";
                                if (Lines[i].Contains("public"))
                                    fun.FunctionAccessModifier = "public";
                                if (Lines[i].Contains("private"))
                                    fun.FunctionAccessModifier = "private";
                                if (Lines[i].Contains("protected"))
                                    fun.FunctionAccessModifier = "protected";
                                if (Statics.isDataType(Lines[i].Substring(0, Lines[i].IndexOf(' '))))
                                    fun.FunctionReturnType = Lines[i].Substring(0, Lines[i].IndexOf(' '));
                                if (Statics.isAccessModifier(Lines[i].Substring(0, Lines[i].IndexOf(' '))))
                                {
                                    int space = Lines[i].IndexOf(' ') + 1;
                                    try
                                    {
                                        if (Statics.isFunctionModifier(Lines[i].Substring(space, Lines[i].IndexOf(' ', space) - space).Trim()))
                                        {
                                            space = Lines[i].IndexOf(' ', space) + 1;
                                            fun.FunctionReturnType = Lines[i].Substring(space, Lines[i].IndexOf(' ', space) - space).Trim();
                                        }
                                        else
                                        {
                                            fun.FunctionReturnType = Lines[i].Substring(space, Lines[i].IndexOf(' ', space) - space).Trim();
                                        }
                                    }
                                    catch { }
                                }

                                GetFunctionClose(ref fun);
                                GetFunctionCode(ref fun);
                                if (fun.FunctionCode == null)
                                {
                                    _functionsAndScopes = null;
                                    _functionsCount = 0;
                                    return;
                                }
                                fun.FunctionName = GetFunctionName(Lines[i]);
                                fun.FunctionHead = Lines[i];
                                _functionsAndScopes.Add(funNumber, fun);
                                i = fun.ScopeEndLine;
                                fun = new FunctionDetails();
                                funNumber++;

                                // return;
                            }
                        }
                    }
                }
                //else
                // _numberOfBlankLines++;
            }
            _functionsCount = funNumber;
            _maxLinelength = arr.Max();
            _lengthOfAllLines = arr.Sum();
            _numberOfScopes = 0;
        }

        #endregion


        #region Propertys

        public System.Collections.Generic.Dictionary<int, FunctionDetails> FunctionsAndScopes
        {
            get { return _functionsAndScopes; }
            set { _functionsAndScopes = value; }
        }

        public int NumberOfArithmaticFormuls
        {
            get { return _numberOfArithmaticFormuls; }
            set { _numberOfArithmaticFormuls = value; }
        }

        public double ArithmaticFormuls
        {
            get
            {
                if (!Statics.Messages.ContainsKey(20))
                    Statics.FromulateMassege(20, string.Format("Number Of Arithmatic Formuls {0} / Code Volume {1}", _numberOfArithmaticFormuls, CodeVolume));
                return Math.Pow(Math.E,-1*((double)_numberOfArithmaticFormuls / CodeVolume));
            }
        }

        public int NumberOfInheritance
        {
            get { return _numberOfInheritance; }
            set { _numberOfInheritance = value; }
        }

        public int FunctionsCount
        {
            get { return _functionsCount; }
            set { _functionsCount = value; }
        }

        public int NumberOfStaticFunctions
        {
            get { return _numberOfStaticFunctions; }
            set { _numberOfStaticFunctions = value; }
        }

        public int NumberOfRecursiveFunctions
        {
            get { return _numberOfRecursiveFunctions; }
            set { _numberOfRecursiveFunctions = value; }
        }

        public double RecursiveFunctions
        {
            get
            {
                if (!Statics.Messages.ContainsKey(18))
                    Statics.FromulateMassege(18, String.Format("(2.71)^({0} [Number Of Recursive Functions])", _numberOfRecursiveFunctions * -1));
                return Math.Pow(2.71, (double)(_numberOfRecursiveFunctions * -1));
            }
        }

        public int NumberOfComments
        {
            get { return _numberOfComments; }
            set { _numberOfComments = value; }
        }

        public double Comments
        {
            get
            {
                if (!Statics.Messages.ContainsKey(4))
                    Statics.FromulateMassege(4, String.Format("(Number Of Comments {0} / (Number Of Comments {1} + Number Of Code Without Comments {2}) ) / 0.20", _numberOfComments, _numberOfComments, _numberOfCodeWithoutComment));
                return ((double)_numberOfComments / (double)(_numberOfCodeWithoutComment + _numberOfComments) / 0.20);
            }
        }
        public int NumberOfClasses
        {
            get { return _numberOfClasses; }
            set { _numberOfClasses = value; }
        }

        public double Classes
        {
            get
            {
                if (_numberOfClasses > 1)
                {
                    ComputeClassesCodes();
                    if (!Statics.Messages.ContainsKey(14))
                        Statics.FromulateMassege(14, String.Format("Median Of \r\n{0} \r\n Equals {1} / {2} ", Statics.StringList<int>(classes), Statics.Median(classes.ToArray()), classes.Max()));
                    return Statics.Median(classes.ToArray()) / (double)classes.Max();
                }
                else
                {
                    if (!Statics.Messages.ContainsKey(14))
                        Statics.FromulateMassege(14, String.Format("Median Of \r\n{0} \r\n Equals {1} / {2} ",1,1,1));
                    return _numberOfClasses;
                }
            }
        }

        public string[] LinesWithoutComments
        {
            get { return Lines; }
            set { Lines = value; }
        }

        public LoopsFinder Loops
        {
            get { return _loops; }
        }

        public int CodeVolume
        {
            get { return _codeVolume; }
        }

        public double Spacing
        {
            get
            {
                if (!Statics.Messages.ContainsKey(16))
                    Statics.FromulateMassege(16, String.Format("Blank Lines Before Functions {0} + Blank Lines Before Classes {1}) / (Number Of Function {2} + Number Of Classes {3}) ",
                        new object [] {
                            _numberOfBlankLinesOfFunction ,
                            _numberOfBlankLinesOfClasses,
                            _functionsAndScopes.Count ,
                            _numberOfClasses
                        }));
                return (double)(_numberOfBlankLinesOfFunction + _numberOfBlankLinesOfClasses) / (double)(_functionsAndScopes.Count + _numberOfClasses);
            }
        }

        public double LengthOfLines
        {
            get
            {
                double median = ComputeLinesLength();
                if (!Statics.Messages.ContainsKey(24))
                    Statics.FromulateMassege(24, String.Format("Median Of \r\n{0} \r\n Equals {1} / Max Length {2} ", Statics.StringList<int>(lengths), median, lengths.Max()));
                return (double)median / (double)lengths.Max();
            }
        }

        public double Indents
        {
            get
            {
                if (!Statics.Messages.ContainsKey(6))
                    Statics.FromulateMassege(6, String.Format("Indents {0} / Loops And Ifs {1}", _numberOfIndents, _numberOfLoopsAndIfs));
                return (double)_numberOfIndents / (double)(_numberOfLoopsAndIfs);
            }
        }

        public int NumberOfCommas
        {
            get { return _numberOfCommas - (_loops.ReadabilityOfTheNestedLoops.NumberOfForLoops * 2); }
        }

        public double Consistancy
        {
            get
            {
                if (!Statics.Messages.ContainsKey(22))
                    Statics.FromulateMassege(22, String.Format("Commas {0} / Code Volume {1}", NumberOfCommas, CodeVolume));
                return (double)NumberOfCommas / CodeVolume;
            }
        }

        public double Scopes
        {
            get
            {
                if (!Statics.Messages.ContainsKey(8))
                    Statics.FromulateMassege(8, String.Format("Median Of All Scopes \r\n{0} \r\n Equals {1} / Max Scope  {2} ", Statics.StringList<int>(eachScopeLength), Statics.Median(eachScopeLength.ToArray()).ToString(), eachScopeLength.Max()));
                return Statics.Median(eachScopeLength.ToArray()) / eachScopeLength.Max();
            }
        }

        public double Inheritance
        {
            get
            {
                if (!Statics.Messages.ContainsKey(10))
                    Statics.FromulateMassege(10, String.Format("Inheritance {0} / Classes {1}", _numberOfInheritance, _numberOfClasses));
                return (double)_numberOfInheritance / (double)_numberOfClasses;
            }
        }

        public double Switch
        {
            get
            {
                int switchsLines = ComputeSwitchsLines();
                if (!Statics.Messages.ContainsKey(42))
                    Statics.FromulateMassege(42, String.Format("Switchs Lines {0} / Code Volume {1}", switchsLines, CodeVolume));
                return (double)switchsLines / CodeVolume;
            }
        }

        public double MeaningfulValue
        {
            get
            {
                if (!Statics.Messages.ContainsKey(2))
                    Statics.FromulateMassege(2, String.Format("All Identifiers \n\r\n\r{0}\n\r\n\rMeaningful Identifiers \n\r\n\r {1} \n\r\n\r All Functions \n\r\n\r {2}\n\r\n\r Meaningful Functions \n\r\n\r {3} \n\r (Meaningful Identifiers {4} / All Identifiers {5}) + (Meaningful Functions {6} / All Functions {7}) ",
                        new object[]
                    {
                        Statics.StringList<string>(identifiers_nodup),
                        Statics.StringList<string>(meaningfulIdentifiers),
                        Statics.StringList<string>(functions_nodup),
                        Statics.StringList<string>(meaningfulFunctions),
                        meaningfulIdentifiers.Count,
                        identifiers_nodup.Count,
                        meaningfulFunctions.Count,
                        functions_nodup.Count,
                    }));
                return ((double)meaningfulIdentifiers.Count / (double)identifiers_nodup.Count) + ((double)meaningfulFunctions.Count / (double)functions_nodup.Count);
            }
        }

        public double Polymorphism
        {
            get
            {
                if (!Statics.Messages.ContainsKey(12))
                    Statics.FromulateMassege(12, String.Format("All Function \n\r\n\r{0}\n\r\n\r Number Of OverLoads {1} / Number Of Function {2}",
                        new object[]{
                        Statics.StringList<string>(FunctionsList()),
                         _numberOfPolymorphism,
                         _functionsAndScopes.Count
                }));
                return (double)(_numberOfPolymorphism) / (double)_functionsAndScopes.Count;
            }
        }

        public Dictionary<string, int> MeaningFull
        {
            get { return _meaningfull; }
        }

        public double IdentifiersLength
        {
            get
            {
                int[] ilengths = ComputeIdentifiersLength();
                if (!Statics.Messages.ContainsKey(26))
                    Statics.FromulateMassege(26, String.Format("Median Of Identifers Length \n\r{0}\n\r\n\r Median {1} / Max Length {2}", Statics.StringArray<int>(ilengths), Statics.Median(ilengths), ilengths.Max()));
                return Statics.Median(ilengths) / ilengths.Max();
            }
        }

        public double IdentifiersFrequency
        {
            get
            {
                if (!Statics.Messages.ContainsKey(28))
                    Statics.FromulateMassege(28, String.Format("Median Of Identifers Occurance \n\r{0}\n\r\n\r Median {1} / Max Length {2}", Statics.StringArray<int>(identifiersOccurance), Statics.Median(identifiersOccurance), identifiersOccurance.Max()));
                return Statics.Median(identifiersOccurance) / (double)identifiersOccurance.Max();
            }
        }

        public double Arrays
        {
            get
            {
                if (!Statics.Messages.ContainsKey(44))
                    Statics.FromulateMassege(44, String.Format("Identifers \n\r{0}\n\r\n\r Arrays {1} / Count {2}", Statics.StringList<String>(identifiers_nodup), _loops.NumberOfArrays, identifiers_nodup.Count));
                return (double)_loops.NumberOfArrays / (double)identifiers_nodup.Count;
            }
        }

        public double IFS
        {
            get
            {
                if (!Statics.Messages.ContainsKey(30))
                    Statics.FromulateMassege(30, String.Format("Number Of Ifs {0} / Code Volume {1}", _loops.NumberOfIfElse, CodeVolume));
                return (double)_loops.NumberOfIfElse / (double)CodeVolume;
            }
        }

        public double NestedIfValue
        {

            get
            {
             //   if (!Statics.Messages.ContainsKey(32))
             //       Statics.FromulateMassege(32, String.Format("(2.71)^({0} [Max Nested Length])", _loops.MaxNested * -1));
                return Math.Pow(Math.E, _loops.MaxNested * -1);
            }
        }

        #endregion
    }
}
