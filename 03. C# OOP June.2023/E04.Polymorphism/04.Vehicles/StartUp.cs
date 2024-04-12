﻿using Vehicles.Core;
using Vehicles.Core.Interfaces;
using Vehicles.IO;

namespace Vehicles
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
