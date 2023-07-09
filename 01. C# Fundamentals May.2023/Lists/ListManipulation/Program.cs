List<int> numbers = Console.ReadLine()
    .Split(' ')
    .Select(int.Parse)
    .ToList();

bool changes = false;
bool isEnd = false;
do
{
    string input = Console.ReadLine();
    string[] command = input.Split(' ');

    if (command[0] == "Add")
    {
        numbers.Add(int.Parse(command[1]));
        changes = true; 
    }
    else if (command[0] == "Remove")
    {
        numbers.Remove(int.Parse(command[1]));
        changes = true;
    }
    else if(command[0] == "RemoveAt")
    {
        numbers.RemoveAt(int.Parse(command[1]));
        changes = true;
    }
    else if (command[0] == "Insert")
    {
        numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
        changes = true;
    }
    else if (command[0] == "Contains")
    {
        if (numbers.Contains(int.Parse(command[1])) == true)
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No such number");
        }
    }
    else if (command[0] == "PrintEven")
    {
        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] % 2 == 0)
            {
                Console.Write(numbers[i] + " ");
            }
        }
        Console.WriteLine();
    }
    else if (command[0] == "PrintOdd")
    {
        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] % 2 == 1)
            {
                Console.Write(numbers[i] + " ");
            }
        }
        Console.WriteLine();
    }
    else if (command[0] == "GetSum")
    {
        int sum = 0;
        for (int i = 0; i < numbers.Count; i++)
        {
            sum += numbers[i];
        }
        Console.WriteLine(sum);
    }
    else if (command[0] == "Filter")
    {
        if (command[1] == "<")
        {
            int max = int.Parse(command[2]);
            for (int i = 0; i < numbers.Count; i++)
            {
                if (max > numbers[i])
                {
                    Console.Write(numbers[i] + " ");
                }
            }
        }
        else if (command[1] == "<=")
        {
            int max = int.Parse(command[2]);
            for (int i = 0; i < numbers.Count; i++)
            {
                if (max >= numbers[i])
                {
                    Console.Write(numbers[i] + " ");
                }
            }
        }
        else if (command[1] == ">")
        {
            int min = int.Parse(command[2]);
            for (int i = 0; i < numbers.Count; i++)
            {
                if (min < numbers[i])
                {
                    Console.Write(numbers[i] + " ");
                }
            }
        }
        else if (command[1] == ">=")
        {
            int min = int.Parse(command[2]);
            for (int i = 0; i < numbers.Count; i++)
            {
                if (min <= numbers[i])
                {
                    Console.Write(numbers[i] + " ");
                }
            }
        }

    }
    else if (input == "end")
    {
        isEnd = true;
    }
} while (isEnd == false);

if (changes == true)
{
    for (int i = 0; i < numbers.Count; i++)
    {
        Console.Write(numbers[i] + " ");
    }
}