List<int> wagons = Console.ReadLine()
    .Split(' ')
    .Select(int.Parse)
    .ToList();

int wagonCapacity = int.Parse(Console.ReadLine());

bool inputEnd = false;
do
{
    string input = Console.ReadLine();
    string[] command = input.Split(' ');

    if (command[0] == "Add")
    {
        Console.WriteLine("Add: ");
        wagons.Add(int.Parse(command[1]));
        foreach (int wagon in wagons)
        {
            Console.Write(wagon + " ");
        }
        Console.WriteLine();
    }
    else if (command[0] == "end")
    {
        inputEnd = true;
    }
    else
    {
        int inputPassengers = int.Parse(command[0]);
        int i = 0;
        while (inputPassengers > 0)
        {
            wagons[i] += inputPassengers;
            if (wagons[i] > wagonCapacity)
            {
                inputPassengers -= wagons[i] - wagonCapacity;
                wagons[i] = wagonCapacity;
            }
        }
        i++;
    }
} while (inputEnd == false);

foreach (int wagon in wagons)
{
    Console.Write(wagon + " ");
}