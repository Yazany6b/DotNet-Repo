
namespace Simple_Code_Editor
{

    public class AdvancedRichTextBox : XRichTextBox
    {
        private System.Collections.Generic.List<Keyword> _keywords;
        private System.Drawing.Color _commentsColor;
        private System.Drawing.Color _quotationColor;
        private System.Drawing.Font _font;
        private char _firstQuotationCharacter;
        private char _secondQuotationCharacter;
        private string _normalCommentSymbol;
        System.Collections.Generic.List<Match> keyword_matchs;
        System.Collections.Generic.List<Match> first_quotation_matchs;
        System.Collections.Generic.List<Match> comments_matchs;
        System.Collections.Generic.List<Match> second_quotation_matchs;
        private System.Windows.Forms.RichTextBoxFinds _rules = System.Windows.Forms.RichTextBoxFinds.MatchCase | System.Windows.Forms.RichTextBoxFinds.WholeWord;
        private bool textPasted = false;
        private bool IgnorePaint = false;
        private int selectionAtPaste = 0;
        private int ProcessingStart = 0;
        private int ProcessingEnd = 0;
        private ContantMenu menu;
        private System.Drawing.Point _parentLocation = new System.Drawing.Point(0, 0);
        int wordStart = 0;
        //public event System.EventHandler TextPaste;
        public AdvancedRichTextBox()
        {
            WordWrap = false;
            StopColoring = false;
            ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            _font = this.Font;
            AcceptsTab = true;
            _firstQuotationCharacter = '"';
            _secondQuotationCharacter = '\'';
            _normalCommentSymbol = "--";
            _quotationColor = System.Drawing.Color.Red;
            _commentsColor = System.Drawing.Color.Green;
            ResevedColor = System.Drawing.Color.Blue;
            OperatorColor = System.Drawing.Color.DarkOrange;
            DataTypeColor = System.Drawing.Color.Cyan;
            FunctionColor = System.Drawing.Color.Navy;
        }

        private void SetupContantMenu()
        {
            if (menu != null)
            {
                menu.Dispose();
            }
            menu = new ContantMenu(ref _keywords);
            menu.KeyPressHandler = new System.Windows.Forms.KeyPressEventHandler(ContantMenuKeyPressHandler);
        }
        private string SubString(int from, int to)
        {
            string temp = "";
            for (int i = from; i <= to; i++)
                temp += Text[i];
            return temp;
        }
        private void ShowContantMenu(int from, int to)
        {
            if (from == to - 1 || from > to - 1)
                return;
            menu.FillListWith(SubString(from, to - 1).Trim());
            _parentLocation = MainWindow.CurrentLocation;
            _parentLocation = new System.Drawing.Point(_parentLocation.X + this.Location.X, _parentLocation.Y + this.Location.Y);
            menu.Location = new System.Drawing.Point(_parentLocation.X + ((to) * ((int)Font.SizeInPoints / 2)), _parentLocation.Y + ((GetLineFromCharIndex(from)) * (int)Font.SizeInPoints));
            menu.Show();
            Focus();
        }

        private void ContantMenuKeyPressHandler(object o, System.Windows.Forms.KeyPressEventArgs e)
        {

        }

        protected override void OnSpacePressed()
        {
            if (menu != null)
                menu.Hide();
            wordStart = SelectionStart;
        }

        protected override void OnArrowUpDownKeyPressed(int code)
        {
            menu.PutInFocus();
        }

        protected override void OnTextManipulationKeyPressed(TextManipulationKeyEventArgs e)
        {

            switch (e.Key)
            {
                case CtrlKey.Ctrl_V:
                    ProcessingStart = e.ManipulationStart;
                    ProcessingEnd = e.ManipulationEnd;
                    ProcessAllText(e.ManipulationStart, e.ManipulationEnd);
                    break;
            }
        }

