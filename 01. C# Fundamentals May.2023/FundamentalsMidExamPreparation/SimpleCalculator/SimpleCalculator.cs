namespace SimpleCalculator
{
    internal class SimpleCalculator
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Stack<string> equation = new Stack<string>(input.Reverse());
            
            int sum = int.Parse(equation.Pop());
            
            //int number = int.Parse(equation.Pop());
            while (equation.Any())
            {
                
                if (equation.Peek() == "+")
                {
                    equation.Pop();
                    sum += int.Parse(equation.Pop());
                }
                else if (equation.Peek() == "-")
                {
                    equation.Pop();
                    sum -= int.Parse(equation.Pop());
                }
            }
            Console.WriteLine(sum);
        }
    }
}