namespace GenericSwapMethod
{
    public  class Program
    {
        public static List<T> swapElements<T>(List<T> items, int[] indexes)
        {
            T buffer = items[indexes[0]];
            items[indexes[0]] = items[indexes[1]];
            items[indexes[1]] = buffer;

            return items;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> list = new List<int>();

            for (int i = 0; i < n; i++)
            {
                list.Add(int.Parse(Console.ReadLine()));
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            swapElements<int>(list, indexes);

            Type type = typeof(int);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(type + ": " + list[i]);
            }
            
        }
    }
}