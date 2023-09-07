using System.Linq.Expressions;

namespace CountCharsInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<char, int> chars = new Dictionary<char, int>();

            foreach (char symbol in input)
            {
                if (!chars.ContainsKey(symbol))
                {
                    chars[symbol] = 1;
                }
                else
                {
                    chars[symbol]++;
                }
            }

            foreach (var symbol in chars)
            {
                if (symbol.Key != ' ')
                {
                    Console.WriteLine($"{symbol.Key} -> {symbol.Value}");
                }
            }
        }
    }
}