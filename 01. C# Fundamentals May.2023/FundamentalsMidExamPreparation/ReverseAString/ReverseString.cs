using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseAString
{
    internal class ReverseString
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> inputString = new Stack<char>(input);

            for (int i = 0; i < input.Length; i++)
            {
                inputString.Push(input[i]);
            }
            while (inputString.Count > 0)
            {
                Console.Write(inputString.Pop());
            }
        }
    }
}