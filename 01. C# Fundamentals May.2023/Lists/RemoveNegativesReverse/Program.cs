﻿List<int> numbers = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToList();

for (int i = 0; i < numbers.Count; i++)
{
    if (numbers[i] < 0)
    {
        numbers.Remove(numbers[i]);
        i = -1;
    }
}
numbers.Reverse();

if (numbers.Count == 0)
{
    Console.WriteLine("empty");
}
else
{
    for (int i = 0; i < numbers.Count; i++)
    {
        Console.Write(numbers[i] + " ");
    }
}