using System.Security.Principal;

namespace Storage_sListOfPhones
{
    internal class Program
    {
        static void Main()
        {
             List<string> phones = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                List<string> arguments = command.Split(" - ").ToList();
                switch (arguments[0])
                {
                    case "Add":
                        if (!phones.Contains(arguments[1]))
                        {
                            string phone = arguments[1];
                            phones.Add(phone);
                        }
                        break;
                    case "Remove":
                        if (arguments.Contains(arguments[1]))
                        {
                            string phone = arguments[1];
                            phones.Remove(phone);
                        }
                        break;
                    case "Bonus phone":
                        string[] bonusPhones = arguments[1].Split(":");
                        string oldPhone = bonusPhones[0];
                        string newPhone = bonusPhones[1];

                        if (phones.IndexOf(bonusPhones[0]) >= 0)
                        {
                            phones.Insert(phones.IndexOf(oldPhone) + 1, newPhone);
                        }
                        break;
                    case "Last":
                        if (phones.Contains(arguments[1]))
                        {
                            string phone = arguments[1];
                            phones.Remove(phone);
                            phones.Add(phone);
                        }
                        break;
                        
                    default: 
                        break;
                }
            }

            string result = string.Join(", ", phones.ToArray());
            Console.WriteLine(result);

        }
    }
}