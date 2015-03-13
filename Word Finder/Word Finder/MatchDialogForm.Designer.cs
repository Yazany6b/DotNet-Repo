namespace Word_Finder
{
    partial class MatchDialogForm
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
            this.dicTextBox = new System.Windows.Forms.TextBox();
            this.fileTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.indexLabel = new System.Windows.Forms.Label();
            this.continueButton = new System.Windows.Forms.Button();
            this.abourButton = new System.Windows.Forms.Button();
            this.ignoreButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // dicTextBox
            // 
            this.dicTextBox.Location = new System.Drawing.Point(95, 39);
            this.dicTextBox.Name = "dicTextBox";
            this.dicTextBox.ReadOnly = true;
            this.dicTextBox.Size = new System.Drawing.Size(418, 20);
            this.dicTextBox.TabIndex = 0;
            // 
            // fileTextBox
            // 
            this.fileTextBox.Location = new System.Drawing.Point(95, 77);
            this.fileTextBox.Name = "fileTextBox";
            this.fileTextBox.ReadOnly = true;
            this.fileTextBox.Size = new System.Drawing.Size(418, 20);
            this.fileTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Directory";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "File Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Match Index";
            // 
            // indexLabel
            // 
            this.indexLabel.AutoSize = true;
            this.indexLabel.Location = new System.Drawing.Point(92, 113);
            this.indexLabel.Name = "indexLabel";
            this.indexLabel.Size = new System.Drawing.Size(13, 13);
            this.indexLabel.TabIndex = 5;
            this.indexLabel.Text = "0";
            // 
            // continueButton
            // 
            this.continueButton.Location = new System.Drawing.Point(12, 252);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(144, 33);
            this.continueButton.TabIndex = 0;
            this.continueButton.Text = "Continue";
            this.continueButton.UseVisualStyleBackColor = true;
            this.continueButton.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // abourButton
            // 
            this.abourButton.Location = new System.Drawing.Point(190, 252);
            this.abourButton.Name = "abourButton";
            this.abourButton.Size = new System.Drawing.Size(144, 33);
            this.abourButton.TabIndex = 1;
            this.abourButton.Text = "Abort";
            this.abourButton.UseVisualStyleBackColor = true;
            this.abourButton.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // ignoreButton
            // 
            this.ignoreButton.Location = new System.Drawing.Point(368, 252);
            this.ignoreButton.Name = "ignoreButton";
            this.ignoreButton.Size = new System.Drawing.Size(144, 33);
            this.ignoreButton.TabIndex = 2;
            this.ignoreButton.Text = "Ignore Current Directiory";
            this.ignoreButton.UseVisualStyleBackColor = true;
            this.ignoreButton.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 18F);
            this.label4.Location = new System.Drawing.Point(181, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "A Match Found";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 142);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(500, 104);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // MatchDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 305);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ignoreButton);
            this.Controls.Add(this.abourButton);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.indexLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fileTextBox);
            this.Controls.Add(this.dicTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MatchDialogForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MatchDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox dicTextBox;
        private System.Windows.Forms.TextBox fileTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label indexLabel;
        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.Button abourButton;
        private System.Windows.Forms.Button ignoreButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}