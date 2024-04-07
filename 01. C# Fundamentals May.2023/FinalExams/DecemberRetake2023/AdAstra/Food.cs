namespace AdAstra
{
    public class Food
    {
        public string Name { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Calories { get; set; }

        public Food(string name, DateTime expirationDate, int calories)
        {
            Name = name;
            ExpirationDate = expirationDate;
            Calories = calories;
        }
    }
}
