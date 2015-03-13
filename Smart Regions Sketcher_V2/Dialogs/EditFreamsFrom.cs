using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace Smart_Regions_Sketcher.Dialogs
{
    public partial class EditFreamsFrom : Form
    {
        private int currentFream = 0;
        private int count = 0;
        private FreamsList animation;

        public bool IsClosed { get; set; }

        public EditFreamsFrom(FreamsList animation, Size size)
        {
            InitializeComponent();

            this.animation = animation;

            ResetUp();

            SetupSize(size);

            this.Text = "Fream : " + (currentFream + 1) + "/" + animation.Count;

            count = animation.Count;

            IsClosed = true;
        }

        protected override void OnLoad(EventArgs e)
        {
            
        }

        public void SetupAnimation()
        {
            nextButton.Enabled = currentFream + 1 < animation.Count;
            prevButton.Enabled = currentFream - 1 > -1;

            this.Text = "Fream : " + (currentFream + 1) + "/" + animation.Count;

            count = animation.Count;
        }

        public void SetupSize(Size size)
        {
            sketchPanel.Size = size;

            this.Width = sketchPanel.Location.X + sketchPanel.Width + sketchPanel.Location.X + nextButton.Width + 20;

            this.Height = sketchPanel.Location.Y + sketchPanel.Height + 69;

            nextButton.Location = new Point(nextButton.Location.X, this.Height - 60);
            prevButton.Location = new Point(prevButton.Location.X, this.Height - 60);

            waitNumericUpDown.Location = new Point(waitNumericUpDown.Location.X, this.Height - 60);

            label1.Location = new Point(label1.Location.X, this.Height - 60);

            setButton.Location = new Point(setButton.Location.X, this.Height - 60);
            setRestButton.Location = new Point(setRestButton.Location.X, this.Height - 60);
            setAllButton.Location = new Point(setAllButton.Location.X, this.Height - 60);
        }


        public void ResetUp()
        {
            if (animation.Count == 0)
                return;

            nextButton.Enabled = currentFream + 1 < animation.Count;
            prevButton.Enabled = currentFream - 1 > -1;

            this.Text = "Fream : " + (currentFream + 1) + "/" + animation.Count;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            currentFream++;

            ResetUp();

            sketchPanel.CreateGraphics().Clear(sketchPanel.BackColor);
            waitNumericUpDown.Value = animation[currentFream].WaitMs;

            sketchPanel.Refresh();
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            currentFream--;

            ResetUp();

            sketchPanel.CreateGraphics().Clear(sketchPanel.BackColor);
            waitNumericUpDown.Value = animation[currentFream].WaitMs;

            sketchPanel.Refresh();
        }

        private void sketchPanel_Paint(object sender, PaintEventArgs e)
        {
            if(animation != null && animation.Count > 0)
                animation[currentFream].Sketcher.Sketch(e.Graphics);
        }

        protected override void OnClosed(EventArgs e)
        {
            IsClosed = true;
            
            base.OnClosed(e);
        }

        private void waitNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            animation[currentFream].WaitMs = (int)waitNumericUpDown.Value;
        }

        private void setRestButton_Click(object sender, EventArgs e)
        {
            for(int i = currentFream ; i < animation.Count ;i++)
                animation[i].WaitMs = (int)waitNumericUpDown.Value;
        }

        private void setAllButton_Click(object sender, EventArgs e)
        {
            foreach (var item in animation)
            {
                item.WaitMs = (int)waitNumericUpDown.Value;
            }
        }

        private void EditFreamsFrom_Load(object sender, EventArgs e)
        {
            IsClosed = false;
        }
    }
}
