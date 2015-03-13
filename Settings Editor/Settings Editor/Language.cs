using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simple_Code_Editor
{
    [System.Serializable]
    public class Language
    {
        public Language()
        {
            Keywords = new List<Keyword>();
            KeywordsColors = new Dictionary<KeywordType, System.Drawing.Color>();
        }

        public List<Keyword> Keywords
        {
            get;
            set;
        }

        public Dictionary<KeywordType, System.Drawing.Color> KeywordsColors
        {
            get;
            set;
        }

        public System.Drawing.Font KeywordsFont
        {
            get;
            set;
        }

        public String CommentsSymbol
        {
            get;
            set;
        }

        public char FirstQuotationsCharacter
        {
            get;
            set;
        }

        public char SecondQuotationsCharacter
        {
            get;
            set;
        }

        public char SkipQuotationsCharacter
        {
            get;
            set;
        }

        public bool HasSkipQuotationsCharacter
        {
            get;
            set;
        }

        public System.Drawing.Color CommentsColor
        {
            get;
            set;
        }

        public System.Drawing.Color QuotationsColor
        {
            get;
            set;
        }

        public System.Windows.Forms.RichTextBoxFinds Rules
        {
            get;
            set;
        }

    }
}
