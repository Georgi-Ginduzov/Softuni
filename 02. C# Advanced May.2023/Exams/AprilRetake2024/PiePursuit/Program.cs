namespace PiePursuit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> contestants = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> pies = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            while (contestants.Count > 0 && pies.Count > 0)
            {
                int contestant = contestants.Peek();
                int pie = pies.Peek();

                if (contestant >= pie)
                {
                    contestants.Dequeue();
                    pies.Pop();

                    if (contestant > pie)
                    {
                        contestants.Enqueue(contestant - pie);
                    }
                }
                else
                {
                    pies.Pop();
                    pies.Push(pie - contestant);
                    contestants.Dequeue();
                }

                if (pies.Count > 1 && pies.Peek() == 1)
                {
                    pies.Pop();
                    if (pies.Count > 0)
                    {
                        pies.Push(pies.Pop() + 1);
                    }
                }
            }

            if (pies.Count == 0 && contestants.Count == 0)
            {
                Console.WriteLine("We have a champion!".Trim());
            }
            else if (pies.Count == 0)
            {
                Console.WriteLine("We will have to wait for more pies to be baked!".Trim());
                Console.WriteLine($"Contestants left: {string.Join(" ", contestants).Trim()}".Trim());
            }
            else
            {
                Console.WriteLine("Our contestants need to rest!".Trim());
                Console.WriteLine($"Pies left: {string.Join(" ", pies).Trim()}".Trim());
            }
        }
    }
}
