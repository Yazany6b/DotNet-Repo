using Smart_Regions_Sketcher.Dialogs;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using YazanLib.Media;
using System.IO;
namespace Smart_Regions_Sketcher
{
    public partial class MainInterface : System.Windows.Forms.Form
    {
        private ISketcher sketcher;

        private SelectorSketcher selector = new SelectorSketcher();

        private EditForm eform;

        private TestRegionForm tform = new TestRegionForm();

        private System.Collections.Generic.List<System.Windows.Forms.Panel> selectors = new System.Collections.Generic.List<System.Windows.Forms.Panel>();

        private System.Windows.Forms.Panel currentSelector = null;

        public System.Collections.Generic.List<AnimationFream> animation = new System.Collections.Generic.List<AnimationFream>();

        private int currentFream = 0;

        private Task playingTask;

        private bool playingAnimation = false;

        private EditFreamsFrom freamsForm;

        public MainInterface()
        {
            InitializeComponent();

            sketcher = SketchersFactory.CreateSketcher("Lines", sketchPanel.CreateGraphics());
            sketcher.SketchColor = sketchPanel.ForeColor;
            sketcher.UnSketchColor = sketchPanel.BackColor;

            freamsForm = new EditFreamsFrom(animation, sketchPanel.Size);
        } 

        protected override void OnSizeChanged(System.EventArgs e)
        {
            lockCheckBox.Checked = true;

            sketchPanel.Size = new System.Drawing.Size(this.Width - 193, this.Height - 25);

            functionsPanel.Location = new System.Drawing.Point(this.Width - 110, functionsPanel.Location.Y);

            if (sketcher != null)
            {
                sketcher.Graphics.Clear(sketcher.UnSketchColor);
                sketcher.Graphics = sketchPanel.CreateGraphics();
                sketcher.Sketch();
            }

            base.OnSizeChanged(e);

            tform.Size = sketchPanel.Size;

            lockCheckBox.Checked = false;
        }

        private System.Drawing.Point firstPoint = System.Drawing.Point.Empty;

        private System.Drawing.Color Negative(System.Drawing.Color c)
        {
            return System.Drawing.Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B);
        }

        private void SketchMouseMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (moveCheckBox.Checked)
                return;

            if ((e.X < sketchPanel.Width && e.X >= 0) && (e.Y < sketchPanel.Height && e.Y >= 0))
            {
                loactionLabel.Text = e.Location.ToString();

                label1.Location = new System.Drawing.Point(label1.Location.X, e.Y + sketchPanel.Location.Y);
                label2.Location = new System.Drawing.Point(e.X + sketchPanel.Location.X, label2.Location.Y);
            }


            if (lockCheckBox.Checked || selectorsCheckBox.Checked)
            {
                return;
            }

