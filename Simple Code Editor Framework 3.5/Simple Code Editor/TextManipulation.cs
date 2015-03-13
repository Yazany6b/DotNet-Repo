using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simple_Code_Editor
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

        public TextManipulationKeyEventArgs(string text, int start, int end, TextManipulationTypes type)
        {
            Text = text;
            ManipulationEnd = end;
            ManipulationStart = start;
            TextManipulationType = type;
            Key = CtrlKey.None;
        }

        public TextManipulationKeyEventArgs(string text, int start, int end, TextManipulationTypes type, CtrlKey key)
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
    public delegate void TextManipulationKeyEventHandler(object sender, TextManipulationKeyEventArgs args);

}
