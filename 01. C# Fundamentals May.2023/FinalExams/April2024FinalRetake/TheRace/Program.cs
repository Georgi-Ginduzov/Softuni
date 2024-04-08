using System.Text;
using System.Text.RegularExpressions;

namespace TheRace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            string pattern = @"([#$%*&])(?<name>[A-Za-z]+)\1=(?<length>\d+)!!(?<code>.+)";
            bool foundCoordinates = false;

            while (foundCoordinates == false)
            {
                input = Console.ReadLine();

                Match match = Regex.Match(input, pattern);
                
                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    int length = int.Parse(match.Groups["length"].Value);
                    string code = match.Groups["code"].Value;

                    if (length == code.Length)
                    {
                        StringBuilder sb = new StringBuilder();

                        for (int i = 0; i < code.Length; i++)
                        {
                            sb.Append((char)(code[i] + length));
                        }

                        Console.WriteLine($"Coordinates found! {name} -> {sb}");
                        foundCoordinates = true;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Nothing found!");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }
            }


        }
    }
}
