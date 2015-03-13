namespace Smart_Regions_Sketcher.Dialogs
{
    partial class EditFreamsFrom
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
            this.prevButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.sketchPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.waitNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.setButton = new System.Windows.Forms.Button();
            this.setAllButton = new System.Windows.Forms.Button();
            this.setRestButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.waitNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // prevButton
            // 
            this.prevButton.Location = new System.Drawing.Point(331, 439);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(75, 23);
            this.prevButton.TabIndex = 0;
            this.prevButton.Text = "Previous";
            this.prevButton.UseVisualStyleBackColor = true;
            this.prevButton.Click += new System.EventHandler(this.prevButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(426, 439);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 1;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // sketchPanel
            // 
            this.sketchPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sketchPanel.Location = new System.Drawing.Point(10, 12);
            this.sketchPanel.Name = "sketchPanel";
            this.sketchPanel.Size = new System.Drawing.Size(488, 421);
            this.sketchPanel.TabIndex = 2;
            this.sketchPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.sketchPanel_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 443);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Wait Ms";
            // 
            // waitNumericUpDown
            // 
            this.waitNumericUpDown.Location = new System.Drawing.Point(58, 441);
            this.waitNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.waitNumericUpDown.Name = "waitNumericUpDown";
            this.waitNumericUpDown.Size = new System.Drawing.Size(54, 20);
            this.waitNumericUpDown.TabIndex = 4;
            this.waitNumericUpDown.ValueChanged += new System.EventHandler(this.waitNumericUpDown_ValueChanged);
            // 
            // setButton
            // 
            this.setButton.Location = new System.Drawing.Point(114, 440);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(37, 23);
            this.setButton.TabIndex = 5;
            this.setButton.Text = "Set";
            this.setButton.UseVisualStyleBackColor = true;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // setAllButton
            // 
            this.setAllButton.Location = new System.Drawing.Point(157, 441);
            this.setAllButton.Name = "setAllButton";
            this.setAllButton.Size = new System.Drawing.Size(66, 23);
            this.setAllButton.TabIndex = 6;
            this.setAllButton.Text = "Set To All";
            this.setAllButton.UseVisualStyleBackColor = true;
            this.setAllButton.Click += new System.EventHandler(this.setAllButton_Click);
            // 
            // setRestButton
            // 
            this.setRestButton.Location = new System.Drawing.Point(229, 441);
            this.setRestButton.Name = "setRestButton";
            this.setRestButton.Size = new System.Drawing.Size(80, 23);
            this.setRestButton.TabIndex = 7;
            this.setRestButton.Text = "Set To Rest";
            this.setRestButton.UseVisualStyleBackColor = true;
            this.setRestButton.Click += new System.EventHandler(this.setRestButton_Click);
            // 
            // EditFreamsFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 474);
            this.Controls.Add(this.setRestButton);
            this.Controls.Add(this.setAllButton);
            this.Controls.Add(this.setButton);
            this.Controls.Add(this.waitNumericUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sketchPanel);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.prevButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditFreamsFrom";
            this.Text = "EditFrom";
            this.Load += new System.EventHandler(this.EditFreamsFrom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.waitNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button prevButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Panel sketchPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown waitNumericUpDown;
        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.Button setAllButton;
        private System.Windows.Forms.Button setRestButton;
    }
}