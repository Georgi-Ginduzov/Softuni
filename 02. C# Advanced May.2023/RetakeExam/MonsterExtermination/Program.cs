namespace MonsterExtermination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] monsterArmours = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(n => n > 0 && n <= 100)
                .ToArray();
            int[] strikePowers = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(n => n > 0 && n <= 100)
                .ToArray();

            Queue<int> armours = new Queue<int>(monsterArmours);
            Stack<int> strikes = new Stack<int>(strikePowers);
            int kills = 0;

            while (armours.Count > 0 && strikes.Count > 0)
            {
                int remainder = 0;
                int armour = armours.Dequeue();
                int strike = strikes.Pop() + remainder;

                if (strike >= armour)
                {
                    remainder = strike - armour;
                    if (strikes.Count == 0 && remainder > 0)
                    {
                        strikes.Push(remainder);
                    }
                    kills++;
                }
                else
                {
                    armour -= (strike - remainder);
                    armours.Enqueue(armour);
                }
            }
            
            if (armours.Count == 0)
            {
                Console.WriteLine("All monsters have been killed!");
                Console.WriteLine($"Total monsters killed: {kills}");
            }
            else
            {
                Console.WriteLine("The soldier has been defeated.");
                Console.WriteLine($"Total monsters killed: {kills}");
            }
        }
    }
}