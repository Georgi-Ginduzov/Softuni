using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CarManifacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;

        private Engine engine;
        private Tire[] tire; 

        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public Engine Engine { get; set; }
        public Tire[] Tire  { get; set; }

        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
        }
        public Car(string make, string model, int year) : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, 
            Engine engine, Tire[] tire) 
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tire = tire;
        }

        public void Drive(double distance)
        {
            if (this.FuelQuantity - (this.FuelConsumption * distance) >= 0)
            {
                this.FuelQuantity -= (this.FuelConsumption * distance);
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip");
            }
        }

        public string WhoAmI()
        {
            string output = $"Make: {this.Make}\nModel: {this.Model}\nYear: {this.Year}" +
                $"\nFuel: {this.FuelQuantity:F2}";
            
            return output;
        }
    }
}
