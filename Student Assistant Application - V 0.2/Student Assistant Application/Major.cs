namespace Student_Assistant_Application
{
    /// <summary>
    /// The Major class
    /// </summary>
    [System.Serializable]
    public class Major
    {
        /// <summary>
        /// Create an instance of type Major using name and the hours
        /// </summary>
        /// <param name="name">the major name</param>
        /// <param name="hours">the total major hours</param>
        public Major(string name, int hours)
        {
            MajorName = name;
            TotalHours = hours;
        }

        /// <summary>
        /// Gets or sets the major name
        /// </summary>
        public string MajorName { get; set; }
        /// <summary>
        /// gets or sets the total major hours
        /// </summary>
        public int TotalHours { get; set; }
    }
}
