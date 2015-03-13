namespace Readability_Test_Tool
{
    partial class ScopeAndFunctions
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.FunctionsDetails = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReturnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccessModifier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Recursive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.FunctionsDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // FunctionsDetails
            // 
            this.FunctionsDetails.AllowUserToAddRows = false;
            this.FunctionsDetails.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FunctionsDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.FunctionsDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FunctionsDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5,
            this.ReturnType,
            this.AccessModifier,
            this.Recursive});
            this.FunctionsDetails.Location = new System.Drawing.Point(-2, 1);
            this.FunctionsDetails.Name = "FunctionsDetails";
            this.FunctionsDetails.ReadOnly = true;
            this.FunctionsDetails.Size = new System.Drawing.Size(583, 476);
            this.FunctionsDetails.TabIndex = 1;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Function Name";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 120;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Static";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // ReturnType
            // 
            this.ReturnType.HeaderText = "Returen Type";
            this.ReturnType.Name = "ReturnType";
            this.ReturnType.ReadOnly = true;
            // 
            // AccessModifier
            // 
            this.AccessModifier.HeaderText = "Access Modifier";
            this.AccessModifier.Name = "AccessModifier";
            this.AccessModifier.ReadOnly = true;
            // 
            // Recursive
            // 
            this.Recursive.HeaderText = "Recursive";
            this.Recursive.Name = "Recursive";
            this.Recursive.ReadOnly = true;
            // 
            // ScopeAndFunctions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 480);
            this.Controls.Add(this.FunctionsDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(586, 508);
            this.MinimumSize = new System.Drawing.Size(586, 508);
            this.Name = "ScopeAndFunctions";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.FunctionsDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView FunctionsDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReturnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccessModifier;
        private System.Windows.Forms.DataGridViewTextBoxColumn Recursive;
    }
}