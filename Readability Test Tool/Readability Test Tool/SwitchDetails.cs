using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Readability_Test_Tool
{
    public class SwitchDetails
    {
        public string [] SwitchCode
        {
            get;
            set;
        }

        public int SwitchLinesCount
        {
            get { return NumberLinesOfCode(); }
        }

        public int NumberLinesOfCode()
        {
            int count = 0;
            if (SwitchCode == null)
                return 0;
            bool main = true;
            for (int i = 0; i < SwitchCode.Length; i++)
            {
                if (SwitchCode[i].Trim() != string.Empty)
                {
                    if (Statics.HasSwitch(SwitchCode[i])&&main)
                    {
                        main = false;
                        continue;
                    }
                    if (SwitchCode[i].Trim() != "{" && SwitchCode[i].Trim() != "}" && SwitchCode[i].Trim() != string.Empty)
                        count++;
                }
            }
            return count;
        }
    }
}
