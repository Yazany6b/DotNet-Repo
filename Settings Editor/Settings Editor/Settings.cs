using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simple_Code_Editor
{
    [System.Serializable]
    public class Settings 
    {
        public Dictionary<SupportedLanguage, Language> Languages
        {
            get;
            set;
        }

        public int NumberOfAllowedKeywords
        {
            get { return 300; }
        }

        public System.Drawing.Size WindowSize
        {
            get;
            set;
        }

        public System.Drawing.Point WindowLocation
        {
            get;
            set;
        }

        public System.Drawing.Color FontColor
        {
            get;
            set;
        }

        public System.Drawing.Color BackColor
        {
            get;
            set;
        }

        public System.Drawing.Font Font
        {
            get;
            set;
        }

        public static void Serialize(Settings settings)
        {
            System.IO.Stream stream;
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments, Environment.SpecialFolderOption.None);
            if(!System.IO.Directory.Exists(path + "\\Simple Code Editor"))
            {
                System.IO.Directory.CreateDirectory(path + "\\Simple Code Editor");
            }
            if (System.IO.File.Exists(path + "\\Simple Code Editor"+"\\Settings.set"))
            {
                stream = System.IO.File.Open(path + "\\Simple Code Editor"+"\\Settings.set", System.IO.FileMode.Open);
            }
            else
            {
                stream = System.IO.File.Open(path + "\\Simple Code Editor" + "\\Settings.set", System.IO.FileMode.Create);
            }

            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            binaryFormatter.Serialize(stream, settings);
            stream.Close();
        }

        public static Settings Deserialize()
        {
            System.IO.Stream stream;
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments, Environment.SpecialFolderOption.None);
            if (System.IO.File.Exists(path + "\\Simple Code Editor" + "\\Settings.set"))
            {
                stream = System.IO.File.Open(path + "\\Simple Code Editor" + "\\Settings.set", System.IO.FileMode.Open);
            }
            else
            {
                return null;
            }

            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            Settings obj =  (Settings)binaryFormatter.Deserialize(stream);
            stream.Close();
            return obj;
        }
    }
}
