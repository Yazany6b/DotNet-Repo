

namespace Student_Assistant_Application
{
    public static class Statics
    {
        #region Messages


        private static System.Collections.Generic.Dictionary<int, string> _messages = new System.Collections.Generic.Dictionary<int, string>();
        /// <summary>
        /// Add message to the messages list
        /// </summary>
        /// <param name="key">a unique integer that identify the message</param>
        /// <param name="value">the string value that the key refers to</param>
        /// <param name="replace">identify whether to replace the value of the key if exist </param>
        public static void FromulateMassege(int key, string value,bool replace = false)
        {
            if (!replace)
                _messages.Add(key, value);
            else
            {
                if (_messages.ContainsKey(key))
                    _messages[key] = value;
                else
                    _messages.Add(key, value);
            }
        }



        /// <summary>
        /// Gets or sets whether to enable messages or not
        /// </summary>
        public static bool EnableMessages
        {
            get;
            set;
        }
        /// <summary>
        /// Get all the global messages from verious program classes 
        /// </summary>
        public static System.Collections.Generic.Dictionary<int, string> Messages
        {
            get { return _messages;}
        }

        #endregion


        #region Language

        /// <summary>
        /// Gets The current language of the program
        /// </summary>
        public static string CurrentLanguage { get; private set; }

        /// <summary>
        /// Identify whether the current language is english
        /// </summary>
        public static bool EnglishLanguage = true;
        /// <summary>
        /// 
        /// </summary>
        public static System.Collections.Generic.Dictionary<string, string> Language = LanguageDeserializer();
        /// <summary>
        /// Write to the registry the defualt language value
        /// </summary>
        /// <param name="lang">The defualt langauge</param>
        public static void SetDefualtLanguage(string lang)
        {
            Microsoft.Win32.RegistryKey subkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("The Student Assistant Application");
            subkey.CreateSubKey("language");
            subkey.SetValue("language", lang);
            subkey.Close();
        }

        /// <summary>
        /// Read the current language file
        /// </summary>
        /// <returns>System.Collections.Generic.Dictionary Of english string and it's translation</returns>
        public static System.Collections.Generic.Dictionary<string, string> LanguageDeserializer()
        {

            System.Collections.Generic.Dictionary<string, string> lang = new System.Collections.Generic.Dictionary<string, string>();
            Microsoft.Win32.RegistryKey subkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("The Student Assistant Application");
            CurrentLanguage = (string)subkey.GetValue("language","none");
            subkey.Close();
            if (CurrentLanguage == "none")
            {
                SetDefualtLanguage("English");
                return lang;
            }
            if(CurrentLanguage.Equals("English",System.StringComparison.OrdinalIgnoreCase))
            {
                EnglishLanguage = true;
                return lang;
            }
            if (!System.IO.File.Exists("Languages\\" + CurrentLanguage + ".lang"))
            {
                //System.Windows.Forms.MessageBox.Show("The Current Language File Not Exits", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                EnglishLanguage = true;
            }
            else
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf;
                System.IO.Stream stream = null;
                try
                {
                    if (System.IO.File.Exists("Languages\\" + CurrentLanguage + ".lang"))
                    {
                        stream = System.IO.File.Open("Languages\\" + CurrentLanguage + ".lang", System.IO.FileMode.Open);
                        bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                        lang = (System.Collections.Generic.Dictionary<string, string>)bf.Deserialize(stream);
                        EnglishLanguage = false;
                    }
                    else
                    {
                        SerializeArabicLanguage();
                        stream = System.IO.File.Open("Languages\\" + CurrentLanguage + ".lang", System.IO.FileMode.Open);
                        bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                        lang = (System.Collections.Generic.Dictionary<string, string>)bf.Deserialize(stream);
                        EnglishLanguage = false;
                    }
                }
                catch
                { EnglishLanguage = true; CurrentLanguage = "English";}
                finally { if (stream != null) stream.Close(); }
            }
            return lang;
        }

