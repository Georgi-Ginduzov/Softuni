using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Knight knight = new("Brave", 20);
            Console.WriteLine(knight);
        }
    }
}