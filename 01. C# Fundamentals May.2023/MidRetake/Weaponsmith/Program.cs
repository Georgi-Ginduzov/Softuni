using System;
using System.Collections.Generic;
using System.Linq;

namespace Weaponsmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> parts = Console.ReadLine().Split("|").ToList();
            string[] command = Console.ReadLine().Split();

            while (command[0] != "Done")
            {
                switch (command[0])
                {
                    case "Remove":
                        if (int.TryParse(command[1], out int removeIndex) && removeIndex >= 0 && removeIndex < parts.Count)
                        {
                            parts.RemoveAt(removeIndex);
                        }
                        break;

                    case "Add":
                        if (int.TryParse(command[2], out int addIndex) && addIndex >= 0 && addIndex < parts.Count)
                        {
                            parts.Insert(addIndex, command[1]);
                        }
                        break;

                    case "Check":
                        if (command[1] == "Odd")
                        {
                            for (int i = 1; i < parts.Count; i = i + 2)
                            {
                                Console.Write(parts[i] + " ");
                            }
                        }
                        else if (command[1] == "Even")
                        {
                            for (int i = 0; i < parts.Count; i = i + 2)
                            {
                                Console.Write(parts[i] + " ");
                            }
                        }
                        break;

                    default:
                        break;
                }
                command = Console.ReadLine().Split();
            }

            Console.WriteLine();
            Console.WriteLine("You crafted " + string.Join("", parts) + "!");
        }
    }
}
