namespace ValidUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ").Where(n => n.Length >= 3 && n.Length <= 16 && n.Contains("\b[A-Z]\\[a-b]\\[0-9][-_]\b")).ToArray();
            // to do -> while conditions write username
            foreach (string username in usernames)
            {
                Console.WriteLine(username);
            }
        }
    }
}