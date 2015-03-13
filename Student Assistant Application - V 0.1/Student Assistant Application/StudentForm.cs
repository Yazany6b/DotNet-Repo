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
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
            StudentObject = null;
            passwordTextBox.UseSystemPasswordChar = true;
            try
            {
                PrepareLanguage();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.StackTrace, e.Message);
            }
        }


        public StudentForm(ref Computer computer)
        {
            InitializeComponent();
            StudentObject = computer.ComputerStudent;
            studentNameTextBox.Text = StudentObject.StudentName;
            majorNameTextBox.Text = StudentObject.StudentMajor.MajorName;
            majorHoursNumericUpDown.Value = StudentObject.StudentMajor.TotalHours;
            passwordTextBox.Text = StudentObject.Password;
            passwordCheckBox.Checked = StudentObject.EnablePassword;
            passwordTextBox.UseSystemPasswordChar = true;
            try
            {
                PrepareLanguage();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.StackTrace, e.Message);
            }
        }

        private void PrepareLanguage()
        {
            if (Statics.EnglishLanguage)
                return;
            if (Statics.Language.ContainsKey("studentform_title"))
                this.Text = Statics.Translate("studentform_title");
            foreach (System.Windows.Forms.Control x in this.Controls)
                if (Statics.Language.ContainsKey( x.Text.Trim()))
                    x.Text = Statics.Translate(x.Text.Trim());


        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (studentNameTextBox.Text.Trim() == string.Empty)
            {
                System.Windows.Forms.MessageBox.Show(Statics.Translate("Please you have to fill all fields."));
                studentNameTextBox.Focus();
                return;
            }else
                if (majorNameTextBox.Text.Trim() == string.Empty)
                {
                    System.Windows.Forms.MessageBox.Show(Statics.Translate("Please you have to fill all fields."));
                    majorNameTextBox.Focus();
                    return;
                }else
                    if (passwordTextBox.Text == string.Empty && passwordCheckBox.Checked)
                    {
                        System.Windows.Forms.MessageBox.Show(Statics.Translate("Please you have to fill all fields."));
                        passwordTextBox.Focus();
                        return;
                    }
            if (StudentObject == null)
            {
                StudentObject = new Student(studentNameTextBox.Text, new Major(majorNameTextBox.Text, (int)majorHoursNumericUpDown.Value));
                StudentObject.EnablePassword = passwordCheckBox.Checked;
                StudentObject.Password = passwordTextBox.Text;
            }
            else
            {
                StudentObject.StudentName = studentNameTextBox.Text;
                StudentObject.StudentMajor.MajorName = majorNameTextBox.Text;
                StudentObject.StudentMajor.TotalHours = (int)majorHoursNumericUpDown.Value;
                StudentObject.EnablePassword = passwordCheckBox.Checked;
                StudentObject.Password = passwordTextBox.Text;
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            studentNameTextBox.Text = "";
            majorNameTextBox.Text = "";
            majorHoursNumericUpDown.Value = majorHoursNumericUpDown.Minimum;
            passwordTextBox.Text = "";
            passwordCheckBox.Checked = false;
        }

        /// <summary>
        /// The current student object
        /// </summary>
        public Student StudentObject {get; private set;}

        private void showCharCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            passwordTextBox.UseSystemPasswordChar = !passwordTextBox.UseSystemPasswordChar;
        }
    }
}
