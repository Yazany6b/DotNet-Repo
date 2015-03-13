namespace Student_Assistant_Application
{
    /// <summary>
    /// The class Student containes the information of any student
    /// </summary>
    [System.Serializable]//this class marked as aserializabe object
    public class Student
    {
        /// <summary>
        /// create an instance of type Student using the name and major
        /// </summary>
        /// <param name="name">Student name</param>
        /// <param name="major">Student Major</param>
        public Student(string name,Major major)
        {
            StudentName = name;
            StudentMajor = major;
            Courses = new System.Collections.Generic.List<Course>();
            EstimatedCourses = new System.Collections.Generic.List<Course>();
        }

        /// <summary>
        /// Gets or sets Student Name
        /// </summary>
        public string StudentName { get; set; }
        /// <summary>
        /// Gets or sets The Total of hours that the user finished
        /// </summary>
        public int FinishedHours  { get; set; }
        /// <summary>
        /// Gets or sets the courses has been taken by the user
        /// </summary>
        public System.Collections.Generic.List<Course> Courses { get; set; }
        /// <summary>
        /// Gets or sets Student major
        /// </summary>
        public Major StudentMajor { get; set; }
        /// <summary>
        /// Gets or sets the student computer object
        /// </summary>
        public Computer StudentComputer { get; set; }
        /// <summary>
        /// Gets or sets the student estimation courses
        /// </summary>
        /// <remarks>This property only to save the last courses that the user use to estimate his/her average</remarks>
        public System.Collections.Generic.List<Course> EstimatedCourses { get; set; }
        /// <summary>
        /// Gets or sets the student file password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Gets or sets whether the student file protected by password 
        /// </summary>
        public bool EnablePassword { get; set; }
     }
}
