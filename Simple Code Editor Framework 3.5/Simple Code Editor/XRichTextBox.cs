using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simple_Code_Editor
{
    public class XRichTextBox : System.Windows.Forms.RichTextBox
    {
        private int start = 0;
        private System.Collections.Generic.Dictionary<int, TabsInfo> _tabs = new Dictionary<int, TabsInfo>();
        private string LastTab = "";

        public event TextManipulationKeyEventHandler TextManipulationKeyPressed;

        public XRichTextBox()
        {
            PaintControl = true;
        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == 0x00f)
            {
                if (PaintControl)
                    base.WndProc(ref m);
                else
                {
                    //m.Msg = 0;
                    m.Result = System.IntPtr.Zero;
                }
            }
            else
                base.WndProc(ref m);
        }

        public bool PaintControl
        {
            get;
            set;
        }

        protected virtual void OnTextManipulationKeyPressed(TextManipulationKeyEventArgs e)
        {
            if (TextManipulationKeyPressed != null)
                TextManipulationKeyPressed(this, e);
        }
        private int ComputeIndentLength(string line)
        {
            return line.Length - line.TrimStart().Length;
        }
        private bool isTabAble(string text)
        {
            if (text.StartsWith("for"))
                return true;
            if (text.StartsWith("while"))
                return true;
            if (text.StartsWith("loop"))
                return true;
            if (text.StartsWith("do"))
                return true;
            if (text.StartsWith("if"))
                return true;
            if (text.StartsWith("else"))
                return true;
            if (text.StartsWith("elsif"))
                return true;
            if (text.EndsWith("{"))
                return true;
            if (text.EndsWith("("))
                return true;
            if (!text.EndsWith(";") && text != string.Empty)
                return true;
            return false;
        }
        private int GetEndPosition(int start)
        {
            for (int i = start; i < Text.Length; i++)
                if (Text[i] == '\n')
                    return i;
            return -1;
        }

        private int GetFirstLetter(int start)
        {
            for (int i = start; i < Text.Length; i++)
                if (char.IsLetter(Text[i]) || Text[i] == '_')
                    return i;
            return -1;
        }
        private string GetTabs(string text)
        {
            string temp = string.Empty;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == (char)9)
                    temp += text[i];
                else
                    break;
            }
            return temp;
        }

        private int GetTabsCount(string text)
        {
            int count = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == (char)9)
                    count++;
                else
                    break;
            }
            return count;
        }

        protected virtual void OnEnterPressed()
        {
            PaintControl = false;
            int selection = SelectionStart;
            int cIndex = GetFirstCharIndexOfCurrentLine();
            int key = GetLineFromCharIndex(cIndex);
            int index = GetFirstCharIndexFromLine(key - 1);
            if (index >= 0)
            {
                SelectionStart = index;
                int length = GetFirstLetter(index) - index;
                if (length > 0)
                {
                    SelectionLength = length;
                    LastTab = GetTabs(SelectedText);
                    if (Lines[GetLineFromCharIndex(index)].Trim().EndsWith("{") || Lines[GetLineFromCharIndex(index)].Trim().EndsWith("then")
                        || Lines[GetLineFromCharIndex(index)].Trim().EndsWith("loop") || Lines[GetLineFromCharIndex(index)].Trim().EndsWith("elsif") ||
                        Lines[GetLineFromCharIndex(index)].Trim().EndsWith("else") || Lines[GetLineFromCharIndex(index)].Trim().Contains("if"))
                        LastTab += (char)9;
                }
                else
                {
                    if (Lines[GetLineFromCharIndex(index)].Trim() == string.Empty)
                    {
                        string text = GetTabs(Lines[GetLineFromCharIndex(index)]);
                        if (text != string.Empty)
                            LastTab = text;
                    }
                    else
                    {
                        if(Lines[GetLineFromCharIndex(index)].Length>0)
                            if (char.IsLetter(Lines[GetLineFromCharIndex(index)][0]))
                            {
                                if (Lines[GetLineFromCharIndex(index)].Trim().EndsWith("{") || Lines[GetLineFromCharIndex(index)].Trim().EndsWith("then")
                                    || Lines[GetLineFromCharIndex(index)].Trim().EndsWith("loop") || Lines[GetLineFromCharIndex(index)].Trim().EndsWith("elsif") ||
                                    Lines[GetLineFromCharIndex(index)].Trim().EndsWith("else") || Lines[GetLineFromCharIndex(index)].Trim().Contains("if")
                                    || Lines[GetLineFromCharIndex(index)].Trim().Contains("begin") || Lines[GetLineFromCharIndex(index)].Trim().EndsWith("values"))
                                {
                                    LastTab = "";
                                    LastTab += (char)9;
                                }
                            }
                    }
                }
                SelectionStart = selection;
                SelectionLength = 0;
                SelectedText = LastTab;
            }

            PaintControl = true;
             
        }
        protected virtual void OnSpacePressed()
        {

        }

        protected virtual void OnArrowUpDownKeyPressed(int code)
        {
        }

        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                try
                {
                    OnEnterPressed();
                }
                catch { PaintControl = true; }
                return;
            }
            TextManipulationKeyEventArgs tm = null;
            switch ((CtrlKey)((int)e.KeyChar))
            {
                case CtrlKey.Ctrl_V :
                tm = new TextManipulationKeyEventArgs(Text.Substring(start, SelectionStart - start), start, SelectionStart - 1, TextManipulationTypes.Pasted);
                break;
                case CtrlKey.Ctrl_C:
                tm = new TextManipulationKeyEventArgs(SelectedText, SelectionStart, SelectionStart + SelectionLength, TextManipulationTypes.Copy);
                break;
                case CtrlKey.Ctrl_X:
                tm = new TextManipulationKeyEventArgs(System.Windows.Forms.Clipboard.GetText(), start, start + System.Windows.Forms.Clipboard.GetText().Length, TextManipulationTypes.Cut);
                break;
            }
            if (tm != null)
            {
                tm.Key = (CtrlKey)((int)e.KeyChar);
                OnTextManipulationKeyPressed(tm);
            }
            else
            {
                if ((int)e.KeyChar >= 1 && (int)e.KeyChar <= 26)
                {
                    tm = new TextManipulationKeyEventArgs();
                    tm.Key = (CtrlKey)((int)e.KeyChar);
                    OnTextManipulationKeyPressed(tm);
                }
            }
        }

        protected override void OnKeyUp(System.Windows.Forms.KeyEventArgs e)
        {
            
            /*
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                //OnEnterPressed();
                //return;
            }
            
            if (e.KeyCode == System.Windows.Forms.Keys.Tab)
            {
                if (_tabs.ContainsKey(GetLineFromCharIndex(GetFirstCharIndexOfCurrentLine())))
                {
                    _tabs[GetLineFromCharIndex(GetFirstCharIndexOfCurrentLine())].NumberOfTabs += 1;
                }
                else
                {
                    TabsInfo ti = new TabsInfo();
                    ti.Text = Lines[GetLineFromCharIndex(GetFirstCharIndexOfCurrentLine())];
                    ti.NumberOfTabs = 1;
                    ti.Line = GetLineFromCharIndex(GetFirstCharIndexOfCurrentLine());
                    _tabs.Add(GetLineFromCharIndex(GetFirstCharIndexOfCurrentLine()), ti);
                }
                return;
            }
             * */
        }
        protected override void OnPreviewKeyDown(System.Windows.Forms.PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Space)
            {
                OnSpacePressed();
            }
            if (e.KeyCode == System.Windows.Forms.Keys.Up)
            {
                OnArrowUpDownKeyPressed(1);
            }
            if (e.KeyCode == System.Windows.Forms.Keys.Down)
            {
                OnArrowUpDownKeyPressed(2);
            }
            if (e.Control)
            {
                start = SelectionStart; 
            }
        }


    }
}