        protected override void OnTextChanged(System.EventArgs e)
        {
            if (StopColoring)
                return;
            //SelectionTabs
            //ShowContantMenu(wordStart, SelectionStart);
            if (Text.Length > 1 && SelectionStart > 0 && _keywords != null)
            {
                if (!textPasted)
                {
                    ProcessingStart = GetCurrentLineStart();
                    ProcessingEnd = GetCurrentLineEnd();
                    ProcessQuotationAndComments();
                    ColoringText();
                }
            }
        }

        public void Reinitialize()
        {
            PaintControl = false;

            int selection = SelectionStart;
            SelectAll();
            SelectionColor = ForeColor;
            SelectionLength = 0;
            SelectionStart = selection;

            PaintControl = true;
        }

        private int FirstSpaceBeforeIndex(int index)
        {
            for (int i = index; i > 0; i--)
            {
                if (Text[i - 1] == ' ')
                    return i;
                if (Text[i - 1] == '\n')
                    return i - 1;
                if (i - 1 == 0)
                    return i;
            }
            return -1;
        }

        private int FirstSpaceAfterIndex(int index)
        {
            for (int i = index - 1; i < Text.Length; i++)
            {
                if (Text[i] == ' ')
                    return i;
                if (Text[i] == '\n')
                    return i - 1;
                if (i + 1 == Text.Length)
                    return i;
            }
            return -1;
        }

        private int GetStartLookingIndex()
        {
            for (int i = SelectionStart - 1; i > 0; i--)
                if (Text[i] == ' ' && i != SelectionStart - 1)
                    return i;
            return 0;
        }

        private int GetEndLookingIndex()
        {
            for (int i = SelectionStart; i < Text.Length; i++)
                if (Text[i] == ' ' && i != SelectionStart)
                    return i;
            return Text.Length;
        }

        private int GetCurrentLineStart()
        {
            for (int i = SelectionStart - 1; i > 0; i--)
                if (Text[i] == '\n')
                    return i;
            return 0;
        }

