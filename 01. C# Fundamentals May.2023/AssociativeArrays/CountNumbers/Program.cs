namespace CountNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<double, int> numbers = new SortedDictionary<double, int>();

            var input = Console.ReadLine().Split(" ").Select(double.Parse).ToString();

            for (int i = 0; i < input.Length; i++)
            {
                if (!numbers.ContainsKey(input[i]))
                {
                    numbers[input[i]] = 1;
                }
                else
                {
                    numbers[input[i]]++;
                }
            }

            foreach (var number in numbers)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }

        }
    }
}