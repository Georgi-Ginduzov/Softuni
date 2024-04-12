using Vehicles.Core.Interfaces;
using Vehicles.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models.Interfaces;
using Vehicles.Models;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string[] input = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            IVehicle car = new Car(double.Parse(input[1]), double.Parse(input[2]));

            input = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            IVehicle truck = new Truck(double.Parse(input[1]), double.Parse(input[2]));

            int commandsCount = int.Parse(reader.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                input = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                switch (input[0])
                {
                    case "Drive":
                        try
                        {
                            if (input[1] == "Car")
                            {
                                Console.WriteLine(car.Drive(double.Parse(input[2])));
                            }
                            else if (input[1] == "Truck")
                            {
                                Console.WriteLine(truck.Drive(double.Parse(input[2])));
                            }
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                        case "Refuel":
                            try
                            {
                                if (input[1] == "Car")
                                {
                                    car.Refuel(double.Parse(input[2]));
                                }
                                else if (input[1] == "Truck")
                                {
                                    truck.Refuel(double.Parse(input[2]));
                                }
                            }
                            catch (ArgumentException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                    default:
                        break;
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
        }
    }
}