        private int GetCurrentLineEnd()
        {
            for (int i = SelectionStart; i < Text.Length; i++)
                if (Text[i] == '\n')
                    return i;
            return Text.Length;
        }
        private Keyword WordType(string word)
        {
            foreach (Keyword key in _keywords)
            {
                if (_rules == System.Windows.Forms.RichTextBoxFinds.MatchCase)
                {
                    if (key.Text.Trim() == word.Trim())
                        return key;
                }
                else
                {
                    if (key.Text.Trim().Equals(word.Trim(), System.StringComparison.OrdinalIgnoreCase))
                        return key;
                }
            }
            return null;
        }
        public void SetText(string text)
        {
            if (StopColoring)
                return;
            ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            int selection = SelectionStart;
            PaintControl = false;
            textPasted = true;
            this.Text = text;
            SelectAll();
            SelectionColor = ForeColor;
            SelectionFont = Font;
            if(_rules.HasFlag(System.Windows.Forms.RichTextBoxFinds.MatchCase))
                 keyword_matchs= SearchPerformer.SearchText(Text, _keywords);
            else
                keyword_matchs= SearchPerformer.SearchTextCaseIgnored(Text, _keywords);
            first_quotation_matchs = SearchPerformer.SearchText(Text, new Expression(_firstQuotationCharacter.ToString(),_firstQuotationCharacter.ToString()));
            second_quotation_matchs = SearchPerformer.SearchText(Text, new Expression(_secondQuotationCharacter.ToString(), _secondQuotationCharacter.ToString()));
            comments_matchs = SearchPerformer.SearchText(Text, new Expression(_normalCommentSymbol.ToString(), "\n"));
            foreach (Match match in keyword_matchs)
            {
                Select(match.Index, match.Length);
                switch ((KeywordType)match.Type)
                {
                    case KeywordType.Reseved:
                        SelectionColor = ResevedColor;
                        break;
                    case KeywordType.Function:
                        SelectionColor = FunctionColor;
                        break;
                    case KeywordType.DataType:
                        SelectionColor = DataTypeColor;
                        break;
                    case KeywordType.Operator:
                        SelectionColor = OperatorColor;
                        break;
                }
                SelectionFont = new System.Drawing.Font(_font.Name, Font.Size, _font.Style);
                SelectionLength = 0;
            }
            foreach (Match match in first_quotation_matchs)
            {
                Select(match.Index, match.Length);
                SelectionColor = _quotationColor;
                SelectionLength = 0;
            }

            foreach (Match match in second_quotation_matchs)
            {
                Select(match.Index, match.Length);
                SelectionColor = _quotationColor;
                SelectionLength = 0;
            }

            foreach (Match match in comments_matchs)
            {
                Select(match.Index, 2);
                if (SelectionColor != _quotationColor)
                {
                    Select(match.Index, match.Length);
                    SelectionColor = _commentsColor;
                }
                SelectionLength = 0;
            }
            SelectionStart = selection;
            SelectionLength = 0;
            SelectionFont = Font;
            SelectionColor = ForeColor;
            ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            textPasted = false;
            PaintControl = true;
        }
        private void ColoringText()
        {
            if (_keywords.Count == 0)
                return;

            int currentSelection = SelectionStart;
            System.Drawing.Color currentColor = SelectionColor;
            int start = ProcessingStart;
            int end = ProcessingEnd;
            PaintControl = false;
            int find_at = start;
            for (int i = 0; i < _keywords.Count; i++)
            {
                if (_keywords[i].Text.Length < 2)
                    continue;
                find_at = start;
                while (find_at != -1)
                {
                    find_at = Find(_keywords[i].Text, find_at, end, _rules);
                    if (find_at > 0)
                        if (Text[find_at - 1] == '_')
                        {
                            find_at += _keywords[i].Text.Length - 1;
                            continue;
                        }
                        else
                        {
                            if (SelectionStart == Text.Length)
                                if (Text[find_at + (_keywords[i].Text.Length)] == '_')
                                {
                                    find_at += _keywords[i].Text.Length - 1;
                                    continue;
                                }
                        }
                    if (find_at != -1)
                    {
                        if (SelectionColor != _quotationColor && SelectionColor != _commentsColor)
                        {
                            switch (_keywords[i].Type)
                            {
                                case KeywordType.Reseved:
                                    SelectionColor = ResevedColor;
                                    break;
                                case KeywordType.Function:
                                    SelectionColor = FunctionColor;
                                    break;
                                case KeywordType.Operator:
                                    if (SelectionColor != FunctionColor)
                                        SelectionColor = OperatorColor;
                                    break;
                                case KeywordType.DataType:
                                    SelectionColor = DataTypeColor;
                                    break;
                            }

                            try
                            {
                                SelectionFont = new System.Drawing.Font(_font.Name, Font.Size, _font.Style, _font.Unit);
                            }
                            catch { }
                        }
                        find_at += _keywords[i].Text.Length - 1;
                    }
                    else
                        break;
                }
            }
            SelectionStart = currentSelection;
            SelectionLength = 0;
            SelectionColor = ForeColor;
            SelectionFont = Font;
            PaintControl = !IgnorePaint;
        }

