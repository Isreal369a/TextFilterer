
namespace TextFilterer
{
    public class VowelFilterer : WordFilter
    {
        const string VOWELS = "aeiou";

        public override string Filter(string word)
        {

            int length = word.Length;
            if (length == 0)
            {
                return base.Filter(word);
            }
            else
            if (length % 2 == 1)
            {
                int mid = length / 2;
                if (VOWELS.Contains(Char.ToLower(word[mid])))
                {

                    return String.Empty;
                }
            }
            else if (length % 2 == 0)
            {
                int firstMid = length / 2 - 1;
                int secondMid = length / 2;
                if (VOWELS.Contains(Char.ToLower(word[firstMid])) || VOWELS.Contains(Char.ToLower(word[secondMid])))
                {
                    return String.Empty;
                }
            }
            return base.Filter(word);

        }
    }
}
