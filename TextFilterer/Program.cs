// See https://aka.ms/new-console-template for more information

using TextFilterer;

var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"TextFile.txt");
var vowelFilter = new VowelFilterer();
var minFilter = new MinWordFilterer();
var characterFilter = new CharacterWordFilter();
var lineSplitter = new SpaceLineSplitter();
vowelFilter.SetNext(minFilter).SetNext(characterFilter);
CalastoneWordFilterClient client = new CalastoneWordFilterClient(lineSplitter);

using (StreamReader sr = new(path))
{
    while (sr.Peek() >= 0)
    {
        string? line = sr.ReadLine();
       
        if (line != null)
        {          
            var filteredLine = client.FilterLine(line, vowelFilter);
            Console.WriteLine(filteredLine);         
        }
        
    }

}