        /// <summary>
        /// Serialize the arabic language file
        /// </summary>
        public static void SerializeArabicLanguage()
        {
            System.IO.Directory.CreateDirectory("Languages");
            System.Collections.Generic.Dictionary<string, string> lang = new System.Collections.Generic.Dictionary<string, string>();
        // Main Menu Labels 

            lang.Add("File", "الملف");
            lang.Add("Edit", "تحرير");
            lang.Add("Language", "اللغه");
            //file menu
            lang.Add("Load File", "تحميل الملف"); lang.Add("Save", "حفظ"); lang.Add("Backup","عمل ملف دعم");
            lang.Add("Reload", "اعادة التحميل"); lang.Add("Reload Backup", "تحميل ملف دعم"); lang.Add("Restart", "أعادة الشغيل"); 
            lang.Add("Exit", "خروج");

            //edit menu
            lang.Add("Edit Courses", "تحديد المواد"); lang.Add("Show Report", "أضهار التقرير");
            lang.Add("Open Estimator", "فتح المخمن"); lang.Add("About", "حول البرنامج");

            //language menu
            lang.Add("Arabic", "عربي"); lang.Add("English", "أنجليزي");

        //lables
            //main form
            lang.Add("Student Name", "اسم الطالب");  lang.Add("Major Hours", "ساعات التخصص");
            lang.Add("Finished Hours", "الساعات المنهيه"); lang.Add("Major Name", "اسم التخصص");
            //estimator form
            lang.Add("Hours", "الساعات"); lang.Add("Average", "المعدل"); 
            lang.Add("Your Average Must Be", "أن معدلك يجب ان يكون");
            //report form
            lang.Add("Student Result", "نتيحة الطالب");
            lang.Add("Unkown", "غير معروف");
            lang.Add("Student Major", "تخصص الطالب");
            lang.Add("Total Major Hours", "عدد الساعات الكلي"); lang.Add("Marks Between 50 - 60", "العلامات بين 50 - 60");
            lang.Add("Marks Between 60 - 70", "العلامات بين 60 - 70"); lang.Add("Marks Between 70 - 80", "العلامات بين 80 - 70");
            lang.Add("Marks Between 80 - 90", "العلامات بين 90 - 80"); lang.Add("Marks Between 90 - 100", "العلامات بين 100 - 90");
            lang.Add("Failed Courses", "المواد الراسبه");
            //About Form
            lang.Add("aboutform About","برنامج مساعدة الطالب\r\n  \r\n\r\n  منتج اخر من مختبر يزن\r\n " +
                "yazanse@yahoo تواصلوا معنا على");

        //Buttons
            //main form
            lang.Add("Create New", "أنشاء جديد"); lang.Add("Edit Current", "تحرير الحالي");
            //student form
            lang.Add("OK", "حسنا"); lang.Add("Cancel", "ألغاء");
            lang.Add("Clear", "مسح");
            //course form
            lang.Add("ADD", "أضافه"); lang.Add("Remove", "حذف");
            //estimator form
            lang.Add("Estimate", "خمن"); lang.Add("Done", "تم");
            lang.Add("Estimate Current Marks", "خمن العلامات الحاليه");
            lang.Add("More Advanced", "أكثر تقدم");
            //report form
            lang.Add("Show Details", "أضهار التفاصيل"); lang.Add("Hide Details", "أخفاء التفاصيل");
        //Check Boxs
            //main form
            lang.Add("Enable Password", "وضع كلمة مرور");
            //student form
            lang.Add("Show Characters", "أضهار الاحرف");
            //course form
            lang.Add("Computed", "محسوبه في المعدل");

        //Other Messages
            lang.Add("Restart The Program To Change The Language", "أعد تشغيل البرنامج لتغيير اللغه");
            //report form
            lang.Add("Very Good", "جيد جدا"); lang.Add("Good", "جيد");
            lang.Add("Accepted", "مقبول"); lang.Add("Excellent", "ممتاز");
            lang.Add("Failed", "راسب"); lang.Add("Advanced Estimator", "المخمن المتقدم");
            //course form 
            lang.Add("Input the course name", "قم بأدخال اسم الماده");
            //main form 
            lang.Add("Do You Want To Save Before Exit", "هل تريد الحفظ قبل الخروج"); lang.Add("Save File", "حفظ الملف");
            lang.Add("Cannot Find The File", ""); lang.Add("Error", "خطاء");
            //student form
            lang.Add("Please you have to fill all fields.", "رجا قم بملئ جميع الحقول");

            lang.Add("Your current average is {0}\nYour new average will be {1}", " {0} أن معدلك الحالي هو\n{1} معدلك الجديد سوف يكون");

            lang.Add("Please Enter The Right Password", "رجا ادخل كلمة المرور الصحيحه");
            lang.Add("Wrong Password", "كلمة سر خطاء");
            
            lang.Add("Sorry", "أسف");
            lang.Add("It's Not Possible Get The Average {0} With This Total Of Hours {1}", "انه ليس من الممكن ان يكو معدلك هو {0} بعدد ساعات {1} فقط");

         //titles 
            lang.Add("estimatorform_title", "المخمن");
            lang.Add("mainform_title", "برنامج مساعد الطالب");
            lang.Add("coursesform_title", "تحرير المواد");
            lang.Add("getpasswordform_title", "ادخل كلمة المرور");
            lang.Add("aboutform_title", "نبذة عن البرنامج");
            lang.Add("studentform_title", "تحرير الطالب");
            lang.Add("reportform_title", "التقرير");

            System.IO.Stream stream = null;
            try
            {
                stream = System.IO.File.Open("Languages\\Arabic.lang", System.IO.FileMode.OpenOrCreate);
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bf.Serialize(stream, lang);
                stream.Close();
            }
            catch
            { }
            finally
            {
                if(stream != null)
                    stream.Close();
            }

        }

