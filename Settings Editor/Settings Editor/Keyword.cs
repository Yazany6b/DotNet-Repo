using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simple_Code_Editor
{
    public enum KeywordType
    {
        Reseved,
        Function,
        Operator,
        DataType
    }
    [System.Serializable]
    public class Keyword
    {
        public Keyword(string keyword,KeywordType type)
        {
            Text = keyword;
            Type = type;
        }
        public Keyword(string keyword)
        {
            Text = keyword;
            Type = KeywordType.Reseved;
        }
        public string Text
        {
            get;
            set;
        }

        public KeywordType Type
        {
            get;
            set;
        }
    }
}
