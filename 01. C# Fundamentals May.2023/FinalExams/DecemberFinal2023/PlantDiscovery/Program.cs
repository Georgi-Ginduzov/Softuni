using System.Linq;
using System.Text;

namespace PlantDiscovery
{
    public class Plant
    {
        public int Rarity { get; set; }
        public List<float> Rating { get; set; }

        public Plant( int rarity)
        {
            Rarity = rarity;
            Rating = new List<float>();
        }

        public float calculateAverageRating()
        {
            if (Rating.Count == 0)
            {
                return 0;
            }
            return Rating.Sum() / Rating.Count;
        }
    }

    public class Program
    {
       

        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine().Trim());

            Dictionary<string, Plant> plants = new();

            for (int i = 0; i < lines; i++)
            {
                string[] plantInput = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);
                string name = plantInput[0];
                int rarity = int.Parse(plantInput[1]);

                plants.Add(name, new Plant(rarity));
            }

            string[] command = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries);
            while (command[0] != "Exhibition")
            {
                string[] data = command[1].Split(" - ");
                string plantName = data[0].Trim();

                if (!plants.ContainsKey(plantName))
                {
                    Console.WriteLine("error");
                    command = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }

                switch (command[0])
                {
                    case "Rate":
                        int rating = int.Parse(data[1]);
                        plants[plantName].Rating.Add(rating);
                        break;
                    case "Update":
                        int newRarity = int.Parse(data[1]);
                        plants[plantName].Rarity = newRarity;
                        break;
                    case "Reset":
                        plants[plantName].Rating.Clear();
                        break;

                    default:
                        break;
                }

                command = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries);
            }

            StringBuilder output = new StringBuilder();
            output.AppendLine("Plants for the exhibition:");
            foreach (var item in plants)
            {
                output.AppendLine($"- {item.Key}; Rarity: {item.Value.Rarity}; Rating: {item.Value.calculateAverageRating():F2}");
            }

            Console.WriteLine(output);
        }
    }
}
