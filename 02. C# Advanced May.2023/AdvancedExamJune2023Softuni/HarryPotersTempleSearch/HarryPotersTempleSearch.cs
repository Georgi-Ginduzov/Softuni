namespace HarryPotersTempleSearch
{
    internal class HarryPotersTempleSearch
    {
        static void Main(string[] args)
        {
            int[] toolsInput = Console.ReadLine() //tools
                .Split()
                .Select(int.Parse)
                .ToArray();
            Queue<int> tools = new Queue<int>(toolsInput);

            int[] substancesInput = Console.ReadLine() // substances
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> substances = new Stack<int>(substancesInput);

            int[] challengesInput = Console.ReadLine() // substances
                .Split()
                .Select(int.Parse)
                .ToArray();
            List<int> challenges = new List<int>(challengesInput);

            while (challenges.Any() && substances.Any() && tools.Any())
            {
                int result = tools.Peek() * substances.Peek(); // 2*9 4*7 6*5 8*3 
                int iterations = challenges.Count();
                bool isResolved = false;
                for (int i = 0; i < iterations; i++)
                {
                    if (result == challenges[i])
                    {
                        tools.Dequeue();
                        substances.Pop();
                        isResolved = true;
                        challenges.RemoveAt(i);
                        break;
                    }
                }
                if (isResolved == false)
                {
                    tools.Enqueue(tools.Dequeue() + 1);

                    int substancesResult = substances.Peek() - 1;
                    if (substancesResult > 0)
                    {
                        substances.Pop();
                        substances.Push(substancesResult);
                    }
                    else
                    {
                        substances.Pop();
                    }

                }
            }

            if (challenges.Count > 0)
            {
                Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
            }
            else
            {
                Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
                
            }
            if (tools.Count > 0)
            {
                string result = string.Empty;
                int iterations = tools.Count;
                for (int i = 0; i < iterations; i++)
                {
                    int number = tools.Dequeue();
                    result += $"{number}, ";
                }
                Console.WriteLine("Tools: " + result.TrimEnd(' ', ','));
            }
            if (substances.Count > 0)
            {
                string result = string.Empty;
                int iterations = substances.Count;
                for (int i = 0; i < iterations; i++)
                {
                    int number = substances.Pop();
                    result += $"{number}, ".ToString();
                }
                Console.WriteLine("Substances: " + result.TrimEnd(' ', ','));
            }
            if (challenges.Count > 0)
            {
                string resultChallenges = string.Empty;
                int iterationsChallenges = challenges.Count;
                for (int i = 0; i < iterationsChallenges; i++)
                {
                    int number = challenges[i];
                    resultChallenges += $"{number}, ";
                }
                Console.WriteLine("Challenges: " + resultChallenges.TrimEnd(' ', ','));
            }

        }
    }
}