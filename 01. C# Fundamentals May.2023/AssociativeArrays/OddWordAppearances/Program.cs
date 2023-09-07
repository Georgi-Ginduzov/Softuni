using System;

namespace OddWordAppearances
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            for (int i = 0; i < input.Length; i++)
            {
                string word = input[i].ToLower();
                if (!dictionary.ContainsKey(word))
                {
                    dictionary[word] = 1;
                }
                else
                {
                    dictionary[word]++;
                }
            }

            string output = null;

            foreach (var word in dictionary)
            {
                if (word.Value % 2 == 1)
                {
                    output += word.Key + " ";
                }
            }

            Console.WriteLine(output);
        }
    }
}