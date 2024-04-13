using Vehicles.Core.Interfaces;
using Vehicles.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models.Interfaces;
using Vehicles.Models;
using Vehicles.Factories.Interfaces;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehicleFactory vehicleFactory;

        private readonly List<IVehicle> vehicles;
        public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;

            vehicles = new List<IVehicle>();
        }

        public void Run()
        {
            vehicles.Add(CreateVehicle());
            vehicles.Add(CreateVehicle());
            vehicles.Add(CreateVehicle());

            
            int commandsCount = int.Parse(reader.ReadLine());
            string[] input;

            for (int i = 0; i < commandsCount; i++)
            {
                input = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = input[0];
                string vehicleType = input[1];
                double distance = double.Parse(input[2]);

                try
                {
                    IVehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == vehicleType);

                    if (vehicle == null)
                    {
                        throw new ArgumentException("Invalid vehicle type");
                    }

                    switch (input[0])
                    {
                        case "Drive":
                            Console.WriteLine(vehicle.Drive(distance, true));
                            break;
                        case "DriveEmpty":
                            Console.WriteLine(vehicle.Drive(distance, false));
                            break;
                        case "Refuel":
                            double fuelAmount = double.Parse(input[2]);
                            vehicle.Refuel(fuelAmount);
                            break;
                        default:
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            foreach (IVehicle vehicle in vehicles)
            {
                Console.WriteLine(vehicle.ToString());
            }

        }

        public IVehicle CreateVehicle()
        {
            string[] input = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string type = input[0];
            double fuelQuantity = double.Parse(input[1]);
            double fuelConsumption = double.Parse(input[2]);
            int tankCapacity = int.Parse(input[3]);

            IVehicle vehicle = vehicleFactory.Create(type, fuelQuantity, fuelConsumption, tankCapacity);

            return vehicle;
        }
    }
}
