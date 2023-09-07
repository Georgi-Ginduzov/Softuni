namespace SynonymDictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();

                if (!dictionary.ContainsKey(word))
                {
                    dictionary[word] = new List<string>{ Console.ReadLine() };
                }
                else
                {
                    dictionary[word].Add(Console.ReadLine());
                }                
            }

            foreach (var word in dictionary)
            {
                ;
                for (int i = 0; i < word.Value.Count; i++)
                {
                    
                }
                Console.WriteLine(word.Key + " - " + string.Join(", ", word.Value));
            }
        }
    }
}