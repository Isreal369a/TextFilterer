namespace TextFilterer
{
    public class CharacterWordFilter : WordFilter
    {
        public char Character { get; set; } = 't';

        public override string Filter(string word)
        {
            if (string.IsNullOrEmpty(word)) return word;

            if (word.ToLower().Contains(Character))
            {
                return String.Empty;
            }
            
            return base.Filter(word);
        }
    }


}
