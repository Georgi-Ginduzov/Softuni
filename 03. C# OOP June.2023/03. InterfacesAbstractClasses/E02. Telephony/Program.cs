using E02._Telephony;
string[] inputNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
string[] inputWebsites = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

ICallable phone = null;
IBrowsable smartphone = new Smartphone();

foreach (string number in inputNumbers)
{
    if (number.Length == 7)
    {
        phone = new StationaryPhone();
    }
    else if (number.Length == 10)
    {
        phone = new Smartphone();
    }

    try
    {
        Console.WriteLine(phone.Call(number));
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
}

foreach (string url in inputWebsites)
{
    try
    {
        Console.WriteLine(smartphone.Browse(url));
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
}