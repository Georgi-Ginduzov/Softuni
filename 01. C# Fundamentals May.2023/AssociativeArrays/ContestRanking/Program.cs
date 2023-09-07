using System.ComponentModel;
using System.Threading.Tasks;

namespace ContestRanking
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<string, int> contests = new Dictionary<string, int>();
            string[] input = Console.ReadLine().Split(":");

            Dictionary<string, Dictionary<string, Dictionary<string, string>>> contests = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();

            contests[input[0]] = new Dictionary<string, Dictionary<string, string>>
            {
                 [input[1]] = new Dictionary<string, string>
                {

                }
            };

            while (input[0] != "end of contests")
            {
                if (contests.ContainsKey(input[0]))
                {
                contests[input[0]] = new Dictionary<string, Dictionary<string, string>>
                    {
                    
                        [input[1]] = new Dictionary<string, string>
                        {

                        }
                    };
                }
                input = Console.ReadLine().Split(":");
            }

            input = Console.ReadLine().Split("=>");
            while (input[0] != "end of submissions")
            {
                if (contests.ContainsKey(input[0]))
                {
                    contests[input[0]][input[1]].Add(input[2], input[3]);
                }
                input = Console.ReadLine().Split("=>");
            }

            Console.Clear();
            
            foreach (var contest in contests)
            {
                foreach (var password in contest.Value)
                {
                    foreach (var username in password.Value)
                    {
                        Console.WriteLine(username.Key);
                        foreach (var attendency in contests)
                        {
                            Console.WriteLine($"{attendency.Key} -> {username.Value}");
                        }
                    }
                }
            }
            
            
        }
    }
}