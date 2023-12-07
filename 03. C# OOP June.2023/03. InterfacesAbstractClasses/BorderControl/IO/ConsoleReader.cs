using E04._BorderControl.IO.Interfaces;

namespace E04._BorderControl.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        => Console.ReadLine();
    }
}
