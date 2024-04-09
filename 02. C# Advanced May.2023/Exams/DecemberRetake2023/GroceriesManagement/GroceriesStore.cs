using System.Text;

namespace GroceriesManagement
{
    public class GroceriesStore
    {
        public int Capacity { get; set; }
        public double Turnover { get; set; }
        public List<Product> Stall;

        public GroceriesStore(int capacity)
        {
            this.Capacity = capacity;
            this.Turnover = 0;
            this.Stall = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            foreach (var item in Stall)
            {
                if (item.Name == product.Name)
                {
                    return;
                }
            }

            Stall.Add(product);
        }

        public bool RemoveProduct(string name)
        {
            foreach (var item in Stall)
            {
                if (item.Name == name)
                {
                    return Stall.Remove(item);
                }
            }

            return false;
        }

        public string SellProduct(string name, double quantity)
        {
            foreach (var item in Stall)
            {
                if (item.Name == name)
                {
                    double totalPrice = item.Price * quantity;
                    Turnover = Turnover + totalPrice;

                    return $"{item.Name} - {totalPrice:F2}$.".Trim();
                }
            }

            return "Product not found".Trim();
        }

        public string GetMostExpensive()
        {
            Product mostExpensiveProduct = Stall[0];

            foreach (var product in Stall)
            {
                if (product.Price > mostExpensiveProduct.Price)
                {
                    mostExpensiveProduct = product;
                }
            }

            return mostExpensiveProduct.ToString();
        }

        public string CashReport() => $"Total Turnover: {Turnover:F2}$".Trim();
        public string PriceList()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine("Groceries Price List:");
            output.AppendJoin("\r\n", Stall.Select(n => n.ToString()));

            return output.ToString().Trim();
        }
    }
}
