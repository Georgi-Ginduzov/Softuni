
namespace BakeryShop
{
    public class Shop
    {
        private Dictionary<string, int> stock;
        private int soldstock;

        public Shop()
        {
            Stock = new Dictionary<string, int>();
            Soldstock = 0;
        }

        public Dictionary<string, int> Stock { get; set; }
        public int Soldstock
        {
            get
            {
                return this.soldstock;
            }
            set
            {
                this.soldstock = value;
            }
        }

        public bool receiveItem(int quantity, string name)
        {
            if (quantity <= 0)
            {
                return false;
            }

            addItem(quantity, name);

            return true;
        }

        private void addItem(int quantity, string name)
        {
            if (Stock.ContainsKey(name))
            {
                Stock[name] += quantity;
            }
            else
            {
                Stock[name] = quantity;
            }
        }

        public bool sellItem(int quantity, string item)
        {
            if (Stock.ContainsKey(item))
            {
                if (Stock[item] - quantity >= 0)
                {

                    Soldstock += quantity;

                    Stock[item] -= quantity;
                    Console.WriteLine($"You sold {quantity} {item}.");
                    if (Stock[item] == 0)
                    {
                        Stock.Remove(item);
                    }
                }
                else
                {
                    int soldQuantity = Stock[item];
                    Stock[item] = 0;
                    Stock.Remove(item);

                    Soldstock += soldQuantity;

                    Console.WriteLine($"There aren't enough {item}. You sold the last {soldQuantity} of them.");
                }
            }
            else
            {
                Console.WriteLine($"You do not have any {item}.");
            }

            return true;
        }

        public void printStockAvailability()
        {
            foreach (var item in Stock)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
