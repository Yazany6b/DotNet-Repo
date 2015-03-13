using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Readability_Test_Tool
{
    public class IfDetails
    {
        public string[] Code
        {
            get;
            set;
        }

        private bool isIfElse()
        {
            if (Code == null)
                return false;
            for (int i = 0; i < Code.Length; i++)
                if (HasElse(i))
                    return true;
            return false;
        }
        private bool isNestedIf()
        {
            if (Code == null)
                return false;
            for (int i = 1; i < Code.Length; i++)
                if (HasIf(i))
                    return true;
            return false;
        }

        private int GetNumberOfNestedLoops()
        {
            int count = 0;
            if (Code == null)
                return 0;
            for (int i = 0; i < Code.Length; i++)
                if (HasIf(i))
                    count++;
            return count;
        }
        private int ComputeNumberOfIfs()
        {
            int count = 0;
            if (Code == null)
                return 0;
            for (int i = 0; i < Code.Length; i++)
                if (HasIf(i))
                    count++;
            return count;
        }
        public bool IfElse
        {
            get { return isIfElse(); }
        }

        private bool HasIf(int line)
        {
            return (Code[line].Contains("if ") || Code[line].Contains("if("));
        }
        private bool HasElse(int line)
        {
            return (Code[line].Contains("else ") || Code[line].Contains("else{") || (Code[line].Contains("else") && Code[line].Length == Code[line].IndexOf("else") + 4));
        }

        public bool IsNested
        {
            get { return (GetNumberOfNestedLoops() > 1); }
        }

        public int NumberOfNestedIfs
        {
            get { return GetNumberOfNestedLoops(); }
        }

        public int NumberOfIfs
        {
            get { return ComputeNumberOfIfs(); }
        }
    }
}
