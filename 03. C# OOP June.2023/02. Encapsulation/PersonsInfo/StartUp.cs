namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            Team team = new Team("Softuni");

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split();
                string firstName = commands[0];
                string lastName = commands[1];
                int age = int.Parse(commands[2]);
                decimal salary = decimal.Parse(commands[3]);

                try
                {
                    Person person = new Person(firstName, lastName, age, salary);

                    people.Add(person);
                    team.AddPlayer(person);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");

        }
    }
}