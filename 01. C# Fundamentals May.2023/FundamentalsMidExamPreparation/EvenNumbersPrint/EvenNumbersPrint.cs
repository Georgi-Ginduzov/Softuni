using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenNumbersPrint
{
    internal class EvenNumbersPrint
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Queue<int> numbers = new Queue<int>(input);

            string result = string.Empty;

            while (numbers.Count > 0) 
            {
                int number = numbers.Dequeue();

                if (number % 2 == 0)
                {
                    result += $"{number}, ";
                }
            }
            Console.WriteLine(result.TrimEnd(' ', ','));
        }
    }
}