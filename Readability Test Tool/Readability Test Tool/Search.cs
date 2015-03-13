using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Readability_Test_Tool
{
    public static class Search
    {
        private static System.IO.StreamReader reader;
        private static bool isSame(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;
            else
                for (int i = 0; i < s1.Length; i++)
                    if (char.ToUpper(s1[i]) != char.ToUpper(s2[i]))
                        return false;
            return true;
        }
        public static bool isWordMeaningfull(string word)
        {
            string getter;
            if(reader!=null)
                reader.Close();
            CreateBase();
            reader = new System.IO.StreamReader("MyBase.dat");
            
            while (!reader.EndOfStream)
            {
                getter = reader.ReadLine().Trim();
                if (isSame(getter.Trim(), word.Trim()))
                {
                    //System.Windows.Forms.MessageBox.Show("The Word :- " + word + " Found");
                    return true;
                }
            }
            return false;
        }

        private static void CreateBase()
        {
            if (!System.IO.File.Exists("MyBase.dat"))
            {
                System.IO.FileStream fs = new System.IO.FileStream("MyBase.dat", System.IO.FileMode.Create);
                fs.Write(global::Readability_Test_Tool.Properties.Resources.MyBase, 0, global::Readability_Test_Tool.Properties.Resources.MyBase.Length);
                fs.Close();
            }
        }

        public static int MeaningfulWord(System.Collections.Generic.List<string> words)
        {
            CreateBase();
            int count = 0;
            for (int i = 0; i < words.Count; i++)
            {
                if (isWordMeaningfull(words[i]))
                    count++;
            }
            return count;
        }
    }
}
