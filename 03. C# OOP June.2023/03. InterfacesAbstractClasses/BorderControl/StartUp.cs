using E04._BorderControl.Core;
using E04._BorderControl.Core.Interfaces;
using E04._BorderControl.IO;
using E04._BorderControl.IO.Interfaces;

namespace BorderControl
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine(new ConsoleReader(), new ConsoleWriter());

            engine.Run();
        }
    }
}