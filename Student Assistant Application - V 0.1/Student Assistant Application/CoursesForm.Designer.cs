namespace Student_Assistant_Application
{
    partial class CoursesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CoursesForm));
            this.avgLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.markNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.hoursNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.courseListVciew = new System.Windows.Forms.ListView();
            this.editButton = new System.Windows.Forms.Button();
            this.computedCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.markNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hoursNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // avgLabel
            // 
            this.avgLabel.AutoSize = true;
            this.avgLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avgLabel.Location = new System.Drawing.Point(-2, 382);
            this.avgLabel.Name = "avgLabel";
            this.avgLabel.Size = new System.Drawing.Size(0, 19);
            this.avgLabel.TabIndex = 11;
            // 
            // nameTextBox
            // 
            this.nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameTextBox.Location = new System.Drawing.Point(238, 12);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(159, 20);
            this.nameTextBox.TabIndex = 0;
            this.nameTextBox.Enter += new System.EventHandler(this.nameTextBox_Enter);
            // 
            // markNumericUpDown
            // 
            this.markNumericUpDown.Location = new System.Drawing.Point(238, 38);
            this.markNumericUpDown.Minimum = new decimal(new int[] {
            35,
            0,
            0,
            0});
            this.markNumericUpDown.Name = "markNumericUpDown";
            this.markNumericUpDown.Size = new System.Drawing.Size(159, 20);
            this.markNumericUpDown.TabIndex = 1;
            this.markNumericUpDown.Value = new decimal(new int[] {
            35,
            0,
            0,
            0});
            this.markNumericUpDown.Enter += new System.EventHandler(this.markNumericUpDown_Enter);
            // 
            // hoursNumericUpDown
            // 
            this.hoursNumericUpDown.Location = new System.Drawing.Point(238, 64);
            this.hoursNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.hoursNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.hoursNumericUpDown.Name = "hoursNumericUpDown";
            this.hoursNumericUpDown.Size = new System.Drawing.Size(157, 20);
            this.hoursNumericUpDown.TabIndex = 2;
            this.hoursNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.hoursNumericUpDown.Enter += new System.EventHandler(this.markNumericUpDown_Enter);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(238, 114);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(79, 36);
            this.addButton.TabIndex = 4;
            this.addButton.Text = "ADD";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(238, 206);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(79, 36);
            this.removeButton.TabIndex = 5;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // courseListVciew
            // 
            this.courseListVciew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.courseListVciew.Location = new System.Drawing.Point(3, 12);
            this.courseListVciew.Name = "courseListVciew";
            this.courseListVciew.Size = new System.Drawing.Size(229, 381);
            this.courseListVciew.TabIndex = 10;
            this.courseListVciew.UseCompatibleStateImageBehavior = false;
            this.courseListVciew.View = System.Windows.Forms.View.Tile;
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(238, 160);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(79, 36);
            this.editButton.TabIndex = 12;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // computedCheckBox
            // 
            this.computedCheckBox.AutoSize = true;
            this.computedCheckBox.Location = new System.Drawing.Point(238, 90);
            this.computedCheckBox.Name = "computedCheckBox";
            this.computedCheckBox.Size = new System.Drawing.Size(75, 17);
            this.computedCheckBox.TabIndex = 15;
            this.computedCheckBox.Text = "Computed";
            this.computedCheckBox.UseVisualStyleBackColor = true;
            // 
            // CoursesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 405);
            this.Controls.Add(this.computedCheckBox);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.avgLabel);
            this.Controls.Add(this.courseListVciew);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.hoursNumericUpDown);
            this.Controls.Add(this.markNumericUpDown);
            this.Controls.Add(this.nameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CoursesForm";
            this.Text = "Edit Courses";
            ((System.ComponentModel.ISupportInitialize)(this.markNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hoursNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label avgLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.NumericUpDown markNumericUpDown;
        private System.Windows.Forms.NumericUpDown hoursNumericUpDown;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.ListView courseListVciew;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.CheckBox computedCheckBox;
    }
}

