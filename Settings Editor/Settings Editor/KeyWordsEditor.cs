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
    public partial class SettingsEditor : Form
    {
        //Dictionary<SupportedLanguage, Language> languages = new Dictionary<SupportedLanguage, Language>();
        Settings sett = null;
        SupportedLanguage currentLanguage = SupportedLanguage.Ada;
        YazanLib.Controls.AdvancedRichTextBox TextArea = new YazanLib.Controls.AdvancedRichTextBox();
        //System.Threading.Tasks.Task task;
        System.Drawing.Size size;
        public SettingsEditor()
        {
            InitializeComponent();
            TextArea.Size = KeywordsListView.Size;
            TextArea.Location = KeywordsListView.Location;
            TextArea.Visible = false;
            Controls.Add(TextArea);
            size = TextArea.Size;
            KeyComboBox.SelectedIndex = 0;
            try
            {
                sett = Settings.Deserialize();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            if (sett == null)
            {
                System.Windows.Forms.Application.ExitThread();
                LanguageComboBox.Enabled = false;
                KAddButton.Enabled = false;
                KAddTextBox.Enabled = false;
                RemoveButton.Enabled = false;
                QCButton.Enabled = false;
                RCButton.Enabled = false;
                OCButton.Enabled = false;
                CCButton.Enabled = false;
                EBCButton.Enabled = false;
                DCButton.Enabled = false;
                EFCButton.Enabled = false;
                KFButton.Enabled = false;
                UCButton.Enabled = false;
                KeyComboBox.Enabled = false;
                EDButton.Enabled = false;
                SaveButton.Enabled = false;
                ChangeButton.Enabled = false;
            }
            else
            {
                TextArea.Font = sett.Font;
                TextArea.BackColor = sett.BackColor;
                TextArea.ForeColor = sett.FontColor;
                KeywordsListView.BackColor = sett.BackColor;
            }
        }

        public SettingsEditor(ref Settings setting)
        {
            InitializeComponent();
            TextArea.Size = KeywordsListView.Size;
            TextArea.Location = KeywordsListView.Location;
            TextArea.Visible = false;
            Controls.Add(TextArea);
            size = TextArea.Size;
            KeyComboBox.SelectedIndex = 0;
            sett = setting;
            if (sett == null)
            {
                System.Windows.Forms.Application.ExitThread();
                LanguageComboBox.Enabled = false;
                KAddButton.Enabled = false;
                KAddTextBox.Enabled = false;
                RemoveButton.Enabled = false;
                QCButton.Enabled = false;
                RCButton.Enabled = false;
                OCButton.Enabled = false;
                CCButton.Enabled = false;
                EBCButton.Enabled = false;
                DCButton.Enabled = false;
                EFCButton.Enabled = false;
                KFButton.Enabled = false;
                UCButton.Enabled = false;
                KeyComboBox.Enabled = false;
                EDButton.Enabled = false;
                SaveButton.Enabled = false;
                ChangeButton.Enabled = false;
            }
            else
            {
                TextArea.Font = sett.Font;
                TextArea.BackColor = sett.BackColor;
                TextArea.ForeColor = sett.FontColor;
                KeywordsListView.BackColor = sett.BackColor;
            }
        }

        private void SetupTextArea()
        {
            switch (currentLanguage)
            {
                case SupportedLanguage.SQL:
                    TextArea.ResevedColor = sett.Languages[SupportedLanguage.SQL].KeywordsColors[KeywordType.Reseved];
                    TextArea.FunctionColor = sett.Languages[SupportedLanguage.SQL].KeywordsColors[KeywordType.Function];
                    TextArea.OperatorColor = sett.Languages[SupportedLanguage.SQL].KeywordsColors[KeywordType.Operator];
                    TextArea.DataTypeColor = sett.Languages[SupportedLanguage.SQL].KeywordsColors[KeywordType.DataType];
                    TextArea.CommentsColor = sett.Languages[SupportedLanguage.SQL].CommentsColor;
                    TextArea.QuotationColor = sett.Languages[SupportedLanguage.SQL].QuotationsColor;
                    TextArea.KeywordsFont = sett.Languages[SupportedLanguage.SQL].KeywordsFont;
                    TextArea.Keywords = sett.Languages[SupportedLanguage.SQL].Keywords;
                    TextArea.Rules = sett.Languages[SupportedLanguage.SQL].Rules;
                    break;
                case SupportedLanguage.Ada:
                    TextArea.ResevedColor = sett.Languages[SupportedLanguage.Ada].KeywordsColors[KeywordType.Reseved];
                    TextArea.FunctionColor = sett.Languages[SupportedLanguage.Ada].KeywordsColors[KeywordType.Function];
                    TextArea.OperatorColor = sett.Languages[SupportedLanguage.Ada].KeywordsColors[KeywordType.Operator];
                    TextArea.DataTypeColor = sett.Languages[SupportedLanguage.Ada].KeywordsColors[KeywordType.DataType];
                    TextArea.CommentsColor = sett.Languages[SupportedLanguage.Ada].CommentsColor;
                    TextArea.QuotationColor = sett.Languages[SupportedLanguage.Ada].QuotationsColor;
                    TextArea.KeywordsFont = sett.Languages[SupportedLanguage.Ada].KeywordsFont;
                    TextArea.Keywords = sett.Languages[SupportedLanguage.Ada].Keywords;
                    TextArea.Rules = sett.Languages[SupportedLanguage.Ada].Rules;
                    break;
                case SupportedLanguage.CPP:
                    TextArea.ResevedColor = sett.Languages[SupportedLanguage.CPP].KeywordsColors[KeywordType.Reseved];
                    TextArea.FunctionColor = sett.Languages[SupportedLanguage.CPP].KeywordsColors[KeywordType.Function];
                    TextArea.OperatorColor = sett.Languages[SupportedLanguage.CPP].KeywordsColors[KeywordType.Operator];
                    TextArea.DataTypeColor = sett.Languages[SupportedLanguage.CPP].KeywordsColors[KeywordType.DataType];
                    TextArea.CommentsColor = sett.Languages[SupportedLanguage.CPP].CommentsColor;
                    TextArea.QuotationColor = sett.Languages[SupportedLanguage.CPP].QuotationsColor;
                    TextArea.KeywordsFont = sett.Languages[SupportedLanguage.CPP].KeywordsFont;
                    TextArea.Keywords = sett.Languages[SupportedLanguage.CPP].Keywords;
                    TextArea.Rules = sett.Languages[SupportedLanguage.CPP].Rules;
                    break;
                case SupportedLanguage.CS:
                    TextArea.ResevedColor = sett.Languages[SupportedLanguage.CS].KeywordsColors[KeywordType.Reseved];
                    TextArea.FunctionColor = sett.Languages[SupportedLanguage.CS].KeywordsColors[KeywordType.Function];
                    TextArea.OperatorColor = sett.Languages[SupportedLanguage.CS].KeywordsColors[KeywordType.Operator];
                    TextArea.DataTypeColor = sett.Languages[SupportedLanguage.CS].KeywordsColors[KeywordType.DataType];
                    TextArea.CommentsColor = sett.Languages[SupportedLanguage.CS].CommentsColor;
                    TextArea.QuotationColor = sett.Languages[SupportedLanguage.CS].QuotationsColor;
                    TextArea.KeywordsFont = sett.Languages[SupportedLanguage.CS].KeywordsFont;
                    TextArea.Keywords = sett.Languages[SupportedLanguage.CS].Keywords;
                    TextArea.Rules = sett.Languages[SupportedLanguage.CS].Rules;
                    break;
                case SupportedLanguage.Java:
                    TextArea.ResevedColor = sett.Languages[SupportedLanguage.Java].KeywordsColors[KeywordType.Reseved];
                    TextArea.FunctionColor = sett.Languages[SupportedLanguage.Java].KeywordsColors[KeywordType.Function];
                    TextArea.OperatorColor = sett.Languages[SupportedLanguage.Java].KeywordsColors[KeywordType.Operator];
                    TextArea.DataTypeColor = sett.Languages[SupportedLanguage.Java].KeywordsColors[KeywordType.DataType];
                    TextArea.CommentsColor = sett.Languages[SupportedLanguage.Java].CommentsColor;
                    TextArea.QuotationColor = sett.Languages[SupportedLanguage.Java].QuotationsColor;
                    TextArea.KeywordsFont = sett.Languages[SupportedLanguage.Java].KeywordsFont;
                    TextArea.Keywords = sett.Languages[SupportedLanguage.Java].Keywords;
                    TextArea.Rules = sett.Languages[SupportedLanguage.Java].Rules;
                    break;
            }
            TextArea.Font = sett.Font;
            TextArea.BackColor = sett.BackColor;
            TextArea.ForeColor = sett.FontColor;
        }


        private void QCButton_Click(object sender, EventArgs e)
        {
            switch (((Button)sender).TabIndex)
            {
                case 6:
                    GetColor.Color = sett.Languages[currentLanguage].KeywordsColors[KeywordType.Operator];
                    if (GetColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        foreach (ListViewItem item in KeywordsListView.Items)
                            if (item.ForeColor == sett.Languages[currentLanguage].KeywordsColors[KeywordType.Operator])
                                item.ForeColor = GetColor.Color;
                        sett.Languages[currentLanguage].KeywordsColors[KeywordType.Operator] = GetColor.Color;
                        OperatorPanel.BackColor = GetColor.Color;
                    }
                    break;
                case 7:
                    GetColor.Color = sett.Languages[currentLanguage].KeywordsColors[KeywordType.DataType];
                    if (GetColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        foreach (ListViewItem item in KeywordsListView.Items)
                            if (item.ForeColor == sett.Languages[currentLanguage].KeywordsColors[KeywordType.DataType])
                                item.ForeColor = GetColor.Color;
                        sett.Languages[currentLanguage].KeywordsColors[KeywordType.DataType] = GetColor.Color;
                        DatatypesPanel.BackColor = GetColor.Color;
                    }
                    break;
                case 8:
                    GetColor.Color = sett.Languages[currentLanguage].KeywordsColors[KeywordType.Function];
                    if (GetColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        foreach (ListViewItem item in KeywordsListView.Items)
                            if (item.ForeColor == sett.Languages[currentLanguage].KeywordsColors[KeywordType.Function])
                                item.ForeColor = GetColor.Color;
                        sett.Languages[currentLanguage].KeywordsColors[KeywordType.Function] = GetColor.Color;
                        PreDPanel.BackColor = GetColor.Color;
                    }
                    break;
                case 9:
                    GetColor.Color = sett.Languages[currentLanguage].CommentsColor;
                    if (GetColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        sett.Languages[currentLanguage].CommentsColor = GetColor.Color;
                        CommentPanel.BackColor = GetColor.Color;
                    }
                    break;
                case 10:
                    GetColor.Color = sett.Languages[currentLanguage].KeywordsColors[KeywordType.Reseved];
                    if (GetColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        
                        foreach(ListViewItem item in KeywordsListView.Items)
                            if(item.ForeColor == sett.Languages[currentLanguage].KeywordsColors[KeywordType.Reseved])
                                item.ForeColor = GetColor.Color;
                        sett.Languages[currentLanguage].KeywordsColors[KeywordType.Reseved] = GetColor.Color;
                        RWPanel.BackColor = GetColor.Color;
                    }
                    break;
                case 11:
                    GetColor.Color = sett.Languages[currentLanguage].QuotationsColor;
                    if (GetColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        sett.Languages[currentLanguage].QuotationsColor = GetColor.Color;
                        QuoPanel.BackColor = GetColor.Color;
                    }
                    break;
                case 12:
                    GetFont.Font = sett.Languages[currentLanguage].KeywordsFont;
                    if (GetFont.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        sett.Languages[currentLanguage].KeywordsFont = GetFont.Font;
                    }
                    break;
                case 13:
                    GetFont.Font = sett.Font;
                    if (GetFont.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        sett.Font = GetFont.Font;
                    }
                    break;
                case 14:
                    GetColor.Color = sett.FontColor;
                    if (GetColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        sett.FontColor = GetColor.Color;
                    }
                    break;
                case 15:
                    GetColor.Color = sett.BackColor;
                    if (GetColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        sett.BackColor = GetColor.Color;
                        foreach (ListViewItem item in KeywordsListView.Items)
                                item.BackColor = GetColor.Color;
                        KeywordsListView.BackColor = sett.BackColor;
                    }
                    break;
            }
            SetupTextArea();
            TextArea.ResetColors();
        }
        private void FillCurrentInfo(SupportedLanguage lang)
        {
            currentLanguage = lang;
            SetupTextArea();
            TextArea.ResetColors();
            KeywordsListView.Clear();
            KeywordsListView.BackColor = sett.BackColor;
            KCountLabel.Text = sett.Languages[currentLanguage].Keywords.Count.ToString() + " Keywords / " + sett.NumberOfAllowedKeywords.ToString();
            for (int i = 0; i < sett.Languages[lang].Keywords.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = sett.Languages[lang].Keywords[i].Text;
                item.ForeColor = sett.Languages[lang].KeywordsColors[sett.Languages[lang].Keywords[i].Type];
                item.Tag = (int)sett.Languages[currentLanguage].Keywords[i].Type;
                item.BackColor = sett.BackColor;
                item.Font = new Font(sett.Languages[lang].KeywordsFont.Name, sett.Font.Size, sett.Languages[lang].KeywordsFont.Style);
                KeywordsListView.Items.Add(item);
            }

            RWPanel.BackColor = sett.Languages[currentLanguage].KeywordsColors[KeywordType.Reseved];
            OperatorPanel.BackColor = sett.Languages[currentLanguage].KeywordsColors[KeywordType.Operator];
            DatatypesPanel.BackColor = sett.Languages[currentLanguage].KeywordsColors[KeywordType.DataType];
            PreDPanel.BackColor = sett.Languages[currentLanguage].KeywordsColors[KeywordType.Function];
            QuoPanel.BackColor = sett.Languages[currentLanguage].QuotationsColor;
            CommentPanel.BackColor = sett.Languages[currentLanguage].CommentsColor;
        }
        private void LanguageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (LanguageComboBox.SelectedIndex)
            {
                case 0:
                    FillCurrentInfo(SupportedLanguage.SQL);
                    break;
                case 1:
                    FillCurrentInfo(SupportedLanguage.CPP);
                    break;
                case 2:
                    FillCurrentInfo(SupportedLanguage.CS);
                    break;
                case 3:
                    FillCurrentInfo(SupportedLanguage.Java);
                    break;
                case 4:
                    FillCurrentInfo(SupportedLanguage.Ada);
                    break;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Settings.Serialize(sett);
        }

        public int IndexOfKeyword(string keyword)
        {
            for (int i = 0; i < sett.Languages[currentLanguage].Keywords.Count; i++)
                if (sett.Languages[currentLanguage].Keywords[i].Text.Trim().Equals(keyword.Trim(), StringComparison.OrdinalIgnoreCase))
                    return i;
            return -1;
        }
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in KeywordsListView.SelectedItems)
            {
                sett.Languages[currentLanguage].Keywords.RemoveAt(IndexOfKeyword(item.Text));
                KeywordsListView.Items.Remove(item);
            }
            KCountLabel.Text = sett.Languages[currentLanguage].Keywords.Count.ToString()+" Keywords / "+sett.NumberOfAllowedKeywords.ToString();
        }

        private void KAddButton_Click(object sender, EventArgs e)
        {
            if (KAddTextBox.Text.Trim() != string.Empty && sett.Languages[currentLanguage].Keywords.Count < sett.NumberOfAllowedKeywords)
            {
                int ind = IndexOfKeyword(KAddTextBox.Text.Trim());
                if (ind == -1)
                {
                    Keyword ky = new Keyword(KAddTextBox.Text, (KeywordType)KeyComboBox.SelectedIndex);
                    sett.Languages[currentLanguage].Keywords.Add(ky);
                    ListViewItem item = new ListViewItem();
                    item.Text = KAddTextBox.Text.Trim();
                    item.Font = new Font(sett.Languages[currentLanguage].KeywordsFont.Name, sett.Font.Size, sett.Languages[currentLanguage].KeywordsFont.Style);
                    item.ForeColor = sett.Languages[currentLanguage].KeywordsColors[(KeywordType)KeyComboBox.SelectedIndex];
                    KeywordsListView.Items.Add(item);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Keyword already exist Or you cannot add any more keywords");
                    KeywordsListView.Focus();
                    KeywordsListView.Items[ind].Selected = true;
                    KeywordsListView.Items[ind].Focused = true;
                }
            }
            KCountLabel.Text = sett.Languages[currentLanguage].Keywords.Count.ToString() + " Keywords / " + sett.NumberOfAllowedKeywords.ToString();
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            /*
            KeywordsListView.Scrollable = false;
            TextArea.ScrollBars = RichTextBoxScrollBars.None;
            if (KeywordsListView.Visible)
            {
                task = new System.Threading.Tasks.Task(StartChangeToBox);
                task.Start();
            }
            else
            {
                task = new System.Threading.Tasks.Task(StartChangeToList);
                task.Start();
            }
            KeywordsListView.Scrollable = true;
            TextArea.ScrollBars = RichTextBoxScrollBars.ForcedBoth;
             * */
            if (KeywordsListView.Visible)
            {
                KeywordsListView.Visible = false;
                TextArea.Visible = true;
                TextArea.Focus();
            }
            else
            {
                KeywordsListView.Visible = true;
                TextArea.Visible = false;
            }
            
        }
        int speed = 100000;
        public void StartChangeToList()
        {
            TextArea.Width = TextArea.Width - 20;
            TextArea.Location = new System.Drawing.Point(TextArea.Location.X + 10, TextArea.Location.Y);
            for (int i = 0; i < speed; i++) ;
            TextArea.Width = TextArea.Width - 20;
            TextArea.Location = new System.Drawing.Point(TextArea.Location.X + 10, TextArea.Location.Y);
            for (int i = 0; i < speed; i++);
            TextArea.Width = TextArea.Width - 20;
            TextArea.Location = new System.Drawing.Point(TextArea.Location.X + 10, TextArea.Location.Y);
            for (int i = 0; i < speed; i++) ;
            TextArea.Width = TextArea.Width - 20;
            TextArea.Location = new System.Drawing.Point(TextArea.Location.X + 10, TextArea.Location.Y);
            for (int i = 0; i < speed; i++) ;
            TextArea.Width = TextArea.Width - 20;
            TextArea.Location = new System.Drawing.Point(TextArea.Location.X + 10, TextArea.Location.Y);
            for (int i = 0; i < speed; i++) ;
            KeywordsListView.Size = TextArea.Size;
            KeywordsListView.Visible = true;
            TextArea.Visible = false;
            KeywordsListView.Width = KeywordsListView.Width + 20;
            KeywordsListView.Location = new System.Drawing.Point(KeywordsListView.Location.X - 10, KeywordsListView.Location.Y);
            for (int i = 0; i < speed; i++) ;
            KeywordsListView.Width = KeywordsListView.Width + 20;
            KeywordsListView.Location = new System.Drawing.Point(KeywordsListView.Location.X - 10, KeywordsListView.Location.Y);
            for (int i = 0; i < speed; i++) ;
            KeywordsListView.Width = KeywordsListView.Width + 20;
            KeywordsListView.Location = new System.Drawing.Point(KeywordsListView.Location.X - 10, KeywordsListView.Location.Y);
            for (int i = 0; i < speed; i++) ;
            KeywordsListView.Width = KeywordsListView.Width + 20;
            KeywordsListView.Location = new System.Drawing.Point(KeywordsListView.Location.X - 10, KeywordsListView.Location.Y);
            for (int i = 0; i < speed; i++) ;
            KeywordsListView.Width = KeywordsListView.Width + 20;
            KeywordsListView.Location = new System.Drawing.Point(KeywordsListView.Location.X - 10, KeywordsListView.Location.Y);
            for (int i = 0; i < speed; i++) ;
            KeywordsListView.Size = size;
            //task.Wait();
        }
        public void StartChangeToBox()
        {
            KeywordsListView.Width = KeywordsListView.Width - 20;
            KeywordsListView.Location = new System.Drawing.Point(KeywordsListView.Location.X + 10, KeywordsListView.Location.Y);
            for (int i = 0; i < speed; i++) ;
            KeywordsListView.Width = KeywordsListView.Width - 20;
            KeywordsListView.Location = new System.Drawing.Point(KeywordsListView.Location.X + 10, KeywordsListView.Location.Y);
            for (int i = 0; i < speed; i++) ;
            KeywordsListView.Width = KeywordsListView.Width - 20;
            KeywordsListView.Location = new System.Drawing.Point(KeywordsListView.Location.X + 10, KeywordsListView.Location.Y);
            for (int i = 0; i < speed; i++) ;
            KeywordsListView.Width = KeywordsListView.Width - 20;
            KeywordsListView.Location = new System.Drawing.Point(KeywordsListView.Location.X + 10, KeywordsListView.Location.Y);
            for (int i = 0; i < speed; i++) ;
            KeywordsListView.Width = KeywordsListView.Width - 20;
            KeywordsListView.Location = new System.Drawing.Point(KeywordsListView.Location.X + 10, KeywordsListView.Location.Y);
            for (int i = 0; i < speed; i++) ;
            TextArea.Size = KeywordsListView.Size;
            TextArea.Visible = true;
            KeywordsListView.Visible = false;
            TextArea.Width = TextArea.Width + 20;
            TextArea.Location = new System.Drawing.Point(TextArea.Location.X - 10, TextArea.Location.Y);
            for (int i = 0; i < speed; i++) ;
            TextArea.Width = TextArea.Width + 20;
            TextArea.Location = new System.Drawing.Point(TextArea.Location.X - 10, TextArea.Location.Y);
            for (int i = 0; i < speed; i++) ;
            TextArea.Width = TextArea.Width + 20;
            TextArea.Location = new System.Drawing.Point(TextArea.Location.X - 10, TextArea.Location.Y);
            for (int i = 0; i < speed; i++) ;
            TextArea.Width = TextArea.Width + 20;
            TextArea.Location = new System.Drawing.Point(TextArea.Location.X - 10, TextArea.Location.Y);
            for (int i = 0; i < speed; i++) ;
            TextArea.Width = TextArea.Width + 20;
            TextArea.Location = new System.Drawing.Point(TextArea.Location.X - 10, TextArea.Location.Y);
            for (int i = 0; i < speed; i++) ;
            TextArea.Size = size;
            //task.Wait();
        }
    }
}
