namespace Student_Assistant_Application
{
    /// <summary>
    /// The computer class
    /// </summary>
    [System.Serializable]
    public class Computer
    {

        /// <summary>
        /// Create an instance of type Computer 
        /// </summary>
        /// <param name="student"></param>
        public Computer(Student student)
        {
            ComputerStudent = student;
            Saved = true;
        }

        /// <summary>
        /// Gets or sets the student reference object
        /// </summary>
        public Student ComputerStudent { get; set; }

        /// <summary>
        /// Gets or sets the student object has been saved with the new changes
        /// </summary>
        public bool Saved { get; set; }

        /// <summary>
        /// Add a new course to the student
        /// </summary>
        /// <param name="c">a course to be added</param>
        /// <returns>System.Boolean identify whether the operation complete successfully</returns>
        public bool Add(Course c)
        {
            if(c == null)
                return false;
            Saved = false;
            for (int i = 0; i < ComputerStudent.Courses.Count; i++)
                if (ComputerStudent.Courses[i].Name.Trim() == c.Name.Trim() && ComputerStudent.Courses[i].Mark == c.Mark && ComputerStudent.Courses[i].Hours == c.Hours)
                {
                    System.Windows.Forms.MessageBox.Show("Coures Already Exist");
                    return false;
                }
            ComputerStudent.Courses.Add(c);
            return true;
        }

        /// <summary>
        /// Add a new course to the student estimated courses list
        /// </summary>
        /// <param name="c">a course to be added</param>
        /// <returns>System.Boolean identify whether the operation complete successfully</returns>
        public bool AddAsEstimated(Course c)
        {
            if (ComputerStudent.EstimatedCourses == null)
                ComputerStudent.EstimatedCourses = new System.Collections.Generic.List<Course>();
            if (c == null)
                return false;
            Saved = false;
            for (int i = 0; i < ComputerStudent.EstimatedCourses.Count; i++)
                if (ComputerStudent.EstimatedCourses[i].Name.Trim() == c.Name.Trim() && ComputerStudent.EstimatedCourses[i].Hours == c.Hours)
                {
                    System.Windows.Forms.MessageBox.Show("Coures Already Exist");
                    return false;
                }
            ComputerStudent.EstimatedCourses.Add(c);
            return true;
        }

        /// <summary>
        /// Modify a course information
        /// </summary>
        /// <param name="index">the course index</param>
        /// <param name="c">new course information</param>
        /// <returns>System.Boolean identify whether the operation complete successfully</returns>
        public bool Modify(int index, Course c)
        {
            if (c == null)
                return false;
            Saved = false;
            if (index < 0 || index >= ComputerStudent.Courses.Count)
                return false;
            for (int i = 0; i < ComputerStudent.Courses.Count; i++)
                if (ComputerStudent.Courses[i].Name.Trim() == c.Name.Trim() && ComputerStudent.Courses[i].Mark == c.Mark && ComputerStudent.Courses[i].Hours == c.Hours)
                {
                    System.Windows.Forms.MessageBox.Show("Coures Already Exist");
                    return false;
                }
            ComputerStudent.Courses[index] = c;
            return true;
        }

        /// <summary>
        /// Modify an estimated course information
        /// </summary>
        /// <param name="index">the course index</param>
        /// <param name="c">new course information</param>
        /// <returns>System.Boolean identify whether the operation complete successfully</returns>
        public bool ModifyEstimated(int index, Course c)
        {
            if (c == null)
                return false;
            Saved = false;
            if (index < 0 || index >= ComputerStudent.EstimatedCourses.Count)
                return false;
            for (int i = 0; i < ComputerStudent.EstimatedCourses.Count; i++)
                if (ComputerStudent.EstimatedCourses[i].Name.Trim() == c.Name.Trim() && ComputerStudent.EstimatedCourses[i].Mark == c.Mark && ComputerStudent.EstimatedCourses[i].Hours == c.Hours)
                {
                    System.Windows.Forms.MessageBox.Show("Coures Already Exist");
                    return false;
                }
            ComputerStudent.EstimatedCourses[index] = c;
            return true;
        }

        /// <summary>
        /// Get course at index
        /// </summary>
        /// <param name="index">the index of the course</param>
        /// <returns>A course at the requasted index or null for out of pound indexs </returns>
        public Course GetAt(int index)
        {
            if (index < 0 || index >= ComputerStudent.Courses.Count)
                return null;
            return ComputerStudent.Courses[index];
        }

        /// <summary>
        /// Get estimated course at index
        /// </summary>
        /// <param name="index">the index of the course</param>
        /// <returns>A course at the requasted index or null for out of pound indexs </returns>
        public Course GetEstimatedAt(int index)
        {
            if (index < 0 || index >= ComputerStudent.EstimatedCourses.Count)
                return null;
            return ComputerStudent.EstimatedCourses[index];
        }

        /// <summary>
        /// get all courses between to marks
        /// </summary>
        /// <param name="mark1">the minimum value</param>
        /// <param name="mark2">the maximum value</param>
        /// <param name="computed">indentify whether to get only the coumputed in average courses</param>
        /// <returns>System.Collections.Generic.List of courses in the given range</returns>
        public System.Collections.Generic.List<Course> CoursesBetween(int mark1, int mark2,bool computed)
        {
            System.Collections.Generic.List<Course> temp = new System.Collections.Generic.List<Course>();
            for (int i = 0; i < ComputerStudent.Courses.Count; i++)
                if(ComputerStudent.Courses[i].Computed == computed)
                    if (ComputerStudent.Courses[i].Mark >= mark1 && ComputerStudent.Courses[i].Mark <= mark2 && (ComputerStudent.Courses[i].Computed))
                        temp.Add(ComputerStudent.Courses[i]);
            return temp;
        }

