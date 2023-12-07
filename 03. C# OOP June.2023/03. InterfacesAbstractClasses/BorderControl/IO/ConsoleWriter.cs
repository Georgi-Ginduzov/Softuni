using E04._BorderControl.IO.Interfaces;

namespace E04._BorderControl.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string line)
        => Console.WriteLine(line);
    }
}
