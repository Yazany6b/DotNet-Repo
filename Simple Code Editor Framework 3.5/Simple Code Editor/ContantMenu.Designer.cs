namespace Simple_Code_Editor
{
    partial class ContantMenu
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
            this.KeywordsListView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // KeywordsListView
            // 
            this.KeywordsListView.Location = new System.Drawing.Point(7, 6);
            this.KeywordsListView.Name = "KeywordsListView";
            this.KeywordsListView.Size = new System.Drawing.Size(132, 215);
            this.KeywordsListView.TabIndex = 0;
            this.KeywordsListView.UseCompatibleStateImageBehavior = false;
            this.KeywordsListView.View = System.Windows.Forms.View.Tile;
            // 
            // ContantMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(145, 226);
            this.ControlBox = false;
            this.Controls.Add(this.KeywordsListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ContantMenu";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "ContantMenu";
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.ContantMenu_Deactivate);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView KeywordsListView;
    }
}