        /// <summary>
        /// get total number of finished hours
        /// </summary>
        /// <param name="onlyComputed">indentify whether to count only the coumputed in average courses</param>
        /// <returns>System.Int32 of total hourse</returns>
        public int TotalHours(bool onlyComputed)
        {
            int hours = 0;
            if (onlyComputed)
            {
                for (int i = 0; i < ComputerStudent.Courses.Count; i++)
                    if (ComputerStudent.Courses[i].Computed)
                        hours += ComputerStudent.Courses[i].Hours;
            }
            else
                for (int i = 0; i < ComputerStudent.Courses.Count; i++)
                    hours += ComputerStudent.Courses[i].Hours;
            return hours;
        }

        /// <summary>
        /// get total number of marks thats only computed in average
        /// </summary>
        /// <returns>System.Int32 of total marks</returns>
        public int TotalMarks()
        {
            int marks = 0;
            for (int i = 0; i < ComputerStudent.Courses.Count; i++)
                if (ComputerStudent.Courses[i].Computed)
                    marks += ComputerStudent.Courses[i].Hours * ComputerStudent.Courses[i].Mark;
            return marks;
        }

        /// <summary>
        /// get total number of registered courses
        /// </summary>
        /// <returns>System.Int32</returns>
        public int TotalCourses()
        {
            return ComputerStudent.Courses.Count;
        }

        /// <summary>
        /// get The average of the current courses
        /// </summary>
        /// <returns>System.Double</returns>
        public double ComputeAverage()
        {
            int sum = 0;
            int hours = 0;
            for(int i = 0;i<ComputerStudent.Courses.Count;i++)
            {
                if (ComputerStudent.Courses[i].Computed)
                {
                    sum += ComputerStudent.Courses[i].Mark * ComputerStudent.Courses[i].Hours;
                    hours += ComputerStudent.Courses[i].Hours;
                }
            }
            
            return Statics.FormatDouble((double)sum / (double)hours , 2);
        }



        /// <summary>
        /// Remove a course at index
        /// </summary>
        /// <param name="index">the course index</param>
        public void RemoveAt(int index)
        {
            ComputerStudent.Courses.RemoveAt(index);
            Saved = false;
        }
        public void RemoveAtFromEstimated(int index)
        {
            ComputerStudent.EstimatedCourses.RemoveAt(index);
            Saved = false;
        }

        /// <summary>
        /// Serilaize an object of type computer
        /// </summary>
        /// <param name="filename">the file path</param>
        /// <param name="computer">the object to be saved</param>
        /// <returns>System.Boolean indicates that the operation done well</returns>
        public static bool Serialize(string filename,ref Computer computer)
        {
            System.IO.Stream stream = null;
            try
            {
                stream = System.IO.File.Open(filename, System.IO.FileMode.OpenOrCreate);
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bf.Serialize(stream, computer.ComputerStudent);
                stream.Close();
                return true;
            }
            catch (System.Exception ex)
            {
                if (stream != null)
                    stream.Close();
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Deserilaize an object of type computer
        /// </summary>
        /// <param name="filename">the file path</param>
        /// <param name="computer">the object to be opended</param>
        /// <returns>System.Boolean indicates that the operation done well</returns>
        public static bool Deserialize(string filename, ref Computer computer)
        {
            System.IO.Stream stream = null;
            try
            {
                stream = System.IO.File.Open(filename, System.IO.FileMode.Open);
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                computer = new Computer(((Student)bf.Deserialize(stream)));
                stream.Close();
                return true;
            }
            catch (System.Exception ex)
            {
                if (stream != null)
                    stream.Close();
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Fill a list view with the current courses 
        /// </summary>
        /// <param name="listview">System.Windows.Forms.ListView</param>
        public void FillList(ref System.Windows.Forms.ListView listview)
        {
            foreach (Course c in ComputerStudent.Courses)
            {
                System.Windows.Forms.ListViewItem item = new System.Windows.Forms.ListViewItem();
                item.Text = c.Name + "  ,  " + c.Hours + "  ,  " + c.Mark;
                listview.Items.Add(item);
            }
        }

        /// <summary>
        /// Get a string containes the object informations
        /// </summary>
        /// <returns>System.String containes the current object information</returns>
        public override string ToString()
        {
            int sum = 0;
            int hours = 0;
            for (int i = 0; i < ComputerStudent.Courses.Count; i++)
            {
                if (ComputerStudent.Courses[i].Computed)
                {
                    sum += ComputerStudent.Courses[i].Mark * ComputerStudent.Courses[i].Hours;
                    hours += ComputerStudent.Courses[i].Hours;
                }
            }
            if (hours == 0)
                return "";
            double avg = ((double)sum / (double)hours);

            return "(All ComputerStudent.Courses marks) " + sum.ToString() + " / (All hours) " + hours.ToString() + " = (Average) " + Statics.FormatDouble(avg, 4);
        }
    }
}
