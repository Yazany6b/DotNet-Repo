namespace Student_Assistant_Application
{
    /// <summary>
    /// The Class Course
    /// </summary>
    [System.Serializable]
    public class Course
    {
        /// <summary>
        /// Create an instance of type Course using the name and the mark and the hours
        /// </summary>
        /// <param name="name">The course name</param>
        /// <param name="mark">The course mark</param>
        /// <param name="hours">The course hours</param>
        public Course(string name, int mark,int hours)
        {
            Name = name;
            Hours = hours;
            Mark = mark;
        }

        /// <summary>
        /// Create an instance of type Course using the name and the mark and the hours
        /// </summary>
        /// <param name="name">The course name</param>
        /// <param name="mark">The course mark</param>
        /// <param name="hours">The course hours</param>
        /// <param name="computed">identify whether the course is computed in the average</param>
        public Course(string name, int mark, int hours,bool computed)
        {
            Name = name;
            Hours = hours;
            Mark = mark;
            Computed = computed;
        }
        /// <summary>
        /// Gets or sets the course name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the course hours
        /// </summary>
        public int Hours { get; set; }
        /// <summary>
        /// Gets or sets the course mark
        /// </summary>
        public int Mark { get; set; }
        /// <summary>
        /// Gets or sets whether the course computed in the average or not
        /// </summary>
        public bool Computed { get; set; }
        /// <summary>
        /// Get a string contines the information of the object
        /// </summary>
        /// <returns>System.String</returns>
        public override string ToString()
        {
            return Name + "  ,  " + Hours.ToString() + "  ,  " + Mark.ToString();
        }
    }
}
