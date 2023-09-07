namespace SnackOrders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Dictionary<string, List<double>> products = new Dictionary<string, List<double>>();
            
            while (input[0] != "buy")
            {
                if (!products.ContainsKey(input[0]))
                {
                    products.Add(input[0], new List<double>());
                    products[input[0]].Add(double.Parse(input[1]));
                    products[input[0]].Add(double.Parse(input[2]));
                }
                else
                {
                    products[input[0]][0] = double.Parse(input[1]);
                    products[input[0]][1] += double.Parse(input[2]);
                }
                input = Console.ReadLine().Split();
            }

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Key} -> {(product.Value[0] * product.Value[1]):F2}");
            }
        }
    }
}