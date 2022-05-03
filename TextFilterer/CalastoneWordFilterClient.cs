namespace TextFilterer
{
    public class CalastoneWordFilterClient
    {
        readonly ILineSplitter _lineSplitter;
        const char SEPERATOR = ' ';

        public CalastoneWordFilterClient(ILineSplitter lineSplitter)
        {
            _lineSplitter = lineSplitter;
        }

        public string FilterLine(string line, IWordFilter filter)
        {   
            if (!string.IsNullOrEmpty(line) && filter!= null)
            {
                List<string> result = new List<string>();
                string[] words = _lineSplitter.Split(line, SEPERATOR); 

                foreach (var word in words)
                {
                    string filterWord = filter.Filter(word);
                    if (!string.IsNullOrEmpty(filterWord))
                        result.Add(filterWord);
                }
                return string.Join(SEPERATOR, result);
            }

           return line;
        }
    }

}