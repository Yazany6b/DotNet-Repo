namespace Readability_Test_Tool
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
            this.Import = new System.Windows.Forms.Button();
            this.CurrentFilePath = new System.Windows.Forms.TextBox();
            this.ErrorsList = new System.Windows.Forms.ListBox();
            this.SFDetails = new System.Windows.Forms.Button();
            this.Report = new System.Windows.Forms.Button();
            this.ReadingLabel = new System.Windows.Forms.Label();
            this.About = new System.Windows.Forms.Button();
            this.ShowButton = new System.Windows.Forms.Button();
            this.SettingGroup = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.FromText = new System.Windows.Forms.Button();
            this.TextArea = new System.Windows.Forms.RichTextBox();
            this.Buttons = new System.Windows.Forms.Panel();
            this.Buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // Import
            // 
            this.Import.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Import.Location = new System.Drawing.Point(242, 11);
            this.Import.Name = "Import";
            this.Import.Size = new System.Drawing.Size(120, 23);
            this.Import.TabIndex = 0;
            this.Import.Text = "Import java file";
            this.Import.UseVisualStyleBackColor = true;
            this.Import.Click += new System.EventHandler(this.Import_Click);
            // 
            // CurrentFilePath
            // 
            this.CurrentFilePath.Enabled = false;
            this.CurrentFilePath.Location = new System.Drawing.Point(6, 11);
            this.CurrentFilePath.Name = "CurrentFilePath";
            this.CurrentFilePath.Size = new System.Drawing.Size(225, 20);
            this.CurrentFilePath.TabIndex = 1;
            // 
            // ErrorsList
            // 
            this.ErrorsList.FormattingEnabled = true;
            this.ErrorsList.Location = new System.Drawing.Point(12, 445);
            this.ErrorsList.Name = "ErrorsList";
            this.ErrorsList.Size = new System.Drawing.Size(902, 95);
            this.ErrorsList.TabIndex = 3;
            // 
            // SFDetails
            // 
            this.SFDetails.Enabled = false;
            this.SFDetails.Location = new System.Drawing.Point(505, 11);
            this.SFDetails.Name = "SFDetails";
            this.SFDetails.Size = new System.Drawing.Size(152, 23);
            this.SFDetails.TabIndex = 42;
            this.SFDetails.Text = "Scope And Functions Details";
            this.SFDetails.UseVisualStyleBackColor = true;
            this.SFDetails.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // Report
            // 
            this.Report.Enabled = false;
            this.Report.Location = new System.Drawing.Point(665, 11);
            this.Report.Name = "Report";
            this.Report.Size = new System.Drawing.Size(105, 23);
            this.Report.TabIndex = 43;
            this.Report.Text = "Details Report";
            this.Report.UseVisualStyleBackColor = true;
            this.Report.Click += new System.EventHandler(this.button3_Click);
            // 
            // ReadingLabel
            // 
            this.ReadingLabel.AutoSize = true;
            this.ReadingLabel.BackColor = System.Drawing.Color.Transparent;
            this.ReadingLabel.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReadingLabel.Location = new System.Drawing.Point(7, 34);
            this.ReadingLabel.Name = "ReadingLabel";
            this.ReadingLabel.Size = new System.Drawing.Size(152, 18);
            this.ReadingLabel.TabIndex = 47;
            this.ReadingLabel.Text = "Reading File . . .";
            this.ReadingLabel.Visible = false;
            // 
            // About
            // 
            this.About.Location = new System.Drawing.Point(879, 11);
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(42, 23);
            this.About.TabIndex = 48;
            this.About.Text = "Help";
            this.About.UseVisualStyleBackColor = true;
            this.About.Click += new System.EventHandler(this.About_Click);
            // 
            // ShowButton
            // 
            this.ShowButton.Location = new System.Drawing.Point(370, 423);
            this.ShowButton.Name = "ShowButton";
            this.ShowButton.Size = new System.Drawing.Size(64, 23);
            this.ShowButton.TabIndex = 49;
            this.ShowButton.Text = "Settings";
            this.ShowButton.UseVisualStyleBackColor = true;
            this.ShowButton.Visible = false;
            this.ShowButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // SettingGroup
            // 
            this.SettingGroup.BackColor = System.Drawing.Color.Transparent;
            this.SettingGroup.Location = new System.Drawing.Point(11, 571);
            this.SettingGroup.Name = "SettingGroup";
            this.SettingGroup.Size = new System.Drawing.Size(903, 48);
            this.SettingGroup.TabIndex = 50;
            this.SettingGroup.TabStop = false;
            this.SettingGroup.Text = " Settings";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(776, 11);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Update Wights";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_2);
            // 
            // FromText
            // 
            this.FromText.Enabled = false;
            this.FromText.Location = new System.Drawing.Point(374, 11);
            this.FromText.Name = "FromText";
            this.FromText.Size = new System.Drawing.Size(121, 23);
            this.FromText.TabIndex = 51;
            this.FromText.Text = "Analyze Written Code";
            this.FromText.UseVisualStyleBackColor = true;
            this.FromText.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // TextArea
            // 
            this.TextArea.AcceptsTab = true;
            this.TextArea.Location = new System.Drawing.Point(12, 58);
            this.TextArea.MinimumSize = new System.Drawing.Size(100, 100);
            this.TextArea.Name = "TextArea";
            this.TextArea.Size = new System.Drawing.Size(902, 365);
            this.TextArea.TabIndex = 52;
            this.TextArea.Text = "";
            this.TextArea.TextChanged += new System.EventHandler(this.TextArea_TextChanged);
            // 
            // Buttons
            // 
            this.Buttons.AutoScroll = true;
            this.Buttons.BackColor = System.Drawing.Color.Transparent;
            this.Buttons.Controls.Add(this.button3);
            this.Buttons.Controls.Add(this.CurrentFilePath);
            this.Buttons.Controls.Add(this.Import);
            this.Buttons.Controls.Add(this.FromText);
            this.Buttons.Controls.Add(this.ReadingLabel);
            this.Buttons.Controls.Add(this.SFDetails);
            this.Buttons.Controls.Add(this.Report);
            this.Buttons.Controls.Add(this.About);
            this.Buttons.Location = new System.Drawing.Point(5, -4);
            this.Buttons.Name = "Buttons";
            this.Buttons.Size = new System.Drawing.Size(956, 56);
            this.Buttons.TabIndex = 53;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(935, 556);
            this.Controls.Add(this.Buttons);
            this.Controls.Add(this.TextArea);
            this.Controls.Add(this.SettingGroup);
            this.Controls.Add(this.ShowButton);
            this.Controls.Add(this.ErrorsList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Readability Tool";
            this.Buttons.ResumeLayout(false);
            this.Buttons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Import;
        private System.Windows.Forms.TextBox CurrentFilePath;
        private System.Windows.Forms.ListBox ErrorsList;
        private System.Windows.Forms.Button SFDetails;
        private System.Windows.Forms.Button Report;
        private System.Windows.Forms.Label ReadingLabel;

        //////////////////////////////////////////

        CodeDetails functions;
        string[] File;
        System.Windows.Forms.OpenFileDialog GetFile;
        System.Threading.Tasks.Task task;
        System.Threading.Tasks.Task showHide;
        bool showed = false;
        System.Drawing.Point old;
        private System.Windows.Forms.Button About;
        bool fromFile = false;
        private System.Windows.Forms.Button ShowButton;
        private System.Windows.Forms.GroupBox SettingGroup;
        WightUpdate wights;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button FromText;
        private System.Windows.Forms.RichTextBox TextArea;
        private System.Windows.Forms.Panel Buttons;
    }
}


