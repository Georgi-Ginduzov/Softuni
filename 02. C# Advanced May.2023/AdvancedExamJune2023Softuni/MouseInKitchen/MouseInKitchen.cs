using System;
using System.Diagnostics;
using System.Diagnostics.Tracing;

namespace MouseInKitchen
{
    internal class MouseInKitchen
    {
        
        static bool isOutside(char[,] area, int x, int y)
        {
            if (area.GetLength(0) - 1 < x)
            {
                Console.WriteLine("No more cheese for tonight!");

                x--;

                area[x, y] = 'M';

                for (int i = 0; i < area.GetLength(0); i++)
                {
                    for (int j = 0; j < area.GetLength(1); j++)
                    {
                        Console.Write(area[i, j]);
                    }
                    Console.WriteLine();
                }
                return true;
            }
            else if (area.GetLength(1) - 1 < y)
            {
                Console.WriteLine("No more cheese for tonight!");

                y--;

                area[x, y] = 'M';

                for (int i = 0; i < area.GetLength(0); i++)
                {
                    for (int j = 0; j < area.GetLength(1); j++)
                    {
                        Console.Write(area[i, j]);
                    }
                    Console.WriteLine();
                }
                return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(',')
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            char[,] area = new char[rows, cols];
            int[] currentPosition = new int[2];

            int cheeseCount = 0;

            for (int i = 0; i < rows; i++)
            {
                string tiles = Console.ReadLine();
                for (int j = 0; j < cols; j++)
                {
                    area[i, j] = tiles[j];
                    if (tiles[j] == 'M')
                    {
                        currentPosition[0] = i;
                        currentPosition[1] = j;
                    }
                    else if (tiles[j] == 'C')
                    {
                        cheeseCount++;
                    }
                }
            }

            string command = Console.ReadLine();
            while (command != "danger")
            {
                area[currentPosition[0], currentPosition[1]] = '*';

                if (command == "up")
                {
                    currentPosition[0]--;
                }
                else if (command == "down")
                {
                    currentPosition[0]++;
                }
                else if (command == "left")
                {
                    currentPosition[1]--;

                }
                else if (command == "right")
                {
                    currentPosition[1]++;

                }
                if (isOutside(area, currentPosition[0], currentPosition[1]) == false)
                {
                    switch (area[currentPosition[0], currentPosition[1]])
                    {
                        case 'C':
                            {
                                area[currentPosition[0], currentPosition[1]] = '*';
                                cheeseCount--;
                                if (cheeseCount == 0)
                                {
                                    Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                                    area[currentPosition[0], currentPosition[1]] = 'M';
                                    for (int i = 0; i < area.GetLength(0); i++)
                                    {
                                        for (int j = 0; j < area.GetLength(1); j++)
                                        {
                                            Console.Write(area[i, j]);
                                        }
                                        Console.WriteLine();
                                    }
                                    return;
                                }
                                break;
                            }
                        case 'T':
                            {
                                Console.WriteLine("Mouse is trapped!");
                                area[currentPosition[0], currentPosition[1]] = 'M';
                                for (int i = 0; i < area.GetLength(0); i++)
                                {
                                    for (int j = 0; j < area.GetLength(1); j++)
                                    {
                                        Console.Write(area[i, j]);
                                    }
                                    Console.WriteLine();
                                }
                                return;
                            }
                        case '@':
                            {
                                if (command == "up")
                                {
                                    currentPosition[0]++;
                                }
                                else if (command == "down")
                                {
                                    currentPosition[0]--;
                                }
                                else if (command == "left")
                                {
                                    currentPosition[1]++;
                                }
                                else if (command == "right")
                                {
                                    currentPosition[1]--;
                                }
                                break;
                            }
                        case '*':
                            {
                                break;
                            }
                        default:
                            break;
                    }
                    
                }
                else
                {
                    
                    return;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine("Mouse will come back later!");
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