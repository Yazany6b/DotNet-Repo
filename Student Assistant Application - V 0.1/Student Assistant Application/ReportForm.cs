namespace Student_Assistant_Application
{
    /// <summary>
    /// The Class ReportForm
    /// </summary>
    public partial class ReportForm : System.Windows.Forms.Form
    {
        /// <summary>
        /// Create an instance of type ReportForm using an object of type Computer
        /// </summary>
        /// <param name="computer">An object of typw Computer</param>
        public ReportForm(ref Computer computer)
        {
            InitializeComponent();
            if (computer != null)
            {
                label35_50.Text = computer.CoursesBetween(35, 49, true).Count.ToString();
                if (Statics.Messages.ContainsKey(6))
                    Statics.Messages.Remove(6);
                Statics.Messages.Add(6, Statics.StringList<Course>(computer.CoursesBetween(35, 49, true)));

                label50_60.Text = computer.CoursesBetween(50, 60,true).Count.ToString();
                if (Statics.Messages.ContainsKey(1))
                    Statics.Messages.Remove(1);    
                Statics.Messages.Add(1, Statics.StringList<Course>(computer.CoursesBetween(50, 60, true)));

                label60_70.Text = computer.CoursesBetween(61, 70, true).Count.ToString();
                if (Statics.Messages.ContainsKey(2))
                    Statics.Messages.Remove(2);    
                Statics.Messages.Add(2, Statics.StringList<Course>(computer.CoursesBetween(61, 70, true)));

                label70_80.Text = computer.CoursesBetween(71, 80, true).Count.ToString();
                if (Statics.Messages.ContainsKey(3))
                    Statics.Messages.Remove(3);    
                Statics.Messages.Add(3, Statics.StringList<Course>(computer.CoursesBetween(71, 80, true)));

                label80_90.Text = computer.CoursesBetween(81, 90, true).Count.ToString();
                if (Statics.Messages.ContainsKey(4))
                    Statics.Messages.Remove(4);    
                Statics.Messages.Add(4, Statics.StringList<Course>(computer.CoursesBetween(81, 90, true)));

                label90_100.Text = computer.CoursesBetween(91, 100, true).Count.ToString();
                if (Statics.Messages.ContainsKey(5))
                    Statics.Messages.Remove(5);    
                Statics.Messages.Add(5, Statics.StringList<Course>(computer.CoursesBetween(91, 100, true)));

                label_avg.Text = computer.ComputeAverage().ToString();
                label_name.Text = computer.ComputerStudent.StudentName;
                label_major.Text = computer.ComputerStudent.StudentMajor.MajorName;
                label_hours.Text = computer.ComputerStudent.StudentMajor.TotalHours.ToString();

                Statics.EnableMessages = true;

                try
                {
                    PrepareLanguage();
                }
                catch (System.Exception e)
                {
                    System.Windows.Forms.MessageBox.Show(e.StackTrace, e.Message);
                }

            }
        }


        private void PrepareLanguage()
        {
            if (Statics.EnglishLanguage)
                return;
            if (Statics.Language.ContainsKey("reportform_title"))
                this.Text = Statics.Language["reportform_title"];
            foreach (System.Windows.Forms.Control x in this.Controls)
                    x.Text = Statics.Translate(x.Text.Trim());
            foreach (System.Windows.Forms.Control x in this.detailsPanels.Controls)
                x.Text = Statics.Translate(x.Text.Trim());

        }

        private void label49_TextChanged(object sender, System.EventArgs e)
        {
            double x;
            int unknown;
            double.TryParse(label_avg.Text, out x);
            unknown = (int)x;
            if (unknown >= 50 && unknown <= 60)
            {
                panel1.BackgroundImage = global::Student_Assistant_Application.Properties.Resources._25P;
                label52.Text = Statics.Translate("Accepted");
                label52.ForeColor = System.Drawing.Color.DarkRed;
            }
            else
                if (unknown > 61 && unknown <= 70)
                {
                    panel1.BackgroundImage = global::Student_Assistant_Application.Properties.Resources._50P;
                    label52.Text = Statics.Translate("Good");
                    label52.ForeColor = System.Drawing.Color.DarkRed;
                }
                else
                    if (unknown > 71 && unknown <= 80)
                    {
                        panel1.BackgroundImage = global::Student_Assistant_Application.Properties.Resources._75P;
                        label52.Text = Statics.Translate("Very Good");
                        label52.ForeColor = System.Drawing.Color.DarkGreen;
                    }
                    else
                        if (unknown > 80)
                        {
                            panel1.BackgroundImage = global::Student_Assistant_Application.Properties.Resources._100P;
                            label52.Text = Statics.Translate("Excellent");
                            label52.ForeColor = System.Drawing.Color.DarkGreen;
                        }
                        else
                        {
                            panel1.BackgroundImage = global::Student_Assistant_Application.Properties.Resources._0P;
                            label52.Text = Statics.Translate("Failed");
                            label52.ForeColor = System.Drawing.Color.Black;
                        }
            label_avg.Location = new System.Drawing.Point((panel1.Width / 2) - (label_avg.Text.Length * (int)label_avg.Font.Size / 2), label_avg.Location.Y);
        }
        System.Threading.Tasks.Task x;
        private void GetStarted()
        {
            this.Height += 20;
            for (int i = 0; i < 1000000; i++) ;
            this.Height += 30;
            for (int i = 0; i < 1000000; i++) ;
            this.Height += 30;
            for (int i = 0; i < 1000000; i++) ;
            this.Height += 30;
            for (int i = 0; i < 1000000; i++) ;
            this.Height += 30;
            for (int i = 0; i < 1000000; i++) ;
            this.Height += 30;
            for (int i = 0; i < 1000000; i++) ;
            this.Height += 30;
            for (int i = 0; i < 1000000; i++) ;
            this.Height += 30;
            for (int i = 0; i < 1000000; i++) ;
            this.Height += 30;
            for (int i = 0; i < 1000000; i++) ;
            this.Height += 30;
            for (int i = 0; i < 1000000; i++) ;
            this.Height += 30;

            button1.Location = new System.Drawing.Point(button1.Location.X, this.Height - 25 - button1.Height);
        }
        private void GetStartedHide()
        {
            this.Height -= 20;
            for (int i = 0; i < 1000000; i++) ;
            this.Height -= 30;
            for (int i = 0; i < 1000000; i++) ;
            this.Height -= 30;
            for (int i = 0; i < 1000000; i++) ;
            this.Height -= 30;
            for (int i = 0; i < 1000000; i++) ;
            this.Height -= 30;
            for (int i = 0; i < 1000000; i++) ;
            this.Height -= 30;
            for (int i = 0; i < 1000000; i++) ;
            this.Height -= 30;
            for (int i = 0; i < 1000000; i++) ;
            this.Height -= 30;
            for (int i = 0; i < 1000000; i++) ;
            this.Height -= 30;
            for (int i = 0; i < 1000000; i++) ;
            this.Height -= 30;
            for (int i = 0; i < 1000000; i++) ;
            this.Height -= 30;
            button1.Location = old;
        }
        bool show = false;
        System.Drawing.Point old;
        private void button1_Click(object sender, System.EventArgs e)
        {
            if (!show)
            {
                old = button1.Location;
                show = true;
                detailsPanels.Visible = false;
                x = System.Threading.Tasks.Task.Factory.StartNew(GetStarted);
                x.Wait();
                button1.Text = Statics.Translate("Hide Details");
                detailsPanels.Visible = true;
            }
            else
            {
                show = false;
                x = System.Threading.Tasks.Task.Factory.StartNew(GetStartedHide);
                x.Wait();
                button1.Text = Statics.Translate("Show Details");
            }
        }

        //the following three functions not implemented yet

        private void DetailLabelMouseLeave(object sender, System.EventArgs e)
        {
            ((System.Windows.Forms.Label)sender).ForeColor = System.Drawing.Color.Black;
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void DetailLabelClicked(object sender, System.EventArgs e)
        {
            if (Statics.EnableMessages)
            {
                ((System.Windows.Forms.Label)sender).ForeColor = System.Drawing.Color.Black;
                MessageViewForm mvform = new MessageViewForm(Statics.Messages[((System.Windows.Forms.Label)sender).TabIndex]);
                mvform.Show();
            }
        }

        private void DetailLabelMouseEnter(object sender, System.EventArgs e)
        {
            if (Statics.EnableMessages)
            {
                ((System.Windows.Forms.Label)sender).ForeColor = System.Drawing.Color.Red;
                this.Cursor = System.Windows.Forms.Cursors.Help;
            }
        }
    }
}
