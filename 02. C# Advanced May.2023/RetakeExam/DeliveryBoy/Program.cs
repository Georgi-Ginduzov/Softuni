using System;

namespace DeliveryBoy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            char[,] area = new char[dimensions[0], dimensions[1]];
            int currentRow = 0, currentCol = 0;

            for (int i = 0; i < dimensions[0]; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < dimensions[1]; j++)
                {
                    area[i, j] = input[j];
                    if (input[j] == 'B') (currentRow, currentCol) = (i, j);
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                int newRow = currentRow, newCol = currentCol;

                switch (command)
                {
                    case "up": newRow--; 
                        break;
                    case "down": newRow++; 
                        break;
                    case "left": newCol--; 
                        break;
                    case "right": newCol++; 
                        break;
                }

                if (IsInside(area, newRow, newCol))
                {
                    char nextCell = area[newRow, newCol];
                    area[currentRow, currentCol] = '.';

                    if (nextCell == 'P')
                    {
                        currentCol = newCol;
                        currentRow = newRow;
                        area[currentRow, currentCol] = 'R';
                        Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
                        break;
                    }
                    else if (nextCell == '-' || nextCell == '.')
                    {
                        if (area[currentRow, currentCol] != 'B')
                        {
                            area[currentRow, currentCol] = '.';
                        }
                        ;
                        currentRow = newRow;
                        currentCol = newCol;
                    }
                }
                else
                {
                    PrintArea(area);
                    Console.WriteLine("The delivery is late. Order is canceled.");
                    Environment.Exit(0);
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                int newRow = currentRow, newCol = currentCol;

                switch (command)
                {
                    case "up": newRow--; break;
                    case "down": newRow++; break;
                    case "left": newCol--; break;
                    case "right": newCol++; break;
                }

                if (IsInside(area, newRow, newCol))
                {
                    char nextCell = area[newRow, newCol];
                    area[currentRow, currentCol] = '.';

                    if (nextCell == 'A')
                    {
                        Console.WriteLine("Pizza is delivered on time! Next order...");
                        break;
                    }
                    else if (nextCell == '-' || nextCell == '.')
                    {
                        if (area[currentRow, currentCol] != 'B')
                        {
                            area[currentRow, currentCol] = '.';
                        }
                        area[currentRow, currentCol] = '.';
                        currentRow = newRow;
                        currentCol = newCol;
                    }
                }
                else
                {
                    Console.WriteLine("The delivery is late. Order is canceled.");
                    PrintArea(area);

                    Environment.Exit(0);
                }
            }

            PrintArea(area);
        }

        static bool IsInside(char[,] area, int row, int col)
        {
            return row >= 0 && row < area.GetLength(0) && col >= 0 && col < area.GetLength(1);
        }

        static void PrintArea(char[,] area)
        {
            for (int i = 0; i < area.GetLength(0); i++)
            {
                for (int j = 0; j < area.GetLength(1); j++)
                {
                    Console.Write(area[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
