namespace Simple_Code_Editor
{
    partial class SettingsEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsEditor));
            this.LanguageComboBox = new System.Windows.Forms.ComboBox();
            this.KeywordsListView = new System.Windows.Forms.ListView();
            this.KAddButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.KAddTextBox = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.OCButton = new System.Windows.Forms.Button();
            this.DCButton = new System.Windows.Forms.Button();
            this.UCButton = new System.Windows.Forms.Button();
            this.CCButton = new System.Windows.Forms.Button();
            this.RCButton = new System.Windows.Forms.Button();
            this.QCButton = new System.Windows.Forms.Button();
            this.KFButton = new System.Windows.Forms.Button();
            this.EDButton = new System.Windows.Forms.Button();
            this.EFCButton = new System.Windows.Forms.Button();
            this.EBCButton = new System.Windows.Forms.Button();
            this.GetColor = new System.Windows.Forms.ColorDialog();
            this.GetFont = new System.Windows.Forms.FontDialog();
            this.RWPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OperatorPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.DatatypesPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.PreDPanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.CommentPanel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.QuoPanel = new System.Windows.Forms.Panel();
            this.KeyComboBox = new System.Windows.Forms.ComboBox();
            this.KCountLabel = new System.Windows.Forms.Label();
            this.ChangeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LanguageComboBox
            // 
            this.LanguageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LanguageComboBox.FormattingEnabled = true;
            this.LanguageComboBox.Items.AddRange(new object[] {
            "Sql",
            "C++",
            "C#",
            "Java",
            "Ada"});
            this.LanguageComboBox.Location = new System.Drawing.Point(42, 12);
            this.LanguageComboBox.Name = "LanguageComboBox";
            this.LanguageComboBox.Size = new System.Drawing.Size(283, 21);
            this.LanguageComboBox.TabIndex = 0;
            this.LanguageComboBox.SelectedIndexChanged += new System.EventHandler(this.LanguageComboBox_SelectedIndexChanged);
            // 
            // KeywordsListView
            // 
            this.KeywordsListView.LabelWrap = false;
            this.KeywordsListView.Location = new System.Drawing.Point(12, 39);
            this.KeywordsListView.MultiSelect = false;
            this.KeywordsListView.Name = "KeywordsListView";
            this.KeywordsListView.Size = new System.Drawing.Size(228, 351);
            this.KeywordsListView.TabIndex = 1;
            this.KeywordsListView.UseCompatibleStateImageBehavior = false;
            this.KeywordsListView.View = System.Windows.Forms.View.Tile;
            // 
            // KAddButton
            // 
            this.KAddButton.Location = new System.Drawing.Point(246, 39);
            this.KAddButton.Name = "KAddButton";
            this.KAddButton.Size = new System.Drawing.Size(82, 23);
            this.KAddButton.TabIndex = 2;
            this.KAddButton.Text = "Add";
            this.KAddButton.UseVisualStyleBackColor = true;
            this.KAddButton.Click += new System.EventHandler(this.KAddButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(246, 68);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(82, 23);
            this.RemoveButton.TabIndex = 3;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // KAddTextBox
            // 
            this.KAddTextBox.Location = new System.Drawing.Point(334, 39);
            this.KAddTextBox.Name = "KAddTextBox";
            this.KAddTextBox.Size = new System.Drawing.Size(90, 20);
            this.KAddTextBox.TabIndex = 4;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(415, 429);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(82, 23);
            this.SaveButton.TabIndex = 5;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // OCButton
            // 
            this.OCButton.Location = new System.Drawing.Point(246, 242);
            this.OCButton.Name = "OCButton";
            this.OCButton.Size = new System.Drawing.Size(132, 23);
            this.OCButton.TabIndex = 6;
            this.OCButton.Text = "Operators Color";
            this.OCButton.UseVisualStyleBackColor = true;
            this.OCButton.Click += new System.EventHandler(this.QCButton_Click);
            // 
            // DCButton
            // 
            this.DCButton.Location = new System.Drawing.Point(246, 271);
            this.DCButton.Name = "DCButton";
            this.DCButton.Size = new System.Drawing.Size(132, 23);
            this.DCButton.TabIndex = 7;
            this.DCButton.Text = "Datatypes Color";
            this.DCButton.UseVisualStyleBackColor = true;
            this.DCButton.Click += new System.EventHandler(this.QCButton_Click);
            // 
            // UCButton
            // 
            this.UCButton.Location = new System.Drawing.Point(246, 300);
            this.UCButton.Name = "UCButton";
            this.UCButton.Size = new System.Drawing.Size(132, 23);
            this.UCButton.TabIndex = 8;
            this.UCButton.Text = "Pre Defined Function";
            this.UCButton.UseVisualStyleBackColor = true;
            this.UCButton.Click += new System.EventHandler(this.QCButton_Click);
            // 
            // CCButton
            // 
            this.CCButton.Location = new System.Drawing.Point(246, 329);
            this.CCButton.Name = "CCButton";
            this.CCButton.Size = new System.Drawing.Size(132, 23);
            this.CCButton.TabIndex = 9;
            this.CCButton.Text = "Comments Color";
            this.CCButton.UseVisualStyleBackColor = true;
            this.CCButton.Click += new System.EventHandler(this.QCButton_Click);
            // 
            // RCButton
            // 
            this.RCButton.Location = new System.Drawing.Point(246, 213);
            this.RCButton.Name = "RCButton";
            this.RCButton.Size = new System.Drawing.Size(132, 23);
            this.RCButton.TabIndex = 10;
            this.RCButton.Text = "Reseved Color";
            this.RCButton.UseVisualStyleBackColor = true;
            this.RCButton.Click += new System.EventHandler(this.QCButton_Click);
            // 
            // QCButton
            // 
            this.QCButton.Location = new System.Drawing.Point(246, 358);
            this.QCButton.Name = "QCButton";
            this.QCButton.Size = new System.Drawing.Size(132, 23);
            this.QCButton.TabIndex = 11;
            this.QCButton.Text = "Quotations Color";
            this.QCButton.UseVisualStyleBackColor = true;
            this.QCButton.Click += new System.EventHandler(this.QCButton_Click);
            // 
            // KFButton
            // 
            this.KFButton.Location = new System.Drawing.Point(246, 184);
            this.KFButton.Name = "KFButton";
            this.KFButton.Size = new System.Drawing.Size(132, 23);
            this.KFButton.TabIndex = 12;
            this.KFButton.Text = "Keyword Font";
            this.KFButton.UseVisualStyleBackColor = true;
            this.KFButton.Click += new System.EventHandler(this.QCButton_Click);
            // 
            // EDButton
            // 
            this.EDButton.Location = new System.Drawing.Point(246, 97);
            this.EDButton.Name = "EDButton";
            this.EDButton.Size = new System.Drawing.Size(132, 23);
            this.EDButton.TabIndex = 13;
            this.EDButton.Text = "Editor Font";
            this.EDButton.UseVisualStyleBackColor = true;
            this.EDButton.Click += new System.EventHandler(this.QCButton_Click);
            // 
            // EFCButton
            // 
            this.EFCButton.Location = new System.Drawing.Point(246, 126);
            this.EFCButton.Name = "EFCButton";
            this.EFCButton.Size = new System.Drawing.Size(132, 23);
            this.EFCButton.TabIndex = 14;
            this.EFCButton.Text = "Editor Font Color";
            this.EFCButton.UseVisualStyleBackColor = true;
            this.EFCButton.Click += new System.EventHandler(this.QCButton_Click);
            // 
            // EBCButton
            // 
            this.EBCButton.Location = new System.Drawing.Point(246, 155);
            this.EBCButton.Name = "EBCButton";
            this.EBCButton.Size = new System.Drawing.Size(132, 23);
            this.EBCButton.TabIndex = 15;
            this.EBCButton.Text = "Editor Back Color";
            this.EBCButton.UseVisualStyleBackColor = true;
            this.EBCButton.Click += new System.EventHandler(this.QCButton_Click);
            // 
            // RWPanel
            // 
            this.RWPanel.Location = new System.Drawing.Point(12, 396);
            this.RWPanel.Name = "RWPanel";
            this.RWPanel.Size = new System.Drawing.Size(21, 20);
            this.RWPanel.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 401);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Reseved Words";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 429);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Operators";
            // 
            // OperatorPanel
            // 
            this.OperatorPanel.Location = new System.Drawing.Point(12, 424);
            this.OperatorPanel.Name = "OperatorPanel";
            this.OperatorPanel.Size = new System.Drawing.Size(21, 20);
            this.OperatorPanel.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(158, 401);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Datatypes";
            // 
            // DatatypesPanel
            // 
            this.DatatypesPanel.Location = new System.Drawing.Point(131, 396);
            this.DatatypesPanel.Name = "DatatypesPanel";
            this.DatatypesPanel.Size = new System.Drawing.Size(21, 20);
            this.DatatypesPanel.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 429);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Predefined Function";
            // 
            // PreDPanel
            // 
            this.PreDPanel.Location = new System.Drawing.Point(131, 424);
            this.PreDPanel.Name = "PreDPanel";
            this.PreDPanel.Size = new System.Drawing.Size(21, 20);
            this.PreDPanel.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(298, 400);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Comments";
            // 
            // CommentPanel
            // 
            this.CommentPanel.Location = new System.Drawing.Point(269, 396);
            this.CommentPanel.Name = "CommentPanel";
            this.CommentPanel.Size = new System.Drawing.Size(21, 20);
            this.CommentPanel.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(296, 429);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Quotation";
            // 
            // QuoPanel
            // 
            this.QuoPanel.Location = new System.Drawing.Point(269, 424);
            this.QuoPanel.Name = "QuoPanel";
            this.QuoPanel.Size = new System.Drawing.Size(21, 20);
            this.QuoPanel.TabIndex = 26;
            // 
            // KeyComboBox
            // 
            this.KeyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KeyComboBox.FormattingEnabled = true;
            this.KeyComboBox.Items.AddRange(new object[] {
            "Reseved",
            "Function",
            "Operator",
            "Datatype"});
            this.KeyComboBox.Location = new System.Drawing.Point(430, 38);
            this.KeyComboBox.Name = "KeyComboBox";
            this.KeyComboBox.Size = new System.Drawing.Size(67, 21);
            this.KeyComboBox.TabIndex = 28;
            // 
            // KCountLabel
            // 
            this.KCountLabel.AutoSize = true;
            this.KCountLabel.Location = new System.Drawing.Point(331, 15);
            this.KCountLabel.Name = "KCountLabel";
            this.KCountLabel.Size = new System.Drawing.Size(63, 13);
            this.KCountLabel.TabIndex = 29;
            this.KCountLabel.Text = "0 Keywords";
            // 
            // ChangeButton
            // 
            this.ChangeButton.BackgroundImage = global::Settings_Editor.Properties.Resources.IC;
            this.ChangeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ChangeButton.Location = new System.Drawing.Point(12, 9);
            this.ChangeButton.Name = "ChangeButton";
            this.ChangeButton.Size = new System.Drawing.Size(24, 25);
            this.ChangeButton.TabIndex = 30;
            this.ChangeButton.UseVisualStyleBackColor = true;
            this.ChangeButton.Click += new System.EventHandler(this.ChangeButton_Click);
            // 
            // SettingsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 456);
            this.Controls.Add(this.ChangeButton);
            this.Controls.Add(this.KCountLabel);
            this.Controls.Add(this.KeyComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.QuoPanel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CommentPanel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PreDPanel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DatatypesPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OperatorPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RWPanel);
            this.Controls.Add(this.EBCButton);
            this.Controls.Add(this.EFCButton);
            this.Controls.Add(this.EDButton);
            this.Controls.Add(this.KFButton);
            this.Controls.Add(this.QCButton);
            this.Controls.Add(this.RCButton);
            this.Controls.Add(this.CCButton);
            this.Controls.Add(this.UCButton);
            this.Controls.Add(this.DCButton);
            this.Controls.Add(this.OCButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.KAddTextBox);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.KAddButton);
            this.Controls.Add(this.KeywordsListView);
            this.Controls.Add(this.LanguageComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SettingsEditor";
            this.Text = "KeyWordsEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox LanguageComboBox;
        private System.Windows.Forms.ListView KeywordsListView;
        private System.Windows.Forms.Button KAddButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.TextBox KAddTextBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button OCButton;
        private System.Windows.Forms.Button DCButton;
        private System.Windows.Forms.Button UCButton;
        private System.Windows.Forms.Button CCButton;
        private System.Windows.Forms.Button RCButton;
        private System.Windows.Forms.Button QCButton;
        private System.Windows.Forms.Button KFButton;
        private System.Windows.Forms.Button EDButton;
        private System.Windows.Forms.Button EFCButton;
        private System.Windows.Forms.Button EBCButton;
        private System.Windows.Forms.ColorDialog GetColor;
        private System.Windows.Forms.FontDialog GetFont;
        private System.Windows.Forms.Panel RWPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel OperatorPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel DatatypesPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel PreDPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel CommentPanel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel QuoPanel;
        private System.Windows.Forms.ComboBox KeyComboBox;
        private System.Windows.Forms.Label KCountLabel;
        private System.Windows.Forms.Button ChangeButton;
    }
}