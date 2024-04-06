using System.Text;
using System.Text.RegularExpressions;

namespace DestinationMapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"([=/])([A-Z][a-zA-Z]{2,})\1";
            MatchCollection matches = Regex.Matches(input, pattern);
            List<string> refactoredMatches = new List<string>();
            
            int travelPoints = 0;

            foreach (Match match in matches)
            {
                string tempMatch = Regex.Replace(match.ToString(), "([=/])", "");
                refactoredMatches.Add(tempMatch);
                travelPoints += tempMatch.Length;
            }

            
            Console.WriteLine("Destinations: " + String.Join(", ", refactoredMatches));
            Console.WriteLine("Travel Points: " + travelPoints);
        }
    }
}
