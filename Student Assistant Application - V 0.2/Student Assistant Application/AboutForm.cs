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
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            if (!Statics.EnglishLanguage)
            {
                label1.Text = Statics.Language["aboutform About"];
                if (Statics.Language.ContainsKey("aboutform_title"))
                    this.Text = Statics.Language["aboutform_title"];
            }
        }
    }
}
