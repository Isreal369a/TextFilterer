
namespace TextFilterer
{
    public class MinWordFilterer : WordFilter
    {
        public override string Filter(string word)
        {
            if (string.IsNullOrEmpty(word)) return word;
            if (word.Length < 3) return string.Empty;
                        
            return base.Filter(word);           

        }
    }
}
