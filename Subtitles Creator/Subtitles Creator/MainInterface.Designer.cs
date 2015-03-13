namespace Subtitles_Creator
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
            this.videoPanel = new System.Windows.Forms.Panel();
            this.playButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.subtitleTextBox = new System.Windows.Forms.TextBox();
            this.startTimeTextBox = new System.Windows.Forms.TextBox();
            this.endTimeTextBox = new System.Windows.Forms.TextBox();
            this.acceptButton = new System.Windows.Forms.Button();
            this.subtitleRichTextBox = new System.Windows.Forms.RichTextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveButton = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.clearButtonButton = new System.Windows.Forms.Button();
            this.controlsPanel = new System.Windows.Forms.Panel();
            this.buttonsPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.controlsPanel.SuspendLayout();
            this.buttonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // videoPanel
            // 
            this.videoPanel.AutoSize = true;
            this.videoPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.videoPanel.Location = new System.Drawing.Point(12, 12);
            this.videoPanel.Name = "videoPanel";
            this.videoPanel.Size = new System.Drawing.Size(635, 363);
            this.videoPanel.TabIndex = 0;
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(3, 5);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(69, 23);
            this.playButton.TabIndex = 2;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(84, 5);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(69, 23);
            this.pauseButton.TabIndex = 3;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(165, 5);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(69, 23);
            this.stopButton.TabIndex = 4;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(253, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "0/0";
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(84, 34);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(69, 23);
            this.openButton.TabIndex = 6;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // subtitleTextBox
            // 
            this.subtitleTextBox.Location = new System.Drawing.Point(3, 102);
            this.subtitleTextBox.Name = "subtitleTextBox";
            this.subtitleTextBox.Size = new System.Drawing.Size(626, 20);
            this.subtitleTextBox.TabIndex = 7;
            this.subtitleTextBox.Enter += new System.EventHandler(this.textBox1_Enter);
            // 
            // startTimeTextBox
            // 
            this.startTimeTextBox.Location = new System.Drawing.Point(3, 76);
            this.startTimeTextBox.Name = "startTimeTextBox";
            this.startTimeTextBox.ReadOnly = true;
            this.startTimeTextBox.Size = new System.Drawing.Size(94, 20);
            this.startTimeTextBox.TabIndex = 8;
            // 
            // endTimeTextBox
            // 
            this.endTimeTextBox.Location = new System.Drawing.Point(109, 76);
            this.endTimeTextBox.Name = "endTimeTextBox";
            this.endTimeTextBox.ReadOnly = true;
            this.endTimeTextBox.Size = new System.Drawing.Size(94, 20);
            this.endTimeTextBox.TabIndex = 9;
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(3, 34);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(69, 23);
            this.acceptButton.TabIndex = 10;
            this.acceptButton.Text = "Accept";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // subtitleRichTextBox
            // 
            this.subtitleRichTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.subtitleRichTextBox.Location = new System.Drawing.Point(650, 12);
            this.subtitleRichTextBox.Name = "subtitleRichTextBox";
            this.subtitleRichTextBox.ReadOnly = true;
            this.subtitleRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.subtitleRichTextBox.Size = new System.Drawing.Size(382, 530);
            this.subtitleRichTextBox.TabIndex = 11;
            this.subtitleRichTextBox.Text = "";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Subtitle files |*.srt";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(165, 34);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(69, 23);
            this.saveButton.TabIndex = 12;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(12, 381);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(632, 45);
            this.trackBar1.TabIndex = 13;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // clearButtonButton
            // 
            this.clearButtonButton.Location = new System.Drawing.Point(215, 73);
            this.clearButtonButton.Name = "clearButtonButton";
            this.clearButtonButton.Size = new System.Drawing.Size(13, 23);
            this.clearButtonButton.TabIndex = 15;
            this.clearButtonButton.Text = "X";
            this.clearButtonButton.UseVisualStyleBackColor = true;
            this.clearButtonButton.Click += new System.EventHandler(this.clearButtonButton_Click);
            // 
            // controlsPanel
            // 
            this.controlsPanel.Controls.Add(this.buttonsPanel);
            this.controlsPanel.Controls.Add(this.clearButtonButton);
            this.controlsPanel.Controls.Add(this.label1);
            this.controlsPanel.Controls.Add(this.subtitleTextBox);
            this.controlsPanel.Controls.Add(this.endTimeTextBox);
            this.controlsPanel.Controls.Add(this.startTimeTextBox);
            this.controlsPanel.Location = new System.Drawing.Point(12, 416);
            this.controlsPanel.Name = "controlsPanel";
            this.controlsPanel.Size = new System.Drawing.Size(632, 126);
            this.controlsPanel.TabIndex = 0;
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Controls.Add(this.pauseButton);
            this.buttonsPanel.Controls.Add(this.stopButton);
            this.buttonsPanel.Controls.Add(this.acceptButton);
            this.buttonsPanel.Controls.Add(this.openButton);
            this.buttonsPanel.Controls.Add(this.playButton);
            this.buttonsPanel.Controls.Add(this.saveButton);
            this.buttonsPanel.Location = new System.Drawing.Point(198, 2);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(237, 61);
            this.buttonsPanel.TabIndex = 0;
            // 
            // MainInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 549);
            this.Controls.Add(this.controlsPanel);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.subtitleRichTextBox);
            this.Controls.Add(this.videoPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainInterface";
            this.Text = "Yazan\'s Subtitles Creator";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.controlsPanel.ResumeLayout(false);
            this.controlsPanel.PerformLayout();
            this.buttonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel videoPanel;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox subtitleTextBox;
        private System.Windows.Forms.TextBox startTimeTextBox;
        private System.Windows.Forms.TextBox endTimeTextBox;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.RichTextBox subtitleRichTextBox;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button clearButtonButton;
        private System.Windows.Forms.Panel controlsPanel;
        private System.Windows.Forms.Panel buttonsPanel;
    }
}

