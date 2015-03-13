namespace Student_Assistant_Application
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editCoursesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openEstimatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arabicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.studentNameTextBox = new System.Windows.Forms.TextBox();
            this.majorNameTextBox = new System.Windows.Forms.TextBox();
            this.majorHoursTextBox = new System.Windows.Forms.TextBox();
            this.finishedHoursTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.createNewButton = new System.Windows.Forms.Button();
            this.passwordCheckBox = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.editCurrentButton = new System.Windows.Forms.Button();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.languageToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(341, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFileToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.backupToolStripMenuItem,
            this.reloadToolStripMenuItem,
            this.reloadBackupToolStripMenuItem,
            this.restartToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadFileToolStripMenuItem
            // 
            this.loadFileToolStripMenuItem.MergeIndex = 0;
            this.loadFileToolStripMenuItem.Name = "loadFileToolStripMenuItem";
            this.loadFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadFileToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.loadFileToolStripMenuItem.Text = "Load File";
            this.loadFileToolStripMenuItem.Click += new System.EventHandler(this.MenuToolStripClicked);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.MergeIndex = 1;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.MenuToolStripClicked);
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.MergeIndex = 2;
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.backupToolStripMenuItem.Text = "Backup";
            this.backupToolStripMenuItem.Click += new System.EventHandler(this.MenuToolStripClicked);
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.MergeIndex = 3;
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.reloadToolStripMenuItem.Text = "Reload";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.MenuToolStripClicked);
            // 
            // reloadBackupToolStripMenuItem
            // 
            this.reloadBackupToolStripMenuItem.MergeIndex = 4;
            this.reloadBackupToolStripMenuItem.Name = "reloadBackupToolStripMenuItem";
            this.reloadBackupToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.R)));
            this.reloadBackupToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.reloadBackupToolStripMenuItem.Text = "Reload Backup";
            this.reloadBackupToolStripMenuItem.Click += new System.EventHandler(this.MenuToolStripClicked);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.MergeIndex = 10;
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.MenuToolStripClicked);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.MergeIndex = 5;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.MenuToolStripClicked);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editCoursesToolStripMenuItem,
            this.showReportToolStripMenuItem,
            this.openEstimatorToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // editCoursesToolStripMenuItem
            // 
            this.editCoursesToolStripMenuItem.MergeIndex = 6;
            this.editCoursesToolStripMenuItem.Name = "editCoursesToolStripMenuItem";
            this.editCoursesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.editCoursesToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.editCoursesToolStripMenuItem.Text = "Edit Courses";
            this.editCoursesToolStripMenuItem.Click += new System.EventHandler(this.MenuToolStripClicked);
            // 
            // showReportToolStripMenuItem
            // 
            this.showReportToolStripMenuItem.MergeIndex = 7;
            this.showReportToolStripMenuItem.Name = "showReportToolStripMenuItem";
            this.showReportToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.showReportToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.showReportToolStripMenuItem.Text = "Show Report";
            this.showReportToolStripMenuItem.Click += new System.EventHandler(this.MenuToolStripClicked);
            // 
            // openEstimatorToolStripMenuItem
            // 
            this.openEstimatorToolStripMenuItem.MergeIndex = 8;
            this.openEstimatorToolStripMenuItem.Name = "openEstimatorToolStripMenuItem";
            this.openEstimatorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.openEstimatorToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.openEstimatorToolStripMenuItem.Text = "Open Estimator";
            this.openEstimatorToolStripMenuItem.Click += new System.EventHandler(this.MenuToolStripClicked);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.MergeIndex = 9;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.MenuToolStripClicked);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arabicToolStripMenuItem,
            this.englishToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // arabicToolStripMenuItem
            // 
            this.arabicToolStripMenuItem.Name = "arabicToolStripMenuItem";
            this.arabicToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.arabicToolStripMenuItem.Text = "Arabic";
            this.arabicToolStripMenuItem.Click += new System.EventHandler(this.LanguageMenuItemClicked);
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Checked = true;
            this.englishToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.englishToolStripMenuItem.Text = "English";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.LanguageMenuItemClicked);
            // 
            // studentNameTextBox
            // 
            this.studentNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.studentNameTextBox.Location = new System.Drawing.Point(118, 53);
            this.studentNameTextBox.Name = "studentNameTextBox";
            this.studentNameTextBox.ReadOnly = true;
            this.studentNameTextBox.Size = new System.Drawing.Size(218, 20);
            this.studentNameTextBox.TabIndex = 1;
            // 
            // majorNameTextBox
            // 
            this.majorNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.majorNameTextBox.Location = new System.Drawing.Point(118, 96);
            this.majorNameTextBox.Name = "majorNameTextBox";
            this.majorNameTextBox.ReadOnly = true;
            this.majorNameTextBox.Size = new System.Drawing.Size(218, 20);
            this.majorNameTextBox.TabIndex = 2;
            // 
            // majorHoursTextBox
            // 
            this.majorHoursTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.majorHoursTextBox.Location = new System.Drawing.Point(118, 139);
            this.majorHoursTextBox.Name = "majorHoursTextBox";
            this.majorHoursTextBox.ReadOnly = true;
            this.majorHoursTextBox.Size = new System.Drawing.Size(218, 20);
            this.majorHoursTextBox.TabIndex = 3;
            // 
            // finishedHoursTextBox
            // 
            this.finishedHoursTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.finishedHoursTextBox.Location = new System.Drawing.Point(118, 182);
            this.finishedHoursTextBox.Name = "finishedHoursTextBox";
            this.finishedHoursTextBox.ReadOnly = true;
            this.finishedHoursTextBox.Size = new System.Drawing.Size(218, 20);
            this.finishedHoursTextBox.TabIndex = 4;
            this.finishedHoursTextBox.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Student Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Major Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Major Hours";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Finished Hours";
            // 
            // createNewButton
            // 
            this.createNewButton.Location = new System.Drawing.Point(15, 271);
            this.createNewButton.Name = "createNewButton";
            this.createNewButton.Size = new System.Drawing.Size(107, 22);
            this.createNewButton.TabIndex = 10;
            this.createNewButton.Text = "Create New";
            this.createNewButton.UseVisualStyleBackColor = true;
            this.createNewButton.Click += new System.EventHandler(this.addAsNewButton_Click);
            // 
            // passwordCheckBox
            // 
            this.passwordCheckBox.AutoSize = true;
            this.passwordCheckBox.Enabled = false;
            this.passwordCheckBox.Location = new System.Drawing.Point(15, 224);
            this.passwordCheckBox.Name = "passwordCheckBox";
            this.passwordCheckBox.Size = new System.Drawing.Size(107, 17);
            this.passwordCheckBox.TabIndex = 11;
            this.passwordCheckBox.Text = "Enable Password";
            this.passwordCheckBox.UseVisualStyleBackColor = true;
            this.passwordCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(118, 221);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '*';
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(218, 20);
            this.textBox1.TabIndex = 12;
            // 
            // editCurrentButton
            // 
            this.editCurrentButton.Enabled = false;
            this.editCurrentButton.Location = new System.Drawing.Point(222, 271);
            this.editCurrentButton.Name = "editCurrentButton";
            this.editCurrentButton.Size = new System.Drawing.Size(107, 22);
            this.editCurrentButton.TabIndex = 13;
            this.editCurrentButton.Text = "Edit Current";
            this.editCurrentButton.UseVisualStyleBackColor = true;
            this.editCurrentButton.Click += new System.EventHandler(this.editCurrentButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 300);
            this.Controls.Add(this.editCurrentButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.passwordCheckBox);
            this.Controls.Add(this.createNewButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.finishedHoursTextBox);
            this.Controls.Add(this.majorHoursTextBox);
            this.Controls.Add(this.majorNameTextBox);
            this.Controls.Add(this.studentNameTextBox);
            this.Controls.Add(this.mainMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Student Assistant Application";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editCoursesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openEstimatorToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox studentNameTextBox;
        private System.Windows.Forms.TextBox majorNameTextBox;
        private System.Windows.Forms.TextBox majorHoursTextBox;
        private System.Windows.Forms.TextBox finishedHoursTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button createNewButton;
        private System.Windows.Forms.ToolStripMenuItem reloadBackupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.CheckBox passwordCheckBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button editCurrentButton;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arabicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;

    }
}