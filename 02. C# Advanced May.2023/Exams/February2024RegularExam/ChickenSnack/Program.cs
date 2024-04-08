using System.Linq;

namespace ChickenSnack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> sequenceOfMoney = new List<int>(
                Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .Where(n => n >= 1 && n <= 20)
                .ToList());
            List<int> sequenceOfFoodPrices = new List<int>(
                Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .Where(n => n >= 1 && n <= 20)
                .ToList());

            int difference = 0;
            int foodCount = 0;

            for (int i = 0; i < sequenceOfFoodPrices.Count; i++)
            {
                sequenceOfMoney[^+(i+1)] += difference;
                difference = sequenceOfMoney[^ + (i + 1)] - sequenceOfFoodPrices[i];

                if (difference >= 0)
                {
                    foodCount++;
                }
                else
                {
                    difference = 0;
                }
                sequenceOfFoodPrices.Remove(i);
                sequenceOfMoney.Remove(sequenceOfMoney.Count - (i + 1));
            }

            string message = foodCount switch
            {
                >= 4 => $"Gluttony of the day! Henry ate {foodCount} foods.",
                > 1 => $"Henry ate: {foodCount} foods.",
                1 => $"Henry ate: {foodCount} food.",
                _ => "Henry remained hungry. He will try next weekend again.",
            };

            Console.WriteLine(message);
        }
    }
}
