using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private int horsePower;
        private double fuel;

        public Vehicle()
        {
            DefaultFuelConsumption = 1.25;
            FuelConsumption = DefaultFuelConsumption;
        }
        public Vehicle(int horsePower, double fuel) : this()
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public int HorsePower { get; set; }
        public double Fuel { get; set; }
        public virtual double FuelConsumption { get; set; }
        public double DefaultFuelConsumption { get; set; }

        public virtual void Drive(double kilometers)
        {
            Fuel -= (kilometers / 100) * FuelConsumption;
        }

    }
}
