using System;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    internal class StackSum
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Stack<int> numbers = new Stack<int>(input);

            string inputCommands = Console.ReadLine().ToLower();
            string[] commands = inputCommands.Split(" ");

            while (commands[0] != "end")
            {
                if (commands[0] == "add")
                {
                    numbers.Push(int.Parse(commands[1]));
                    numbers.Push(int.Parse(commands[2]));
                }
                else if (commands[0] == "remove" && int.Parse(commands[1]) < numbers.Count)
                {
                    for (int i = 0; i < int.Parse(commands[1]); i++)
                    {
                        numbers.Pop();
                    }
                }
                inputCommands = Console.ReadLine().ToLower();
                commands = inputCommands.Split(" ");
            }

            int sum = 0, iterations = numbers.Count;
            for (int i = 0; i < iterations; i++)
            {
                sum += numbers.Pop();
            }

            Console.WriteLine("Sum: " + sum);
        }
    }
}