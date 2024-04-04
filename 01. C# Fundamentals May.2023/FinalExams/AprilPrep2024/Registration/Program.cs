using System.Text;

namespace Registration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            StringBuilder username = new StringBuilder(input[0]);

            while (input[0] != "Registration")
            {
                switch (input[0])
                {
                    case "Letters":
                        if (input[1] == "Lower")
                        {
                            for (int i = 0; i < username.Length; i++)
                            {
                                username[0] = char.ToLower(username[0]);
                            }
                        }
                        else if (input[1] == "Upper")
                        {
                            for (int i = 0; i < username.Length; i++)
                            {
                                username[0] = char.ToUpper(username[0]);
                            }
                        }
                        Console.WriteLine(username);
                    break;

                    case "Reverse":
                        int startIndex = int.Parse(input[1]);
                        int endIndex = int.Parse(input[2]);

                        if (startIndex < 0 || endIndex >= username.Length)
                        {
                            continue;
                        }

                        char[] charArrayUsername = new char[endIndex - startIndex +1];
                        int j = 0;
                        for (int i = startIndex; i < endIndex+1; i++)
                        {
                            charArrayUsername[j++] = username[i];
                        }
                        Array.Reverse(charArrayUsername);

                        Console.WriteLine(charArrayUsername);
                    break;

                    case "Substring":
                        string substring = input[1];
                        string tempUsername = username.ToString();

                        if (tempUsername.Contains(substring))
                        {
                            username = username.Replace(substring, "");
                            Console.WriteLine(username);
                        }
                        else
                        {
                            Console.WriteLine($"The username {username} doesn't contain {substring}.");
                        }
                        break;

                     case "Replace":
                        char charToReplace = char.Parse(input[1]);

                        username.Replace(charToReplace, '-');
                        username = username.Replace(charToReplace, '-');

                        Console.WriteLine(username);
                        break;

                    case "IsValid":
                        char charToContain = char.Parse(input[1]);
                        tempUsername = username.ToString();

                        if (tempUsername.Contains(charToContain))
                        {
                            Console.WriteLine("Valid username.");
                        }
                        else
                        {
                            Console.WriteLine($"{charToContain} must be contained in your username.");
                        }
                        break;

                    default:
                        break;
                }

                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
