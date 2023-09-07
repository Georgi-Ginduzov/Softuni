namespace PaintingsNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> paintings = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string[] command = Console.ReadLine().Split();

            while (command[0] != "END")
            {
                switch (command[0])
                {
                    case "Insert":
                        break;
                    case "Switch":
                        break;
                    case "Hide":
                        if (paintings.Contains(int.Parse(command[1])))
                        {
                            paintings.Remove(int.Parse(command[1]));
                        }
                        break;
                    case "Reverse":
                        paintings.Reverse();
                        break;
                    default:
                        break;
                }
            }
            for (int i = 0; i < paintings.Count; i++)
            {
                Console.Write(paintings[i] + " ");
            }
        }
    }
}