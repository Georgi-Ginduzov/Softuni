using System.Text;

namespace ClearSkies
{
    /*public class Airspace
    {
        public Airspace(char[,] map, int enemiesCount)
        {
            Map = map;
            this.enemiesCount = enemiesCount;

        }

        public char[,] Map { get; set; }
        public Jetfighter Jetfighter { get; set; }
        public int enemiesCount { get; set; }

    }
    public class Jetfighter
    {
        public int InitialArmor { get; set; }
        
    }*/


    internal class Program
    {
        static void PrintAirspace(char[,] map)
        {
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map.Length; j++)
                {
                    output.Append(map[i, j]);
                }
                output.AppendLine();
            }

            Console.WriteLine(output);
        }

        static bool IsWithinTheAirspace(int coordinate, int size)
        {
            if (coordinate >= 0 && coordinate <= size)
            {
                return true;
            }
            return false;
        }

        static int TakeDamage(int armor) => armor - 100;
        static int Repair() => 300;
        static bool moreEnemiesLeft(int enemyCount) => enemyCount > 0;
        
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());
            char[,] airspace = new char[sizeOfMatrix, sizeOfMatrix];
            int initialArmor = 300;
            Dictionary<char, int> position = new Dictionary<char, int>();
            int enemyCount = 0;

            for (int i = 0; i < sizeOfMatrix; i++)
            {
                char[] inputLine = Console.ReadLine().ToCharArray();

                for (int j = 0; j < sizeOfMatrix; j++)
                {
                    airspace[i, j] = inputLine[j];
                    if (inputLine[j] == 'J')
                    {
                        position['x'] = i;
                        position['y'] = j;
                    }
                    else if (inputLine[j] == 'E')
                    {
                        enemyCount++;
                    }
                }
            }

            while (enemyCount > 0 || initialArmor > 0)
            {
                airspace[position['x'], position['y']] = '-';
                switch (Console.ReadLine())
                {
                    case "up":
                        if (IsWithinTheAirspace(position['x'] - 1, sizeOfMatrix))
                        {
                            position['x']--;
                        }

                        char airspaceSymbol = airspace[position['x'], position['y']];

                        switch (airspaceSymbol)
                        {
                            case 'E':
                                initialArmor = TakeDamage(initialArmor);

                                if (initialArmor > 0)
                                {
                                    if (moreEnemiesLeft(enemyCount))
                                    {

                                    }
                                    else
                                    {
                                        Console.WriteLine("Mission accomplished, you neutralized the aerial threat!");
                                        PrintAirspace(airspace);
                                        return;
                                    }
                                    // 
                                }
                                break;
                            case 'R':
                                initialArmor = Repair();
                                break;

                            default:
                                break;
                        }

                        break;
                    case "down":
                        if (IsWithinTheAirspace(position['x'] + 1, sizeOfMatrix))
                        {
                            position['x']++;
                        }
                        break;
                    case "left":
                        if (IsWithinTheAirspace(position['y'] - 1, sizeOfMatrix))
                        {
                            position['y']--;
                        }
                        break;
                    case "right":
                        if (IsWithinTheAirspace(position['y'] + 1, sizeOfMatrix))
                        {
                            position['y']++;
                        }
                        break;

                    default:
                        break;
                }
            }


            // Print the final state
            // Print mission status
            PrintAirspace(airspace);
        }
    }
}
