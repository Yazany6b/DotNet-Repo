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
    public partial class CoursesForm : Form
    {
        bool editMode = false;
        int editIndex = -1;
        Computer computer;
        public CoursesForm(ref Computer computer)
        {
            InitializeComponent();
            try
            {
                PrepareLanguage();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.StackTrace, e.Message);
            }
            this.computer = computer;
            if (computer != null)
                computer.FillList(ref courseListVciew);
            else
            {
                addButton.Enabled = false;
                removeButton.Enabled = false;
                editButton.Enabled = false;
            }
            courseListVciew.MultiSelect = false;
        }

        private void PrepareLanguage()
        {
            if (Statics.EnglishLanguage)
                return;
            if (Statics.Language.ContainsKey("courseform_title"))
                this.Text = Statics.Language["courseform_title"];
            foreach (Control x in this.Controls)
                    x.Text = Statics.Translate(x.Text.Trim());

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
                bool added = computer.Add(new Course(nameTextBox.Text.Trim(), (int)markNumericUpDown.Value, (int)hoursNumericUpDown.Value,computedCheckBox.Checked));
                if (added)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = nameTextBox.Text.Trim() + "  ,  " + ((int)markNumericUpDown.Value).ToString() + "  ,  " + ((int)hoursNumericUpDown.Value).ToString();
                    courseListVciew.Items.Add(item);
                    item.EnsureVisible();
                }
            }
            else
            {
                bool modified = computer.Modify(editIndex, new Course(nameTextBox.Text.Trim(), (int)markNumericUpDown.Value, (int)hoursNumericUpDown.Value));
                if (modified)
                {
                    courseListVciew.Focus();
                    courseListVciew.Items[editIndex].Text = nameTextBox.Text.Trim() + "  ,  " + ((int)markNumericUpDown.Value).ToString() + "  ,  " + ((int)hoursNumericUpDown.Value).ToString();
                    courseListVciew.Items[editIndex].EnsureVisible();
                    courseListVciew.Items[editIndex].Selected = true;
                    editMode = false;
                }
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (courseListVciew.SelectedItems.Count > 0)
            {
                computer.RemoveAt(courseListVciew.SelectedItems[0].Index);
                courseListVciew.SelectedItems[0].Remove();
            }
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
            if (courseListVciew.SelectedItems.Count > 0)
            {
                editMode = true;
                editIndex = courseListVciew.SelectedItems[0].Index;
                Course x = computer.GetAt(courseListVciew.SelectedItems[0].Index);
                nameTextBox.Text = x.Name;
                markNumericUpDown.Value = x.Mark;
                hoursNumericUpDown.Value = x.Hours;
                computedCheckBox.Checked = x.Computed;
                nameTextBox.Focus();
            }
        }

        //Unused Parts
        //
        //
        private void button1_Click(object sender, EventArgs e)
        {
            if (computer == null)
                return;
            Statics.PrintToFile(computer.CoursesBetween(0, 100,false));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (computer == null)
                return;
            List<Course> x = Statics.ReadFromFile();
            foreach (Course c in x)
                computer.Add(c);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < computer.ComputerStudent.Courses.Count; i++)
                computer.ComputerStudent.Courses[i].Computed = true;
        }

        public bool EnableAdding
        {
            get { return addButton.Enabled; }
            set { addButton.Enabled = value; }
        }

        public bool EnableRemoving
        {
            get { return removeButton.Enabled; }
            set { removeButton.Enabled = value; }
        }

        public bool EnableEditing
        {
            get { return editButton.Enabled; }
            set { editButton.Enabled = value; }
        }
    }
}
