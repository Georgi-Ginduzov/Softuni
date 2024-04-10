namespace EscapeTheMaze
{
    internal class Program
    {
        static bool IsOutOfBounds(int coordinate, int size) => coordinate < 0 || coordinate >= size;
        static void printMaze(char[,] maze)
        {
            for (int row = 0; row < maze.GetLength(0); row++)
            {
                for (int col = 0; col < maze.GetLength(1); col++)
                {
                    Console.Write(maze[row, col]);
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            if (size < 4 || size > 10)
            {
                Environment.Exit(0);
            }

            char[,] maze = new char[size, size];
            int xPosition = 0;
            int yPosition = 0;

            int health = 100;
            int attackDamage = 40;

            int xCount = 0;

            for (int row = 0; row < size; row++)
            {
                char[] rowData = Console.ReadLine().ToArray();
                for (int col = 0; col < size; col++)
                {
                    maze[row, col] = rowData[col];
                    if (maze[row, col] == 'P')
                    {
                        xPosition = row;
                        yPosition = col;

                        maze[row, col] = '-';
                    }
                    else if (maze[row,col] == 'X')
                    {
                        xCount++;
                    }
                }
            }

            if (xCount == 0)
            {
                Environment.Exit(0);
            }

            string command;
            while ((command = Console.ReadLine().Trim()) != null)
            {
                switch (command)
                {
                    case "up":
                        if (IsOutOfBounds(xPosition - 1, size))
                        {
                            continue;
                        }
                        xPosition--;
                        break;
                    case "down":
                        if (IsOutOfBounds(xPosition + 1, size))
                        {
                            continue;
                        }
                        xPosition++;
                        break;
                    case "left":
                        if (IsOutOfBounds(yPosition - 1, size))
                        {
                            continue;
                        }
                        yPosition--;
                        break;
                    case "right":
                        if (IsOutOfBounds(yPosition + 1, size))
                        {
                            continue;
                        }
                        yPosition++;
                        break;

                    default:
                        break;
                }

                switch (maze[xPosition, yPosition])
                {
                    case 'X':
                        maze[xPosition, yPosition] = 'P';

                        Console.WriteLine("Player escaped the maze. Danger passed!".Trim());
                        Console.WriteLine($"Player's health: {health} units".Trim());
                        printMaze(maze);

                        Environment.Exit(0);
                        break;
                    case 'M':
                        health -= attackDamage;

                        if (health <= 0)
                        {
                            maze[xPosition, yPosition] = 'P';

                            health = 0;

                            Console.WriteLine("Player is dead. Maze over!".Trim());
                            Console.WriteLine($"Player's health: {health} units".Trim());
                            printMaze(maze);

                            Environment.Exit(0);
                        }
                        else
                        {
                            maze[xPosition, yPosition] = '-';
                        }
                        break;
                    case 'H':
                        health += 15;

                        if (health > 100)
                        {
                            health = 100;
                        }

                        maze[xPosition, yPosition] = '-';
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
