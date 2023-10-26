using System.Collections.Generic;

namespace ContestRanking
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(":");

            Dictionary<string, Dictionary<string, Dictionary<string, List<string>>>> contests = new Dictionary<string, Dictionary<string, Dictionary<string, List<string>>>>();

            contests[input[0]] = new Dictionary<string, Dictionary<string, List<string>>>
            {
                [input[1]] = new Dictionary<string, List<string>>
                {

                }
            };

            while (input[0] != "end of contests")
            {
                if (!contests.ContainsKey(input[0]))
                {
                    contests[input[0]] = new Dictionary<string, Dictionary<string, List<string>>>
                    {

                        [input[1]] = new Dictionary<string, List<string>>
                        {

                        }
                    };
                }
                else
                {

                }
                input = Console.ReadLine().Split(":");
            }

            input = Console.ReadLine().Split("=>");
            while (input[0] != "end of submissions")
            {
                string contestName = input[0];
                string contestPassword = input[1];
                string username = input[2];
                string points = input[3];

                if (contests.ContainsKey(contestName))
                {
                    if (contests[contestName].ContainsKey(contestPassword))
                    {
                        contests[contestName][contestPassword][username] = new List<string>
                        {
                            points
                        };
                    }
                }
                else
                {
                    
                }
                input = Console.ReadLine().Split("=>");
            }

            Console.Clear();

            /* var sortedStudents = contests
                 .SelectMany(contest => contest.Value.SelectMany(password => password.Value,
                     (contestName, password) => new { ContestName = contestName.Key, Password = password }))
                 .SelectMany(user => user.Password.Value.Select(
                     entry => new { Username = entry.Key, ContestNameg = user.ContestName, Points = entry.Value }))
                 .GroupBy(student => student.Username)
                 .OrderByDescending(student => student.Sum(entry => int.Parse(entry.Points)))
                 .ThenBy(student => student.Key);*//*


            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student.Key);
                foreach (var contest in student.GroupBy(c => c.ContestName))
                {
                    foreach (var entry in contest)
                    {
                        Console.WriteLine($"# {entry.ContestName} -> {entry.Points}");
                    }
                }


            }*/


            foreach (var (contestName, contestPas) in contests)
            {
                foreach (var (password, users) in contestPas)
                {
                    Console.WriteLine(users.Key);
                }
            }
        }
    }
}