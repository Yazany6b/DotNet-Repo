
namespace Simple_Code_Editor
{
    public class SearchPerformer
    {
        public static bool IgnoreCase = false;
        public static System.Collections.Generic.List<Match> SearchText(System.String text, System.Collections.Generic.List<Keyword> _keywords)
        {
            System.Collections.Generic.List<Match> list = new System.Collections.Generic.List<Match>();
            int look = -1;
            for (int i = 0; i < _keywords.Count; i++)
            {
                for (int ii = 0; ii < text.Length; ii++)
                {
                    if (text[ii] == _keywords[i].Text[look + 1])
                        look++;
                    else
						{
							look = -1;
                            continue;
						}
                    if (_keywords[i].Text.Length == look + 1)
                    {
                        if (AcceptedMatch(ii - look, look + 1, text))
                            list.Add(new Match(ii - look, look + 1, _keywords[i].Text, (int)_keywords[i].Type));
                        look = -1;
                    }
                }
            }
            return list;
        }

        public static System.Collections.Generic.List<Match> SearchTextCaseIgnored(System.String text, System.Collections.Generic.List<Keyword> _keywords)
        {
            System.Collections.Generic.List<Match> list = new System.Collections.Generic.List<Match>();
            int look = -1;
            for (int i = 0; i < _keywords.Count; i++)
            {
                for (int ii = 0; ii < text.Length; ii++)
                {
                    if (char.ToLower(text[ii]) == char.ToLower(_keywords[i].Text[look + 1]))
                        look++;
                    else
                    {
                        look = -1;
                        continue;
                    }
                    if (_keywords[i].Text.Length == look + 1)
                    {
                        if (AcceptedMatch(ii - look, look + 1, text))
                            list.Add(new Match(ii - look, look + 1, _keywords[i].Text, (int)_keywords[i].Type));
                        look = -1;
                    }
                }
            }
            return list;
        }

        public static System.Collections.Generic.List<Match> SearchTextCaseIgnored(System.String text, System.Collections.Generic.List<Keyword> _keywords,int start,int end)
        {
            System.Collections.Generic.List<Match> list = new System.Collections.Generic.List<Match>();
            int look = -1;
            for (int i = 0; i < _keywords.Count; i++)
            {
                for (int ii = start; ii < end; ii++)
                {
                    if (char.ToLower(text[ii]) == char.ToLower(_keywords[i].Text[look + 1]))
                        look++;
                    else
                        look = -1;
                    if (_keywords[i].Text.Length == look + 1)
                    {
                        if (AcceptedMatch(ii - look, look + 1, text))
                            list.Add(new Match(ii - look, look + 1, _keywords[i].Text, (int)_keywords[i].Type));
                        look = -1;
                    }
                }
            }
            return list;
        }


        public static System.Collections.Generic.List<Match> SearchText(System.String text, System.Collections.Generic.List<Keyword> _keywords, int start, int end)
        {
            System.Collections.Generic.List<Match> list = new System.Collections.Generic.List<Match>();
            int look = -1;
            for (int i = 0; i < _keywords.Count; i++)
            {
                look = -1;
                for (int ii = start; ii < end; ii++)
                {
                    if (text[ii] == _keywords[i].Text[look + 1])
                        look++;
                    else
                    {
                        look = -1;
                        continue;
                    }
                    if (_keywords[i].Text.Length == look + 1)
                    {
                        if (AcceptedMatch(ii - look, look + 1, text))
                            list.Add(new Match(ii - look, look + 1, _keywords[i].Text, (int)_keywords[i].Type));
                        look = -1;
                    }
                }
            }
            return list;
        }


        private static bool Equal(System.String keyword, int start, System.String text)
        {
            if (start + keyword.Length + 1 >= text.Length)
                return false;
            for (int i = start; i < (keyword.Length + start); i++)
                if (keyword[i - start] != text[i])
                    return false;
            return true;
        }

        public static System.Collections.Generic.List<Match> SearchText(System.String text, Expression exp)
        {
            System.Collections.Generic.List<Match> list = new System.Collections.Generic.List<Match>();
            bool inExp = false;
            int start = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (!inExp)
                {
                    if (Equal(exp.startSymbol, i, text))
                    {
                        start = i;
                        inExp = true;
                    }
                }
                else
                {
                    if (Equal(exp.endSymbol, i, text))
                    {
                        list.Add(new Match(start, (i - start) + 1, ""));
                        inExp = false;
                    }
                }
            }
            return list;
        }

        public static System.Collections.Generic.List<Match> SearchText(System.String text, Expression exp, int start, int end)
        {
            System.Collections.Generic.List<Match> list = new System.Collections.Generic.List<Match>();
            bool inExp = false;
            int inStart = 0;
            for (int i = start; i < end; i++)
            {
                if (!inExp)
                {
                    if (Equal(exp.startSymbol, i, text))
                    {
                        inStart = i;
                        inExp = true;
                    }
                }
                else
                {
                    if (Equal(exp.endSymbol, i, text))
                    {
                        list.Add(new Match(inStart, (i - inStart), ""));
                        inExp = false;
                    }
                }
            }
            return list;
        }

        private static bool IsNumber(char ch)
        {
            if ((int)ch >= 48 || (int)ch <= 57)
                return true;
            return false;
        }
        public static System.Collections.Generic.List<Match> SearchTextForNumbers(System.String text)
        {
            System.Collections.Generic.List<Match> list = new System.Collections.Generic.List<Match>();
            int look = -1;
            for (int ii = 0; ii < text.Length; ii++)
            {
                if (IsNumber(text[ii]))
                    look++;
                else
                    look = -1;
                if (look != -1)
                {
                    //								 list.Add(new Match(ii - look,look+1,_keywords[i].Text));
                    look = -1;
                }
            }
            return list;
        }

        public static int Attachable(char ch)
        {
            if (char.IsWhiteSpace(ch))
                return 1;
            int value = (int)ch;
            if ((value >= 65 && value <= 90) || (value >= 97 && value <= 122) || (value >= 48 && value <= 57) || value == 95)
                return 0;
            return 1;
        }

        public static bool AcceptedMatch(Match match, string text)
        {
            int accepted = 0;
            if (match.Index - 1 >= 0)
                accepted += Attachable(text[match.Index - 1]);
            else
                accepted++;
            if ((match.Index + match.Length) < text.Length)
                accepted += Attachable(text[(match.Index + match.Length)]);
            else
                accepted++;
            return accepted == 2;
        }
        public static bool AcceptedMatch(int index, int length, string text)
        {
            int accepted = 0;
            if (index - 1 >= 0)
                accepted += Attachable(text[index - 1]);
            else
                accepted++;
            if ((index + length) < text.Length)
                accepted += Attachable(text[(index + length)]);
            else
                accepted++;
            return accepted == 2;
        }
    }
}