namespace ResaourceQuantity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string material = Console.ReadLine();
            int quantity;
            Dictionary<string, int> resources = new Dictionary<string   , int>();

            while (material != "stop")
            {
                quantity = int.Parse(Console.ReadLine());

                if (!resources.ContainsKey(material))
                {
                    resources[material] = quantity;
                }
                else
                {
                    resources[material] += quantity;
                }
                
                material = Console.ReadLine();
            }   

            foreach (var resource in resources)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}