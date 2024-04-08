using System.Text;

namespace BattleManager
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split(':');

            Dictionary<string, PersonStats> people = new Dictionary<string, PersonStats>();

            while (command[0] != "Results")
            {
                string commandType = command[0];

                switch (commandType)
                {
                    case "Add":
                        string personName = command[1];
                        int health = int.Parse(command[2]);
                        int energy = int.Parse(command[3]);

                        if (people.ContainsKey(personName))
                        {
                            people[personName].Health += health;
                        }
                        else
                        {
                            people[personName] = new PersonStats(health, energy);
                        }
                        break;
                    case "Attack":
                        string attackerName = command[1];
                        string defenderName = command[2];
                        int damage = int.Parse(command[3]);

                        if (people.ContainsKey(attackerName) && people.ContainsKey(defenderName))
                        {
                            people[defenderName].Health -= damage;
                            people[attackerName].Energy--;

                            if (people[defenderName].Health <= 0)
                            {
                                people.Remove(defenderName);
                                Console.WriteLine($"{defenderName} was disqualified!");
                            }
                            if (people[attackerName].Energy <= 0)
                            {
                                people.Remove(attackerName);
                                Console.WriteLine($"{attackerName} was disqualified!");
                            }
                        }

                        break;
                    case "Delete":
                        string username = command[1];

                        if (username == "All")
                        {
                            people.Clear();
                            command = Console.ReadLine().Split(':');
                            continue;
                        }

                        if (people.ContainsKey(username))
                        {
                            people.Remove(username);
                        }
                        break;

                    default:
                        break;
                }

                command = Console.ReadLine().Split(':');
            }

            StringBuilder output = new StringBuilder();
            output.AppendLine($"People count: {people.Count}");
            foreach (var person in people)
            {
                output.AppendLine($"{person.Key} - {person.Value.Health} - {person.Value.Energy}");
            }

            Console.WriteLine(output.ToString().Trim());
        }
    }
}
