using System.Collections.Generic;

namespace RecursiveStringCompare
{
    public class Program
    {
        int compareItems<T>(List<T> items, T compareWith) where T : IComparable<T>
        {
            int count = 0;
            int i = 0;
            while (items[i].CompareTo(compareWith) == 1)
            {
                count++;
            }
            if (i < items.Count - 1)
            {
                return compareItems<T>(List < T > items, compareWith);// To Do
            }
            return 0;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}