        /// <summary>
        /// Translate an english string to the current corresponding value in the current program language 
        /// </summary>
        /// <param name="str">the english string</param>
        /// <returns>System.String containes the translated string</returns>
        public static string Translate(string str)
        {
            if (!EnglishLanguage)//if the current language is string dont convert
            {
                if (Language.ContainsKey(str.Trim()))
                    return Language[str.Trim()];
            }
            return str;
        }

        #endregion
        /// <summary>
        /// convert a list of objects to a string object 
        /// </summary>
        /// <typeparam name="type">the type you want to convert from</typeparam>
        /// <param name="list">the list of values that you want to convert</param>
        /// <remarks>all list values will be separated by \n character in the string object </remarks>
        /// <returns>System.String a string object that containes the list</returns>
        public static string StringList<type>(System.Collections.Generic.List<type> list)
        {
            if (list.Count == 0)
                return "";
            string tem = "";
            for (int i = 0; i < list.Count; i++)
            {
                tem += list[i].ToString() + "\r\n";
            }
            return tem;
        }

        /// <summary>
        /// Format a double indentifier
        /// </summary>
        /// <param name="number">the double identifier</param>
        /// <param name="presition">number of digits after the dot</param>
        /// <returns>System.Double containes the formated value</returns>
        public static double FormatDouble(double number, int presition)
        {
            string num = number.ToString();//convert to string
            if (num.Substring(num.IndexOf('.') + 1).Length > presition)//if number of digits after the dot more the presition
            {
                double dnum;
                double.TryParse(num.Substring(0, num.IndexOf('.') + presition + 1), out dnum);//only take the wanted value
                return dnum;
            }
            else//if number of digits after the dot less the presition return the number
                return number;
        }

        /// <summary>
        /// Print A courses list to the file Data.dat
        /// </summary>
        /// <remarks>this function only used by the program developer</remarks>
        /// <param name="cor">Courses List</param>
        public static void PrintToFile(System.Collections.Generic.List<Course> cor)
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter("My_Data");
            for (int i = 0; i < cor.Count; i++)
                sw.WriteLine(cor[i].Name + " " + cor[i].Mark + " " + cor[i].Hours+"\n");
            sw.Close();
        }
        /// <summary>
        /// Print A courses list to the file Data.dat
        /// </summary>
        /// <remarks>this function only used by the program developer</remarks>
        /// <returns>System.Collections.Generic.List of all courses in the file</returns>
        public static System.Collections.Generic.List<Course> ReadFromFile()
        {
            System.IO.StreamReader sr = new System.IO.StreamReader("My_Data");
            System.Collections.Generic.List<Course> cor = new System.Collections.Generic.List<Course>();
            for (int i = 0; i < cor.Count; i++)
            {
                string [] line = sr.ReadLine().Split(new char[]{' '});
                int mark;
                int hour;
                int.TryParse(line[1],out mark);
                int.TryParse(line[2],out hour);
                cor.Add(new Course(line[0], mark, hour));
            }
            sr.Close();
            return cor;
        }
    }
}
