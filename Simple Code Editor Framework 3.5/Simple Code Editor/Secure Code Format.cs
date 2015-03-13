
namespace Simple_Code_Editor
{
    public static class SecureCodeFormat
    {
        public static int ratio = 2;
        private static int ListSorterByCharacter(CharacterInfo info1, CharacterInfo info2)
        {
            if (info1 == null && info2 == null)
                return 0;
            else
                if (info1 == null)
                    return -1;
                else
                    if (info2 == null)
                        return 1;
            if (info1.Character > info2.Character)
                return 1;
            else
                if (info2.Character > info1.Character)
                    return -1;
            return 0;
        }

        private static int ListSorterByIndex(CharacterInfo info1, CharacterInfo info2)
        {
            if (info1 == null && info2 == null)
                return 0;
            else
                if (info1 == null)
                    return -1;
                else
                    if (info2 == null)
                        return 1;
            if (info1.Index > info2.Index)
                return 1;
            else
                if (info2.Index > info1.Index)
                    return -1;
            return 0;
        }

        public static void Save(string path,string text,string password,SupportedLanguage language)
        {
            System.Collections.Generic.List<CharacterInfo> list = new System.Collections.Generic.List<CharacterInfo>();
            for (int i = 0; i < text.Length; i++)
            {
                list.Add(new CharacterInfo((char)(text[i] + ratio), i, 0));
            }
            for (int i = 0; i < password.Length; i++)
            {
                list.Add(new CharacterInfo((char)(password[i] + ratio), i, 1));
            }

            list.Sort(new System.Comparison<CharacterInfo>(ListSorterByCharacter));

            SCF scf = new SCF();
            scf.Characters = list;
            scf.Language = language;
            System.IO.Stream stream = System.IO.File.Open(path, System.IO.FileMode.OpenOrCreate);
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            bf.Serialize(stream, scf);
            stream.Close();
        }

        public static string GetText(string path)
        {
            System.IO.Stream stream = System.IO.File.Open(path, System.IO.FileMode.OpenOrCreate);
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            SCF scf;
            try
            {
                scf = (SCF)bf.Deserialize(stream);
            }
            catch 
            {
                System.Windows.Forms.MessageBox.Show("Unable To Read The File", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return string.Empty;
            }
            finally
            {
                stream.Close();
            }
            string temp = "";
            scf.Characters.Sort(new System.Comparison<CharacterInfo>(ListSorterByIndex));
            for (int i = 0; i < scf.Characters.Count; i++)
            {
                if (scf.Characters[i].Type == 0)
                {
                    temp += (char)(scf.Characters[i].Character - ratio);
                }
            }
            return temp;
        }
        public static string GetPassword(string path)
        {
            System.IO.Stream stream = System.IO.File.Open(path, System.IO.FileMode.OpenOrCreate);
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            SCF scf;
            try
            {
                scf = (SCF)bf.Deserialize(stream);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Unable To Read The File", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return string.Empty;
            }
            finally
            {
                stream.Close();
            }
            string temp = "";
            scf.Characters.Sort(new System.Comparison<CharacterInfo>(ListSorterByIndex));
            for (int i = 0; i < scf.Characters.Count; i++)
            {
                if (scf.Characters[i].Type == 1)
                {
                    temp += (char)(scf.Characters[i].Character - ratio);
                }
            }
            return temp;
        }

        public static SupportedLanguage GetLanguage(string path)
        {
            System.IO.Stream stream = System.IO.File.Open(path, System.IO.FileMode.OpenOrCreate);
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            SCF scf;
            try
            {
                scf = (SCF)bf.Deserialize(stream);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Unable To Read The File", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return SupportedLanguage.Ada;
            }
            finally
            {
                stream.Close();
            }
            return scf.Language;
        }

    }
}
