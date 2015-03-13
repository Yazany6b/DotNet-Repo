using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Student_Assistant_Application
{
    /// <summary>
    /// Class EstimatorForm
    /// </summary>
    public partial class EstimatorForm : Form
    {
        private Computer computer;
        private bool editMode = false;
        private int editIndex = -1;
        private Student_Assistant_Application.Animations.UpDownAnimation updown;
        /// <summary>
        /// Create an instance of type EstimatorForm
        /// </summary>
        /// <param name="computer">The student computer object</param>
        public EstimatorForm(ref Computer computer)
        {
            InitializeComponent();
            ecoursesListVciew.MultiSelect = false;
            try
            {
                PrepareLanguage();//prepare the form language
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.StackTrace, e.Message);
            }
            this.computer = computer;
            if (computer != null)
            {
                hoursNumericUpDown.Minimum = 1;//the minimum hours 
                hoursNumericUpDown.Maximum = computer.ComputerStudent.StudentMajor.TotalHours - computer.TotalHours(false);//sill hours
                label3.Text += " 1 - " + hoursNumericUpDown.Maximum.ToString();
                hoursNumericUpDown.Value = hoursNumericUpDown.Minimum;
                avgNumericUpDown.Minimum = (decimal)computer.ComputeAverage();//the minimum estimated average
                avgNumericUpDown.Maximum = 100;//the max average 
                avgNumericUpDown.Value = avgNumericUpDown.Minimum;

                advAvgNumericUpDown.Minimum = avgNumericUpDown.Minimum;//the minimum estimated average
                advAvgNumericUpDown.Maximum = 100;//the max average 
                advAvgNumericUpDown.Value = avgNumericUpDown.Minimum;

                existAveageNumericUpDown.Value = avgNumericUpDown.Value;
                
                if(computer.ComputerStudent.EstimatedCourses != null)
                    foreach(Course x in computer.ComputerStudent.EstimatedCourses)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = x.Name + " , " + x.Mark.ToString() + " , " + x.Hours.ToString() + " , ";
                        ecoursesListVciew.Items.Add(item);
                    }
            }
            else
            {
                estimateButton.Enabled = false;
                estimateCurrentButton.Enabled = false;
                AdvancedCheckBox.Enabled = false;
            }

            updown = new Animations.UpDownAnimation(ecoursesListVciew,coursesListView);
            FillCoursesListView();
        }

        private void PrepareLanguage()
        {
            if (Statics.EnglishLanguage)
                return;
            if (Statics.Language.ContainsKey("estimatorform_title"))
                this.Text = Statics.Translate("estimatorform_title");
            foreach (Control x in this.Controls)
                    x.Text = Statics.Translate(x.Text.Trim());
            foreach (Control x in this.currentInfoPanel.Controls)
                x.Text = Statics.Translate(x.Text.Trim());
            foreach (Control x in this.groupBox1.Controls)
                x.Text = Statics.Translate(x.Text.Trim());
        }

        private void FillCoursesListView()
        {
            coursesListView.BackColor = System.Drawing.Color.Black;
            foreach (Course x in computer.ComputerStudent.Courses)
            {
                ListViewItem item = new ListViewItem(x.ToString());
                item.ForeColor = System.Drawing.Color.White;
                coursesListView.Items.Add(item);
            }
        }

        private void estimateButton_Click(object sender, EventArgs e)
        {
            double estimated = 0;
            if (!existInfoPanel.Enabled)
            {
                 estimated = ((double)avgNumericUpDown.Value * (double)(computer.TotalHours(true) + (double)hoursNumericUpDown.Value)) - (double)computer.TotalMarks();//get the estimated value
                estimated /= (double)hoursNumericUpDown.Value;
            }
            else
            {
                estimated = ((double)avgNumericUpDown.Value * (double)((double)existHoursNumericUpDown.Value + (double)hoursNumericUpDown.Value)) - (double)(existHoursNumericUpDown.Value * existAveageNumericUpDown.Value);//get the estimated value
                estimated /= (double)hoursNumericUpDown.Value;
            }

            if (estimated > 100.0)
            {
                System.Windows.Forms.MessageBox.Show(string.Format(Statics.Translate("It's Not Possible Get The Average {0} With This Total Of Hours {1}"),avgNumericUpDown.Value,hoursNumericUpDown.Value),Statics.Translate("Sorry"),MessageBoxButtons.OK,MessageBoxIcon.Information);
                label1.Text = Statics.Translate("Your Average Must Be ");
            }else
                label1.Text = Statics.Translate("Your Average Must Be ") + (Statics.FormatDouble(estimated,4)).ToString();//get the estimated average
        }

        private bool HasCourse(List<Course> courses, Course c)
        {
            foreach (Course x in courses)
                if (x.Name.Equals(c.Name, StringComparison.OrdinalIgnoreCase) && x.Hours == c.Hours)
                    return true;
            return false;
        }

        private List<Course> Marge(List<Course> list1, List<Course> list2)
        {
            List<Course> temp = new List<Course>();
            for (int i = 0; i < list1.Count; i++)
                temp.Add(list1[i]);
            for (int i = 0; i < list2.Count; i++)
                temp.Add(list2[i]);
            return temp;
        }

        private List<Course> WithoutEstimatedCourses()
        {
            List<Course> temp = new List<Course>();
            foreach (Course x in computer.ComputerStudent.Courses)
                if (!HasCourse(computer.ComputerStudent.EstimatedCourses, x))
                    temp.Add(x);
            return temp;
        }

        private double AVG(List<Course> list)
        {
            int sum = 0;
            int hours = 0;
            for(int i = 0;i<list.Count;i++)
                if (list[i].Computed)
                {
                    sum += list[i].Mark * list[i].Hours;
                    hours += list[i].Hours;
                }
            return (double)sum / (double)hours;
        }

        private int Totalhours(List<Course> list)
        {
            int hours = 0;
            for (int i = 0; i < list.Count; i++)
                if (list[i].Computed)
                    hours += list[i].Hours;
            return hours;
        }

        private int TotalMarks(List<Course> list)
        {
            int marks = 0;
            for (int i = 0; i < list.Count; i++)
                if (list[i].Computed)
                    marks += list[i].Mark * list[i].Hours;
            return marks;
        }

        private void advEstimateButton_Click(object sender, EventArgs e)
        {
            List<Course> without = WithoutEstimatedCourses();
            double estimated = ((double)advAvgNumericUpDown.Value * (double)(Totalhours(without) + (double)Totalhours(computer.ComputerStudent.EstimatedCourses))) - (double)TotalMarks(without);//get the estimated value
            estimated /= (double)Totalhours(computer.ComputerStudent.EstimatedCourses);

            if (estimated > 100.0)
            {
                System.Windows.Forms.MessageBox.Show(string.Format(Statics.Translate("It's Not Possible Get The Average {0} With This Total Of Hours {1}"), advAvgNumericUpDown.Value, Totalhours(computer.ComputerStudent.EstimatedCourses)), Statics.Translate("Sorry"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                advAvgLabel.Text = Statics.Translate("Your Average Must Be ");
            }
            else
            {
                estimateCurrentButton.Enabled = true;
                advAvgLabel.Text = Statics.Translate("Your Average Must Be ") + (Statics.FormatDouble(estimated, 4)).ToString();//get the estimated average
                ecoursesListVciew.Items.Clear();
                foreach (Course x in computer.ComputerStudent.EstimatedCourses)
                {
                    x.Mark = (int)estimated;
                    ecoursesListVciew.Items.Add(new ListViewItem(x.ToString()));
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            computer.Saved = false;
            if (nameTextBox.Text.Trim() == string.Empty)
            {
                System.Windows.Forms.MessageBox.Show(Statics.Translate("Input the course name"));
                return;
            }
            if (!editMode)
            {
                bool added = computer.AddAsEstimated(new Course(nameTextBox.Text.Trim(), (int)markNumericUpDown.Value, (int)advHoursNumericUpDown.Value, computedCheckBox.Checked));
                if (added)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = nameTextBox.Text.Trim() + "  ,  0  ,  " + ((int)advHoursNumericUpDown.Value).ToString();
                    ecoursesListVciew.Items.Add(item);
                    item.EnsureVisible();
                }
            }
            else
            {
                bool modified = computer.ModifyEstimated(editIndex, new Course(nameTextBox.Text.Trim(), (int)markNumericUpDown.Value, (int)advHoursNumericUpDown.Value));
                if (modified)
                {
                    
                    ecoursesListVciew.Focus();
                    ecoursesListVciew.Items[editIndex].Text = nameTextBox.Text.Trim() + "  ,  " + ((int)markNumericUpDown.Value).ToString() + "  ,  " + ((int)advHoursNumericUpDown.Value).ToString();
                    ecoursesListVciew.Items[editIndex].EnsureVisible();
                    ecoursesListVciew.Items[editIndex].Selected = true;
                }
                markNumericUpDown.Enabled = false;
                editButton.Enabled = true;
                addButton.Text = Statics.Translate("ADD");
                editMode = false;
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (ecoursesListVciew.SelectedItems.Count > 0)
            {
                computer.RemoveAtFromEstimated(ecoursesListVciew.SelectedItems[0].Index);
                ecoursesListVciew.SelectedItems[0].Remove();
            }
            editMode = false;
        }

        private void nameTextBox_Enter(object sender, EventArgs e)
        {
            nameTextBox.SelectAll();
        }

        private void markNumericUpDown_Enter(object sender, EventArgs e)
        {
            ((NumericUpDown)sender).Select();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (ecoursesListVciew.SelectedItems.Count > 0)
            {
                editMode = true;
                editButton.Enabled = false;
                addButton.Text = Statics.Translate("Done");
                editIndex = ecoursesListVciew.SelectedItems[0].Index;
                Course x = computer.GetEstimatedAt(ecoursesListVciew.SelectedItems[0].Index);
                nameTextBox.Text = x.Name;
                markNumericUpDown.Value = x.Mark;
                advHoursNumericUpDown.Value = x.Hours;
                computedCheckBox.Checked = x.Computed;
                nameTextBox.Focus();
                markNumericUpDown.Enabled = true;
            }
        }


        //Animations
        System.Threading.Tasks.Task x;
        private void GetStarted()
        {
            //229, 219

            currentInfoPanel.Enabled = false;
            this.Size = new Size(240, 230);
            for (int i = 0; i < 1000000; i++) ;
            this.Size = new Size(270, 250);
            for (int i = 0; i < 1000000; i++) ;
            this.Size = new Size(320, 280);
            for (int i = 0; i < 1000000; i++) ;
            this.Size = new Size(369, 300);
            for (int i = 0; i < 1000000; i++) ;
            this.Size = new Size(400, 320);
            for (int i = 0; i < 1000000; i++) ;
            this.Size = new Size(450, 350);
            for (int i = 0; i < 1000000; i++) ;
            this.Size = new Size(500, 375);
            for (int i = 0; i < 1000000; i++) ;
            this.Size = new Size(550, 390);
            for (int i = 0; i < 1000000; i++) ;
            this.Size = new Size(600, 410);
            for (int i = 0; i < 1000000; i++) ;
            this.Size = new Size(676, 432);
            for (int i = 0; i < 1000000; i++) ;

            this.Size = new Size(682, 432);
        }
        private void GetStartedHide()
        {
            currentInfoPanel.Enabled = true;
            this.Size = new Size(600, 410);
            for (int i = 0; i < 1000000; i++) ;
            this.Size = new Size(550, 390);
            for (int i = 0; i < 1000000; i++) ;
            this.Size = new Size(500, 375);
            for (int i = 0; i < 1000000; i++) ;
            this.Size = new Size(450, 350);
            for (int i = 0; i < 1000000; i++) ;
            this.Size = new Size(400, 320);
            for (int i = 0; i < 1000000; i++) ;
            this.Size = new Size(369, 300);
            for (int i = 0; i < 1000000; i++) ;
            this.Size = new Size(320, 280);
            for (int i = 0; i < 1000000; i++) ;
            this.Size = new Size(270, 250);
            for (int i = 0; i < 1000000; i++) ;
            this.Size = new Size(240, 230);
            for (int i = 0; i < 1000000; i++) ;
            this.Size = new Size(229, 219);
            for (int i = 0; i < 1000000; i++) ;

            //this.Size = new Size(229, 219);
        }
        bool show = false;

        private void AdvancedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            if (!show)
            {
                show = true;
                x = System.Threading.Tasks.Task.Factory.StartNew(GetStarted);
                x.Wait();
            }
            else
            {
                show = false;
                x = System.Threading.Tasks.Task.Factory.StartNew(GetStartedHide);
                x.Wait();
            }
            groupBox1.Visible = true;
        }

        private void estimateCurrentButton_Click(object sender, EventArgs e)
        {
            List<Course> whole = Marge(WithoutEstimatedCourses(),computer.ComputerStudent.EstimatedCourses);
            System.Windows.Forms.MessageBox.Show(string.Format(Statics.Translate("Your current average is {0}\nYour new average will be {1}") ,computer.ComputeAverage(),Statics.FormatDouble((double)TotalMarks(whole) / (double)Totalhours(whole),2)));
        }

        private void coursesButton_Click(object sender, EventArgs e)
        {
            updown.PerformAnimation();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
                existInfoPanel.Enabled = true;
            else
            {
                existInfoPanel.Enabled = false;
                currentInfoPanel.Enabled = AdvancedCheckBox.Checked;
            }
        }
    }
}
