using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<string> coffees = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            switch (command[0])
            {
                case "Include":
                    string coffee = command[1];
                    coffees.Add(coffee);
                    break;
                case "Remove":
                    string position = command[1];
                    int count = int.Parse(command[2]);

                    if (position == "first" && count <= coffees.Count)
                    {
                        coffees = coffees.Skip(count).ToList();
                    }
                    else if (position == "last" && count <= coffees.Count)
                    {
                        coffees = coffees.Take(coffees.Count - count).ToList();
                    }
                    break;
                case "Prefer":
                    int index1 = int.Parse(command[1]);
                    int index2 = int.Parse(command[2]);
                    if (index1 <= coffees.Count && index1 > -1 && index2 <= coffees.Count && index2 > -1)
                    {
                        string temp = coffees[index1];
                        coffees[index1] = coffees[index2];
                        coffees[index2] = temp;
                    }
                    break;
                case "Reverse":
                    coffees.Reverse();
                    break;
                default:
                    break;
            }
            
        }

        Console.WriteLine("Coffees:");
        Console.WriteLine(string.Join(" ", coffees));
    }
}
