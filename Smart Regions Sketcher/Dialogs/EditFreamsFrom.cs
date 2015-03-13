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
        public List<AnimationFream> Freams { get; set; }
        private int currentFream = 0;
        private int count = 0;

        public bool IsClosed { get; set; }

        public EditFreamsFrom(List<AnimationFream> freams,Size size)
        {
            InitializeComponent();

            this.Freams = freams;

            nextButton.Enabled = freams != null && freams.Count != 0;
            prevButton.Enabled = false;

            SetupSize(size);

            this.Text = "Fream : " + (currentFream+1) + "/" + freams.Count;

            count = freams.Count;

            IsClosed = true;
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
            if (Freams.Count == 0)
                return;

            if (currentFream + 1 >= Freams.Count)
                nextButton.Enabled = false;
            else
                nextButton.Enabled = true;

            if (currentFream - 1 >= 0)
                prevButton.Enabled = true;
            else
                prevButton.Enabled = false;

            this.Text = "Fream : " + (currentFream + 1) + "/" + Freams.Count;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            currentFream++;

            ResetUp();

            sketchPanel.CreateGraphics().Clear(sketchPanel.BackColor);
            waitNumericUpDown.Value = Freams[currentFream].WaitMs;

            sketchPanel.Refresh();
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            currentFream--;

            ResetUp();

            sketchPanel.CreateGraphics().Clear(sketchPanel.BackColor);
            waitNumericUpDown.Value = Freams[currentFream].WaitMs;

            sketchPanel.Refresh();
        }

        private void sketchPanel_Paint(object sender, PaintEventArgs e)
        {
            if(Freams != null && Freams.Count > 0)
                Freams[currentFream].Sketcher.Sketch(e.Graphics);
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
            Freams[currentFream].WaitMs = (int)waitNumericUpDown.Value;
        }

        private void setRestButton_Click(object sender, EventArgs e)
        {
            for(int i = currentFream ; i < Freams.Count ;i++)
                Freams[i].WaitMs = (int)waitNumericUpDown.Value;
        }

        private void setAllButton_Click(object sender, EventArgs e)
        {
            foreach (var item in Freams)
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
