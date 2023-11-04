using System.Security.Cryptography.X509Certificates;
using Telephony.IO.Interfaces;

namespace Telephony.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        => Console.ReadLine();
    }
}
