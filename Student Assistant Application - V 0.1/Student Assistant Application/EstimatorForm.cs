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
        /// <summary>
        /// Create an instance of type EstimatorForm
        /// </summary>
        /// <param name="computer">The student computer object</param>
        public EstimatorForm(ref Computer computer)
        {
            InitializeComponent();
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
            }
            else
            {
                estimateButton.Enabled = false;
            }
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
        }


        private void estimateButton_Click(object sender, EventArgs e)
        {
            double estimated = 0;
            estimated = ((double)avgNumericUpDown.Value * (double)(computer.TotalHours(true) + (double)hoursNumericUpDown.Value)) - (double)computer.TotalMarks();//get the estimated value
                estimated /= (double)hoursNumericUpDown.Value;

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

        private void estimateCurrentButton_Click(object sender, EventArgs e)
        {
            List<Course> whole = Marge(WithoutEstimatedCourses(),computer.ComputerStudent.EstimatedCourses);
            System.Windows.Forms.MessageBox.Show(string.Format(Statics.Translate("Your current average is {0}\nYour new average will be {1}") ,computer.ComputeAverage(),Statics.FormatDouble((double)TotalMarks(whole) / (double)Totalhours(whole),2)));
        }
    }
}
