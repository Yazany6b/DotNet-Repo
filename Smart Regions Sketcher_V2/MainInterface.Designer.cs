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
            this.deleteButton = new System.Windows.Forms.Button();
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.smoothButton = new System.Windows.Forms.Button();
            this.matchFormsButton = new System.Windows.Forms.Button();
            this.fixingButton = new System.Windows.Forms.Button();
            this.resizeRegionButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.clearAllButton = new System.Windows.Forms.Button();
            this.saveAsButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.curReglabel = new System.Windows.Forms.Label();
            this.nextRegButton = new System.Windows.Forms.Button();
            this.prevRegButton = new System.Windows.Forms.Button();
            this.newRegionButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.saveFreamButton = new System.Windows.Forms.Button();
            this.playFreamsButton = new System.Windows.Forms.Button();
            this.viewFreamsButton = new System.Windows.Forms.Button();
            this.playTimeLabel = new System.Windows.Forms.Label();
            this.nextFreamButton = new System.Windows.Forms.Button();
            this.freamIndexLabel = new System.Windows.Forms.Label();
            this.prevFreamButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.moveCheckBox = new System.Windows.Forms.CheckBox();
            this.freamsCheckBox = new System.Windows.Forms.CheckBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.selectorContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cloneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.sketchPanel.SuspendLayout();
            this.methodGroupBox.SuspendLayout();
            this.functionsPanel.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.selectorContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // sketchPanel
            // 
            this.sketchPanel.BackColor = System.Drawing.SystemColors.Control;
            this.sketchPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.sketchPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sketchPanel.Controls.Add(this.selectionPanel);
            this.sketchPanel.ForeColor = System.Drawing.Color.Red;
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
            // deleteButton
            // 
            this.deleteButton.ForeColor = System.Drawing.Color.Black;
            this.deleteButton.Location = new System.Drawing.Point(88, 45);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(82, 23);
            this.deleteButton.TabIndex = 1;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // editPointsButton
            // 
            this.editPointsButton.ForeColor = System.Drawing.Color.Black;
            this.editPointsButton.Location = new System.Drawing.Point(0, 19);
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
            this.selectorsCheckBox.Location = new System.Drawing.Point(6, 19);
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
            this.moveButton.Location = new System.Drawing.Point(0, 48);
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
            this.importButton.Location = new System.Drawing.Point(88, 104);
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
            this.exportButton.Location = new System.Drawing.Point(0, 103);
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
            this.loactionLabel.Size = new System.Drawing.Size(48, 13);
            this.loactionLabel.TabIndex = 24;
            this.loactionLabel.Text = "X=0;Y=0";
            // 
            // methodGroupBox
            // 
            this.methodGroupBox.Controls.Add(this.polygonsRadioButton);
            this.methodGroupBox.Controls.Add(this.linesRadioButton);
            this.methodGroupBox.Location = new System.Drawing.Point(3, 488);
            this.methodGroupBox.Name = "methodGroupBox";
            this.methodGroupBox.Size = new System.Drawing.Size(170, 89);
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
            this.linesRadioButton.Size = new System.Drawing.Size(50, 17);
            this.linesRadioButton.TabIndex = 0;
            this.linesRadioButton.TabStop = true;
            this.linesRadioButton.Text = "Lines";
            this.linesRadioButton.UseVisualStyleBackColor = true;
            this.linesRadioButton.CheckedChanged += new System.EventHandler(this.SketchMethodChanged);
            // 
            // lockCheckBox
            // 
            this.lockCheckBox.AutoSize = true;
            this.lockCheckBox.Location = new System.Drawing.Point(98, 19);
            this.lockCheckBox.Name = "lockCheckBox";
            this.lockCheckBox.Size = new System.Drawing.Size(50, 17);
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
            this.label2.Size = new System.Drawing.Size(9, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "|";
            // 
            // functionsPanel
            // 
            this.functionsPanel.AutoScroll = true;
            this.functionsPanel.Controls.Add(this.groupBox4);
            this.functionsPanel.Controls.Add(this.groupBox3);
            this.functionsPanel.Controls.Add(this.groupBox2);
            this.functionsPanel.Controls.Add(this.groupBox1);
            this.functionsPanel.Controls.Add(this.methodGroupBox);
            this.functionsPanel.Location = new System.Drawing.Point(524, 25);
            this.functionsPanel.Name = "functionsPanel";
            this.functionsPanel.Size = new System.Drawing.Size(176, 577);
            this.functionsPanel.TabIndex = 29;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.smoothButton);
            this.groupBox4.Controls.Add(this.matchFormsButton);
            this.groupBox4.Controls.Add(this.editPointsButton);
            this.groupBox4.Controls.Add(this.fixingButton);
            this.groupBox4.Controls.Add(this.resizeRegionButton);
            this.groupBox4.Controls.Add(this.moveButton);
            this.groupBox4.Location = new System.Drawing.Point(3, 175);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(170, 119);
            this.groupBox4.TabIndex = 43;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tools";
            // 
            // smoothButton
            // 
            this.smoothButton.Enabled = false;
            this.smoothButton.ForeColor = System.Drawing.Color.Black;
            this.smoothButton.Location = new System.Drawing.Point(88, 77);
            this.smoothButton.Name = "smoothButton";
            this.smoothButton.Size = new System.Drawing.Size(82, 23);
            this.smoothButton.TabIndex = 32;
            this.smoothButton.Text = "Smooth";
            this.smoothButton.UseVisualStyleBackColor = true;
            // 
            // matchFormsButton
            // 
            this.matchFormsButton.ForeColor = System.Drawing.Color.Black;
            this.matchFormsButton.Location = new System.Drawing.Point(0, 77);
            this.matchFormsButton.Name = "matchFormsButton";
            this.matchFormsButton.Size = new System.Drawing.Size(82, 23);
            this.matchFormsButton.TabIndex = 31;
            this.matchFormsButton.Text = "Match Forms";
            this.matchFormsButton.UseVisualStyleBackColor = true;
            this.matchFormsButton.Click += new System.EventHandler(this.matchFormsButton_Click);
            // 
            // fixingButton
            // 
            this.fixingButton.ForeColor = System.Drawing.Color.Black;
            this.fixingButton.Location = new System.Drawing.Point(88, 48);
            this.fixingButton.Name = "fixingButton";
            this.fixingButton.Size = new System.Drawing.Size(82, 23);
            this.fixingButton.TabIndex = 28;
            this.fixingButton.Text = "Refine";
            this.fixingButton.UseVisualStyleBackColor = true;
            this.fixingButton.Click += new System.EventHandler(this.fixingButton_Click);
            // 
            // resizeRegionButton
            // 
            this.resizeRegionButton.ForeColor = System.Drawing.Color.Black;
            this.resizeRegionButton.Location = new System.Drawing.Point(88, 19);
            this.resizeRegionButton.Name = "resizeRegionButton";
            this.resizeRegionButton.Size = new System.Drawing.Size(82, 23);
            this.resizeRegionButton.TabIndex = 30;
            this.resizeRegionButton.Text = "Resize Region";
            this.resizeRegionButton.UseVisualStyleBackColor = true;
            this.resizeRegionButton.Click += new System.EventHandler(this.resizeRegionButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.clearAllButton);
            this.groupBox3.Controls.Add(this.saveAsButton);
            this.groupBox3.Controls.Add(this.saveButton);
            this.groupBox3.Controls.Add(this.curReglabel);
            this.groupBox3.Controls.Add(this.nextRegButton);
            this.groupBox3.Controls.Add(this.prevRegButton);
            this.groupBox3.Controls.Add(this.newRegionButton);
            this.groupBox3.Controls.Add(this.exportButton);
            this.groupBox3.Controls.Add(this.importButton);
            this.groupBox3.Controls.Add(this.deleteButton);
            this.groupBox3.Location = new System.Drawing.Point(3, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(170, 173);
            this.groupBox3.TabIndex = 42;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Region";
            // 
            // clearAllButton
            // 
            this.clearAllButton.ForeColor = System.Drawing.Color.Black;
            this.clearAllButton.Location = new System.Drawing.Point(46, 16);
            this.clearAllButton.Name = "clearAllButton";
            this.clearAllButton.Size = new System.Drawing.Size(82, 23);
            this.clearAllButton.TabIndex = 45;
            this.clearAllButton.Text = "Clear All";
            this.clearAllButton.UseVisualStyleBackColor = true;
            this.clearAllButton.Click += new System.EventHandler(this.clearAllButton_Click);
            // 
            // saveAsButton
            // 
            this.saveAsButton.ForeColor = System.Drawing.Color.Black;
            this.saveAsButton.Location = new System.Drawing.Point(88, 75);
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.Size = new System.Drawing.Size(82, 23);
            this.saveAsButton.TabIndex = 44;
            this.saveAsButton.Text = "Save As";
            this.saveAsButton.UseVisualStyleBackColor = true;
            this.saveAsButton.Click += new System.EventHandler(this.saveAsButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.ForeColor = System.Drawing.Color.Black;
            this.saveButton.Location = new System.Drawing.Point(0, 75);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(82, 23);
            this.saveButton.TabIndex = 43;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // curReglabel
            // 
            this.curReglabel.AutoSize = true;
            this.curReglabel.Location = new System.Drawing.Point(74, 159);
            this.curReglabel.Name = "curReglabel";
            this.curReglabel.Size = new System.Drawing.Size(24, 13);
            this.curReglabel.TabIndex = 42;
            this.curReglabel.Text = "1/1";
            // 
            // nextRegButton
            // 
            this.nextRegButton.Enabled = false;
            this.nextRegButton.ForeColor = System.Drawing.Color.Black;
            this.nextRegButton.Location = new System.Drawing.Point(88, 133);
            this.nextRegButton.Name = "nextRegButton";
            this.nextRegButton.Size = new System.Drawing.Size(82, 23);
            this.nextRegButton.TabIndex = 41;
            this.nextRegButton.Text = ">";
            this.nextRegButton.UseVisualStyleBackColor = true;
            this.nextRegButton.Click += new System.EventHandler(this.nextRegButton_Click);
            // 
            // prevRegButton
            // 
            this.prevRegButton.Enabled = false;
            this.prevRegButton.ForeColor = System.Drawing.Color.Black;
            this.prevRegButton.Location = new System.Drawing.Point(0, 133);
            this.prevRegButton.Name = "prevRegButton";
            this.prevRegButton.Size = new System.Drawing.Size(82, 23);
            this.prevRegButton.TabIndex = 40;
            this.prevRegButton.Text = "<";
            this.prevRegButton.UseVisualStyleBackColor = true;
            this.prevRegButton.Click += new System.EventHandler(this.prevRegButton_Click);
            // 
            // newRegionButton
            // 
            this.newRegionButton.ForeColor = System.Drawing.Color.Black;
            this.newRegionButton.Location = new System.Drawing.Point(0, 45);
            this.newRegionButton.Name = "newRegionButton";
            this.newRegionButton.Size = new System.Drawing.Size(82, 23);
            this.newRegionButton.TabIndex = 39;
            this.newRegionButton.Text = "New Region";
            this.newRegionButton.UseVisualStyleBackColor = true;
            this.newRegionButton.Click += new System.EventHandler(this.newRegionButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.saveFreamButton);
            this.groupBox2.Controls.Add(this.playFreamsButton);
            this.groupBox2.Controls.Add(this.viewFreamsButton);
            this.groupBox2.Controls.Add(this.playTimeLabel);
            this.groupBox2.Controls.Add(this.nextFreamButton);
            this.groupBox2.Controls.Add(this.freamIndexLabel);
            this.groupBox2.Controls.Add(this.prevFreamButton);
            this.groupBox2.Location = new System.Drawing.Point(3, 300);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(170, 106);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Freams";
            // 
            // saveFreamButton
            // 
            this.saveFreamButton.ForeColor = System.Drawing.Color.Black;
            this.saveFreamButton.Location = new System.Drawing.Point(0, 19);
            this.saveFreamButton.Name = "saveFreamButton";
            this.saveFreamButton.Size = new System.Drawing.Size(82, 23);
            this.saveFreamButton.TabIndex = 31;
            this.saveFreamButton.Text = "Save Fream";
            this.saveFreamButton.UseVisualStyleBackColor = true;
            this.saveFreamButton.Click += new System.EventHandler(this.saveFreamButton_Click);
            // 
            // playFreamsButton
            // 
            this.playFreamsButton.ForeColor = System.Drawing.Color.Black;
            this.playFreamsButton.Location = new System.Drawing.Point(88, 19);
            this.playFreamsButton.Name = "playFreamsButton";
            this.playFreamsButton.Size = new System.Drawing.Size(82, 23);
            this.playFreamsButton.TabIndex = 32;
            this.playFreamsButton.Text = "Play Freams";
            this.playFreamsButton.UseVisualStyleBackColor = true;
            this.playFreamsButton.Click += new System.EventHandler(this.playFreamsButton_Click);
            // 
            // viewFreamsButton
            // 
            this.viewFreamsButton.ForeColor = System.Drawing.Color.Black;
            this.viewFreamsButton.Location = new System.Drawing.Point(0, 48);
            this.viewFreamsButton.Name = "viewFreamsButton";
            this.viewFreamsButton.Size = new System.Drawing.Size(82, 23);
            this.viewFreamsButton.TabIndex = 33;
            this.viewFreamsButton.Text = "Edit Freams";
            this.viewFreamsButton.UseVisualStyleBackColor = true;
            this.viewFreamsButton.Click += new System.EventHandler(this.viewFreamsButton_Click);
            // 
            // playTimeLabel
            // 
            this.playTimeLabel.AutoSize = true;
            this.playTimeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.playTimeLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playTimeLabel.ForeColor = System.Drawing.Color.White;
            this.playTimeLabel.Location = new System.Drawing.Point(99, 45);
            this.playTimeLabel.Name = "playTimeLabel";
            this.playTimeLabel.Size = new System.Drawing.Size(49, 26);
            this.playTimeLabel.TabIndex = 38;
            this.playTimeLabel.Text = "00:00,00\r\n00:00,00";
            // 
            // nextFreamButton
            // 
            this.nextFreamButton.Enabled = false;
            this.nextFreamButton.ForeColor = System.Drawing.Color.Black;
            this.nextFreamButton.Location = new System.Drawing.Point(46, 77);
            this.nextFreamButton.Name = "nextFreamButton";
            this.nextFreamButton.Size = new System.Drawing.Size(36, 23);
            this.nextFreamButton.TabIndex = 35;
            this.nextFreamButton.Text = ">";
            this.nextFreamButton.UseVisualStyleBackColor = true;
            this.nextFreamButton.Click += new System.EventHandler(this.nextFreamButton_Click);
            // 
            // freamIndexLabel
            // 
            this.freamIndexLabel.AutoSize = true;
            this.freamIndexLabel.Location = new System.Drawing.Point(112, 82);
            this.freamIndexLabel.Name = "freamIndexLabel";
            this.freamIndexLabel.Size = new System.Drawing.Size(24, 13);
            this.freamIndexLabel.TabIndex = 37;
            this.freamIndexLabel.Text = "0/0";
            // 
            // prevFreamButton
            // 
            this.prevFreamButton.Enabled = false;
            this.prevFreamButton.ForeColor = System.Drawing.Color.Black;
            this.prevFreamButton.Location = new System.Drawing.Point(0, 77);
            this.prevFreamButton.Name = "prevFreamButton";
            this.prevFreamButton.Size = new System.Drawing.Size(36, 23);
            this.prevFreamButton.TabIndex = 36;
            this.prevFreamButton.Text = "<";
            this.prevFreamButton.UseVisualStyleBackColor = true;
            this.prevFreamButton.Click += new System.EventHandler(this.prevFreamButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lockCheckBox);
            this.groupBox1.Controls.Add(this.selectorsCheckBox);
            this.groupBox1.Controls.Add(this.moveCheckBox);
            this.groupBox1.Controls.Add(this.freamsCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(1, 412);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(170, 70);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mods";
            // 
            // moveCheckBox
            // 
            this.moveCheckBox.AutoSize = true;
            this.moveCheckBox.Location = new System.Drawing.Point(6, 42);
            this.moveCheckBox.Name = "moveCheckBox";
            this.moveCheckBox.Size = new System.Drawing.Size(56, 17);
            this.moveCheckBox.TabIndex = 27;
            this.moveCheckBox.Text = "Move ";
            this.moveCheckBox.UseVisualStyleBackColor = true;
            // 
            // freamsCheckBox
            // 
            this.freamsCheckBox.AutoSize = true;
            this.freamsCheckBox.Location = new System.Drawing.Point(98, 42);
            this.freamsCheckBox.Name = "freamsCheckBox";
            this.freamsCheckBox.Size = new System.Drawing.Size(60, 17);
            this.freamsCheckBox.TabIndex = 34;
            this.freamsCheckBox.Text = "Freams";
            this.freamsCheckBox.UseVisualStyleBackColor = true;
            this.freamsCheckBox.CheckedChanged += new System.EventHandler(this.freamsCheckBox_CheckedChanged);
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
            this.ClientSize = new System.Drawing.Size(719, 605);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.functionsPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sketchPanel);
            this.Controls.Add(this.loactionLabel);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainInterface";
            this.Text = "Smart Regions Sketcher : Untitled";
            this.Load += new System.EventHandler(this.MainInterface_Load);
            this.sketchPanel.ResumeLayout(false);
            this.methodGroupBox.ResumeLayout(false);
            this.methodGroupBox.PerformLayout();
            this.functionsPanel.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.selectorContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel sketchPanel;
        private System.Windows.Forms.Button deleteButton;
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
        private System.Windows.Forms.Button newRegionButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button nextRegButton;
        private System.Windows.Forms.Button prevRegButton;
        private System.Windows.Forms.Label curReglabel;
        private System.Windows.Forms.Button saveAsButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button clearAllButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button smoothButton;
        private System.Windows.Forms.Button matchFormsButton;
    }
}

