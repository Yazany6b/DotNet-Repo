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
            this.AdvancedCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.coursesButton = new System.Windows.Forms.Button();
            this.estimateCurrentButton = new System.Windows.Forms.Button();
            this.advAvgNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.advEstimateButton = new System.Windows.Forms.Button();
            this.advAvgLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.messageLabel = new System.Windows.Forms.Label();
            this.computedCheckBox = new System.Windows.Forms.CheckBox();
            this.editButton = new System.Windows.Forms.Button();
            this.ecoursesListVciew = new System.Windows.Forms.ListView();
            this.removeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.advHoursNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.markNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.coursesListView = new System.Windows.Forms.ListView();
            this.currentInfoPanel = new System.Windows.Forms.Panel();
            this.existInfoPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.existHoursNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.existAveageNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.hoursNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.avgNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advAvgNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advHoursNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.markNumericUpDown)).BeginInit();
            this.currentInfoPanel.SuspendLayout();
            this.existInfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.existHoursNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.existAveageNumericUpDown)).BeginInit();
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
            // AdvancedCheckBox
            // 
            this.AdvancedCheckBox.AutoSize = true;
            this.AdvancedCheckBox.Location = new System.Drawing.Point(15, 163);
            this.AdvancedCheckBox.Name = "AdvancedCheckBox";
            this.AdvancedCheckBox.Size = new System.Drawing.Size(101, 17);
            this.AdvancedCheckBox.TabIndex = 6;
            this.AdvancedCheckBox.Text = "More Advanced";
            this.AdvancedCheckBox.UseVisualStyleBackColor = true;
            this.AdvancedCheckBox.CheckedChanged += new System.EventHandler(this.AdvancedCheckBox_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.coursesButton);
            this.groupBox1.Controls.Add(this.estimateCurrentButton);
            this.groupBox1.Controls.Add(this.advAvgNumericUpDown);
            this.groupBox1.Controls.Add(this.advEstimateButton);
            this.groupBox1.Controls.Add(this.advAvgLabel);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.messageLabel);
            this.groupBox1.Controls.Add(this.computedCheckBox);
            this.groupBox1.Controls.Add(this.editButton);
            this.groupBox1.Controls.Add(this.ecoursesListVciew);
            this.groupBox1.Controls.Add(this.removeButton);
            this.groupBox1.Controls.Add(this.addButton);
            this.groupBox1.Controls.Add(this.advHoursNumericUpDown);
            this.groupBox1.Controls.Add(this.markNumericUpDown);
            this.groupBox1.Controls.Add(this.nameTextBox);
            this.groupBox1.Controls.Add(this.coursesListView);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(230, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(443, 389);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Advanced Estimator";
            // 
            // coursesButton
            // 
            this.coursesButton.Location = new System.Drawing.Point(218, 248);
            this.coursesButton.Name = "coursesButton";
            this.coursesButton.Size = new System.Drawing.Size(79, 36);
            this.coursesButton.TabIndex = 32;
            this.coursesButton.Text = "Courses";
            this.coursesButton.UseVisualStyleBackColor = true;
            this.coursesButton.Click += new System.EventHandler(this.coursesButton_Click);
            // 
            // estimateCurrentButton
            // 
            this.estimateCurrentButton.Enabled = false;
            this.estimateCurrentButton.Location = new System.Drawing.Point(303, 332);
            this.estimateCurrentButton.Name = "estimateCurrentButton";
            this.estimateCurrentButton.Size = new System.Drawing.Size(135, 36);
            this.estimateCurrentButton.TabIndex = 30;
            this.estimateCurrentButton.Text = "Estimate Current Marks";
            this.estimateCurrentButton.UseVisualStyleBackColor = true;
            this.estimateCurrentButton.Click += new System.EventHandler(this.estimateCurrentButton_Click);
            // 
            // advAvgNumericUpDown
            // 
            this.advAvgNumericUpDown.DecimalPlaces = 3;
            this.advAvgNumericUpDown.Location = new System.Drawing.Point(272, 306);
            this.advAvgNumericUpDown.Name = "advAvgNumericUpDown";
            this.advAvgNumericUpDown.Size = new System.Drawing.Size(105, 20);
            this.advAvgNumericUpDown.TabIndex = 26;
            // 
            // advEstimateButton
            // 
            this.advEstimateButton.Location = new System.Drawing.Point(218, 334);
            this.advEstimateButton.Name = "advEstimateButton";
            this.advEstimateButton.Size = new System.Drawing.Size(79, 36);
            this.advEstimateButton.TabIndex = 29;
            this.advEstimateButton.Text = "Estimate";
            this.advEstimateButton.UseVisualStyleBackColor = true;
            this.advEstimateButton.Click += new System.EventHandler(this.advEstimateButton_Click);
            // 
            // advAvgLabel
            // 
            this.advAvgLabel.AutoSize = true;
            this.advAvgLabel.Location = new System.Drawing.Point(218, 371);
            this.advAvgLabel.Name = "advAvgLabel";
            this.advAvgLabel.Size = new System.Drawing.Size(114, 13);
            this.advAvgLabel.TabIndex = 27;
            this.advAvgLabel.Text = "Your Average Must Be";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(218, 308);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Average";
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(-43, 17);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(13, 13);
            this.messageLabel.TabIndex = 25;
            this.messageLabel.Text = "X";
            // 
            // computedCheckBox
            // 
            this.computedCheckBox.AutoSize = true;
            this.computedCheckBox.Location = new System.Drawing.Point(218, 94);
            this.computedCheckBox.Name = "computedCheckBox";
            this.computedCheckBox.Size = new System.Drawing.Size(75, 17);
            this.computedCheckBox.TabIndex = 24;
            this.computedCheckBox.Text = "Computed";
            this.computedCheckBox.UseVisualStyleBackColor = true;
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(218, 160);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(79, 36);
            this.editButton.TabIndex = 23;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // ecoursesListVciew
            // 
            this.ecoursesListVciew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ecoursesListVciew.Location = new System.Drawing.Point(6, 15);
            this.ecoursesListVciew.Name = "ecoursesListVciew";
            this.ecoursesListVciew.Size = new System.Drawing.Size(206, 368);
            this.ecoursesListVciew.TabIndex = 22;
            this.ecoursesListVciew.UseCompatibleStateImageBehavior = false;
            this.ecoursesListVciew.View = System.Windows.Forms.View.Tile;
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(218, 204);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(79, 36);
            this.removeButton.TabIndex = 21;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(218, 116);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(79, 36);
            this.addButton.TabIndex = 20;
            this.addButton.Text = "ADD";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // advHoursNumericUpDown
            // 
            this.advHoursNumericUpDown.Location = new System.Drawing.Point(218, 68);
            this.advHoursNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.advHoursNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.advHoursNumericUpDown.Name = "advHoursNumericUpDown";
            this.advHoursNumericUpDown.Size = new System.Drawing.Size(159, 20);
            this.advHoursNumericUpDown.TabIndex = 19;
            this.advHoursNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // markNumericUpDown
            // 
            this.markNumericUpDown.Enabled = false;
            this.markNumericUpDown.Location = new System.Drawing.Point(218, 42);
            this.markNumericUpDown.Name = "markNumericUpDown";
            this.markNumericUpDown.Size = new System.Drawing.Size(159, 20);
            this.markNumericUpDown.TabIndex = 18;
            // 
            // nameTextBox
            // 
            this.nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameTextBox.Location = new System.Drawing.Point(218, 16);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(159, 20);
            this.nameTextBox.TabIndex = 17;
            // 
            // coursesListView
            // 
            this.coursesListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.coursesListView.Location = new System.Drawing.Point(6, 15);
            this.coursesListView.Name = "coursesListView";
            this.coursesListView.Size = new System.Drawing.Size(206, 368);
            this.coursesListView.TabIndex = 31;
            this.coursesListView.UseCompatibleStateImageBehavior = false;
            this.coursesListView.View = System.Windows.Forms.View.Tile;
            this.coursesListView.Visible = false;
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
            // existInfoPanel
            // 
            this.existInfoPanel.Controls.Add(this.label4);
            this.existInfoPanel.Controls.Add(this.existHoursNumericUpDown);
            this.existInfoPanel.Controls.Add(this.existAveageNumericUpDown);
            this.existInfoPanel.Controls.Add(this.label7);
            this.existInfoPanel.Enabled = false;
            this.existInfoPanel.Location = new System.Drawing.Point(2, 247);
            this.existInfoPanel.Name = "existInfoPanel";
            this.existInfoPanel.Size = new System.Drawing.Size(224, 94);
            this.existInfoPanel.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Hours";
            // 
            // existHoursNumericUpDown
            // 
            this.existHoursNumericUpDown.Location = new System.Drawing.Point(88, 18);
            this.existHoursNumericUpDown.Name = "existHoursNumericUpDown";
            this.existHoursNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.existHoursNumericUpDown.TabIndex = 0;
            // 
            // existAveageNumericUpDown
            // 
            this.existAveageNumericUpDown.DecimalPlaces = 3;
            this.existAveageNumericUpDown.Location = new System.Drawing.Point(88, 56);
            this.existAveageNumericUpDown.Name = "existAveageNumericUpDown";
            this.existAveageNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.existAveageNumericUpDown.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Average";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(5, 224);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(99, 17);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "From Exist Info";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // EstimatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(564, 423);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.existInfoPanel);
            this.Controls.Add(this.currentInfoPanel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.AdvancedCheckBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EstimatorForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "The Estimator";
            ((System.ComponentModel.ISupportInitialize)(this.hoursNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.avgNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advAvgNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advHoursNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.markNumericUpDown)).EndInit();
            this.currentInfoPanel.ResumeLayout(false);
            this.currentInfoPanel.PerformLayout();
            this.existInfoPanel.ResumeLayout(false);
            this.existInfoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.existHoursNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.existAveageNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown hoursNumericUpDown;
        private System.Windows.Forms.NumericUpDown avgNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button estimateButton;
        private System.Windows.Forms.CheckBox AdvancedCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.CheckBox computedCheckBox;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.ListView ecoursesListVciew;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.NumericUpDown advHoursNumericUpDown;
        private System.Windows.Forms.NumericUpDown markNumericUpDown;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Panel currentInfoPanel;
        private System.Windows.Forms.NumericUpDown advAvgNumericUpDown;
        private System.Windows.Forms.Button advEstimateButton;
        private System.Windows.Forms.Label advAvgLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button estimateCurrentButton;
        private System.Windows.Forms.ListView coursesListView;
        private System.Windows.Forms.Button coursesButton;
        private System.Windows.Forms.Panel existInfoPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown existHoursNumericUpDown;
        private System.Windows.Forms.NumericUpDown existAveageNumericUpDown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBox1;

    }
}