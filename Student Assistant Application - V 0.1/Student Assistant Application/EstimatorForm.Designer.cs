namespace Student_Assistant_Application
{
    partial class EstimatorForm
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
            this.hoursNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.avgNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.estimateButton = new System.Windows.Forms.Button();
            this.currentInfoPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.hoursNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.avgNumericUpDown)).BeginInit();
            this.currentInfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // hoursNumericUpDown
            // 
            this.hoursNumericUpDown.Location = new System.Drawing.Point(88, 18);
            this.hoursNumericUpDown.Name = "hoursNumericUpDown";
            this.hoursNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.hoursNumericUpDown.TabIndex = 0;
            // 
            // avgNumericUpDown
            // 
            this.avgNumericUpDown.DecimalPlaces = 3;
            this.avgNumericUpDown.Location = new System.Drawing.Point(88, 56);
            this.avgNumericUpDown.Name = "avgNumericUpDown";
            this.avgNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.avgNumericUpDown.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Your Average Must Be";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Average";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Hours";
            // 
            // estimateButton
            // 
            this.estimateButton.Location = new System.Drawing.Point(9, 87);
            this.estimateButton.Name = "estimateButton";
            this.estimateButton.Size = new System.Drawing.Size(69, 24);
            this.estimateButton.TabIndex = 5;
            this.estimateButton.Text = "Estimate";
            this.estimateButton.UseVisualStyleBackColor = true;
            this.estimateButton.Click += new System.EventHandler(this.estimateButton_Click);
            // 
            // currentInfoPanel
            // 
            this.currentInfoPanel.Controls.Add(this.label3);
            this.currentInfoPanel.Controls.Add(this.hoursNumericUpDown);
            this.currentInfoPanel.Controls.Add(this.avgNumericUpDown);
            this.currentInfoPanel.Controls.Add(this.estimateButton);
            this.currentInfoPanel.Controls.Add(this.label1);
            this.currentInfoPanel.Controls.Add(this.label2);
            this.currentInfoPanel.Location = new System.Drawing.Point(5, 12);
            this.currentInfoPanel.Name = "currentInfoPanel";
            this.currentInfoPanel.Size = new System.Drawing.Size(224, 143);
            this.currentInfoPanel.TabIndex = 8;
            // 
            // EstimatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(238, 174);
            this.Controls.Add(this.currentInfoPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EstimatorForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "The Estimator";
            ((System.ComponentModel.ISupportInitialize)(this.hoursNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.avgNumericUpDown)).EndInit();
            this.currentInfoPanel.ResumeLayout(false);
            this.currentInfoPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown hoursNumericUpDown;
        private System.Windows.Forms.NumericUpDown avgNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button estimateButton;
        private System.Windows.Forms.Panel currentInfoPanel;

    }
}