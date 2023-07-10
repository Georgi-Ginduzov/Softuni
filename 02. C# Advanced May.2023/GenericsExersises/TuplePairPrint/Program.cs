using System;
using CustomTuple;

namespace CustomTuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] name = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] beer = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] numbers = Console.ReadLine()
                .Split(" ");

            CustomTuple<string, string> nameAndAdress =
                new($"{name[0]} {name[1]}", name[2]);
            Console.WriteLine(nameAndAdress);

            CustomTuple<string, int> amountOfBeer = 
                new(beer[0], int.Parse(beer[1]));
            Console.WriteLine(amountOfBeer);

            CustomTuple<int, double> intAndDouble = 
                new(int.Parse(numbers[0]), double.Parse(numbers[1]));
            Console.WriteLine(intAndDouble);

        }
    }
}