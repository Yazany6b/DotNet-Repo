namespace Smart_Regions_Sketcher
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainInterface));
            this.sketchPanel = new System.Windows.Forms.Panel();
            this.selectionPanel = new System.Windows.Forms.Panel();
            this.clearButton = new System.Windows.Forms.Button();
            this.editPointsButton = new System.Windows.Forms.Button();
            this.selectorsCheckBox = new System.Windows.Forms.CheckBox();
            this.moveButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.loactionLabel = new System.Windows.Forms.Label();
            this.methodGroupBox = new System.Windows.Forms.GroupBox();
            this.polygonsRadioButton = new System.Windows.Forms.RadioButton();
            this.linesRadioButton = new System.Windows.Forms.RadioButton();
            this.lockCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.functionsPanel = new System.Windows.Forms.Panel();
            this.playTimeLabel = new System.Windows.Forms.Label();
            this.freamIndexLabel = new System.Windows.Forms.Label();
            this.prevFreamButton = new System.Windows.Forms.Button();
            this.nextFreamButton = new System.Windows.Forms.Button();
            this.freamsCheckBox = new System.Windows.Forms.CheckBox();
            this.viewFreamsButton = new System.Windows.Forms.Button();
            this.playFreamsButton = new System.Windows.Forms.Button();
            this.saveFreamButton = new System.Windows.Forms.Button();
            this.resizeRegionButton = new System.Windows.Forms.Button();
            this.fixingButton = new System.Windows.Forms.Button();
            this.moveCheckBox = new System.Windows.Forms.CheckBox();
            this.bitmapButton = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.selectorContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cloneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.sketchPanel.SuspendLayout();
            this.methodGroupBox.SuspendLayout();
            this.functionsPanel.SuspendLayout();
            this.selectorContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // sketchPanel
            // 
            this.sketchPanel.BackColor = System.Drawing.SystemColors.Control;
            this.sketchPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.sketchPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sketchPanel.Controls.Add(this.selectionPanel);
            this.sketchPanel.ForeColor = System.Drawing.Color.Black;
            this.sketchPanel.Location = new System.Drawing.Point(82, 25);
            this.sketchPanel.Name = "sketchPanel";
            this.sketchPanel.Size = new System.Drawing.Size(437, 547);
            this.sketchPanel.TabIndex = 0;
            this.sketchPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.SketchPanelPaint);
            this.sketchPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SketchMouseMoved);
            this.sketchPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SketchMouseUp);
            // 
            // selectionPanel
            // 
            this.selectionPanel.BackColor = System.Drawing.Color.Transparent;
            this.selectionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectionPanel.Location = new System.Drawing.Point(3, 3);
            this.selectionPanel.Name = "selectionPanel";
            this.selectionPanel.Size = new System.Drawing.Size(33, 35);
            this.selectionPanel.TabIndex = 0;
            this.selectionPanel.Visible = false;
            // 
            // clearButton
            // 
            this.clearButton.ForeColor = System.Drawing.Color.Black;
            this.clearButton.Location = new System.Drawing.Point(3, 5);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(82, 23);
            this.clearButton.TabIndex = 1;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // editPointsButton
            // 
            this.editPointsButton.ForeColor = System.Drawing.Color.Black;
            this.editPointsButton.Location = new System.Drawing.Point(3, 36);
            this.editPointsButton.Name = "editPointsButton";
            this.editPointsButton.Size = new System.Drawing.Size(82, 23);
            this.editPointsButton.TabIndex = 2;
            this.editPointsButton.Text = "Edit Points";
            this.editPointsButton.UseVisualStyleBackColor = true;
            this.editPointsButton.Click += new System.EventHandler(this.editPointsButton_Click);
            // 
            // selectorsCheckBox
            // 
            this.selectorsCheckBox.AutoSize = true;
            this.selectorsCheckBox.Location = new System.Drawing.Point(6, 380);
            this.selectorsCheckBox.Name = "selectorsCheckBox";
            this.selectorsCheckBox.Size = new System.Drawing.Size(70, 17);
            this.selectorsCheckBox.TabIndex = 14;
            this.selectorsCheckBox.Text = "Selectors";
            this.selectorsCheckBox.UseVisualStyleBackColor = true;
            this.selectorsCheckBox.CheckedChanged += new System.EventHandler(this.selectorsCheckBox_CheckedChanged);
            // 
            // moveButton
            // 
            this.moveButton.ForeColor = System.Drawing.Color.Black;
            this.moveButton.Location = new System.Drawing.Point(3, 68);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(82, 23);
            this.moveButton.TabIndex = 21;
            this.moveButton.Text = "Move Region";
            this.moveButton.UseVisualStyleBackColor = true;
            this.moveButton.Click += new System.EventHandler(this.moveButton_Click);
            // 
            // importButton
            // 
            this.importButton.ForeColor = System.Drawing.Color.Black;
            this.importButton.Location = new System.Drawing.Point(3, 132);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(82, 23);
            this.importButton.TabIndex = 22;
            this.importButton.Text = "Import";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.ForeColor = System.Drawing.Color.Black;
            this.exportButton.Location = new System.Drawing.Point(3, 164);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(82, 23);
            this.exportButton.TabIndex = 23;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // loactionLabel
            // 
            this.loactionLabel.AutoSize = true;
            this.loactionLabel.Location = new System.Drawing.Point(0, 13);
            this.loactionLabel.Name = "loactionLabel";
            this.loactionLabel.Size = new System.Drawing.Size(51, 13);
            this.loactionLabel.TabIndex = 24;
            this.loactionLabel.Text = "X=0;Y=0";
            // 
            // methodGroupBox
            // 
            this.methodGroupBox.Controls.Add(this.polygonsRadioButton);
            this.methodGroupBox.Controls.Add(this.linesRadioButton);
            this.methodGroupBox.Location = new System.Drawing.Point(6, 476);
            this.methodGroupBox.Name = "methodGroupBox";
            this.methodGroupBox.Size = new System.Drawing.Size(83, 68);
            this.methodGroupBox.TabIndex = 25;
            this.methodGroupBox.TabStop = false;
            this.methodGroupBox.Text = "Method";
            // 
            // polygonsRadioButton
            // 
            this.polygonsRadioButton.AutoSize = true;
            this.polygonsRadioButton.Location = new System.Drawing.Point(6, 42);
            this.polygonsRadioButton.Name = "polygonsRadioButton";
            this.polygonsRadioButton.Size = new System.Drawing.Size(68, 17);
            this.polygonsRadioButton.TabIndex = 1;
            this.polygonsRadioButton.Text = "Polygons";
            this.polygonsRadioButton.UseVisualStyleBackColor = true;
            this.polygonsRadioButton.CheckedChanged += new System.EventHandler(this.SketchMethodChanged);
            // 
            // linesRadioButton
            // 
            this.linesRadioButton.AutoSize = true;
            this.linesRadioButton.Checked = true;
            this.linesRadioButton.Location = new System.Drawing.Point(6, 19);
            this.linesRadioButton.Name = "linesRadioButton";
            this.linesRadioButton.Size = new System.Drawing.Size(49, 17);
            this.linesRadioButton.TabIndex = 0;
            this.linesRadioButton.TabStop = true;
            this.linesRadioButton.Text = "Lines";
            this.linesRadioButton.UseVisualStyleBackColor = true;
            this.linesRadioButton.CheckedChanged += new System.EventHandler(this.SketchMethodChanged);
            // 
            // lockCheckBox
            // 
            this.lockCheckBox.AutoSize = true;
            this.lockCheckBox.Location = new System.Drawing.Point(6, 403);
            this.lockCheckBox.Name = "lockCheckBox";
            this.lockCheckBox.Size = new System.Drawing.Size(47, 17);
            this.lockCheckBox.TabIndex = 26;
            this.lockCheckBox.Text = "Lock";
            this.lockCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "__";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "|";
            // 
            // functionsPanel
            // 
            this.functionsPanel.Controls.Add(this.playTimeLabel);
            this.functionsPanel.Controls.Add(this.freamIndexLabel);
            this.functionsPanel.Controls.Add(this.prevFreamButton);
            this.functionsPanel.Controls.Add(this.nextFreamButton);
            this.functionsPanel.Controls.Add(this.freamsCheckBox);
            this.functionsPanel.Controls.Add(this.viewFreamsButton);
            this.functionsPanel.Controls.Add(this.playFreamsButton);
            this.functionsPanel.Controls.Add(this.saveFreamButton);
            this.functionsPanel.Controls.Add(this.resizeRegionButton);
            this.functionsPanel.Controls.Add(this.fixingButton);
            this.functionsPanel.Controls.Add(this.moveCheckBox);
            this.functionsPanel.Controls.Add(this.clearButton);
            this.functionsPanel.Controls.Add(this.editPointsButton);
            this.functionsPanel.Controls.Add(this.selectorsCheckBox);
            this.functionsPanel.Controls.Add(this.lockCheckBox);
            this.functionsPanel.Controls.Add(this.moveButton);
            this.functionsPanel.Controls.Add(this.methodGroupBox);
            this.functionsPanel.Controls.Add(this.importButton);
            this.functionsPanel.Controls.Add(this.exportButton);
            this.functionsPanel.Location = new System.Drawing.Point(524, 25);
            this.functionsPanel.Name = "functionsPanel";
            this.functionsPanel.Size = new System.Drawing.Size(90, 547);
            this.functionsPanel.TabIndex = 29;
            // 
            // playTimeLabel
            // 
            this.playTimeLabel.AutoSize = true;
            this.playTimeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.playTimeLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playTimeLabel.ForeColor = System.Drawing.Color.White;
            this.playTimeLabel.Location = new System.Drawing.Point(3, 351);
            this.playTimeLabel.Name = "playTimeLabel";
            this.playTimeLabel.Size = new System.Drawing.Size(51, 26);
            this.playTimeLabel.TabIndex = 38;
            this.playTimeLabel.Text = "00:00,00\r\n00:00,00";
            // 
            // freamIndexLabel
            // 
            this.freamIndexLabel.AutoSize = true;
            this.freamIndexLabel.Location = new System.Drawing.Point(3, 336);
            this.freamIndexLabel.Name = "freamIndexLabel";
            this.freamIndexLabel.Size = new System.Drawing.Size(23, 13);
            this.freamIndexLabel.TabIndex = 37;
            this.freamIndexLabel.Text = "0/0";
            // 
            // prevFreamButton
            // 
            this.prevFreamButton.ForeColor = System.Drawing.Color.Black;
            this.prevFreamButton.Location = new System.Drawing.Point(4, 312);
            this.prevFreamButton.Name = "prevFreamButton";
            this.prevFreamButton.Size = new System.Drawing.Size(36, 23);
            this.prevFreamButton.TabIndex = 36;
            this.prevFreamButton.Text = "<";
            this.prevFreamButton.UseVisualStyleBackColor = true;
            this.prevFreamButton.Click += new System.EventHandler(this.prevFreamButton_Click);
            // 
            // nextFreamButton
            // 
            this.nextFreamButton.ForeColor = System.Drawing.Color.Black;
            this.nextFreamButton.Location = new System.Drawing.Point(49, 312);
            this.nextFreamButton.Name = "nextFreamButton";
            this.nextFreamButton.Size = new System.Drawing.Size(36, 23);
            this.nextFreamButton.TabIndex = 35;
            this.nextFreamButton.Text = ">";
            this.nextFreamButton.UseVisualStyleBackColor = true;
            this.nextFreamButton.Click += new System.EventHandler(this.nextFreamButton_Click);
            // 
            // freamsCheckBox
            // 
            this.freamsCheckBox.AutoSize = true;
            this.freamsCheckBox.Location = new System.Drawing.Point(6, 449);
            this.freamsCheckBox.Name = "freamsCheckBox";
            this.freamsCheckBox.Size = new System.Drawing.Size(61, 17);
            this.freamsCheckBox.TabIndex = 34;
            this.freamsCheckBox.Text = "Freams";
            this.freamsCheckBox.UseVisualStyleBackColor = true;
            this.freamsCheckBox.CheckedChanged += new System.EventHandler(this.freamsCheckBox_CheckedChanged);
            // 
            // viewFreamsButton
            // 
            this.viewFreamsButton.ForeColor = System.Drawing.Color.Black;
            this.viewFreamsButton.Location = new System.Drawing.Point(3, 283);
            this.viewFreamsButton.Name = "viewFreamsButton";
            this.viewFreamsButton.Size = new System.Drawing.Size(82, 23);
            this.viewFreamsButton.TabIndex = 33;
            this.viewFreamsButton.Text = "Edit Freams";
            this.viewFreamsButton.UseVisualStyleBackColor = true;
            this.viewFreamsButton.Click += new System.EventHandler(this.viewFreamsButton_Click);
            // 
            // playFreamsButton
            // 
            this.playFreamsButton.ForeColor = System.Drawing.Color.Black;
            this.playFreamsButton.Location = new System.Drawing.Point(4, 254);
            this.playFreamsButton.Name = "playFreamsButton";
            this.playFreamsButton.Size = new System.Drawing.Size(82, 23);
            this.playFreamsButton.TabIndex = 32;
            this.playFreamsButton.Text = "Play Freams";
            this.playFreamsButton.UseVisualStyleBackColor = true;
            this.playFreamsButton.Click += new System.EventHandler(this.playFreamsButton_Click);
            // 
            // saveFreamButton
            // 
            this.saveFreamButton.ForeColor = System.Drawing.Color.Black;
            this.saveFreamButton.Location = new System.Drawing.Point(4, 225);
            this.saveFreamButton.Name = "saveFreamButton";
            this.saveFreamButton.Size = new System.Drawing.Size(82, 23);
            this.saveFreamButton.TabIndex = 31;
            this.saveFreamButton.Text = "Save Fream";
            this.saveFreamButton.UseVisualStyleBackColor = true;
            this.saveFreamButton.Click += new System.EventHandler(this.saveFreamButton_Click);
            // 
            // resizeRegionButton
            // 
            this.resizeRegionButton.ForeColor = System.Drawing.Color.Black;
            this.resizeRegionButton.Location = new System.Drawing.Point(3, 100);
            this.resizeRegionButton.Name = "resizeRegionButton";
            this.resizeRegionButton.Size = new System.Drawing.Size(82, 23);
            this.resizeRegionButton.TabIndex = 30;
            this.resizeRegionButton.Text = "Resize Region";
            this.resizeRegionButton.UseVisualStyleBackColor = true;
            this.resizeRegionButton.Click += new System.EventHandler(this.resizeRegionButton_Click);
            // 
            // fixingButton
            // 
            this.fixingButton.ForeColor = System.Drawing.Color.Black;
            this.fixingButton.Location = new System.Drawing.Point(4, 196);
            this.fixingButton.Name = "fixingButton";
            this.fixingButton.Size = new System.Drawing.Size(82, 23);
            this.fixingButton.TabIndex = 28;
            this.fixingButton.Text = "Fixing";
            this.fixingButton.UseVisualStyleBackColor = true;
            this.fixingButton.Click += new System.EventHandler(this.fixingButton_Click);
            // 
            // moveCheckBox
            // 
            this.moveCheckBox.AutoSize = true;
            this.moveCheckBox.Location = new System.Drawing.Point(6, 426);
            this.moveCheckBox.Name = "moveCheckBox";
            this.moveCheckBox.Size = new System.Drawing.Size(55, 17);
            this.moveCheckBox.TabIndex = 27;
            this.moveCheckBox.Text = "Move ";
            this.moveCheckBox.UseVisualStyleBackColor = true;
            // 
            // bitmapButton
            // 
            this.bitmapButton.Location = new System.Drawing.Point(-31, 474);
            this.bitmapButton.Name = "bitmapButton";
            this.bitmapButton.Size = new System.Drawing.Size(82, 23);
            this.bitmapButton.TabIndex = 29;
            this.bitmapButton.Text = "Sketch";
            this.bitmapButton.UseVisualStyleBackColor = true;
            this.bitmapButton.Visible = false;
            this.bitmapButton.Click += new System.EventHandler(this.bitmapButton_Click);
            // 
            // selectorContextMenuStrip
            // 
            this.selectorContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cloneToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.selectorContextMenuStrip.Name = "selectorContextMenuStrip";
            this.selectorContextMenuStrip.Size = new System.Drawing.Size(108, 48);
            // 
            // cloneToolStripMenuItem
            // 
            this.cloneToolStripMenuItem.Name = "cloneToolStripMenuItem";
            this.cloneToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.cloneToolStripMenuItem.Text = "Clone";
            this.cloneToolStripMenuItem.Click += new System.EventHandler(this.SelectorMenuItemClicked);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.SelectorMenuItemClicked);
            // 
            // openImageDialog
            // 
            this.openImageDialog.FileName = "openImageDialog";
            // 
            // MainInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(614, 574);
            this.Controls.Add(this.functionsPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bitmapButton);
            this.Controls.Add(this.sketchPanel);
            this.Controls.Add(this.loactionLabel);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainInterface";
            this.Text = "Smart Regions Sketcher";
            this.Load += new System.EventHandler(this.MainInterface_Load);
            this.sketchPanel.ResumeLayout(false);
            this.methodGroupBox.ResumeLayout(false);
            this.methodGroupBox.PerformLayout();
            this.functionsPanel.ResumeLayout(false);
            this.functionsPanel.PerformLayout();
            this.selectorContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel sketchPanel;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button editPointsButton;
        private System.Windows.Forms.CheckBox selectorsCheckBox;
        private System.Windows.Forms.Button moveButton;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Label loactionLabel;
        private System.Windows.Forms.GroupBox methodGroupBox;
        private System.Windows.Forms.RadioButton polygonsRadioButton;
        private System.Windows.Forms.RadioButton linesRadioButton;
        private System.Windows.Forms.CheckBox lockCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel functionsPanel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Panel selectionPanel;
        private System.Windows.Forms.CheckBox moveCheckBox;
        private System.Windows.Forms.ContextMenuStrip selectorContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem cloneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Button fixingButton;
        private System.Windows.Forms.Button bitmapButton;
        private System.Windows.Forms.OpenFileDialog openImageDialog;
        private System.Windows.Forms.Button resizeRegionButton;
        private System.Windows.Forms.Button saveFreamButton;
        private System.Windows.Forms.Button playFreamsButton;
        private System.Windows.Forms.Button viewFreamsButton;
        private System.Windows.Forms.CheckBox freamsCheckBox;
        private System.Windows.Forms.Button prevFreamButton;
        private System.Windows.Forms.Button nextFreamButton;
        private System.Windows.Forms.Label freamIndexLabel;
        private System.Windows.Forms.Label playTimeLabel;
    }
}

