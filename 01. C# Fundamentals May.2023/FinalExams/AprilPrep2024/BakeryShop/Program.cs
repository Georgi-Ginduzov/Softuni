namespace BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shop bakery = new Shop();
            string[] input = Console.ReadLine().Split(' ');

            while (input[0] != "Complete")
            {
                int quantity = int.Parse(input[1]);
                string item = input[2];

                switch (input[0])
                {
                    case "Receive":
                        bakery.receiveItem(quantity, item);
                        break;
                    case "Sell":
                        bakery.sellItem(quantity, item);
                        break;
                }

                input = Console.ReadLine().Split(' ');
            }

            bakery.printStockAvailability();
            Console.WriteLine($"All sold: {bakery.Soldstock} goods");
        }
    }
}