        private void ProcessQuotationAndComments()
        {
            PaintControl = false;
            int start = ProcessingStart;
            int end = ProcessingEnd;
            bool skip1 = false;
            bool skip2 = false;
            bool found = false;
            int length = 0;
            int currentSelection = SelectionStart;
            System.Drawing.Color currentColor = SelectionColor;
            SelectionStart = start;
            SelectionLength = end - start;
            SelectionColor = ForeColor;
            SelectionFont = Font;
            for (int i = start; i < end; i++)
            {
                if (Text[i] == _secondQuotationCharacter && !skip1)
                {
                    if (i != 0)
                    {
                        if (Text[i - 1] != '\\')
                        {
                            if (!skip2)
                            {
                                length = 0;
                                SelectionStart = i;
                            }
                            skip2 = !skip2;
                            found = true;
                            length++;
                            continue;
                        }
                    }
                    else
                    {
                        if (!skip2)
                        {
                            length = 0;
                            SelectionStart = i;
                        }
                        skip2 = !skip2;
                        found = true;
                        length++;
                        continue;
                    }
                }
                if (Text[i] == _firstQuotationCharacter)
                {
                    if (i != 0)
                    {
                        if (Text[i - 1] != '\\')
                        {
                            if (!skip1)
                            {
                                length = 0;
                                SelectionStart = i;
                            }
                            skip1 = !skip1;
                            found = true;
                            length++;
                            continue;
                        }
                    }
                    else
                    {
                        if (!skip1)
                        {
                            length = 0;
                            SelectionStart = i;
                        }
                        skip1 = !skip1;
                        found = true;
                        length++;
                        continue;
                    }
                }
                if (skip1 || (skip1 || skip2))
                {
                    length++;
                    continue;
                }
                if (found)
                {
                    start = i;
                    SelectionLength = length;
                    SelectionColor = _quotationColor;
                    found = false;
                }
            }
            if (found && skip1)
            {
                SelectionLength = end - SelectionStart;
                SelectionColor = _quotationColor;
            }
            start = ProcessingStart;
            end = ProcessingEnd;
            start = Find(_normalCommentSymbol, start, end, System.Windows.Forms.RichTextBoxFinds.None);
            if (start != -1)
            {
                SelectionStart = start;
                SelectionLength = end - start;
                SelectionColor = _commentsColor;
                SelectionStart = 0;
                SelectionLength = 0;
                start += end - start;
            }
            SelectionStart = currentSelection;
            SelectionLength = 0;
            SelectionColor = currentColor;
            PaintControl = !IgnorePaint;
        }

        public void PasteText(string Text)
        {
            selectionAtPaste = SelectionStart;
            SelectedText = Text;
            OnTextManipulationKeyPressed(new TextManipulationKeyEventArgs(System.Windows.Forms.Clipboard.GetText(), selectionAtPaste, selectionAtPaste + System.Windows.Forms.Clipboard.GetText().Length, TextManipulationTypes.Pasted));
        }

        public void ResetColors()
        {
            if (StopColoring)
                return;
            ProcessAllText();
        }

        public void ReperformKeywordsMatch()
        {
            if (StopColoring)
                return;
            int selection = SelectionStart;
            PaintControl = false;
            textPasted = true;

            if (_rules.HasFlag(System.Windows.Forms.RichTextBoxFinds.MatchCase))
                keyword_matchs = SearchPerformer.SearchText(Text, _keywords);
            else
                keyword_matchs = SearchPerformer.SearchTextCaseIgnored(Text, _keywords);
            foreach (Match match in keyword_matchs)
            {
                Select(match.Index, match.Length);
                switch ((KeywordType)match.Type)
                {
                    case KeywordType.Reseved:
                        SelectionColor = ResevedColor;
                        break;
                    case KeywordType.Function:
                        SelectionColor = FunctionColor;
                        break;
                    case KeywordType.DataType:
                        SelectionColor = DataTypeColor;
                        break;
                    case KeywordType.Operator:
                        SelectionColor = OperatorColor;
                        break;
                }
                SelectionFont = new System.Drawing.Font(_font.Name, Font.Size, _font.Style);
                SelectionLength = 0;
            }
            SelectionStart = selection;
            SelectionLength = 0;
            PaintControl = true;
        }

        public void ReperformQuotationsMatch()
        {
            if (StopColoring)
                return;
            PaintControl = false;
            first_quotation_matchs = SearchPerformer.SearchText(Text, new Expression(_firstQuotationCharacter.ToString(), _firstQuotationCharacter.ToString()));
            second_quotation_matchs = SearchPerformer.SearchText(Text, new Expression(_secondQuotationCharacter.ToString(), _secondQuotationCharacter.ToString()));
            foreach (Match match in first_quotation_matchs)
            {
                Select(match.Index, match.Length);
                SelectionColor = _quotationColor;
                SelectionLength = 0;
            }

            foreach (Match match in second_quotation_matchs)
            {
                Select(match.Index, match.Length);
                SelectionColor = _quotationColor;
                SelectionLength = 0;
            }

            PaintControl = true;
        }

