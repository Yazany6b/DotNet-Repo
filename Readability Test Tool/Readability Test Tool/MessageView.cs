using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Readability_Test_Tool
{
    public partial class MessageView : Form
    {
        public MessageView(string message)
        {
            InitializeComponent();
            richTextBox1.Text = message;
        }
    }
}
