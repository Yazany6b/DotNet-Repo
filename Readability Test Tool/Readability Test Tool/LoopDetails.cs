using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Readability_Test_Tool
{
    /// <summary>
    /// Loops types
    /// </summary>
    public enum LoopsTypes
    {
        DoWhile,
        While,
        For,
        None
    }
    /// <summary>
    /// containes methodes and attributes of any loop
    /// </summary>
    public class LoopDetails
    {
        private LoopsTypes _loopType;
        private string[] _loopCode;

        private int _startBraceIndex;
        private int _endBraceIndex;
        private int _scopeStartLine;
        private int _scopeEndLine;
        private int _numberOfNestedLoops = 0;
        private int _numberOfWhileLoops = 0;
        private int _numberOfForLoops = 0;
        private int _numberOfDoWhileLoops = 0;
        private bool _nestedLoop = false;

        /// <summary>
        /// Gets or sets the current loop definition
        /// </summary>
        public string[] LoopCode
        {
            get { return _loopCode; }
            set { _loopCode = value; CheckCode();}
        }
        /// <summary>
        /// Gets or sets current loop type
        /// </summary>
        public LoopsTypes LoopType
        {
            get { return _loopType; }
            set { _loopType = value; }
        }

        /// <summary>
        /// Gets or sets whether the current loop is a for loop
        /// </summary>
        public bool ForLoop
        {
            get { return _loopType == LoopsTypes.For; }
        }

        /// <summary>
        /// Gets or sets whether the current loop is a do-while loop
        /// </summary>
        public bool DoWhileLoop
        {
            get { return _loopType == LoopsTypes.DoWhile; }
        }


        /// <summary>
        /// Gets or sets whether the current loop is a while loop
        /// </summary>
        public bool WhileLoop
        {
            get { return _loopType == LoopsTypes.While; }
        }

        /// <summary>
        /// Gets or sets whether the current loop is a nested loop
        /// </summary>
        public bool NestedLoop
        {
            get { return _nestedLoop; }
            set { _nestedLoop = value; }
        }

        /// <summary>
        /// Gets or sets the start index of the loop open brace in the code to defined the starting of the loop definition
        /// </summary>
        public int StartBraceIndex
        {
            get { return _startBraceIndex; }
            set { _startBraceIndex = value; }
        }


        /// <summary>
        /// Gets or sets the index of the loop close brace in the code to defined the end of the loop definition
        /// </summary>
        public int EndBraceIndex
        {
            get { return _endBraceIndex; }
            set { _endBraceIndex = value; }
        }

        /// <summary>
        /// Gets or sets the line of the loop open brace in the code to defined the starting line of the loop definition
        /// </summary>
        public int ScopeStartLine
        {
            get { return _scopeStartLine; }
            set { _scopeStartLine = value; }
        }

        /// <summary>
        /// Gets or sets the line of the loop close brace in the code to defined the end line of the loop definition
        /// </summary>
        public int ScopeEndLine
        {
            get { return _scopeEndLine; }
            set { _scopeEndLine = value; }
        }

        /// <summary>
        /// Gets or sets how many nested loops in the current loop
        /// </summary>
        public int NumberOfNestedLoops
        {
            get { return _numberOfNestedLoops; }
        }

        /// <summary>
        /// Gets or sets number of for loops
        /// </summary>
        public int NumberOfForLoops
        {
            get { return _numberOfForLoops; }
        }

        /// <summary>
        /// Gets or sets number of while loops
        /// </summary>
        public int NumberOfWhileLoops
        {
            get { return _numberOfWhileLoops; }
        }

        /// <summary>
        /// Gets or sets number of do-while loops
        /// </summary>
        public int NumberOfDoWhileLoops
        {
            get { return _numberOfDoWhileLoops; }
        }
        /// <summary>
        /// Compute the readability result for the current loop values 
        /// </summary>
        /// <param name="list">a list containes all loops definition</param>
        /// <returns>returns the readability value</returns>
        public static LoopsReport ReadabilityResulte(System.Collections.Generic.Dictionary<int , LoopDetails> list)
        {
            int dos = 0;//do whiles
            int maxNestedLoop = 0;
            int fors = 0;//for 
            int whiles = 0;//while
            LoopsReport report = new LoopsReport();
            for (int i = 0; i < list.Count; i++)
            {
                if (maxNestedLoop < list[i + 1].NumberOfNestedLoops)
                    maxNestedLoop = list[i + 1].NumberOfNestedLoops;
                dos += list[i + 1].NumberOfDoWhileLoops;
                fors += list[i + 1].NumberOfForLoops;
                whiles += list[i + 1].NumberOfWhileLoops;
            }
            if(maxNestedLoop > 0)
                maxNestedLoop--;//remove main nested loops
            report.NestedLoopValue = Math.Pow(Math.E, maxNestedLoop * -1);
            if (!Statics.Messages.ContainsKey(40))
                Statics.FromulateMassege(40, string.Format("(2.71)^({0})", maxNestedLoop*-1));
            if (fors != 0 || whiles != 0 || dos != 0)
            {
                report.NumberOfDoWhileLoops = dos;
                report.DoWhileLoopsValue = (double)dos / (double)(fors + dos + whiles);
                if(!Statics.Messages.ContainsKey(38))
                    Statics.FromulateMassege(38, string.Format("Number Of Do-While {0} / (Number Of Do-While {0} + Number Of While {1} + Number Of For {2})", dos,whiles,fors));
                report.NumberOfForLoops = fors;
                report.ForLoopsValue = (double)fors / (double)(fors + dos + whiles);
                if (!Statics.Messages.ContainsKey(34))
                    Statics.FromulateMassege(34, string.Format("Number Of For {2} / (Number Of Do-While {0} + Number Of While {1} + Number Of For {2})", dos, whiles, fors));
                report.NumberOfWhileLoops = whiles;
                report.WhileLoopsValue = (double)whiles / (double)(fors + dos + whiles);
                if (!Statics.Messages.ContainsKey(36))
                    Statics.FromulateMassege(36, string.Format("Number Of While {1} / (Number Of Do-While {0} + Number Of While {1} + Number Of For {2})", dos, whiles, fors));
            }
            else
            {
                report.DoWhileLoopsValue = 0;
                report.NumberOfForLoops = fors;
                report.ForLoopsValue = 0;
                report.NumberOfWhileLoops = whiles;
                report.WhileLoopsValue = 0;
                if (!Statics.Messages.ContainsKey(38))
                    Statics.FromulateMassege(38, string.Format("Number Of Do-While {0} / (Number Of Do-While {0} + Number Of While {1} + Number Of For {2})", dos, whiles, fors));
                if (!Statics.Messages.ContainsKey(34))
                    Statics.FromulateMassege(34, string.Format("Number Of For {2} / (Number Of Do-While {0} + Number Of While {1} + Number Of For {2})", dos, whiles, fors));
                if (!Statics.Messages.ContainsKey(36))
                    Statics.FromulateMassege(36, string.Format("Number Of While {1} / (Number Of Do-While {0} + Number Of While {1} + Number Of For {2})", dos, whiles, fors));
            }
            return report;
        }
        private void CheckCode()//set the counts
        {
            _numberOfNestedLoops = 0;
            _numberOfForLoops = 0;
            _numberOfWhileLoops = 0;
            _numberOfDoWhileLoops = 0;
            if (_loopCode == null)
                return;
            //bool first = false;
            for (int i = 0; i < _loopCode.Length; i++)
            {
                if(HasFor(_loopCode[i]))
                {
                    _numberOfForLoops++;
                }
                if (HasWhile(_loopCode[i]))
                {
                    _numberOfWhileLoops++;
                }
                if (HasDo(_loopCode[i]))
                {
                    _numberOfDoWhileLoops++;
                }
            }
            if(_numberOfWhileLoops != 0 && _numberOfDoWhileLoops != 0)
                _numberOfWhileLoops -= _numberOfDoWhileLoops;
            _numberOfNestedLoops = _numberOfWhileLoops+_numberOfForLoops+_numberOfDoWhileLoops;
        }
        private bool HasFor(string line)
        {
            return (line.Contains("for ") || line.Contains("for("));
        }
        private bool HasWhile(string line)
        {
            return ((line.Contains("while ") || line.Contains("while(")));
        }
        private bool HasDo(string line)
        {
            return (line.Contains("do ") || line.Contains("do{") || (line.Contains("do") && line.Length == line.IndexOf("do") + 2) || (line.IndexOf("do") == 0 && line.Length == 2));
        }

        public int NumberOfLoops
        {
            get { return _numberOfForLoops+_numberOfWhileLoops+_numberOfDoWhileLoops; }
        }
    }
}
