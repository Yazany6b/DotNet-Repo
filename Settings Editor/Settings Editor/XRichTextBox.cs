using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YazanLib.Controls
{
    public enum TextManipulationTypes
    {
        Copy,
        Cut,
        Pasted,
        None
    }

    public enum CtrlKey
    {
        None = 0,
        Ctrl_A = 1,
        Ctrl_B,
        Ctrl_C,
        Ctrl_D,
        Ctrl_E,
        Ctrl_F,
        Ctrl_G,
        Ctrl_H,
        Ctrl_I,
        Ctrl_J,
        Ctrl_K,
        Ctrl_L,
        Ctrl_M,
        Ctrl_N,
        Ctrl_O,
        Ctrl_P,
        Ctrl_Q,
        Ctrl_R,
        Ctrl_S,
        Ctrl_T,
        Ctrl_U,
        Ctrl_V,
        Ctrl_W,
        Ctrl_X,
        Ctrl_Y,
        Ctrl_Z
    }
    public class TextManipulationKeyEventArgs
    {

        public TextManipulationKeyEventArgs()
        {
            Text = "";
            ManipulationEnd = 0;
            ManipulationStart = 0;
            TextManipulationType = TextManipulationTypes.None;
        }

        public TextManipulationKeyEventArgs(string text,int start,int end,TextManipulationTypes type)
        {
            Text = text;
            ManipulationEnd = end;
            ManipulationStart = start;
            TextManipulationType = type;
            Key = CtrlKey.None;
        }

        public TextManipulationKeyEventArgs(string text, int start, int end, TextManipulationTypes type,CtrlKey key)
        {
            Text = text;
            ManipulationEnd = end;
            ManipulationStart = start;
            TextManipulationType = type;
            Key = key;
        }

        public string Text
        {
            get;
            set;
        }

        public int ManipulationStart
        {
            get;
            set;
        }

        public int ManipulationEnd
        {
            get;
            set;
        }

        public TextManipulationTypes TextManipulationType
        {
            get;
            set;
        }

        public CtrlKey Key
        {
            get;
            set;
        }

    }
    public delegate void TextManipulationKeyEventHandler(object sender,TextManipulationKeyEventArgs args);
    public class XRichTextBox : System.Windows.Forms.RichTextBox
    {
        private int start = 0;


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
                    m.Result = System.IntPtr.Zero;
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

        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
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

        protected override void OnPreviewKeyDown(System.Windows.Forms.PreviewKeyDownEventArgs e)
        {
            if (e.Control)
            {
                start = SelectionStart; 
            }
        }


    }
}
