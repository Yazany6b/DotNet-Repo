namespace Subtitles_Files_Time_Modifier
{
    partial class MainInterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainInterface));
            this.importButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.performButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.subtitleRichTextBox = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.startNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.endNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.allRadioButton = new System.Windows.Forms.RadioButton();
            this.impRadioButton = new System.Windows.Forms.RadioButton();
            this.backRadioButton = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.toolsGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.findNextButton = new System.Windows.Forms.Button();
            this.findTextBox = new System.Windows.Forms.TextBox();
            this.aboutLabel = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.swapButton = new System.Windows.Forms.Button();
            this.clsAllButton = new System.Windows.Forms.Button();
            this.clsButton = new System.Windows.Forms.Button();
            this.equalButton = new System.Windows.Forms.Button();
            this.divButton = new System.Windows.Forms.Button();
            this.multButton = new System.Windows.Forms.Button();
            this.minusButton = new System.Windows.Forms.Button();
            this.plusButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.hoursFilterRadioButton = new System.Windows.Forms.RadioButton();
            this.minutesFilterRadioButton = new System.Windows.Forms.RadioButton();
            this.secondsFilterRadioButton = new System.Windows.Forms.RadioButton();
            this.timeFilterRadioButton = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.operand2MaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.operand1MaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.goButton = new System.Windows.Forms.Button();
            this.goNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.endLineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.startLineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.unitComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.startNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.toolsGroupBox.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.goNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endLineNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startLineNumericUpDown)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(553, 72);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(75, 23);
            this.importButton.TabIndex = 0;
            this.importButton.Text = "Import";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(655, 72);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(75, 23);
            this.exportButton.TabIndex = 1;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // performButton
            // 
            this.performButton.Enabled = false;
            this.performButton.Location = new System.Drawing.Point(12, 72);
            this.performButton.Name = "performButton";
            this.performButton.Size = new System.Drawing.Size(78, 23);
            this.performButton.TabIndex = 2;
            this.performButton.Text = "Perform";
            this.performButton.UseVisualStyleBackColor = true;
            this.performButton.Click += new System.EventHandler(this.performButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Add to start Time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Add to end Time";
            // 
            // subtitleRichTextBox
            // 
            this.subtitleRichTextBox.BackColor = System.Drawing.Color.White;
            this.subtitleRichTextBox.Font = new System.Drawing.Font("Century", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtitleRichTextBox.Location = new System.Drawing.Point(12, 101);
            this.subtitleRichTextBox.Name = "subtitleRichTextBox";
            this.subtitleRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.subtitleRichTextBox.Size = new System.Drawing.Size(718, 429);
            this.subtitleRichTextBox.TabIndex = 7;
            this.subtitleRichTextBox.Text = "";
            this.subtitleRichTextBox.WordWrap = false;
            this.subtitleRichTextBox.HScroll += new System.EventHandler(this.subtitleRichTextBox_HScroll);
            this.subtitleRichTextBox.SelectionChanged += new System.EventHandler(this.subtitleRichTextBox_SelectionChanged);
            this.subtitleRichTextBox.VScroll += new System.EventHandler(this.subtitleRichTextBox_VScroll);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Subtitle files |*.srt";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Subtitle files |*.srt";
            // 
            // startNumericUpDown
            // 
            this.startNumericUpDown.Location = new System.Drawing.Point(108, 21);
            this.startNumericUpDown.Maximum = new decimal(new int[] {
            5000000,
            0,
            0,
            0});
            this.startNumericUpDown.Minimum = new decimal(new int[] {
            5000000,
            0,
            0,
            -2147483648});
            this.startNumericUpDown.Name = "startNumericUpDown";
            this.startNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.startNumericUpDown.TabIndex = 8;
            // 
            // endNumericUpDown
            // 
            this.endNumericUpDown.Location = new System.Drawing.Point(108, 47);
            this.endNumericUpDown.Maximum = new decimal(new int[] {
            5000000,
            0,
            0,
            0});
            this.endNumericUpDown.Minimum = new decimal(new int[] {
            5000000,
            0,
            0,
            -2147483648});
            this.endNumericUpDown.Name = "endNumericUpDown";
            this.endNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.endNumericUpDown.TabIndex = 9;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(96, 72);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(451, 23);
            this.progressBar1.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.allRadioButton);
            this.groupBox1.Controls.Add(this.impRadioButton);
            this.groupBox1.Controls.Add(this.backRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(553, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 64);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Performance";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(175, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // allRadioButton
            // 
            this.allRadioButton.AutoSize = true;
            this.allRadioButton.Checked = true;
            this.allRadioButton.Location = new System.Drawing.Point(123, 27);
            this.allRadioButton.Name = "allRadioButton";
            this.allRadioButton.Size = new System.Drawing.Size(36, 17);
            this.allRadioButton.TabIndex = 2;
            this.allRadioButton.TabStop = true;
            this.allRadioButton.Text = "All";
            this.allRadioButton.UseVisualStyleBackColor = true;
            // 
            // impRadioButton
            // 
            this.impRadioButton.AutoSize = true;
            this.impRadioButton.Location = new System.Drawing.Point(6, 40);
            this.impRadioButton.Name = "impRadioButton";
            this.impRadioButton.Size = new System.Drawing.Size(98, 17);
            this.impRadioButton.TabIndex = 1;
            this.impRadioButton.Text = "Important Only";
            this.impRadioButton.UseVisualStyleBackColor = true;
            // 
            // backRadioButton
            // 
            this.backRadioButton.AutoSize = true;
            this.backRadioButton.Location = new System.Drawing.Point(6, 18);
            this.backRadioButton.Name = "backRadioButton";
            this.backRadioButton.Size = new System.Drawing.Size(94, 17);
            this.backRadioButton.TabIndex = 0;
            this.backRadioButton.Text = "In Background";
            this.backRadioButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(12, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(289, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Enter Postive numbers to increase or negative to decrease";
            // 
            // toolsGroupBox
            // 
            this.toolsGroupBox.Controls.Add(this.groupBox7);
            this.toolsGroupBox.Controls.Add(this.aboutLabel);
            this.toolsGroupBox.Controls.Add(this.groupBox4);
            this.toolsGroupBox.Controls.Add(this.groupBox3);
            this.toolsGroupBox.Location = new System.Drawing.Point(736, 2);
            this.toolsGroupBox.Name = "toolsGroupBox";
            this.toolsGroupBox.Size = new System.Drawing.Size(260, 528);
            this.toolsGroupBox.TabIndex = 13;
            this.toolsGroupBox.TabStop = false;
            this.toolsGroupBox.Text = "Tools";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.findNextButton);
            this.groupBox7.Controls.Add(this.findTextBox);
            this.groupBox7.Location = new System.Drawing.Point(20, 422);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(220, 65);
            this.groupBox7.TabIndex = 21;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Search";
            // 
            // findNextButton
            // 
            this.findNextButton.Location = new System.Drawing.Point(9, 42);
            this.findNextButton.Name = "findNextButton";
            this.findNextButton.Size = new System.Drawing.Size(92, 20);
            this.findNextButton.TabIndex = 1;
            this.findNextButton.Text = "Find Next";
            this.findNextButton.UseVisualStyleBackColor = true;
            this.findNextButton.Click += new System.EventHandler(this.findNextButton_Click);
            // 
            // findTextBox
            // 
            this.findTextBox.Location = new System.Drawing.Point(9, 19);
            this.findTextBox.Name = "findTextBox";
            this.findTextBox.Size = new System.Drawing.Size(205, 20);
            this.findTextBox.TabIndex = 0;
            // 
            // aboutLabel
            // 
            this.aboutLabel.AutoSize = true;
            this.aboutLabel.Font = new System.Drawing.Font("Tempus Sans ITC", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutLabel.ForeColor = System.Drawing.Color.Maroon;
            this.aboutLabel.Location = new System.Drawing.Point(89, 490);
            this.aboutLabel.Name = "aboutLabel";
            this.aboutLabel.Size = new System.Drawing.Size(89, 35);
            this.aboutLabel.TabIndex = 20;
            this.aboutLabel.Text = "About";
            this.aboutLabel.Click += new System.EventHandler(this.aboutLabel_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.resultTextBox);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.operand2MaskedTextBox);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.operand1MaskedTextBox);
            this.groupBox4.Location = new System.Drawing.Point(20, 70);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(220, 351);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Time Calculator";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.swapButton);
            this.groupBox6.Controls.Add(this.clsAllButton);
            this.groupBox6.Controls.Add(this.clsButton);
            this.groupBox6.Controls.Add(this.equalButton);
            this.groupBox6.Controls.Add(this.divButton);
            this.groupBox6.Controls.Add(this.multButton);
            this.groupBox6.Controls.Add(this.minusButton);
            this.groupBox6.Controls.Add(this.plusButton);
            this.groupBox6.Location = new System.Drawing.Point(9, 195);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(199, 150);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Operation";
            // 
            // swapButton
            // 
            this.swapButton.Location = new System.Drawing.Point(118, 90);
            this.swapButton.Name = "swapButton";
            this.swapButton.Size = new System.Drawing.Size(75, 23);
            this.swapButton.TabIndex = 6;
            this.swapButton.Text = "Swap";
            this.swapButton.UseVisualStyleBackColor = true;
            this.swapButton.Click += new System.EventHandler(this.Tool_Cal_Opera_Clicked);
            // 
            // clsAllButton
            // 
            this.clsAllButton.Location = new System.Drawing.Point(118, 61);
            this.clsAllButton.Name = "clsAllButton";
            this.clsAllButton.Size = new System.Drawing.Size(75, 23);
            this.clsAllButton.TabIndex = 5;
            this.clsAllButton.Text = "Clear All";
            this.clsAllButton.UseVisualStyleBackColor = true;
            this.clsAllButton.Click += new System.EventHandler(this.Tool_Cal_Opera_Clicked);
            // 
            // clsButton
            // 
            this.clsButton.Location = new System.Drawing.Point(118, 32);
            this.clsButton.Name = "clsButton";
            this.clsButton.Size = new System.Drawing.Size(75, 23);
            this.clsButton.TabIndex = 4;
            this.clsButton.Text = "Clear";
            this.clsButton.UseVisualStyleBackColor = true;
            this.clsButton.Click += new System.EventHandler(this.Tool_Cal_Opera_Clicked);
            // 
            // equalButton
            // 
            this.equalButton.Location = new System.Drawing.Point(118, 119);
            this.equalButton.Name = "equalButton";
            this.equalButton.Size = new System.Drawing.Size(75, 23);
            this.equalButton.TabIndex = 7;
            this.equalButton.Text = "Snipping";
            this.equalButton.UseVisualStyleBackColor = true;
            this.equalButton.Click += new System.EventHandler(this.Tool_Cal_Opera_Clicked);
            // 
            // divButton
            // 
            this.divButton.Location = new System.Drawing.Point(6, 119);
            this.divButton.Name = "divButton";
            this.divButton.Size = new System.Drawing.Size(75, 23);
            this.divButton.TabIndex = 3;
            this.divButton.Text = "/";
            this.divButton.UseVisualStyleBackColor = true;
            this.divButton.Click += new System.EventHandler(this.Tool_Cal_Opera_Clicked);
            // 
            // multButton
            // 
            this.multButton.Location = new System.Drawing.Point(6, 90);
            this.multButton.Name = "multButton";
            this.multButton.Size = new System.Drawing.Size(75, 23);
            this.multButton.TabIndex = 2;
            this.multButton.Text = "*";
            this.multButton.UseVisualStyleBackColor = true;
            this.multButton.Click += new System.EventHandler(this.Tool_Cal_Opera_Clicked);
            // 
            // minusButton
            // 
            this.minusButton.Location = new System.Drawing.Point(6, 32);
            this.minusButton.Name = "minusButton";
            this.minusButton.Size = new System.Drawing.Size(75, 23);
            this.minusButton.TabIndex = 0;
            this.minusButton.Text = "+";
            this.minusButton.UseVisualStyleBackColor = true;
            this.minusButton.Click += new System.EventHandler(this.Tool_Cal_Opera_Clicked);
            // 
            // plusButton
            // 
            this.plusButton.Location = new System.Drawing.Point(6, 61);
            this.plusButton.Name = "plusButton";
            this.plusButton.Size = new System.Drawing.Size(75, 23);
            this.plusButton.TabIndex = 1;
            this.plusButton.Text = "-";
            this.plusButton.UseVisualStyleBackColor = true;
            this.plusButton.Click += new System.EventHandler(this.Tool_Cal_Opera_Clicked);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 163);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Result";
            // 
            // resultTextBox
            // 
            this.resultTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.resultTextBox.Location = new System.Drawing.Point(59, 160);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.ReadOnly = true;
            this.resultTextBox.Size = new System.Drawing.Size(149, 20);
            this.resultTextBox.TabIndex = 5;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.hoursFilterRadioButton);
            this.groupBox5.Controls.Add(this.minutesFilterRadioButton);
            this.groupBox5.Controls.Add(this.secondsFilterRadioButton);
            this.groupBox5.Controls.Add(this.timeFilterRadioButton);
            this.groupBox5.Location = new System.Drawing.Point(6, 85);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(202, 69);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Result Filter";
            // 
            // hoursFilterRadioButton
            // 
            this.hoursFilterRadioButton.AutoSize = true;
            this.hoursFilterRadioButton.Location = new System.Drawing.Point(78, 42);
            this.hoursFilterRadioButton.Name = "hoursFilterRadioButton";
            this.hoursFilterRadioButton.Size = new System.Drawing.Size(53, 17);
            this.hoursFilterRadioButton.TabIndex = 3;
            this.hoursFilterRadioButton.Text = "Hours";
            this.hoursFilterRadioButton.UseVisualStyleBackColor = true;
            // 
            // minutesFilterRadioButton
            // 
            this.minutesFilterRadioButton.AutoSize = true;
            this.minutesFilterRadioButton.Location = new System.Drawing.Point(6, 42);
            this.minutesFilterRadioButton.Name = "minutesFilterRadioButton";
            this.minutesFilterRadioButton.Size = new System.Drawing.Size(62, 17);
            this.minutesFilterRadioButton.TabIndex = 2;
            this.minutesFilterRadioButton.Text = "Minutes";
            this.minutesFilterRadioButton.UseVisualStyleBackColor = true;
            // 
            // secondsFilterRadioButton
            // 
            this.secondsFilterRadioButton.AutoSize = true;
            this.secondsFilterRadioButton.Location = new System.Drawing.Point(75, 19);
            this.secondsFilterRadioButton.Name = "secondsFilterRadioButton";
            this.secondsFilterRadioButton.Size = new System.Drawing.Size(65, 17);
            this.secondsFilterRadioButton.TabIndex = 1;
            this.secondsFilterRadioButton.Text = "Seconds";
            this.secondsFilterRadioButton.UseVisualStyleBackColor = true;
            // 
            // timeFilterRadioButton
            // 
            this.timeFilterRadioButton.AutoSize = true;
            this.timeFilterRadioButton.Checked = true;
            this.timeFilterRadioButton.Location = new System.Drawing.Point(6, 19);
            this.timeFilterRadioButton.Name = "timeFilterRadioButton";
            this.timeFilterRadioButton.Size = new System.Drawing.Size(47, 17);
            this.timeFilterRadioButton.TabIndex = 0;
            this.timeFilterRadioButton.TabStop = true;
            this.timeFilterRadioButton.Text = "Time";
            this.timeFilterRadioButton.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Op2";
            // 
            // operand2MaskedTextBox
            // 
            this.operand2MaskedTextBox.Location = new System.Drawing.Point(59, 55);
            this.operand2MaskedTextBox.Mask = "00:00:00";
            this.operand2MaskedTextBox.Name = "operand2MaskedTextBox";
            this.operand2MaskedTextBox.PromptChar = '0';
            this.operand2MaskedTextBox.Size = new System.Drawing.Size(149, 20);
            this.operand2MaskedTextBox.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Op1";
            // 
            // operand1MaskedTextBox
            // 
            this.operand1MaskedTextBox.Location = new System.Drawing.Point(59, 29);
            this.operand1MaskedTextBox.Mask = "00:00:00";
            this.operand1MaskedTextBox.Name = "operand1MaskedTextBox";
            this.operand1MaskedTextBox.PromptChar = '0';
            this.operand1MaskedTextBox.Size = new System.Drawing.Size(149, 20);
            this.operand1MaskedTextBox.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.goButton);
            this.groupBox3.Controls.Add(this.goNumericUpDown);
            this.groupBox3.Location = new System.Drawing.Point(20, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(220, 48);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Go To Line";
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(164, 19);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(50, 20);
            this.goButton.TabIndex = 1;
            this.goButton.Text = "Go";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // goNumericUpDown
            // 
            this.goNumericUpDown.Location = new System.Drawing.Point(6, 19);
            this.goNumericUpDown.Name = "goNumericUpDown";
            this.goNumericUpDown.Size = new System.Drawing.Size(152, 20);
            this.goNumericUpDown.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Font = new System.Drawing.Font("Tempus Sans ITC", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(570, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 35);
            this.label4.TabIndex = 14;
            this.label4.Text = ".";
            this.label4.Visible = false;
            // 
            // endLineNumericUpDown
            // 
            this.endLineNumericUpDown.Location = new System.Drawing.Point(374, 47);
            this.endLineNumericUpDown.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.endLineNumericUpDown.Name = "endLineNumericUpDown";
            this.endLineNumericUpDown.Size = new System.Drawing.Size(78, 20);
            this.endLineNumericUpDown.TabIndex = 18;
            this.endLineNumericUpDown.ValueChanged += new System.EventHandler(this.endLineNumericUpDown_ValueChanged);
            // 
            // startLineNumericUpDown
            // 
            this.startLineNumericUpDown.Location = new System.Drawing.Point(374, 21);
            this.startLineNumericUpDown.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.startLineNumericUpDown.Name = "startLineNumericUpDown";
            this.startLineNumericUpDown.Size = new System.Drawing.Size(78, 20);
            this.startLineNumericUpDown.TabIndex = 17;
            this.startLineNumericUpDown.ValueChanged += new System.EventHandler(this.startLineNumericUpDown_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(315, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "End line";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(315, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Start Line";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tempus Sans ITC", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Maroon;
            this.label7.Location = new System.Drawing.Point(455, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 35);
            this.label7.TabIndex = 19;
            this.label7.Text = "/";
            // 
            // unitComboBox
            // 
            this.unitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.unitComboBox.FormattingEnabled = true;
            this.unitComboBox.Items.AddRange(new object[] {
            "MS",
            "Sec",
            "Minu",
            "Hours"});
            this.unitComboBox.Location = new System.Drawing.Point(6, 18);
            this.unitComboBox.Name = "unitComboBox";
            this.unitComboBox.Size = new System.Drawing.Size(68, 21);
            this.unitComboBox.TabIndex = 20;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.unitComboBox);
            this.groupBox8.Location = new System.Drawing.Point(234, 18);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(80, 49);
            this.groupBox8.TabIndex = 21;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Unit";
            // 
            // MainInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 542);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.endLineNumericUpDown);
            this.Controls.Add(this.startLineNumericUpDown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.toolsGroupBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.endNumericUpDown);
            this.Controls.Add(this.startNumericUpDown);
            this.Controls.Add(this.subtitleRichTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.performButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.importButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainInterface";
            this.Text = "The Subtitles Modifier";
            ((System.ComponentModel.ISupportInitialize)(this.startNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolsGroupBox.ResumeLayout(false);
            this.toolsGroupBox.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.goNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endLineNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startLineNumericUpDown)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button performButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox subtitleRichTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.NumericUpDown startNumericUpDown;
        private System.Windows.Forms.NumericUpDown endNumericUpDown;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton impRadioButton;
        private System.Windows.Forms.RadioButton backRadioButton;
        private System.Windows.Forms.RadioButton allRadioButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox toolsGroupBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown endLineNumericUpDown;
        private System.Windows.Forms.NumericUpDown startLineNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.NumericUpDown goNumericUpDown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.MaskedTextBox operand1MaskedTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox operand2MaskedTextBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton timeFilterRadioButton;
        private System.Windows.Forms.RadioButton secondsFilterRadioButton;
        private System.Windows.Forms.RadioButton minutesFilterRadioButton;
        private System.Windows.Forms.RadioButton hoursFilterRadioButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button plusButton;
        private System.Windows.Forms.Button minusButton;
        private System.Windows.Forms.Button multButton;
        private System.Windows.Forms.Button divButton;
        private System.Windows.Forms.Button swapButton;
        private System.Windows.Forms.Button clsAllButton;
        private System.Windows.Forms.Button clsButton;
        private System.Windows.Forms.Button equalButton;
        private System.Windows.Forms.Label aboutLabel;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button findNextButton;
        private System.Windows.Forms.TextBox findTextBox;
        private System.Windows.Forms.ComboBox unitComboBox;
        private System.Windows.Forms.GroupBox groupBox8;
    }
}

