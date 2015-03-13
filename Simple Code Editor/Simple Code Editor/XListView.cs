
namespace YazanLib.Controls
{
    /// <summary>
    /// containes the ListView functionality with ability to handle it's messages
    /// </summary>
    public class XListView : System.Windows.Forms.ListView, ITriggerable
    {

        System.Collections.Generic.List<Simple_Code_Editor.Keyword> _keywords = new System.Collections.Generic.List<Simple_Code_Editor.Keyword>();

        /// <summary>
        /// Occures when a message sent to the implementer control
        /// </summary>
        public event MessageSentHandler MessageSent;
        public event System.EventHandler EnterPressed;
        private System.Collections.Generic.List<int> _messages = new System.Collections.Generic.List<int>();

        /// <summary>
        /// Creates an instance of type XListView
        /// </summary>
        public XListView()
        {
            KeepInDefault = false;
            this.Scrollable = true;
            HideSelection = false;
            this.MultiSelect = false;
            Size = new System.Drawing.Size(120, 170);
            Margin = new System.Windows.Forms.Padding(10);
            BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.View = System.Windows.Forms.View.Tile;
            DefaultMessage = System.Windows.Forms.Message.Create(this.Handle, Windows_Messages.WM_NULL, (System.IntPtr)1,System.IntPtr.Zero);
        }

        /// <summary>
        /// Send a message to the WndProc function
        /// </summary>
        /// <param name="m">a reference to the message</param>
        public void SendMessage(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == YazanLib.Controls.Windows_Messages.WM_KEYDOWN)
            {
                if ((YazanLib.Controls.Windows_Keys)m.WParam == YazanLib.Controls.Windows_Keys.VK_RETURN)
                {
                    if (EnterPressed != null)
                    {
                        EnterPressed(this, new System.EventArgs());
                        base.WndProc(ref m);
                        return;
                    }
                }
            }
            Focus();
            WndProc(ref m);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m">Message</param>
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (KeepInDefault)
            {
                System.Windows.Forms.Message ms = System.Windows.Forms.Message.Create(DefaultMessage.HWnd,DefaultMessage.Msg,DefaultMessage.LParam,DefaultMessage.WParam);
                base.WndProc(ref ms);
                return;
            }
            if (MessageSent != null && _messages.Contains(m.Msg))
                MessageSent(this, ref m);
            base.WndProc(ref m);
        }

        public void FillListWith(string start,bool ignoreCase)
        {
            this.Clear();
            start = start.Trim();
            bool res;
            for (int i = 0; i < _keywords.Count; i++)
            {
                if(ignoreCase)
                    res = _keywords[i].Text.StartsWith(start, System.StringComparison.OrdinalIgnoreCase);
                else
                    res = _keywords[i].Text.StartsWith(start);
                if (res)
                {
                    System.Windows.Forms.ListViewItem it = new System.Windows.Forms.ListViewItem();
                    it.Text = _keywords[i].Text;
                    this.Items.Add(it);
                }
            }
            Update();
            Refresh();
        }

        /// <summary>
        ///Identifies the messages that will trigger the MessageSent Event.
        /// </summary>
        public System.Collections.Generic.List<int> Messages
        {
            get { return _messages; }
            protected set { _messages = value; }
        }


        /// <summary>
        /// Sets Or Gets whether to keep sending only the defualt message
        /// </summary>
        public bool KeepInDefault
        {
            set;
            get;
        }

        /// <summary>
        /// Sets Or Gets the default message of the current control
        /// </summary>
        public System.Windows.Forms.Message DefaultMessage
        {
            get;
            set;
        }

        public System.Collections.Generic.List<Simple_Code_Editor.Keyword> Keywords
        {
            get { return _keywords; }
            set { _keywords = value; }
        }

    }
}
