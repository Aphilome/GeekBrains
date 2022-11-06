namespace FullSearchSamples.Services.Impl
{
    public class SimpleSearcher
    {
        public void Search(string word, IEnumerable<string> data)
        {
            foreach (var item in data)
            {
                if (item.Contains(word, StringComparison.InvariantCultureIgnoreCase))
                    Console.WriteLine(item);
            }
        }
    }
}
