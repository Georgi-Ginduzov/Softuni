using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingSystem
{
    public class VendingMachine
    {
        public VendingMachine(int buttonCapacity)
        {
            ButtonCapacity = buttonCapacity;
            Drinks = new List<Drink>();
        }

        public int ButtonCapacity { get; set; }
        public List<Drink> Drinks { get; set; }
        public int GetCount => Drinks.Count;

        public void AddDrink(Drink drink)
        {
            if (GetCount < ButtonCapacity)
            {
                Drinks.Add(drink);
            }
        }
        public bool RemoveDrink(string name)
        {
            Drink drinkToRemove = Drinks.FirstOrDefault(d => d.Name == name);
            if (drinkToRemove != null)
            {
                Drinks.Remove(drinkToRemove);
                return true;
            }
            return false;
        }

        public Drink GetLongest()
        => this.Drinks
            .OrderBy(n => n.Volume)
            .Last();
        
        public Drink GetCheapest()
        => this.Drinks.OrderBy(n => n.Price)
            .FirstOrDefault();

        public string BuyDrink(string name)
        {
            Drink drinkToBuy = Drinks.FirstOrDefault(d => d.Name == name);
            if (drinkToBuy != null)
            {
                return drinkToBuy.ToString();
            }
            return "False";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
         
            sb.AppendLine("Drinks available:");
            foreach (Drink drink in Drinks)
            {
                sb.AppendLine(drink.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        private bool IsInList(string name)
        {
            return Drinks.Any(drink => drink.Name.Equals(name));
        }

    }
}
