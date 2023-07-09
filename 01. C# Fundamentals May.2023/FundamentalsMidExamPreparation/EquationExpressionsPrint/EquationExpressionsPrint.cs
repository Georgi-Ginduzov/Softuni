using System;
using System.Collections.Generic;
using System.Linq;

namespace EquationExpressionsPrint
{
    internal class EquationExpressionsPrint
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> scopes = new Stack<int>();
            
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    scopes.Push(i);
                }
                else if (input[i] == ')') 
                {
                    int iterations = i;

                    for (int j = scopes.Pop(); j <= iterations; j++)
                    {
                        Console.Write(input[j]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}