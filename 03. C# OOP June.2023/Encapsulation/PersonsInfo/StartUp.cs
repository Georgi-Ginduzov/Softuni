namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n  = int.Parse(Console.ReadLine());
            List<Person> people = new();

            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split();
                var person = new Person(commands[0], commands[1], int.Parse(commands[2]), decimal.Parse(commands[3]));
                people.Add(person);
            }

            decimal percentace = decimal.Parse(Console.ReadLine());

            


        }
    }
}