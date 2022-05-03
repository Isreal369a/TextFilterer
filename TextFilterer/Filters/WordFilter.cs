namespace TextFilterer
{
    public abstract class WordFilter : IWordFilter
    {
        private IWordFilter? _nextFilter;

        public virtual string Filter(string word)
        {
            if(_nextFilter != null)
                return _nextFilter.Filter(word);

            return word;
        }


        public IWordFilter SetNext(IWordFilter wordFilter)
        {
            _nextFilter = wordFilter;
            return _nextFilter;
        }
    }
}