using System.Linq;

namespace EnterNumbers
{
    internal class Program
    {
        static void ReadNumber(int start, int end)
        {
            List<int> validNumbers = new List<int>();
            int number = 1;

            while (validNumbers.Count < 10)
            {
                try
                {
                    number = int.Parse(Console.ReadLine().Trim());
                    
                    if (number <= start || number >= end)
                    {
                        throw new ArithmeticException();
                    }

                    validNumbers.Add(number);
                    start = number;
                }
                catch (ArithmeticException)
                {
                    Console.WriteLine($"Your number is not in range {start} - 100!");
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Number!");
                }
            }
            Console.WriteLine(String.Join(", ", validNumbers));
        }
        static void Main(string[] args)
        {
            ReadNumber(1, 100);
        }
    }
}