        public void ReperformCommentsMatch()
        {
            if (StopColoring)
                return;
            PaintControl = false;
            comments_matchs = SearchPerformer.SearchText(Text, new Expression(_normalCommentSymbol.ToString(), "\n"));

            foreach (Match match in comments_matchs)
            {
                Select(match.Index, match.Length);
                SelectionColor = _commentsColor;
                SelectionLength = 0;
            }

            PaintControl = true;
        }
        public void ProcessAllText()
        {
            if (StopColoring)
                return;
            if (_keywords != null)
                if (_keywords.Count == 0)
                    return;
            if (Text.Length == 0)
                return;
            ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            int selection = SelectionStart;
            PaintControl = false;
            textPasted = true;
            SelectAll();
            SelectionColor = ForeColor;
            SelectionFont = Font;
            if (_rules.HasFlag(System.Windows.Forms.RichTextBoxFinds.MatchCase))
                keyword_matchs = SearchPerformer.SearchText(Text, _keywords);
            else
                keyword_matchs = SearchPerformer.SearchTextCaseIgnored(Text, _keywords);
            first_quotation_matchs = SearchPerformer.SearchText(Text, new Expression(_firstQuotationCharacter.ToString(), _firstQuotationCharacter.ToString()));
            second_quotation_matchs = SearchPerformer.SearchText(Text, new Expression(_secondQuotationCharacter.ToString(), _secondQuotationCharacter.ToString()));
            comments_matchs = SearchPerformer.SearchText(Text, new Expression(_normalCommentSymbol.ToString(), "\n"));
            foreach (Match match in keyword_matchs)
            {
                Select(match.Index, match.Length);
                switch ((KeywordType)match.Type)
                {
                    case KeywordType.Reseved:
                        SelectionColor = ResevedColor;
                        break;
                    case KeywordType.Function:
                        SelectionColor = FunctionColor;
                        break;
                    case KeywordType.DataType:
                        SelectionColor = DataTypeColor;
                        break;
                    case KeywordType.Operator:
                        SelectionColor = OperatorColor;
                        break;
                }
                SelectionFont = new System.Drawing.Font(_font.Name, Font.Size, _font.Style);
                SelectionLength = 0;
            }
            foreach (Match match in first_quotation_matchs)
            {
                Select(match.Index, match.Length);
                SelectionColor = _quotationColor;
                SelectionLength = 0;
            }

            foreach (Match match in second_quotation_matchs)
            {
                Select(match.Index, match.Length);
                SelectionColor = _quotationColor;
                SelectionLength = 0;
            }

            foreach (Match match in comments_matchs)
            {
                Select(match.Index, 2);
                if (SelectionColor != _quotationColor)
                {
                    Select(match.Index, match.Length);
                    SelectionColor = _commentsColor;
                }
                SelectionLength = 0;
            }

            SelectionStart = selection;
            SelectionLength = 0;
            SelectionFont = Font;
            SelectionColor = ForeColor;
            ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            textPasted = false;
            PaintControl = true;
        }
        public void ProcessAllText(int start,int end)
        {
            if (StopColoring)
                return;
            if (_keywords != null)
                if (_keywords.Count == 0)
                    return;
            if (Text.Length == 0)
                return;
            ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            int selection = SelectionStart;
            PaintControl = false;
            textPasted = true;
            SelectAll();
            SelectionColor = ForeColor;
            SelectionFont = Font;
            if (_rules.HasFlag(System.Windows.Forms.RichTextBoxFinds.MatchCase))
                keyword_matchs = SearchPerformer.SearchText(Text, _keywords,start,end);
            else
                keyword_matchs = SearchPerformer.SearchTextCaseIgnored(Text, _keywords, start, end);
            first_quotation_matchs = SearchPerformer.SearchText(Text, new Expression(_firstQuotationCharacter.ToString(), _firstQuotationCharacter.ToString()), start, end);
            second_quotation_matchs = SearchPerformer.SearchText(Text, new Expression(_secondQuotationCharacter.ToString(), _secondQuotationCharacter.ToString()), start, end);
            comments_matchs = SearchPerformer.SearchText(Text, new Expression(_normalCommentSymbol.ToString(), "\n"), start, end);
            foreach (Match match in keyword_matchs)
            {
                Select(match.Index, match.Length);
                switch ((KeywordType)match.Type)
                {
                    case KeywordType.Reseved:
                        SelectionColor = ResevedColor;
                        break;
                    case KeywordType.Function:
                        SelectionColor = FunctionColor;
                        break;
                    case KeywordType.DataType:
                        SelectionColor = DataTypeColor;
                        break;
                    case KeywordType.Operator:
                        SelectionColor = OperatorColor;
                        break;
                }
                SelectionFont = new System.Drawing.Font(_font.Name, Font.Size, _font.Style);
                SelectionLength = 0;
            }
            foreach (Match match in first_quotation_matchs)
            {
                Select(match.Index, match.Length);
                SelectionColor = _quotationColor;
                SelectionLength = 0;
            }

            foreach (Match match in second_quotation_matchs)
            {
                Select(match.Index, match.Length);
                SelectionColor = _quotationColor;
                SelectionLength = 0;
            }

            foreach (Match match in comments_matchs)
            {
                Select(match.Index, 2);
                if (SelectionColor != _quotationColor)
                {
                    Select(match.Index, match.Length);
                    SelectionColor = _commentsColor;
                }
                SelectionLength = 0;
            }

            SelectionStart = selection;
            SelectionLength = 0;
            SelectionFont = Font;
            SelectionColor = ForeColor;
            ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            textPasted = false;
            PaintControl = true;

        }

