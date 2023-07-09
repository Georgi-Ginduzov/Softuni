List<double> numbers = Console.ReadLine()
    .Split(' ')
    .Select(double.Parse)
    .ToList();

for (int i = 0; i < numbers.Count / 2; i++)
{
    double first = numbers[i], last = numbers[numbers.Count - i - 1];
    numbers[i] = first + last;
}

for (int i = 0; i < numbers.Count / 2;i++)
{
    Console.Write(numbers[i] + " ");
}
if (numbers.Count % 2 == 1)
{
    Console.WriteLine(numbers[numbers.Count / 2]);
}