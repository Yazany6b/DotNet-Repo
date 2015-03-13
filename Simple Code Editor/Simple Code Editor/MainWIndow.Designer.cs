namespace Simple_Code_Editor
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.ViewPanel = new System.Windows.Forms.Panel();
            this.GetColor = new System.Windows.Forms.ColorDialog();
            this.GetFont = new System.Windows.Forms.FontDialog();
            this.SaveFile = new System.Windows.Forms.SaveFileDialog();
            this.OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditorFontMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.KeyWordsFontMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.EditorFontColorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditorBackColorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.KeyWordsColorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operatorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataTypesColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preDefinedFunctionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.CommentsColorItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuotationsColorItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ResetSettingsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SQLMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CPPMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.JavaMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ADAMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NoneMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLanguagesEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFileDialogBox = new System.Windows.Forms.SaveFileDialog();
            this.OpenFileDialogBox = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ViewPanel
            // 
            this.ViewPanel.Location = new System.Drawing.Point(12, 27);
            this.ViewPanel.Name = "ViewPanel";
            this.ViewPanel.Size = new System.Drawing.Size(488, 414);
            this.ViewPanel.TabIndex = 2;
            // 
            // OpenFile
            // 
            this.OpenFile.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.programToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(512, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenMenuItem,
            this.SaveMenuItem,
            this.SaveAsMenuItem,
            this.ExitMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // OpenMenuItem
            // 
            this.OpenMenuItem.MergeIndex = 1;
            this.OpenMenuItem.Name = "OpenMenuItem";
            this.OpenMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenMenuItem.Size = new System.Drawing.Size(183, 22);
            this.OpenMenuItem.Text = "Open";
            this.OpenMenuItem.Click += new System.EventHandler(this.MenuItemClicked);
            // 
            // SaveMenuItem
            // 
            this.SaveMenuItem.MergeIndex = 2;
            this.SaveMenuItem.Name = "SaveMenuItem";
            this.SaveMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveMenuItem.Size = new System.Drawing.Size(183, 22);
            this.SaveMenuItem.Text = "Save";
            this.SaveMenuItem.Click += new System.EventHandler(this.MenuItemClicked);
            // 
            // SaveAsMenuItem
            // 
            this.SaveAsMenuItem.MergeIndex = 3;
            this.SaveAsMenuItem.Name = "SaveAsMenuItem";
            this.SaveAsMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.S)));
            this.SaveAsMenuItem.Size = new System.Drawing.Size(183, 22);
            this.SaveAsMenuItem.Text = "Save As";
            this.SaveAsMenuItem.Click += new System.EventHandler(this.MenuItemClicked);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.MergeIndex = 4;
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(183, 22);
            this.ExitMenuItem.Text = "Exit";
            this.ExitMenuItem.Click += new System.EventHandler(this.MenuItemClicked);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyMenuItem,
            this.CutMenuItem,
            this.DeleteMenuItem,
            this.PasteMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // CopyMenuItem
            // 
            this.CopyMenuItem.MergeIndex = 5;
            this.CopyMenuItem.Name = "CopyMenuItem";
            this.CopyMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.CopyMenuItem.Size = new System.Drawing.Size(148, 22);
            this.CopyMenuItem.Text = "Copy";
            this.CopyMenuItem.Click += new System.EventHandler(this.MenuItemClicked);
            // 
            // CutMenuItem
            // 
            this.CutMenuItem.MergeIndex = 6;
            this.CutMenuItem.Name = "CutMenuItem";
            this.CutMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.CutMenuItem.Size = new System.Drawing.Size(148, 22);
            this.CutMenuItem.Text = "Cut";
            this.CutMenuItem.Click += new System.EventHandler(this.MenuItemClicked);
            // 
            // DeleteMenuItem
            // 
            this.DeleteMenuItem.MergeIndex = 7;
            this.DeleteMenuItem.Name = "DeleteMenuItem";
            this.DeleteMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.DeleteMenuItem.Size = new System.Drawing.Size(148, 22);
            this.DeleteMenuItem.Text = "Delete";
            this.DeleteMenuItem.Click += new System.EventHandler(this.MenuItemClicked);
            // 
            // PasteMenuItem
            // 
            this.PasteMenuItem.MergeIndex = 8;
            this.PasteMenuItem.Name = "PasteMenuItem";
            this.PasteMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.PasteMenuItem.Size = new System.Drawing.Size(148, 22);
            this.PasteMenuItem.Text = "Paste";
            this.PasteMenuItem.Click += new System.EventHandler(this.MenuItemClicked);
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsMenuItem,
            this.LanguageMenuItem,
            this.aboutToolStripMenuItem,
            this.openLanguagesEditorToolStripMenuItem});
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.programToolStripMenuItem.Text = "Program";
            // 
            // SettingsMenuItem
            // 
            this.SettingsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditorFontMenuItem,
            this.KeyWordsFontMenuItem,
            this.toolStripSeparator3,
            this.EditorFontColorMenuItem,
            this.EditorBackColorMenuItem,
            this.toolStripSeparator1,
            this.KeyWordsColorMenuItem,
            this.operatorsToolStripMenuItem,
            this.dataTypesColorToolStripMenuItem,
            this.preDefinedFunctionsToolStripMenuItem,
            this.toolStripSeparator2,
            this.CommentsColorItem,
            this.QuotationsColorItem,
            this.ResetSettingsItem});
            this.SettingsMenuItem.Name = "SettingsMenuItem";
            this.SettingsMenuItem.Size = new System.Drawing.Size(229, 22);
            this.SettingsMenuItem.Text = "Settings";
            // 
            // EditorFontMenuItem
            // 
            this.EditorFontMenuItem.MergeIndex = 9;
            this.EditorFontMenuItem.Name = "EditorFontMenuItem";
            this.EditorFontMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.EditorFontMenuItem.Size = new System.Drawing.Size(216, 22);
            this.EditorFontMenuItem.Text = "Editor Font";
            this.EditorFontMenuItem.Click += new System.EventHandler(this.MenuItemClicked);
            // 
            // KeyWordsFontMenuItem
            // 
            this.KeyWordsFontMenuItem.MergeIndex = 13;
            this.KeyWordsFontMenuItem.Name = "KeyWordsFontMenuItem";
            this.KeyWordsFontMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.K)));
            this.KeyWordsFontMenuItem.Size = new System.Drawing.Size(216, 22);
            this.KeyWordsFontMenuItem.Text = "KeyWords Font";
            this.KeyWordsFontMenuItem.Click += new System.EventHandler(this.MenuItemClicked);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(213, 6);
            // 
            // EditorFontColorMenuItem
            // 
            this.EditorFontColorMenuItem.MergeIndex = 10;
            this.EditorFontColorMenuItem.Name = "EditorFontColorMenuItem";
            this.EditorFontColorMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.EditorFontColorMenuItem.Size = new System.Drawing.Size(216, 22);
            this.EditorFontColorMenuItem.Text = "Editor Font Color";
            this.EditorFontColorMenuItem.Click += new System.EventHandler(this.MenuItemClicked);
            // 
            // EditorBackColorMenuItem
            // 
            this.EditorBackColorMenuItem.MergeIndex = 11;
            this.EditorBackColorMenuItem.Name = "EditorBackColorMenuItem";
            this.EditorBackColorMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.B)));
            this.EditorBackColorMenuItem.Size = new System.Drawing.Size(216, 22);
            this.EditorBackColorMenuItem.Text = "Editor Back Color";
            this.EditorBackColorMenuItem.Click += new System.EventHandler(this.MenuItemClicked);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(213, 6);
            // 
            // KeyWordsColorMenuItem
            // 
            this.KeyWordsColorMenuItem.MergeIndex = 12;
            this.KeyWordsColorMenuItem.Name = "KeyWordsColorMenuItem";
            this.KeyWordsColorMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            this.KeyWordsColorMenuItem.Size = new System.Drawing.Size(216, 22);
            this.KeyWordsColorMenuItem.Text = "Reseveds Color";
            this.KeyWordsColorMenuItem.Click += new System.EventHandler(this.MenuItemClicked);
            // 
            // operatorsToolStripMenuItem
            // 
            this.operatorsToolStripMenuItem.MergeIndex = 21;
            this.operatorsToolStripMenuItem.Name = "operatorsToolStripMenuItem";
            this.operatorsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.operatorsToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.operatorsToolStripMenuItem.Text = "Operators Color";
            this.operatorsToolStripMenuItem.Click += new System.EventHandler(this.MenuItemClicked);
            // 
            // dataTypesColorToolStripMenuItem
            // 
            this.dataTypesColorToolStripMenuItem.MergeIndex = 24;
            this.dataTypesColorToolStripMenuItem.Name = "dataTypesColorToolStripMenuItem";
            this.dataTypesColorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.dataTypesColorToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.dataTypesColorToolStripMenuItem.Text = "DataTypes Color";
            this.dataTypesColorToolStripMenuItem.Click += new System.EventHandler(this.MenuItemClicked);
            // 
            // preDefinedFunctionsToolStripMenuItem
            // 
            this.preDefinedFunctionsToolStripMenuItem.MergeIndex = 20;
            this.preDefinedFunctionsToolStripMenuItem.Name = "preDefinedFunctionsToolStripMenuItem";
            this.preDefinedFunctionsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.I)));
            this.preDefinedFunctionsToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.preDefinedFunctionsToolStripMenuItem.Text = "Pre Defined Functions";
            this.preDefinedFunctionsToolStripMenuItem.Click += new System.EventHandler(this.MenuItemClicked);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(213, 6);
            // 
            // CommentsColorItem
            // 
            this.CommentsColorItem.MergeIndex = 18;
            this.CommentsColorItem.Name = "CommentsColorItem";
            this.CommentsColorItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.M)));
            this.CommentsColorItem.Size = new System.Drawing.Size(216, 22);
            this.CommentsColorItem.Text = "Comments Color";
            this.CommentsColorItem.Click += new System.EventHandler(this.MenuItemClicked);
            // 
            // QuotationsColorItem
            // 
            this.QuotationsColorItem.MergeIndex = 19;
            this.QuotationsColorItem.Name = "QuotationsColorItem";
            this.QuotationsColorItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Q)));
            this.QuotationsColorItem.Size = new System.Drawing.Size(216, 22);
            this.QuotationsColorItem.Text = "Quotations Color";
            this.QuotationsColorItem.Click += new System.EventHandler(this.MenuItemClicked);
            // 
            // ResetSettingsItem
            // 
            this.ResetSettingsItem.MergeIndex = 25;
            this.ResetSettingsItem.Name = "ResetSettingsItem";
            this.ResetSettingsItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.G)));
            this.ResetSettingsItem.Size = new System.Drawing.Size(216, 22);
            this.ResetSettingsItem.Text = "Reset Settings";
            this.ResetSettingsItem.Click += new System.EventHandler(this.MenuItemClicked);
            // 
            // LanguageMenuItem
            // 
            this.LanguageMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SQLMenuItem,
            this.CPPMenuItem,
            this.CSMenuItem,
            this.JavaMenuItem,
            this.ADAMenuItem,
            this.NoneMenuItem});
            this.LanguageMenuItem.Name = "LanguageMenuItem";
            this.LanguageMenuItem.Size = new System.Drawing.Size(229, 22);
            this.LanguageMenuItem.Text = "Language";
            // 
            // SQLMenuItem
            // 
            this.SQLMenuItem.MergeIndex = 14;
            this.SQLMenuItem.Name = "SQLMenuItem";
            this.SQLMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.SQLMenuItem.Size = new System.Drawing.Size(138, 22);
            this.SQLMenuItem.Text = "SQL";
            this.SQLMenuItem.Click += new System.EventHandler(this.MenuItemClicked);
            // 
            // CPPMenuItem
            // 
            this.CPPMenuItem.MergeIndex = 15;
            this.CPPMenuItem.Name = "CPPMenuItem";
            this.CPPMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.CPPMenuItem.Size = new System.Drawing.Size(138, 22);
            this.CPPMenuItem.Text = "C++";
            this.CPPMenuItem.Click += new System.EventHandler(this.MenuItemClicked);
            // 
            // CSMenuItem
            // 
            this.CSMenuItem.MergeIndex = 16;
            this.CSMenuItem.Name = "CSMenuItem";
            this.CSMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.CSMenuItem.Size = new System.Drawing.Size(138, 22);
            this.CSMenuItem.Text = "C#";
            this.CSMenuItem.Click += new System.EventHandler(this.MenuItemClicked);
            // 
            // JavaMenuItem
            // 
            this.JavaMenuItem.MergeIndex = 17;
            this.JavaMenuItem.Name = "JavaMenuItem";
            this.JavaMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.J)));
            this.JavaMenuItem.Size = new System.Drawing.Size(138, 22);
            this.JavaMenuItem.Text = "Java";
            this.JavaMenuItem.Click += new System.EventHandler(this.MenuItemClicked);
            // 
            // ADAMenuItem
            // 
            this.ADAMenuItem.Checked = true;
            this.ADAMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ADAMenuItem.MergeIndex = 23;
            this.ADAMenuItem.Name = "ADAMenuItem";
            this.ADAMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.ADAMenuItem.Size = new System.Drawing.Size(138, 22);
            this.ADAMenuItem.Text = "Ada";
            this.ADAMenuItem.Click += new System.EventHandler(this.MenuItemClicked);
            // 
            // NoneMenuItem
            // 
            this.NoneMenuItem.MergeIndex = 28;
            this.NoneMenuItem.Name = "NoneMenuItem";
            this.NoneMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.N)));
            this.NoneMenuItem.Size = new System.Drawing.Size(138, 22);
            this.NoneMenuItem.Text = "None";
            this.NoneMenuItem.Click += new System.EventHandler(this.MenuItemClicked);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.MergeIndex = 22;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.U)));
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.MenuItemClicked);
            // 
            // openLanguagesEditorToolStripMenuItem
            // 
            this.openLanguagesEditorToolStripMenuItem.MergeIndex = 27;
            this.openLanguagesEditorToolStripMenuItem.Name = "openLanguagesEditorToolStripMenuItem";
            this.openLanguagesEditorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.O)));
            this.openLanguagesEditorToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.openLanguagesEditorToolStripMenuItem.Text = "Open Languages Editor";
            this.openLanguagesEditorToolStripMenuItem.Click += new System.EventHandler(this.MenuItemClicked);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 463);
            this.Controls.Add(this.ViewPanel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel ViewPanel;
        private System.Windows.Forms.ColorDialog GetColor;
        private System.Windows.Forms.FontDialog GetFont;
        private System.Windows.Forms.SaveFileDialog SaveFile;
        private System.Windows.Forms.OpenFileDialog OpenFile;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CopyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PasteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SettingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditorFontMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditorFontColorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditorBackColorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem KeyWordsColorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem KeyWordsFontMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LanguageMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SQLMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CPPMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem JavaMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CommentsColorItem;
        private System.Windows.Forms.ToolStripMenuItem QuotationsColorItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ADAMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem operatorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataTypesColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preDefinedFunctionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ResetSettingsItem;
        private System.Windows.Forms.ToolStripMenuItem openLanguagesEditorToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog SaveFileDialogBox;
        private System.Windows.Forms.OpenFileDialog OpenFileDialogBox;
        private System.Windows.Forms.ToolStripMenuItem NoneMenuItem;
    }
}

