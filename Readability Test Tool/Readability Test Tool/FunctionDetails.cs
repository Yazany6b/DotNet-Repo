
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Readability_Test_Tool
{
    /// <summary>
    /// Containes methodes and attribute that any function code have
    /// </summary>
    public class FunctionDetails
    {
        private string _functionHead;
        private string _functionName;
        private string _functionReturnType;
        private string _functionType;
        private string _functionAccessModifier;
        private string[] _functionCode;

        private int _startBraceIndex;
        private int _endBraceIndex;
        private int _scopeStartLine;
        private int _scopeEndLine;
        /// <summary>
        /// Make an instance of the class FunctionDetails
        /// </summary>
        public FunctionDetails()
        {
        }

        /// <summary>
        /// Gets or sets the function header
        /// </summary>
        public string FunctionHead
        {
            get { return _functionHead; }
            set { _functionHead = value; }
        }


        /// <summary>
        /// Gets or sets the function name
        /// </summary>
        public string FunctionName
        {
            get { return _functionName; }
            set { _functionName = value; }
        }


        /// <summary>
        /// Gets or sets the function return type. If the return type not exist then it's a constractor
        /// </summary>
        public string FunctionReturnType
        {
            get { return _functionReturnType; }
            set { _functionReturnType = value; }
        }


        /// <summary>
        /// Gets or sets 
        /// </summary>
        public string FunctionType
        {
            get { return _functionType; }
            set { _functionType = value; }
        }

        public string FunctionAccessModifier
        {
            get { return _functionAccessModifier; }
            set { _functionAccessModifier = value; }
        }


        /// <summary>
        /// Gets or sets the function definition
        /// </summary>
        public string[] FunctionCode
        {
            get { return _functionCode; }
            set { _functionCode = value; }
        }

        /// <summary>
        /// Gets true true if the function is static
        /// </summary>
        public bool Static
        {
            get { return _functionType == "static"; }
        }

        /// <summary>
        /// Gets true if the function is a recursive function
        /// </summary>
        public bool Recursive
        {
            get { return isRecursiveFunction(); }
        }

        /// <summary>
        /// Gets or sets the index of the function open brace
        /// </summary>
        public int StartBraceIndex
        {
            get { return _startBraceIndex; }
            set { _startBraceIndex = value; }
        }

        /// <summary>
        /// Gets or sets the index of the function close brace
        /// </summary>
        public int EndBraceIndex
        {
            get { return _endBraceIndex; }
            set { _endBraceIndex = value; }
        }

        /// <summary>
        /// Gets or sets the open brace line
        /// </summary>
        public int ScopeStartLine
        {
            get { return _scopeStartLine; }
            set { _scopeStartLine = value; }
        }

        /// <summary>
        /// Gets or sets the close brace line
        /// </summary>
        public int ScopeEndLine
        {
            get { return _scopeEndLine; }
            set { _scopeEndLine = value; }
        }

        private bool isRecursiveFunction()//is the current function is recrsive
        {
            if (_functionCode == null)//no code
                return false;
            if (_functionName == null)//no name
                return false;
            _functionName = _functionName.Trim();//name without spaces
            for (int i = 0; i < _functionCode.Length; i++)//check function code
            {
                if (_functionCode[i].Contains(_functionName))//function name is in the code
                {
                    try
                    {
                        if (GetFirstCharacterAfterIndex(_functionCode[i].IndexOf(_functionName)+_functionName.Length-1,i) == '(')//the next character after the name must be '('
                        {
                            return true;//the function is recrsive
                        }
                    }
                    catch { }//character no exist
                }
            }
            return false;
        }
        // first character after index
        private char GetFirstCharacterAfterIndex(int index, int line)
        {
            index++;
            string[] Lines = _functionCode;
            for (int i = line; i < Lines.Length; i++)
            {
                for (int ii = index; ii < Lines[i].Length; ii++)
                {
                    if (Lines[i][ii] != ' ')
                    {
                        return Lines[i][ii];
                    }
                }
                index = 0;
            }
            return ' ';
        }
    }
}
