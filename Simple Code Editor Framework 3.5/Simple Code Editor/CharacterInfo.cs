using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simple_Code_Editor
{
    [Serializable]
    public class CharacterInfo
    {
        public CharacterInfo(char ch, int index, int type)
        {
            Character = ch;
            Index = index;
            Type = type;
        }
        public char Character { get; set; }
        public int Index { get; set; }
        public int Type { get; set; }
    }
}
