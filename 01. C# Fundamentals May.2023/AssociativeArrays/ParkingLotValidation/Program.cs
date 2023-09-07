namespace ParkingLotValidation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] input;
            Dictionary<string, string> users = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine().Split();
                string username = input[1];

                if (input[0] == "register")
                {
                    string plateNumber = input[2];
                    
                    if (!users.ContainsKey(username))
                    {
                        users[username] = plateNumber;
                        Console.WriteLine($"{username} registered {plateNumber} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {users[username]}");
                    }
                }
                else if (input[0] == "unregister")
                {
                    if (!users.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                    else
                    {
                        users.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                }
                
            } 

            foreach (var product in users)
            {
                Console.WriteLine($"{product.Key} => {product.Value}");
            }
        }
    }
}