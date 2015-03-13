
namespace Simple_Code_Editor
{
    [System.Serializable]
    public class SCF
    {
        public System.Collections.Generic.List<CharacterInfo> Characters
        {
            get;
            set;
        }

        public SupportedLanguage Language
        {
            get;
            set;
        }
    }
}
