namespace TextFilterer
{
    public interface ILineSplitter
    {
        public string[] Split(string line, char separator);
    }

    public class SpaceLineSplitter : ILineSplitter
    {
        public string[] Split(string line, char separator)
        {
            return line.Split(separator);
        }
    }
}