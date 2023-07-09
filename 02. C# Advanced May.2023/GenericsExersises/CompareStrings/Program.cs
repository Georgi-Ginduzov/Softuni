namespace CompareStrings
{
    public class Program
    {
        public static int compareItems<T>(List<T> items, T compareWith) where T : IComparable<T>
        {
            int count = 0;
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].CompareTo(compareWith) == 1)
                {
                    count++;
                }
            }
            return count;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> items = new List<string>();

            for (int i = 0; i < n; i++)
            {
                items.Add(Console.ReadLine());
            }

            string toCompare = Console.ReadLine();

            Console.WriteLine(compareItems<string>(items, toCompare));

        }
    }
}