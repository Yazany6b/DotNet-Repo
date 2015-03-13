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
    /// The main interface of the application
    /// </summary>
    public partial class MainForm : Form
    {
        private Computer currentComputer = null;//the current computer that the program read information from
        private string currentPath = "";//save path
        /// <summary>
        /// Create a copy of the program
        /// </summary>
        public MainForm()
        {
            InitializeComponent();//prepare the interface
            try
            {
                //Statics.SerializeArabicLanguage();
                //Statics.SetDefualtLanguage("Arabic");
                PrepareLanguage();//prepare the interface langauge
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.StackTrace,e.Message);
            }
            //get the documants path
            string myDocPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //create the folder "Student Assistent Save" if not exist
            if (!System.IO.Directory.Exists(myDocPath + System.IO.Path.DirectorySeparatorChar + "Student Assistent Save"))
            {
                System.IO.Directory.CreateDirectory(myDocPath + System.IO.Path.DirectorySeparatorChar + "Student Assistent Save");
                System.IO.Directory.CreateDirectory(myDocPath + System.IO.Path.DirectorySeparatorChar + "Student Assistent Save\\Backup");
                //save the new path
                currentPath = myDocPath + System.IO.Path.DirectorySeparatorChar + "Student Assistent Save";
            }
            else
            {
                //save the new path
                currentPath = myDocPath + System.IO.Path.DirectorySeparatorChar + "Student Assistent Save";
            }
        }

        /// <summary>
        /// Create a copy of the program using a marks file
        /// </summary>
        /// <param name="filename">the path of the marks file</param>
        public MainForm(string filename)
        {
            InitializeComponent();
            try
            {
                //Statics.SerializeArabicLanguage();
                //Statics.SetDefualtLanguage("Arabic");
                
                PrepareLanguage();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.StackTrace, e.Message);
            }
            //get the documants path
            string myDocPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //create the folder "Student Assistent Save" if not exist
            if (!System.IO.Directory.Exists(myDocPath + System.IO.Path.DirectorySeparatorChar + "Student Assistent Save"))
            {
                System.IO.Directory.CreateDirectory(myDocPath + System.IO.Path.DirectorySeparatorChar + "Student Assistent Save");
                System.IO.Directory.CreateDirectory(myDocPath + System.IO.Path.DirectorySeparatorChar + "Student Assistent Save\\Backup");
                //save the new path
                currentPath = myDocPath + System.IO.Path.DirectorySeparatorChar + "Student Assistent Save";
            }
            else
            {
                //save the new path
                currentPath = myDocPath + System.IO.Path.DirectorySeparatorChar + "Student Assistent Save";
            }
            Computer.Deserialize(filename, ref currentComputer);//read the file into the current computer
        }


        private void PrepareLanguage()
        {
            if (Statics.EnglishLanguage)
                return;
            if(Statics.Language.ContainsKey("mainform_title"))
                this.Text = Statics.Translate("mainform_title");

            fileToolStripMenuItem.Text = Statics.Translate(fileToolStripMenuItem.Text);
            editToolStripMenuItem.Text = Statics.Translate(editToolStripMenuItem.Text);
            languageToolStripMenuItem.Text = Statics.Translate(languageToolStripMenuItem.Text);

            foreach (System.Windows.Forms.ToolStripMenuItem x in fileToolStripMenuItem.DropDownItems)
                    x.Text = Statics.Translate(x.Text.Trim());

            foreach (System.Windows.Forms.ToolStripMenuItem x in editToolStripMenuItem.DropDownItems)
                    x.Text = Statics.Translate(x.Text.Trim());

            englishToolStripMenuItem.Checked = false;

            foreach (System.Windows.Forms.ToolStripMenuItem x in languageToolStripMenuItem.DropDownItems)
            {
                if (x.Text == Statics.CurrentLanguage)
                    x.Checked = true;
                x.Text = Statics.Translate(x.Text.Trim());
            }

            foreach (Control x in this.Controls)
                    x.Text = Statics.Translate(x.Text.Trim());
            
        }

        protected override void OnClosing(CancelEventArgs e)//called when close the application
        {
            if (currentComputer == null)//close if the computer is null
                return;
            if (!currentComputer.Saved)//if computer information is modified and not saved to the file
            {
                //ask if the user what to close with out saving
                DialogResult res = System.Windows.Forms.MessageBox.Show(Statics.Translate("Do You Want To Save Before Exit"),Statics.Translate("Save File"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    MenuToolStripClicked(saveToolStripMenuItem, null);
                }
                else
                    e.Cancel = (res == System.Windows.Forms.DialogResult.Cancel);//indentify if the user whant to cancel the operation
            }
        }

        private void MenuToolStripClicked(object sender, EventArgs e)
        {
            //allow the menu strips that has the margeIndex 0 ,5, 9 or 10 to perform thier action even if computer is null
            if (currentComputer == null && (((ToolStripItem)sender).MergeIndex != 0 && ((ToolStripItem)sender).MergeIndex != 9) && ((ToolStripItem)sender).MergeIndex != 10 && ((ToolStripItem)sender).MergeIndex != 5)
                return;
            switch (((ToolStripItem)sender).MergeIndex)
            {
                case 0:
                    openFileDialog.Filter = "Student File (*.saf)|*.saf";//open only saf files
                    openFileDialog.Multiselect = false;//open one file only
                    openFileDialog.InitialDirectory = currentPath ;//the look bath
                    if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)//file choosed
                    {
                        bool done = Computer.Deserialize(openFileDialog.FileName,ref currentComputer);//read the file
                        if (!done)//the operation does not done well
                        {
                            currentComputer = null;
                            studentNameTextBox.Text = "";
                            majorNameTextBox.Text = "";
                            majorHoursTextBox.Text = "";
                            finishedHoursTextBox.Text = "0";
                            return;
                        }
                        if (currentComputer.ComputerStudent.EnablePassword && done)//the current file is protected by password
                        {
                            GetPasswordForm pform = new GetPasswordForm(currentComputer.ComputerStudent.Password);//get password
                            if (pform.ShowDialog() != System.Windows.Forms.DialogResult.OK)//the password is not correct
                            {
                                //dont change any thing
                                currentComputer = null;
                                studentNameTextBox.Text = "";
                                majorNameTextBox.Text = "";
                                majorHoursTextBox.Text = "";
                                finishedHoursTextBox.Text = "0";
                                editCurrentButton.Enabled = false;
                                return;
                            }
                        }
                        if (done)//the process done well
                        {
                            //read the file and fill the information

                            studentNameTextBox.Text = currentComputer.ComputerStudent.StudentName;
                            majorNameTextBox.Text = currentComputer.ComputerStudent.StudentMajor.MajorName;
                            majorHoursTextBox.Text = currentComputer.ComputerStudent.StudentMajor.TotalHours.ToString();
                            finishedHoursTextBox.Text = currentComputer.TotalHours(false).ToString();
                            editCurrentButton.Enabled = true;
                        }
                    }
                    break;
                case 1:
                    //save the current information
                    Computer.Serialize(currentPath + System.IO.Path.DirectorySeparatorChar + currentComputer.ComputerStudent.StudentName + "_" + currentComputer.ComputerStudent.StudentMajor.MajorName + " Marks.saf", ref currentComputer);
                    break;
                case 2:
                    //save a backup to the current state
                    Computer.Serialize(currentPath + System.IO.Path.DirectorySeparatorChar + "Backup" + System.IO.Path.DirectorySeparatorChar + currentComputer.ComputerStudent.StudentName + "_" + currentComputer.ComputerStudent.StudentMajor.MajorName + " Marks.saf", ref currentComputer);
                    break;
                case 3:
                    //reload the file if exist
                    if (System.IO.File.Exists(currentPath + System.IO.Path.DirectorySeparatorChar + currentComputer.ComputerStudent.StudentName + "_" + currentComputer.ComputerStudent.StudentMajor.MajorName + " Marks.saf"))
                    {
                        Computer.Deserialize(currentPath + System.IO.Path.DirectorySeparatorChar + currentComputer.ComputerStudent.StudentName + "_" + currentComputer.ComputerStudent.StudentMajor.MajorName + " Marks.saf", ref currentComputer);
                    }
                    else
                    {
                        //the file not exist
                        System.Windows.Forms.MessageBox.Show(Statics.Translate("Cannot Find The File"), Statics.Translate(""), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case 4:
                    //reload backup
                    if (System.IO.File.Exists(currentPath + System.IO.Path.DirectorySeparatorChar + "Backup" + System.IO.Path.DirectorySeparatorChar + currentComputer.ComputerStudent.StudentName + "_" + currentComputer.ComputerStudent.StudentMajor.MajorName + " Marks.saf"))
                    {
                        Computer.Deserialize(currentPath + System.IO.Path.DirectorySeparatorChar + "Backup" + System.IO.Path.DirectorySeparatorChar + currentComputer.ComputerStudent.StudentName + "_" + currentComputer.ComputerStudent.StudentMajor.MajorName + " Marks.saf", ref currentComputer);
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show(Statics.Translate("Cannot Find The File"), Statics.Translate("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case 5:
                    //exit the thread
                    Application.ExitThread();
                    break;
                case 6:
                    //open the forms editor
                    CoursesForm cform = new CoursesForm(ref currentComputer);
                    cform.ShowDialog();
                    break;
                case 7:
                    //open the report form 
                    ReportForm rform = new ReportForm(ref currentComputer);
                    rform.ShowDialog();
                    break;
                case 8:
                    //open the estimator
                    EstimatorForm eform = new EstimatorForm(ref currentComputer);
                    eform.ShowDialog();
                    break;
                case 9:
                    //open the about form
                    AboutForm aform = new AboutForm();
                    aform.ShowDialog();
                    break;
                case 10:
                    //restart the application
                    if (currentComputer != null)
                    {
                        if (!currentComputer.Saved)
                        {
                            System.ComponentModel.CancelEventArgs args = new CancelEventArgs();
                            OnClosing(args);//ask the user if he want to restart the app. without saving
                            if (args.Cancel)//the user want to cancel the operation
                                return;
                        }
                    }
                    System.Windows.Forms.Application.Restart();//restart the current app.
                    break;
            }
        }

        private void addAsNewButton_Click(object sender, EventArgs e)
        {
            //if (currentComputer == null)
            //    return;

            //create from the current information a new student
            if (currentComputer != null) 
            {
                if (!currentComputer.Saved)//if the current information not saved
                {
                    System.ComponentModel.CancelEventArgs args = new CancelEventArgs();
                    OnClosing(args);
                    if (args.Cancel)//cancel the operation
                        return;
                }
            }
            StudentForm sform = new StudentForm();//create new info.
            sform.ShowDialog();
            if (sform.StudentObject == null)
                return;
            currentComputer = new Computer(sform.StudentObject);//set the created student as the default of the application
            currentComputer.Saved = false;
            studentNameTextBox.Text = currentComputer.ComputerStudent.StudentName;
            majorNameTextBox.Text = currentComputer.ComputerStudent.StudentMajor.MajorName;
            majorHoursTextBox.Text = currentComputer.ComputerStudent.StudentMajor.TotalHours.ToString();
            finishedHoursTextBox.Text = currentComputer.TotalHours(false).ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = ((CheckBox)sender).Checked;//the password text box enabled if the check box is enabled 
        }

        private void editCurrentButton_Click(object sender, EventArgs e)
        {
            StudentForm sform = new StudentForm(ref currentComputer);//start the form with the current information for edit only
            sform.ShowDialog();
            currentComputer.Saved = false;
            studentNameTextBox.Text = currentComputer.ComputerStudent.StudentName;
            majorNameTextBox.Text = currentComputer.ComputerStudent.StudentMajor.MajorName;
            majorHoursTextBox.Text = currentComputer.ComputerStudent.StudentMajor.TotalHours.ToString();
            finishedHoursTextBox.Text = currentComputer.TotalHours(false).ToString();
        }

        private void LanguageMenuItemClicked(object sender, EventArgs e)
        {
            if (((System.Windows.Forms.ToolStripMenuItem)sender).Checked)
                return;
            arabicToolStripMenuItem.Checked = false;
            englishToolStripMenuItem.Checked = false;
            ((System.Windows.Forms.ToolStripMenuItem)sender).Checked = true;
            Statics.SetDefualtLanguage(((System.Windows.Forms.ToolStripMenuItem)sender).Text);//set the defualt language of the program
            System.Windows.Forms.MessageBox.Show(Statics.Translate("Restart The Program To Change The Language"));//ask for restarting to perform
        }
    }
}
