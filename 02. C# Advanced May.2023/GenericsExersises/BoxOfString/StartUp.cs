namespace BoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Box<int>[] items = new Box<int>[n];

            for (int i = 0; i < n; i++)
            {
                items[i] = new Box<int>(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(items[i]);
            }
        }
    }
}