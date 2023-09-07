namespace RegisterCompany_sEmployees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> employees = new Dictionary<string, List<string>>();
            string[] input = Console.ReadLine().Split(" -> ");

            while (input[0] != "End")
            {
                if (!employees.ContainsKey(input[0]))
                {
                    employees[input[0]] = new List<string>()
                    {
                        input[1]
                    };
                }
                else
                {
                    employees[input[0]].Add(input[1]);
                }

                input = Console.ReadLine().Split(" -> ");
            }

            foreach (var employee in employees)
            {
                Console.WriteLine(employee.Key);
                for (int i = 0; i < employee.Value.Count; i++)
                {
                    Console.WriteLine($"-- {employee.Value[i]}");
                }
            }
        }
    }
}