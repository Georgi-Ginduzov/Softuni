namespace SquareRoot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());

            try
            {
                if (number < 0) {
                    throw new ArithmeticException();
                }

                number = Math.Sqrt(number);
                Console.WriteLine(number);
            }
            catch (ArithmeticException)
            {
                Console.WriteLine("Invalid number.");
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
