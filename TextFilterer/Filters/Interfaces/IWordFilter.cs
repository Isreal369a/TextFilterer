namespace TextFilterer
{
    public interface IWordFilter
    {
        public IWordFilter SetNext(IWordFilter wordFilter);
        public string Filter(string word);
    }

}