using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Student_Assistant_Application
{
    public partial class MessageViewForm : Form
    {
        public MessageViewForm(string message)
        {
            InitializeComponent();
            richTextBox1.Text = message;
        }
    }
}