        public System.Collections.Generic.List<Keyword> Keywords
        {
            get { return _keywords; }
            set { _keywords = value; SetupContantMenu(); }
        }

        public System.Drawing.Color CommentsColor
        {
            get { return _commentsColor; }
            set { _commentsColor = value; }
        }

        public System.Drawing.Color QuotationColor
        {
            get { return _quotationColor; }
            set { _quotationColor = value; }
        }

        public System.Drawing.Font KeywordsFont
        {
            get { return _font; }
            set { _font = value; }
        }

        public System.Windows.Forms.RichTextBoxFinds Rules
        {
            get { return _rules; }
            set { _rules = value; }
        }

        public char FirstQuotationCharacter
        {
            get { return _firstQuotationCharacter; }
            set { _firstQuotationCharacter = value; }
        }

        public char SecondQuotationCharacter
        {
            get { return _secondQuotationCharacter; }
            set { _secondQuotationCharacter = value; }
        }

        public string NormalCommentSymbol
        {
            get { return _normalCommentSymbol; }
            set { _normalCommentSymbol = value; }
        }

        public System.Drawing.Color ResevedColor
        {
            get;
            set;
        }
        public System.Drawing.Color DataTypeColor
        {
            get;
            set;
        }
        public System.Drawing.Color OperatorColor
        {
            get;
            set;
        }
        public System.Drawing.Color FunctionColor
        {
            get;
            set;
        }

        public System.Drawing.Point ParentLocation
        {
            set { _parentLocation = value; }
        }

        public bool StopColoring
        {
            get;
            set;
        }
        /*
        public string OpenCommentSymbol
        {
            get { return _openCommentSymbol; }
            set { _openCommentSymbol = value; }
        }

        public string CloseCommentSymbol
        {
            get { return _closeCommentSymbol; }
            set { _closeCommentSymbol = value; }
        }
         */
    }
}
