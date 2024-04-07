using System.Text;

namespace TheImitationGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder message = new StringBuilder(Console.ReadLine());
            string[] command = Console.ReadLine().Split('|');

            while (command[0] != "Decode")
            {
                switch (command[0])
                {
                    case "Move":
                        int numberOfLetters = int.Parse(command[1]);
                        StringBuilder firstNLetters = new StringBuilder();

                        for (int i = 0; i < numberOfLetters; i++)
                        {
                            firstNLetters.Append(message[i]);
                            
                        }

                        message.Remove(0, numberOfLetters);
                        message.Append(firstNLetters.ToString());
                        break;

                    case "Insert":
                        int index = int.Parse(command[1]);
                        string value = command[2];

                        message.Insert(index, value);
                        break;

                    case "ChangeAll":
                        string substing = command[1];
                        string replacement = command[2];

                        message.Replace(substing, replacement);
                        break;

                    default:
                        break;
                }
                command = Console.ReadLine().Split('|');
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
