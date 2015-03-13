using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Simple_Code_Editor
{
    public partial class ContantMenu : Form
    {
        List<Keyword> _keywords = new List<Keyword>();
        public ContantMenu(ref List<Keyword> keywords)
        {
            InitializeComponent();
            _keywords = keywords;
            KeywordsListView.Scrollable = true;
            KeywordsListView.MultiSelect = false;
        }
        public void FillListWith(string start)
        {
            KeywordsListView.Clear();
            bool first = true;
            for (int i = 0; i < _keywords.Count; i++)
            {
                if (_keywords[i].Text.StartsWith(start, StringComparison.OrdinalIgnoreCase))
                {
                    ListViewItem it = new ListViewItem();
                    it.Text = _keywords[i].Text;
                    it.Selected = first;
                    first = false;
                    KeywordsListView.Items.Add(it);
                }
            }
        }

        public KeyPressEventHandler KeyPressHandler
        {
            set { KeywordsListView.KeyPress += value; }
        }

        private void ContantMenu_Deactivate(object sender, EventArgs e)
        {
        }

        public void PutInFocus()
        {
            KeywordsListView.Focus();
        }

        public void SelectNext()
        {
            if(KeywordsListView.SelectedIndices[0] != KeywordsListView.Items.Count -1)
                KeywordsListView.Items[KeywordsListView.SelectedIndices[0] + 1].Selected = true;
        }

        public void SelectPrev()
        {
            if(KeywordsListView.SelectedIndices[0] != 0)
                KeywordsListView.Items[KeywordsListView.SelectedIndices[0] - 1].Selected = true;
        }
    }
}
