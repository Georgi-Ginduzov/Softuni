int n = int.Parse(Console.ReadLine());

List<string> productsList = new List<string>();

for (int i = 0; i < n; i++)
{
    productsList.Add(Console.ReadLine());
}

productsList.Sort();
for (int i = 0;i < productsList.Count;i++)
{
    Console.WriteLine((i + 1) + "." + productsList[i]);
}
