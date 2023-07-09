List<int> firstList = Console.ReadLine()
    .Split(' ')
    .Select(int.Parse)
    .ToList();

List<int> secondList = Console.ReadLine()
    .Split(' ')
    .Select(int.Parse)
    .ToList();

List<int> result = new List<int>();

int iterations;

if (firstList.Count > secondList.Count)
{
    iterations = secondList.Count;
    for (int i = 0; i < iterations; i++)
    {
        result.Add(firstList[i]);
        result.Add(secondList[i]);        
    }
    for (int i = secondList.Count; i < firstList.Count; i++)
    {
        result.Add(firstList[i]);
    }
}
else
{
    iterations = firstList.Count;
    for (int i = 0; i < iterations; i++)
    {
        result.Add(firstList[i]);
        result.Add(secondList[i]);
    }
    for (int i = firstList.Count; i < secondList.Count; i++)
    {
        result.Add(secondList[i]);
    }
}

for (int i = 0; i < result.Count; i++)
{
    Console.Write(result[i] + " ");
}