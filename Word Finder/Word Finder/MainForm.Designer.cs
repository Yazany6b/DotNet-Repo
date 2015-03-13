namespace Word_Finder
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
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.simpleLookingButton = new System.Windows.Forms.Button();
            this.wordTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.superLookingButton = new System.Windows.Forms.Button();
            this.statLabel = new System.Windows.Forms.Label();
            this.dicLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.totalLabel = new System.Windows.Forms.Label();
            this.currentLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ignoreButton = new System.Windows.Forms.Button();
            this.pauseContinueButton = new System.Windows.Forms.Button();
            this.abortButton = new System.Windows.Forms.Button();
            this.searchOpGroupBox = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.thierdSizeUnitComboBox = new System.Windows.Forms.ComboBox();
            this.thierdSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.secondSizeUnitComboBox = new System.Windows.Forms.ComboBox();
            this.secondSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.byRangeCheckBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.firstSizeUnitComboBox = new System.Windows.Forms.ComboBox();
            this.firstSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.bySizeCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.byWordCheckBox = new System.Windows.Forms.CheckBox();
            this.searchOpGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thierdSizeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondSizeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstSizeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(84, 12);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(388, 20);
            this.pathTextBox.TabIndex = 0;
            this.pathTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(84, 304);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(113, 29);
            this.browseButton.TabIndex = 1;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // simpleLookingButton
            // 
            this.simpleLookingButton.Enabled = false;
            this.simpleLookingButton.Location = new System.Drawing.Point(222, 304);
            this.simpleLookingButton.Name = "simpleLookingButton";
            this.simpleLookingButton.Size = new System.Drawing.Size(113, 29);
            this.simpleLookingButton.TabIndex = 2;
            this.simpleLookingButton.Text = "Simple Looking";
            this.simpleLookingButton.UseVisualStyleBackColor = true;
            this.simpleLookingButton.Click += new System.EventHandler(this.startLookingButton_Click);
            // 
            // wordTextBox
            // 
            this.wordTextBox.Location = new System.Drawing.Point(72, 36);
            this.wordTextBox.Name = "wordTextBox";
            this.wordTextBox.Size = new System.Drawing.Size(383, 20);
            this.wordTextBox.TabIndex = 3;
            this.wordTextBox.TextChanged += new System.EventHandler(this.wordTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Word";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(84, 279);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(388, 14);
            this.progressBar1.TabIndex = 6;
            // 
            // superLookingButton
            // 
            this.superLookingButton.Enabled = false;
            this.superLookingButton.Location = new System.Drawing.Point(359, 304);
            this.superLookingButton.Name = "superLookingButton";
            this.superLookingButton.Size = new System.Drawing.Size(113, 29);
            this.superLookingButton.TabIndex = 7;
            this.superLookingButton.Text = "Super Looking";
            this.superLookingButton.UseVisualStyleBackColor = true;
            this.superLookingButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // statLabel
            // 
            this.statLabel.AutoSize = true;
            this.statLabel.Location = new System.Drawing.Point(8, 218);
            this.statLabel.Name = "statLabel";
            this.statLabel.Size = new System.Drawing.Size(51, 13);
            this.statLabel.TabIndex = 8;
            this.statLabel.Text = "Directory";
            // 
            // dicLabel
            // 
            this.dicLabel.AutoSize = true;
            this.dicLabel.Location = new System.Drawing.Point(81, 220);
            this.dicLabel.Name = "dicLabel";
            this.dicLabel.Size = new System.Drawing.Size(19, 13);
            this.dicLabel.TabIndex = 9;
            this.dicLabel.Text = "XX";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Total Files";
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Location = new System.Drawing.Point(81, 241);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(13, 13);
            this.totalLabel.TabIndex = 11;
            this.totalLabel.Text = "0";
            // 
            // currentLabel
            // 
            this.currentLabel.AutoSize = true;
            this.currentLabel.Location = new System.Drawing.Point(81, 263);
            this.currentLabel.Name = "currentLabel";
            this.currentLabel.Size = new System.Drawing.Size(13, 13);
            this.currentLabel.TabIndex = 13;
            this.currentLabel.Text = "0";
            this.currentLabel.TextChanged += new System.EventHandler(this.currentLabel_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 262);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Searched Files";
            // 
            // ignoreButton
            // 
            this.ignoreButton.Enabled = false;
            this.ignoreButton.Location = new System.Drawing.Point(359, 343);
            this.ignoreButton.Name = "ignoreButton";
            this.ignoreButton.Size = new System.Drawing.Size(113, 29);
            this.ignoreButton.TabIndex = 16;
            this.ignoreButton.Text = "Ignore Directory";
            this.ignoreButton.UseVisualStyleBackColor = true;
            this.ignoreButton.Click += new System.EventHandler(this.ignoreButton_Click);
            // 
            // pauseContinueButton
            // 
            this.pauseContinueButton.Enabled = false;
            this.pauseContinueButton.Location = new System.Drawing.Point(222, 343);
            this.pauseContinueButton.Name = "pauseContinueButton";
            this.pauseContinueButton.Size = new System.Drawing.Size(113, 29);
            this.pauseContinueButton.TabIndex = 15;
            this.pauseContinueButton.Text = "Pause";
            this.pauseContinueButton.UseVisualStyleBackColor = true;
            this.pauseContinueButton.Click += new System.EventHandler(this.pauseContinueButton_Click);
            // 
            // abortButton
            // 
            this.abortButton.Enabled = false;
            this.abortButton.Location = new System.Drawing.Point(84, 343);
            this.abortButton.Name = "abortButton";
            this.abortButton.Size = new System.Drawing.Size(113, 29);
            this.abortButton.TabIndex = 14;
            this.abortButton.Text = "Abort";
            this.abortButton.UseVisualStyleBackColor = true;
            this.abortButton.Click += new System.EventHandler(this.abortButton_Click);
            // 
            // searchOpGroupBox
            // 
            this.searchOpGroupBox.Controls.Add(this.label7);
            this.searchOpGroupBox.Controls.Add(this.thierdSizeUnitComboBox);
            this.searchOpGroupBox.Controls.Add(this.thierdSizeNumericUpDown);
            this.searchOpGroupBox.Controls.Add(this.secondSizeUnitComboBox);
            this.searchOpGroupBox.Controls.Add(this.secondSizeNumericUpDown);
            this.searchOpGroupBox.Controls.Add(this.byRangeCheckBox);
            this.searchOpGroupBox.Controls.Add(this.label6);
            this.searchOpGroupBox.Controls.Add(this.firstSizeUnitComboBox);
            this.searchOpGroupBox.Controls.Add(this.firstSizeNumericUpDown);
            this.searchOpGroupBox.Controls.Add(this.bySizeCheckBox);
            this.searchOpGroupBox.Controls.Add(this.label4);
            this.searchOpGroupBox.Controls.Add(this.byWordCheckBox);
            this.searchOpGroupBox.Controls.Add(this.wordTextBox);
            this.searchOpGroupBox.Controls.Add(this.label2);
            this.searchOpGroupBox.Location = new System.Drawing.Point(11, 38);
            this.searchOpGroupBox.Name = "searchOpGroupBox";
            this.searchOpGroupBox.Size = new System.Drawing.Size(461, 177);
            this.searchOpGroupBox.TabIndex = 17;
            this.searchOpGroupBox.TabStop = false;
            this.searchOpGroupBox.Text = "Search Options";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(251, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "And";
            // 
            // thierdSizeUnitComboBox
            // 
            this.thierdSizeUnitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.thierdSizeUnitComboBox.FormattingEnabled = true;
            this.thierdSizeUnitComboBox.Items.AddRange(new object[] {
            "Byte",
            "KB",
            "MB",
            "GB"});
            this.thierdSizeUnitComboBox.Location = new System.Drawing.Point(393, 141);
            this.thierdSizeUnitComboBox.Name = "thierdSizeUnitComboBox";
            this.thierdSizeUnitComboBox.Size = new System.Drawing.Size(60, 21);
            this.thierdSizeUnitComboBox.TabIndex = 17;
            // 
            // thierdSizeNumericUpDown
            // 
            this.thierdSizeNumericUpDown.Location = new System.Drawing.Point(283, 141);
            this.thierdSizeNumericUpDown.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.thierdSizeNumericUpDown.Name = "thierdSizeNumericUpDown";
            this.thierdSizeNumericUpDown.Size = new System.Drawing.Size(94, 20);
            this.thierdSizeNumericUpDown.TabIndex = 16;
            this.thierdSizeNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // secondSizeUnitComboBox
            // 
            this.secondSizeUnitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.secondSizeUnitComboBox.FormattingEnabled = true;
            this.secondSizeUnitComboBox.Items.AddRange(new object[] {
            "Byte",
            "KB",
            "MB",
            "GB"});
            this.secondSizeUnitComboBox.Location = new System.Drawing.Point(183, 141);
            this.secondSizeUnitComboBox.Name = "secondSizeUnitComboBox";
            this.secondSizeUnitComboBox.Size = new System.Drawing.Size(60, 21);
            this.secondSizeUnitComboBox.TabIndex = 15;
            // 
            // secondSizeNumericUpDown
            // 
            this.secondSizeNumericUpDown.Location = new System.Drawing.Point(73, 141);
            this.secondSizeNumericUpDown.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.secondSizeNumericUpDown.Name = "secondSizeNumericUpDown";
            this.secondSizeNumericUpDown.Size = new System.Drawing.Size(94, 20);
            this.secondSizeNumericUpDown.TabIndex = 14;
            this.secondSizeNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // byRangeCheckBox
            // 
            this.byRangeCheckBox.AutoSize = true;
            this.byRangeCheckBox.Location = new System.Drawing.Point(18, 121);
            this.byRangeCheckBox.Name = "byRangeCheckBox";
            this.byRangeCheckBox.Size = new System.Drawing.Size(72, 17);
            this.byRangeCheckBox.TabIndex = 13;
            this.byRangeCheckBox.Text = "By Range";
            this.byRangeCheckBox.UseVisualStyleBackColor = true;
            this.byRangeCheckBox.CheckedChanged += new System.EventHandler(this.byRangeCheckBox_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Between";
            // 
            // firstSizeUnitComboBox
            // 
            this.firstSizeUnitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.firstSizeUnitComboBox.FormattingEnabled = true;
            this.firstSizeUnitComboBox.Items.AddRange(new object[] {
            "Byte",
            "KB",
            "MB",
            "GB"});
            this.firstSizeUnitComboBox.Location = new System.Drawing.Point(249, 81);
            this.firstSizeUnitComboBox.Name = "firstSizeUnitComboBox";
            this.firstSizeUnitComboBox.Size = new System.Drawing.Size(60, 21);
            this.firstSizeUnitComboBox.TabIndex = 11;
            // 
            // firstSizeNumericUpDown
            // 
            this.firstSizeNumericUpDown.Location = new System.Drawing.Point(73, 82);
            this.firstSizeNumericUpDown.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.firstSizeNumericUpDown.Name = "firstSizeNumericUpDown";
            this.firstSizeNumericUpDown.Size = new System.Drawing.Size(170, 20);
            this.firstSizeNumericUpDown.TabIndex = 10;
            this.firstSizeNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // bySizeCheckBox
            // 
            this.bySizeCheckBox.AutoSize = true;
            this.bySizeCheckBox.Location = new System.Drawing.Point(18, 62);
            this.bySizeCheckBox.Name = "bySizeCheckBox";
            this.bySizeCheckBox.Size = new System.Drawing.Size(60, 17);
            this.bySizeCheckBox.TabIndex = 9;
            this.bySizeCheckBox.Text = "By Size";
            this.bySizeCheckBox.UseVisualStyleBackColor = true;
            this.bySizeCheckBox.CheckedChanged += new System.EventHandler(this.bySizeCheckBox_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Size";
            // 
            // byWordCheckBox
            // 
            this.byWordCheckBox.AutoSize = true;
            this.byWordCheckBox.Location = new System.Drawing.Point(18, 17);
            this.byWordCheckBox.Name = "byWordCheckBox";
            this.byWordCheckBox.Size = new System.Drawing.Size(67, 17);
            this.byWordCheckBox.TabIndex = 6;
            this.byWordCheckBox.Text = "By Word";
            this.byWordCheckBox.UseVisualStyleBackColor = true;
            this.byWordCheckBox.CheckedChanged += new System.EventHandler(this.byWordCheckBox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(488, 375);
            this.Controls.Add(this.searchOpGroupBox);
            this.Controls.Add(this.ignoreButton);
            this.Controls.Add(this.pauseContinueButton);
            this.Controls.Add(this.abortButton);
            this.Controls.Add(this.currentLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dicLabel);
            this.Controls.Add(this.statLabel);
            this.Controls.Add(this.superLookingButton);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.simpleLookingButton);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.pathTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Word Searcher";
            this.searchOpGroupBox.ResumeLayout(false);
            this.searchOpGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thierdSizeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondSizeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstSizeNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Button simpleLookingButton;
        private System.Windows.Forms.TextBox wordTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button superLookingButton;
        private System.Windows.Forms.Label statLabel;
        private System.Windows.Forms.Label dicLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label currentLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ignoreButton;
        private System.Windows.Forms.Button pauseContinueButton;
        private System.Windows.Forms.Button abortButton;
        private System.Windows.Forms.GroupBox searchOpGroupBox;
        private System.Windows.Forms.CheckBox byWordCheckBox;
        private System.Windows.Forms.CheckBox bySizeCheckBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown firstSizeNumericUpDown;
        private System.Windows.Forms.ComboBox firstSizeUnitComboBox;
        private System.Windows.Forms.ComboBox secondSizeUnitComboBox;
        private System.Windows.Forms.NumericUpDown secondSizeNumericUpDown;
        private System.Windows.Forms.CheckBox byRangeCheckBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox thierdSizeUnitComboBox;
        private System.Windows.Forms.NumericUpDown thierdSizeNumericUpDown;
    }
}

