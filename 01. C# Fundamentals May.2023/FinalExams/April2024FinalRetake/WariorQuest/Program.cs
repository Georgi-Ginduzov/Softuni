using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;

namespace WariorQuest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder skill = new StringBuilder(Console.ReadLine());
            
            string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            StringBuilder commandBuild = new StringBuilder();
            commandBuild.AppendJoin(' ', command);

            while (commandBuild.ToString().Trim() != "For Azeroth")
            {
                switch (command[0])
                {
                    case "GladiatorStance":
                        for (int i = 0; i < skill.Length; i++)
                        {
                            skill[i] = Char.ToUpper(skill[i]);
                        }
                        Console.WriteLine(skill);
                        break;
                    case "DefensiveStance":
                        for (int i = 0; i < skill.Length; i++)
                        {
                            skill[i] = Char.ToLower(skill[i]);
                        }
                        Console.WriteLine(skill);
                        break;
                    case "Dispel":
                        int index = int.Parse(command[1]);
                        char letter = char.Parse(command[2]);

                        if (index >= 0 && index < skill.Length)
                        {
                            skill = skill.Remove(index, 1).Insert(index, letter.ToString());
                            Console.WriteLine("Success!");
                        }
                        else
                        {
                            Console.WriteLine("Dispel too weak.");
                        }
                        break;
                    case "Target":
                        if (command[1] == "Change")
                        {
                            string substring = command[2];
                            string secondSubstring = command[3];

                            skill = skill.Replace(substring, secondSubstring);

                            Console.WriteLine(skill);
                        }
                        else if (command[1] == "Remove")
                        {
                            string substring = command[2];

                            if (skill.ToString().Contains(substring))
                            {
                                skill = skill.Replace(substring, "");
                                Console.WriteLine(skill);

                            }
                        }
                        else
                        {
                            Console.WriteLine("Command doesn't exist!");
                        }
                        break;
                    default:
                        Console.WriteLine("Command doesn't exist!");
                        break;
                }

                command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                commandBuild = new StringBuilder();
                commandBuild.AppendJoin(' ', command);
            }
        }
    }
}
