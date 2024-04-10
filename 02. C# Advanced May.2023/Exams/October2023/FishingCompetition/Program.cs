namespace FishingCompetition
{
    internal class Program
    {
        static bool isOutside(int coordinate, int size) => coordinate < 0 || coordinate >= size;
        static void printArea(char[,] area)
        {
            for (int row = 0; row < area.GetLength(0); row++)
            {
                for (int col = 0; col < area.GetLength(1); col++)
                {
                    Console.Write(area[row, col]);
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] fishingArea = new char[size, size];
            int xCoordinate = 0;
            int yCoordinate = 0;

            int cathedFish = 0;
            int fishToCatch = 20;

            for (int row = 0; row < size; row++)
            {
                char[] rowValues = Console.ReadLine().ToArray();
                for (int col = 0; col < size; col++)
                {
                    fishingArea[row, col] = rowValues[col];
                    if (fishingArea[row, col] == 'S')
                    {
                        xCoordinate = row;
                        yCoordinate = col;
                    }
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "collect the nets")
            {
                switch (command)
                {
                    case "up":
                        if (isOutside(xCoordinate - 1, yCoordinate))
                        {
                            xCoordinate = size - 1;
                        }
                        else
                        {
                            xCoordinate--;
                        }

                        if (fishingArea[xCoordinate, yCoordinate] == 'W')
                        {
                            Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{xCoordinate},{yCoordinate}]");
                            Environment.Exit(0);
                        }
                        else if (char.IsDigit(fishingArea[xCoordinate, yCoordinate]))
                        {
                            cathedFish += (int)fishingArea[xCoordinate, yCoordinate];
                            fishingArea[xCoordinate, yCoordinate] = '-';
                        }
                        break;
                    case "down":
                        if (isOutside(xCoordinate + 1, yCoordinate))
                        {
                            xCoordinate = 0;
                        }
                        else
                        {
                            xCoordinate++;
                        }

                        if (fishingArea[xCoordinate, yCoordinate] == 'W')
                        {
                            Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{xCoordinate},{yCoordinate}]");
                            Environment.Exit(0);
                        }
                        else if (char.IsDigit(fishingArea[xCoordinate, yCoordinate]))
                        {
                            cathedFish += (int)fishingArea[xCoordinate, yCoordinate];
                            fishingArea[xCoordinate, yCoordinate] = '-';
                        }
                        break;
                    case "left":
                        if (isOutside(xCoordinate, yCoordinate - 1))
                        {
                            yCoordinate = size - 1;
                        }
                        else
                        {
                            yCoordinate--;
                        }

                        if (fishingArea[xCoordinate, yCoordinate] == 'W')
                        {
                            Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{xCoordinate},{yCoordinate}]");
                            Environment.Exit(0);
                        }
                        else if (char.IsDigit(fishingArea[xCoordinate, yCoordinate]))
                        {
                            cathedFish += (int)fishingArea[xCoordinate, yCoordinate];
                            fishingArea[xCoordinate, yCoordinate] = '-';
                        }
                        break;
                    case "right":
                        if (isOutside(xCoordinate, yCoordinate + 1))
                        {
                            yCoordinate = 0;
                        }
                        else
                        {
                            yCoordinate++;
                        }

                        if (fishingArea[xCoordinate, yCoordinate] == 'W')
                        {
                            Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{xCoordinate},{yCoordinate}]");
                            Environment.Exit(0);
                        }
                        else if (char.IsDigit(fishingArea[xCoordinate, yCoordinate]))
                        {
                            cathedFish += (int)fishingArea[xCoordinate, yCoordinate];
                            fishingArea[xCoordinate, yCoordinate] = '-';
                        }
                        break;

                    default:
                        break;

                }
            }

            if (cathedFish >= fishToCatch)
            {
                Console.WriteLine("Success! You managed to reach the quota!");
            }
            else
            {
                Console.WriteLine($"You didn't catch enough fish and didn't reach the quota!You need {fishToCatch - cathedFish}tons of fish more.");
            }

            if (cathedFish > 0)
            {
                Console.WriteLine($"Amount of fish caught: {cathedFish} tons.");
            }

            printArea(fishingArea);
        }
    }
}
