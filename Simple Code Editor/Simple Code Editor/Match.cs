namespace Simple_Code_Editor
{
    public class Match
    {
        private int _index;
        private int _length;
        private string _word;
        private int _type;
        public Match(int index, int length, string word)
        {
            _index = index;
            _length = length;
            _word = word;
            _type = -1;
        }
        public Match(int index, int length, string word, int type)
        {
            _index = index;
            _length = length;
            _word = word;
            _type = type;
        }
        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        public int Length
        {
            get { return _length; }
            set { _length = value; }
        }

        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Word
        {
            get { return _word; }
            set { _word = value; }
        }
    }
}