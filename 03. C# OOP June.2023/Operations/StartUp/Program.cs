namespace StartUp
{
    public class Program
    {
        static void Main(string[] args)
        {
            MathOperations operation = new MathOperations();

            Console.WriteLine(operation.Add(2, 3));
            Console.WriteLine(operation.Add(2.2, 3.3, 4.4));
            Console.WriteLine(operation.Add(2.3m, 3.2m, 4.3m));

        }
    }
}