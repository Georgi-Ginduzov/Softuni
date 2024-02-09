namespace WorldTour
{
    public class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();
            string[] command = Console.ReadLine().Split(' ', ':');


            while (command[0] != "Travel")
            {
                switch (command[0])
                {
                    case "Add":
                        // Begin from third and insert fourth
                        int beginning = int.Parse(command[2]);
                        stops = stops.Insert(beginning, command[3]);
                        break;

                    case "Remove":
                        // Begin from third and finish at fourth
                        
                        stops = stops.Remove(int.Parse(command[2]), int.Parse(command[3]) - int.Parse(command[2]) + 1);
                        break;

                    case "Switch":
                        // remove second and insert third
                        stops = stops.Replace(command[1], command[2]);
                        break;

                    default:
                        break;
                }
                Console.WriteLine(stops);
                command = Console.ReadLine().Split(' ', ':');
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }
    }
}
