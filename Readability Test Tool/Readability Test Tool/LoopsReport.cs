using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Readability_Test_Tool
{
    /// <summary>
    /// Containes all readability values that needed to generate the readability resulte  
    /// </summary>
    public class LoopsReport
    {
        /// <summary>
        /// Gets or sets the number of while loops int the code
        /// </summary>
        public int NumberOfWhileLoops
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the number of while loops int the code
        /// </summary>
        public double WhileLoopsValue
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the number of do-while loops int the code
        /// </summary>
        public int NumberOfDoWhileLoops
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the number of do-while loops int the code
        /// </summary>
        public double DoWhileLoopsValue
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the number of for loops int the code
        /// </summary>
        public int NumberOfForLoops
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the number of for loops int the code
        /// </summary>
        public double ForLoopsValue
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the number of nested loops int the code
        /// </summary>
        public int NumberNestedLoops
        {
            get;
            set;
        }

        public double NestedLoopsValue
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the readability value
        /// </summary>
        public double ReadabilityValue
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the max nested loop
        /// </summary>
        public double NestedLoopValue
        {
            get;
            set;
        }
    }
}
