
namespace YazanLib.Controls
{

    public class AdvancedRichTextBox : XRichTextBox
    {
        private System.Collections.Generic.List<Simple_Code_Editor.Keyword> _keywords;
        private System.Drawing.Color _commentsColor;
        private System.Drawing.Color _quotationColor;
        private System.Drawing.Font _font;
        private char _firstQuotationCharacter;
        private char _secondQuotationCharacter;
        private string _normalCommentSymbol;
        private System.Windows.Forms.RichTextBoxFinds _rules = System.Windows.Forms.RichTextBoxFinds.MatchCase | System.Windows.Forms.RichTextBoxFinds.WholeWord;
        private bool textPasted = false;
        private int selectionAtPaste = 0;
        private int ProcessingStart = 0;
        private int ProcessingEnd = 0;
        //public event System.EventHandler TextPaste;
        public AdvancedRichTextBox()
        {
            WordWrap = false;
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
        /*
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == 0x00f)
            {
                if (paint)
                    base.WndProc(ref m);
                else
                    m.Result = System.IntPtr.Zero;
            }
            else
                base.WndProc(ref m);

        }
         
        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 22)
            {
                textPasted = true;
                if (TextPaste != null)
                    TextPaste(this, new System.EventArgs());
                OnTextPaste(e);
            }
        }

        protected override void OnPreviewKeyDown(System.Windows.Forms.PreviewKeyDownEventArgs e)
        {
            if (e.Control)
                selectionAtPaste = SelectionStart;
        }

        protected virtual void OnTextPaste(System.EventArgs e)
        {
            ProcessingStart = selectionAtPaste;
            ProcessingEnd = SelectionStart;
            textPasted = true;
            ProcessQuotationAndComments();
            ColoringText();
            textPasted = false;
        }
        */
        protected override void OnTextManipulationKeyPressed(TextManipulationKeyEventArgs e)
        {
            switch (e.Key)
            {
                case CtrlKey.Ctrl_V:
                    ProcessingStart = e.ManipulationStart;
                    ProcessingEnd = e.ManipulationEnd;
                    ProcessQuotationAndComments();
                    ColoringText();
                    break;
            }
        }

        protected override void OnTextChanged(System.EventArgs e)
        {
            if (Text.Length > 1 && _keywords != null)
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
                if (Text[i-1] == ' ')
                    return i;
                if (Text[i-1] == '\n')
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
                    return i-1;
                if (i + 1 == Text.Length)
                    return i;
            }
            return -1;
        }

        private int GetStartLookingIndex()
        {
            for (int i = SelectionStart-1; i > 0; i--)
                if (Text[i] == ' ' && i != SelectionStart-1)
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
                    if (find_at != -1)
                    {
                        SelectionStart = find_at;
                        SelectionLength = _keywords[i].Text.Length;
                        if (SelectionColor != _quotationColor && SelectionColor != _commentsColor)
                        {
                            switch (_keywords[i].Type)
                            {
                                case Simple_Code_Editor.KeywordType.Reseved:
                                    SelectionColor = ResevedColor;
                                    break;
                                case Simple_Code_Editor.KeywordType.Function:
                                    SelectionColor = FunctionColor;
                                    break;
                                case Simple_Code_Editor.KeywordType.Operator:
                                    if (SelectionColor != FunctionColor)
                                        SelectionColor = OperatorColor;
                                    break;
                                case Simple_Code_Editor.KeywordType.DataType:
                                    SelectionColor = DataTypeColor;
                                    break;
                            }

                            try
                            {
                                SelectionFont = new System.Drawing.Font(_font.Name, Font.Size, _font.Style, _font.Unit);
                            }
                            catch { }
                        }
                        //if (_keywords[i].Text.Length > 1)
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


            PaintControl = true;
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
                if (skip1 || (skip1||skip2))
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

            while (start != -1)
            {
                start = Find(_normalCommentSymbol, start, end, System.Windows.Forms.RichTextBoxFinds.MatchCase);
                if (start != -1)
                {
                    SelectionStart = start;
                    SelectionLength = end - start;
                    SelectionColor = _commentsColor;
                    SelectionStart = 0;
                    SelectionLength = 0;
                    start += end - start;
                }
                if (ProcessingEnd != Text.Length)
                    break;
            }
            SelectionStart = currentSelection;
            SelectionLength = 0;
            SelectionColor = currentColor;

            PaintControl = true;
        }

        public void PasteText(string Text)
        {
            selectionAtPaste = SelectionStart;
            SelectedText = Text;
            OnTextManipulationKeyPressed(new TextManipulationKeyEventArgs(System.Windows.Forms.Clipboard.GetText(),selectionAtPaste,selectionAtPaste +System.Windows.Forms.Clipboard.GetText().Length,TextManipulationTypes.Pasted));
        }

        public void ResetColors()
        {
            ProcessingStart = 0;
            ProcessingEnd = Text.Length;
            ProcessQuotationAndComments();
            ColoringText();
        }


        public void ProcessAllText()
        {
            if(_keywords != null)
                if (_keywords.Count == 0)
                    return;
            if (Text.Length == 0)
                return;

            ProcessingStart = 0;
            ProcessingEnd = Text.Length;

            ProcessQuotationAndComments();
            ColoringText();

            ProcessingStart = 0;
            ProcessingEnd = 0;
        }



        public System.Collections.Generic.List<Simple_Code_Editor.Keyword> Keywords
        {
            get { return _keywords; }
            set { _keywords = value; }
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