            sketcher.SketchMouseMoved(sender, e);
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                tform.SetRegion(sketcher);
        }

        private void SketchMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (moveCheckBox.Checked)
            {
                if (sketcher.SketchPoints.Count <= 0)
                    return;
                int minX = sketcher.SketchPoints[0].X;
                int minY = sketcher.SketchPoints[0].Y;

                for (int i = 1; i < sketcher.SketchPoints.Count; i++)
                {
                    if (minX > sketcher.SketchPoints[i].X)
                        minX = sketcher.SketchPoints[i].X;

                }

                for (int i = 1; i < sketcher.SketchPoints.Count; i++)
                {
                    if (minY > sketcher.SketchPoints[i].Y)
                        minY = sketcher.SketchPoints[i].Y;
                }


                int xratio = minX - e.X;
                int yratio = minY - e.Y;

                sketcher.UnSketch();

                if (selectorsCheckBox.Checked)
                {
                    HideSelectPanels();
                }

                if (eform != null)
                    eform.Close();

                for (int i = 0; i < sketcher.SketchPoints.Count; i++)
                {
                    sketcher.SketchPoints[i] = new System.Drawing.Point(sketcher.SketchPoints[i].X - xratio, sketcher.SketchPoints[i].Y - yratio);
                }

                sketcher.Sketch();

                if (selectorsCheckBox.Checked)
                    ShowSelectPanels();

                tform.SetRegion(sketcher);

                return;
            }

            if (lockCheckBox.Checked || selectorsCheckBox.Checked)
            {
                selectionPanel.Visible = false;
                firstPoint = System.Drawing.Point.Empty;
                return;
            }

            sketcher.SketchMouseUp(sender, e);
            tform.SetRegion(sketcher);
        }

        private void SketchPanelPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            sketcher.Sketch();
        }

        private void SketchMethodChanged(object sender, System.EventArgs e)
        {
            if (!((System.Windows.Forms.RadioButton)sender).Checked)
                return;

            if (sketcher.SketchPoints.Count != 0 && System.Windows.Forms.MessageBox.Show("Do you want to convert the old points to the new methode?", "Convert", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                sketcher.UnSketch();
                {
                    if (selectorsCheckBox.Checked)
                        HideSelectPanels();
                    sketcher = SketchersConverter.ConvertFrom(sketcher);
                    if (selectorsCheckBox.Checked)
                        ShowSelectPanels();
                } sketcher.Sketch();
                tform.SetRegion(sketcher);
            }
            else
            {

                sketcher.Clear();

                sketcher = SketchersFactory.CreateSketcher(((System.Windows.Forms.RadioButton)sender).Text, sketchPanel.CreateGraphics());
                sketcher.SketchColor = sketchPanel.ForeColor;
                sketcher.UnSketchColor = sketchPanel.BackColor;
            }
        }

        private void clearButton_Click(object sender, System.EventArgs e)
        {
            sketcher.Clear();
            tform.ResetRegion();
            tform.ResetGraphics();
            if (selectorsCheckBox.Checked)
            {
                selectorsCheckBox.Checked = false;
            }

            sketchPanel.CreateGraphics().Clear(sketchPanel.BackColor);
        }

        private void editPointsButton_Click(object sender, System.EventArgs e)
        {
            editPointsButton.Enabled = false;
            eform = new EditForm(sketcher.SketchPoints, sketchPanel.ClientSize);

            eform.FormClosed += new System.Windows.Forms.FormClosedEventHandler(OnEditFormClose);
            eform.ChangeHappend += new System.EventHandler(OnEditFormChanges);
            eform.SelectClicked += new System.EventHandler(OnEditFormSelect);

            eform.Show();
        }

        private void OnEditFormClose(object c, System.EventArgs e)
        {
            eform = null;

            editPointsButton.Enabled = true;
        }

        private void OnEditFormChanges(object c, System.EventArgs e)
        {
            sketcher.UnSketch();

            sketcher.SketchPoints = Statics.ClonePointsList(eform.Points);

            sketcher.Sketch();
            tform.SetRegion(sketcher);
        }

        private void OnEditFormSelect(object c, System.EventArgs e)
        {
            sketcher.UnSketch();
            System.Drawing.Point sel = (System.Drawing.Point)c;
            sketcher.Graphics.Clear(sketcher.UnSketchColor);
            sketcher.Sketch();

            sketcher.Graphics.DrawEllipse(new System.Drawing.Pen((sketcher.SketchColor != System.Drawing.Color.Black ? System.Drawing.Color.Black : System.Drawing.Color.Red)), new System.Drawing.Rectangle(sel, new System.Drawing.Size(10, 10)));
        }

        #region Selectors Implemention

        private void ShowSelectPanels()
        {
            
            for (int i = 0; i < sketcher.SketchPoints.Count; i++)
            {
                if (i > 0)
                    if (sketcher.SketchPoints[i - 1].X == sketcher.SketchPoints[i].X && sketcher.SketchPoints[i - 1].Y == sketcher.SketchPoints[i].Y)
                        continue;

                System.Windows.Forms.Panel x = new System.Windows.Forms.Panel();
                x.TabIndex = i;
                x.Size = new System.Drawing.Size(8, 8);
                x.Location = sketcher.SketchPoints[i];
                x.BackColor = System.Drawing.Color.Blue;
                x.MouseMove += new System.Windows.Forms.MouseEventHandler(SelectorPanelMouseMove);
                x.MouseUp += new System.Windows.Forms.MouseEventHandler(SelectorPanelMouseUp);
                x.MouseClick += new System.Windows.Forms.MouseEventHandler(SelectorPanelMouseClick);

                selectors.Add(x);
                sketchPanel.Controls.Add(x);

                
            }
        }

        private void HideSelectPanels()
        {
            foreach (System.Windows.Forms.Panel x in selectors)
                sketchPanel.Controls.Remove(x);
            selectors.Clear();
        }

        void SelectorPanelMouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                currentSelector = ((System.Windows.Forms.Panel)sender);

                System.Drawing.Point p = new System.Drawing.Point(this.Location.X + sketchPanel.Location.X + ((System.Windows.Forms.Panel)sender).Location.X,
                    this.Location.Y + sketchPanel.Location.Y + currentSelector.Location.Y);

                selectorContextMenuStrip.Show(p);
            }
        }

        private void SelectorPanelMouseMove(object c, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                System.Windows.Forms.Panel selector = ((System.Windows.Forms.Panel)c);
                selector.BackColor = System.Drawing.Color.Red;
                sketcher.UnSketch();

                selector.Location = new System.Drawing.Point(selector.Location.X + e.X, selector.Location.Y + e.Y);

                sketcher.SketchPoints[selector.TabIndex] = selector.Location;

                if (eform != null)
                    eform.Points[selector.TabIndex] = selector.Location;

                if (selector.TabIndex + 1 < sketcher.SketchPoints.Count)
                {
                    sketcher.SketchPoints[selector.TabIndex + 1] = selector.Location;

                    if (eform != null)
                        eform.Points[selector.TabIndex + 1] = selector.Location;
                }

                sketcher.Sketch();

                tform.SetRegion(sketcher);

                Update();
            }
        }

        private void SelectorPanelMouseUp(object c, System.Windows.Forms.MouseEventArgs e)
        {
            ((System.Windows.Forms.Panel)c).BackColor = System.Drawing.Color.Blue;
        }

        private void selectorsCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            lockCheckBox.Checked = selectorsCheckBox.Checked;
            lockCheckBox.Enabled = !selectorsCheckBox.Checked;

            if (selectorsCheckBox.Checked)
                ShowSelectPanels();
            else
                HideSelectPanels();
        }

        private void SelectorMenuItemClicked(object sender, System.EventArgs e)
        {
            if (sender == cloneToolStripMenuItem)
            {
                int index = currentSelector.TabIndex;
                System.Drawing.Point point = sketcher.SketchPoints[index];

                if (index > 0 && index + 2 < sketcher.SketchPoints.Count)
                {
                    sketcher.UnSketch();
                    {
                        int next_index = index - 1;
                        System.Drawing.Point next = sketcher.SketchPoints[index + 1];
                        System.Drawing.Point new_point = new System.Drawing.Point(next.X + 5, next.Y + 5);
                        sketcher.SketchPoints[next_index + 1] = new_point;

                        sketcher.SketchPoints.Insert(next_index + 1, new_point);

                    } sketcher.Sketch();
                    tform.SetRegion(sketcher);

                }
                else
                {
                    return;
                }


                HideSelectPanels();
                ShowSelectPanels();

            }
            else
                if (sender == deleteToolStripMenuItem)
                {
                    int index = currentSelector.TabIndex;

                    if (index - 1 > 0 && index + 2 < sketcher.SketchPoints.Count)
                    {
                        sketcher.UnSketch();
                        {
                            int prev_index = index - 1;
                            sketcher.SketchPoints[prev_index - 1] = sketcher.SketchPoints[index + 1];

                            sketcher.SketchPoints.RemoveAt(prev_index);
                            sketcher.SketchPoints.RemoveAt(prev_index);

                        } sketcher.Sketch();
                        tform.SetRegion(sketcher);

                    }
                    else
                    {
                        return;
                    }


                    HideSelectPanels();
                    ShowSelectPanels();
                }
        }

        #endregion

        private void moveButton_Click(object sender, System.EventArgs e)
        {

            if (sketcher.SketchPoints.Count <= 0)
                return;
            int minX = sketcher.SketchPoints[0].X;
            int minY = sketcher.SketchPoints[0].Y;

            for (int i = 1; i < sketcher.SketchPoints.Count; i++)
            {
                if (minX > sketcher.SketchPoints[i].X)
                    minX = sketcher.SketchPoints[i].X;

            }

            for (int i = 1; i < sketcher.SketchPoints.Count; i++)
            {
                if (minY > sketcher.SketchPoints[i].Y)
                    minY = sketcher.SketchPoints[i].Y;
            }

            MoveForm mv = new MoveForm(new System.Drawing.Point(this.Width - 1, this.Height - 1));

            if (mv.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int xratio = minX - mv.XValue;
                int yratio = minY - mv.YValue;

                sketcher.UnSketch();

                if (selectorsCheckBox.Checked)
                {
                    HideSelectPanels();
                }

                if (eform != null)
                    eform.Close();

                for (int i = 0; i < sketcher.SketchPoints.Count; i++)
                {
                    sketcher.SketchPoints[i] = new System.Drawing.Point(sketcher.SketchPoints[i].X - xratio, sketcher.SketchPoints[i].Y - yratio);
                }

                sketcher.Sketch();

                if (selectorsCheckBox.Checked)
                    ShowSelectPanels();

                tform.SetRegion(sketcher);

            }

            mv.Dispose();
        }

        private void importButton_Click(object sender, System.EventArgs e)
        {
            openFileDialog.Filter = "Regions And Animation Files (*.ycr;*.yca) | *.ycr;*.yca";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (Path.GetExtension(openFileDialog.FileName).Equals(".yca", System.StringComparison.OrdinalIgnoreCase))
                {
                    System.Collections.Generic.List<RegionData> data = YazanLib.Media.CustomRegions.ImportRegions(openFileDialog.FileName);

                    if (data == null)
                    {
                        MessageBox.Show("Unable to import data unkown format","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }

                    animation.Clear();

                    foreach (var item in data)
                    {

                        ISketcher sk = SketchersFactory.CreateSketcher(item.Type, sketchPanel.CreateGraphics());
                        sk.SketchPoints = item.Points;

                        sk.SketchColor = sketchPanel.ForeColor;
                        sk.UnSketchColor = sketchPanel.BackColor;
                        
                        animation.Add(new AnimationFream(sk, item.WaitMs));
                    }

                    sketcher.UnSketch();

                    if (selectorsCheckBox.Checked)
                        HideSelectPanels();

                    sketcher = animation[animation.Count - 1].Sketcher;

                    sketcher.Graphics = sketchPanel.CreateGraphics();

                    lockCheckBox.Checked = true;

                    foreach (System.Windows.Forms.Control control in methodGroupBox.Controls)
                        if (control.Text == sketcher.Type && control is RadioButton)
                        {
                            ((System.Windows.Forms.RadioButton)control).Checked = true;
                            break;
                        }

                    sketcher.Sketch();

                    tform.SetRegion(sketcher);

                    if (selectorsCheckBox.Checked)
                        ShowSelectPanels();

                    lockCheckBox.Checked = false;
                }
                else
                {
                    YazanLib.Media.RegionData data = YazanLib.Media.CustomRegions.ImportRegion(openFileDialog.FileName);

                    if (data == null)
                    {
                        MessageBox.Show("Unable to import data unkown format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (selectorsCheckBox.Checked)
                       HideSelectPanels();

                    sketcher = SketchersFactory.CreateSketcher(data.Type, sketchPanel.CreateGraphics());
                    sketcher.SketchColor = sketchPanel.ForeColor;
                    sketcher.UnSketchColor = sketchPanel.BackColor;
                    sketcher.SketchPoints = data.Points;

                    foreach (System.Windows.Forms.Control control in methodGroupBox.Controls)
                        if (control.Text == data.Type && control is RadioButton)
                        {
                            ((System.Windows.Forms.RadioButton)control).Checked = true;
                            break;
                        }

                    sketcher.Sketch();
                    tform.SetRegion(sketcher);

                    if (selectorsCheckBox.Checked)
                        ShowSelectPanels();
                }
            }
        }

        private void exportButton_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Do you want to export the animation freams also?", "Export Animation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                System.Collections.Generic.List<RegionData> data = new System.Collections.Generic.List<RegionData>();

                if (animation[animation.Count - 1].Sketcher != sketcher)
                {
                    animation.Add(new AnimationFream(sketcher));
                }

                foreach (var item in animation)
                {
                    RegionData rd = new RegionData(item.Sketcher.Type, item.Sketcher.SketchPoints);
                    rd.WaitMs = item.WaitMs;

                    data.Add(rd);
                }

                saveFileDialog.Filter = "Animation Files (*.yca) | *.yca;";

                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    YazanLib.Media.CustomRegions.ExportRegions(data, saveFileDialog.FileName);
                }
            }
            else
            {
                saveFileDialog.Filter = "Regions Files (*.ycr) | *.ycr;";

                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    YazanLib.Media.CustomRegions.ExportRegion(new YazanLib.Media.RegionData(sketcher.Type, sketcher.SketchPoints), saveFileDialog.FileName);
                }
            }
        }

        private void MainInterface_Load(object sender, System.EventArgs e)
        {
            tform.Show(this);
            tform.Size = sketchPanel.Size;
        }

        public void FixSketch()
        {
            sketcher.UnSketch();
            if (selectorsCheckBox.Checked)
                HideSelectPanels();

            sketcher.Graphics.DrawString("Rebuilding . . . ", new System.Drawing.Font("Consals", 30f), System.Drawing.Brushes.Red,
                10,sketchPanel.Height / 2 - 15);

            for (int i = 0; i < sketcher.SketchPoints.Count; i++)
            {
                if (i == 0)
                {
                    if (i + 1 < sketcher.SketchPoints.Count)
                    {
                        if (sketcher.SketchPoints[i].Equals(sketcher.SketchPoints[i + 1]))
                        {
                            sketcher.SketchPoints.RemoveAt(i + 1);
                            i = -1;
                            continue;
                        }
                    }
                }else
                    if (i + 1 < sketcher.SketchPoints.Count)
                    {
                        if (!sketcher.SketchPoints[i - 1].Equals(sketcher.SketchPoints[i]) && !sketcher.SketchPoints[i + 1].Equals(sketcher.SketchPoints[i]))
                        {
                            sketcher.SketchPoints.Insert(i, sketcher.SketchPoints[i]);
                            i = -1;
                            continue;
                        }
                        else
                            if (sketcher.SketchPoints[i - 1].Equals(sketcher.SketchPoints[i]) && sketcher.SketchPoints[i + 1].Equals(sketcher.SketchPoints[i]))
                            {
                                sketcher.SketchPoints.RemoveAt(i);
                                i = -1;
                                continue;
                            }
                    }
                    else
                    {
                        if (i > 0)
                        {
                            if (sketcher.SketchPoints[i - 1].Equals(sketcher.SketchPoints[i]))
                            {
                                sketcher.SketchPoints.RemoveAt(i);
                                i = -1;
                                continue;
                            }
                        }
                    }
            }

            sketcher.Graphics.Clear(sketcher.UnSketchColor);
            sketcher.Sketch();
            tform.SetRegion(sketcher);
            if (selectorsCheckBox.Checked)
                ShowSelectPanels();
        }

        private void fixingButton_Click(object sender, System.EventArgs e)
        {
            if (sketcher.SketchPoints.Count == 0)
                return;
            FixSketch();
        }

        private unsafe void bitmapButton_Click(object sender, System.EventArgs e)
        {
            System.Drawing.Bitmap map = new System.Drawing.Bitmap(sketchPanel.Width, sketchPanel.Height);

            System.Drawing.Imaging.BitmapData data = map.LockBits(new System.Drawing.Rectangle(0, 0, map.Width, map.Height),
                 System.Drawing.Imaging.ImageLockMode.WriteOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            int pixel_size = 4;

            for (int y = 0; y < map.Height; y++)
            {
                byte* row = (byte*)data.Scan0 + (y * data.Stride);
                for (int x = 0; x < map.Width; x++)
                {
                    row[x * pixel_size + 0] = sketchPanel.BackColor.R;
                    row[x * pixel_size + 1] = sketchPanel.BackColor.G;
                    row[x * pixel_size + 2] = sketchPanel.BackColor.B;
                    row[x * pixel_size + 3] = sketchPanel.BackColor.A;
                }
            }

            map.UnlockBits(data);

            if (openImageDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MoveForm fr = new MoveForm(new System.Drawing.Point(map.Width - 1, map.Height - 1));

                fr.Text = "Choose the bitmap start point";

                if (fr.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    System.Drawing.Bitmap nmap = new System.Drawing.Bitmap(openImageDialog.FileName);

                    map = new System.Drawing.Bitmap(nmap, fr.XValue + nmap.Width, fr.YValue + nmap.Height);

                    data = map.LockBits(new System.Drawing.Rectangle(0, 0, map.Width, map.Height),
                        System.Drawing.Imaging.ImageLockMode.WriteOnly,
                        System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                    System.Drawing.Imaging.BitmapData ndata = nmap.LockBits(new System.Drawing.Rectangle(0, 0, nmap.Width, nmap.Height),
                        System.Drawing.Imaging.ImageLockMode.ReadOnly,
                        System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                    for (int y = 0; y < nmap.Height; y++)
                    {
                        byte* row = (byte*)data.Scan0 + (y * data.Stride);
                        for (int x = 0; x < nmap.Width; x++)
                        {
                            
                        }
                    }
                }
            }

        }

        private void resizeRegionButton_Click(object sender, System.EventArgs e)
        {
            //FixSketch();

            if (sketcher.SketchPoints.Count == 0)
                return;

            int min_x = sketcher.SketchPoints[0].X;
            int max_x = sketcher.SketchPoints[0].X;

            int min_y = sketcher.SketchPoints[0].Y;
            int max_y = sketcher.SketchPoints[0].Y;

            foreach (var item in sketcher.SketchPoints)
            {
                if (min_x > item.X)
                    min_x = item.X;

                if (max_x < item.X)
                    max_x = item.X;

                if (min_y > item.Y)
                    min_y = item.Y;

                if (max_y < item.Y)
                    max_y = item.Y;
            }

            int old_width = max_x - min_x;
            int old_height = max_y - min_y;

            int new_width = 0;
            int new_height = 0;

            ResizeForm form = new ResizeForm();
            form.ChooseSize = new System.Drawing.Size(old_width, old_height);

            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                new_width = form.ChooseSize.Width;
                new_height = form.ChooseSize.Height;
            }
            else
                return;

            sketcher.UnSketch();
            for (int i = 0; i < sketcher.SketchPoints.Count; i++)
            {
                if(i < sketcher.SketchPoints.Count-1 && !sketcher.SketchPoints[i].Equals(sketcher.SketchPoints[i+1]))
                {
                    System.Console.WriteLine("{0}[{2}] - {1}[{3}]",sketcher.SketchPoints[i],sketcher.SketchPoints[i+1],i,i+1);

                    int x_max_index = sketcher.SketchPoints[i].X > sketcher.SketchPoints[i + 1].X ? i : i + 1;
                    int y_max_index = sketcher.SketchPoints[i].Y > sketcher.SketchPoints[i + 1].Y ? i : i + 1;
                    int x_min_index = i == x_max_index ? i + 1 : i;
                    int y_min_index = i == y_max_index ? i + 1 : i;
                    System.Console.WriteLine("MinMax {0},{1} - {2},{3}",x_min_index,x_max_index,y_min_index,y_max_index);
                    int width = sketcher.SketchPoints[x_max_index].X - sketcher.SketchPoints[x_min_index].X;
                    int height = sketcher.SketchPoints[y_max_index].Y - sketcher.SketchPoints[y_min_index].Y;

                    System.Console.WriteLine("width={0} - height={1}", width, height);
                    int perf_width = (width*new_width)/old_width;
                    int perf_Height = (height*new_height)/old_height;

                    System.Console.WriteLine("prefw={0} - redfh={1}", perf_width, perf_Height);

                    int diff_width = perf_width - width;
                    int diff_height = perf_Height - height;

                    System.Console.WriteLine("diffw={0} - diffh={1}", diff_width, diff_height);

                    Point oldp = sketcher.SketchPoints[i + 1];

                    if(sketcher.SketchPoints[x_max_index].X != sketcher.SketchPoints[x_min_index].X)
                        sketcher.SketchPoints[x_max_index] = new System.Drawing.Point(sketcher.SketchPoints[x_max_index].X + diff_width,sketcher.SketchPoints[x_max_index].Y);

                    if (sketcher.SketchPoints[y_max_index].Y != sketcher.SketchPoints[y_min_index].Y)
                        sketcher.SketchPoints[y_max_index] = new System.Drawing.Point(sketcher.SketchPoints[y_max_index].X, sketcher.SketchPoints[y_max_index].Y + diff_width);

                    if (i + 2 < sketcher.SketchPoints.Count - 1 && oldp.Equals(sketcher.SketchPoints[i + 2]))
                        sketcher.SketchPoints[i + 2] = sketcher.SketchPoints[i + 1];

                    System.Console.WriteLine("Point After ", sketcher.SketchPoints[i + 1]);
                    System.Console.WriteLine("--------------------------------------");
                }
            }

            sketcher.Sketch();
        }

        private int IndexOfFream(ISketcher sketcher)
        {
            int i = -1;
            foreach (var item in animation)
            {
                i++;
                if (sketcher == item.Sketcher)
                    return i;
            }

            return i;
        }

        private void saveFreamButton_Click(object sender, System.EventArgs e)
        {
            if (freamsCheckBox.Checked)
                return;

            freamsCheckBox.Enabled = true;

            //int index = IndexOfFream(sketcher);
            //if (index != -1)
            //{
                animation.Add(new AnimationFream((ISketcher)sketcher.Clone()));
                if (!freamsForm.IsClosed)
                    freamsForm.ResetUp();
                this.freamIndexLabel.Text = "1/" + animation.Count;
            //}
            //else
            //    animation[index].Sketcher = sketcher;
        }

        private void viewFreamsButton_Click(object sender, System.EventArgs e)
        {
            if(freamsForm.IsClosed)
                freamsForm = new EditFreamsFrom(animation, sketchPanel.Size);
            freamsForm.Show();
        }

        private void freamsCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            if (freamsCheckBox.Checked)
            {
                lockCheckBox.Enabled = false;
                lockCheckBox.Checked = true;

                moveCheckBox.Enabled = false;
                moveCheckBox.Checked = false;

                nextFreamButton.Enabled = true;
                prevFreamButton.Enabled = true;

                animation.Add(new AnimationFream((ISketcher)sketcher.Clone(), 0));

                Resetup();
            }
            else
            {
                lockCheckBox.Enabled = true;
                lockCheckBox.Checked = true;

                moveCheckBox.Enabled = true;
                moveCheckBox.Checked = false;

                nextFreamButton.Enabled = false;
                prevFreamButton.Enabled = false;

                sketcher.UnSketch();

                if (selectorsCheckBox.Checked)
                    HideSelectPanels();

                sketcher = animation[animation.Count - 1].Sketcher;

                animation.RemoveAt(animation.Count - 1);

                tform.SetRegion(sketcher);

                sketcher.Sketch();

                if (selectorsCheckBox.Checked)
                    ShowSelectPanels();
            }

           
        }

        private void Resetup()
        {
            if (currentFream + 1 >= animation.Count)
                nextFreamButton.Enabled = false;
            else
                nextFreamButton.Enabled = true;

            if (currentFream - 1 >= 0)
                prevFreamButton.Enabled = true;
            else
                prevFreamButton.Enabled = false;

            freamIndexLabel.Text = (currentFream + 1) + "/" + animation.Count;
        }

        private void SetupFream()
        {

            if (selectorsCheckBox.Checked)
                HideSelectPanels();

            sketcher.UnSketch();

            sketcher = animation[currentFream].Sketcher;

            sketcher.Graphics = sketchPanel.CreateGraphics();

            sketcher.Sketch();

            tform.SetRegion(sketcher);

            if (selectorsCheckBox.Checked)
                ShowSelectPanels();
        }


        private void nextFreamButton_Click(object sender, System.EventArgs e)
        {
            currentFream++;

            Resetup();

            SetupFream();
        }

        private void prevFreamButton_Click(object sender, System.EventArgs e)
        {
            currentFream--;

            Resetup();

            SetupFream();
        }

        private void playFreamsButton_Click(object sender, System.EventArgs e)
        {
            if (playingAnimation)
            {
                playingAnimation = false;
                playFreamsButton.Text = "Play Freams";
                return;
            }


            long maxMs = 0;
            long currentMS = 0;

            foreach (var item in animation)
            {
                maxMs += item.WaitMs;
            }

            if (maxMs == 0)
                return;

            playFreamsButton.Text = "Stop Freams";
            playingAnimation = true;
            lockCheckBox.Checked = true;

            if (selectorsCheckBox.Checked)
                HideSelectPanels();

            foreach (Control item in functionsPanel.Controls)
            {
                if (item == playFreamsButton)
                    playFreamsButton.Enabled = true;
                else
                    if (item == playTimeLabel)
                        playFreamsButton.Enabled = true;
                else
                    item.Enabled = false;
            }

            freamsCheckBox.Checked = true;

            playingTask = new Task(() =>
                {
                    currentFream = 0;
                    int tick = 0;
                    int count = 0;
                    currentMS = (long)System.Environment.TickCount;
                    lock (animation)
                        count = animation.Count;

                    while (currentFream < count && playingAnimation)
                    {
                        this.Invoke(new System.Windows.Forms.MethodInvoker(() =>
                            {
                                lock (sketchPanel)
                                {
                                    freamIndexLabel.Text = (currentFream + 1) + "/" + animation.Count;

                                    sketcher.UnSketch();

                                    sketcher = animation[currentFream].Sketcher;

                                    sketcher.Graphics = sketchPanel.CreateGraphics();

                                    sketcher.Sketch();

                                    tform.SetRegion(sketcher);

                                    
                                }
                            }));

                        lock(animation)
                            tick = System.Environment.TickCount + animation[currentFream].WaitMs;

                        while (System.Environment.TickCount < tick)
                        {
                            lock (playTimeLabel)
                            {
                                playTimeLabel.Text = Statics.ToTime(System.Environment.TickCount - currentMS) + "\n" + Statics.ToTime(maxMs);
                            }
                        }

                        currentFream++;
                    }

                    currentFream = 0;
                    this.Invoke( new System.Windows.Forms.MethodInvoker(()=>
                        {
                            foreach (Control item in functionsPanel.Controls)
                            {
                                item.Enabled = true;
                            }
                            if (selectorsCheckBox.Checked)
                                ShowSelectPanels();

                            playTimeLabel.Text = "00:00,00\n00:00,00";
                            playFreamsButton.Text = "Play Freams";
                            freamsCheckBox.Checked = false;
                            playingAnimation = false;
                        }));
                });

            playingTask.Start();
        }
    }
}
