using System.Globalization;
using System.Text.RegularExpressions;

namespace AdAstra
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Food> foodList = new List<Food>();
            int minimumCaloriesPerDay = 2000;

            string input = Console.ReadLine();
            string pattern = @"([#|])(?<name>[A-Za-z\s]+)\1(?<expirationDate>\d{2}\/\d{2}\/\d{2})\1(?<calories>\d+)\1";
            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                string name = match.Groups["name"].Value;
                DateTime expirationDate = DateTime.ParseExact(match.Groups["expirationDate"].Value, "dd/MM/yy", CultureInfo.InvariantCulture);
                int calories = int.Parse(match.Groups["calories"].Value);

                foodList.Add(new Food(name, expirationDate, calories));
            }

            int daysToLastWithFood = foodList.Sum(food => food.Calories) / minimumCaloriesPerDay;

            Console.WriteLine($"You have food to last you for: {daysToLastWithFood} days!");
            foreach (var food in foodList)
            {
                Console.WriteLine($"Item: {food.Name}, Best before: {food.ExpirationDate.ToString("dd/MM/y")}, Nutrition: {food.Calories}");
            }
        }
    }
}
