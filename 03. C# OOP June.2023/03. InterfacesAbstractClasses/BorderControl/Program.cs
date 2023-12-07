using E04._BorderControl.Core;
using E04._BorderControl.Core.Interfaces;

namespace BorderControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();

            engine.Run();
        }
    }
}