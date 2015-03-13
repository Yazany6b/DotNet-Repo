namespace Student_Assistant_Application
{
    partial class StudentForm
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
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.majorNameTextBox = new System.Windows.Forms.TextBox();
            this.studentNameTextBox = new System.Windows.Forms.TextBox();
            this.majorHoursNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.showCharCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.majorHoursNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordTextBox.Location = new System.Drawing.Point(111, 141);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(218, 20);
            this.passwordTextBox.TabIndex = 22;
            // 
            // passwordCheckBox
            // 
            this.passwordCheckBox.AutoSize = true;
            this.passwordCheckBox.Location = new System.Drawing.Point(2, 132);
            this.passwordCheckBox.Name = "passwordCheckBox";
            this.passwordCheckBox.Size = new System.Drawing.Size(107, 17);
            this.passwordCheckBox.TabIndex = 21;
            this.passwordCheckBox.Text = "Enable Password";
            this.passwordCheckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Major Hours";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Major Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Student Name";
            // 
            // majorNameTextBox
            // 
            this.majorNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.majorNameTextBox.Location = new System.Drawing.Point(111, 62);
            this.majorNameTextBox.Name = "majorNameTextBox";
            this.majorNameTextBox.Size = new System.Drawing.Size(218, 20);
            this.majorNameTextBox.TabIndex = 14;
            // 
            // studentNameTextBox
            // 
            this.studentNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.studentNameTextBox.Location = new System.Drawing.Point(111, 22);
            this.studentNameTextBox.Name = "studentNameTextBox";
            this.studentNameTextBox.Size = new System.Drawing.Size(218, 20);
            this.studentNameTextBox.TabIndex = 13;
            // 
            // majorHoursNumericUpDown
            // 
            this.majorHoursNumericUpDown.Location = new System.Drawing.Point(111, 102);
            this.majorHoursNumericUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.majorHoursNumericUpDown.Minimum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.majorHoursNumericUpDown.Name = "majorHoursNumericUpDown";
            this.majorHoursNumericUpDown.Size = new System.Drawing.Size(218, 20);
            this.majorHoursNumericUpDown.TabIndex = 23;
            this.majorHoursNumericUpDown.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(19, 182);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 24;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(125, 182);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 25;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(233, 182);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 26;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // showCharCheckBox
            // 
            this.showCharCheckBox.AutoSize = true;
            this.showCharCheckBox.Location = new System.Drawing.Point(2, 155);
            this.showCharCheckBox.Name = "showCharCheckBox";
            this.showCharCheckBox.Size = new System.Drawing.Size(108, 17);
            this.showCharCheckBox.TabIndex = 27;
            this.showCharCheckBox.Text = "Show Characters";
            this.showCharCheckBox.UseVisualStyleBackColor = true;
            this.showCharCheckBox.CheckedChanged += new System.EventHandler(this.showCharCheckBox_CheckedChanged);
            // 
            // StudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 209);
            this.Controls.Add(this.showCharCheckBox);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.majorHoursNumericUpDown);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.passwordCheckBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.majorNameTextBox);
            this.Controls.Add(this.studentNameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StudentForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "StudentForm";
            ((System.ComponentModel.ISupportInitialize)(this.majorHoursNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.CheckBox passwordCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox majorNameTextBox;
        private System.Windows.Forms.TextBox studentNameTextBox;
        private System.Windows.Forms.NumericUpDown majorHoursNumericUpDown;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.CheckBox showCharCheckBox;
    }
}