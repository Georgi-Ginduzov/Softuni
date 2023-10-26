using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        public Car() : base()
        {
            DefaultFuelConsumption = 3;
            FuelConsumption = DefaultFuelConsumption;
        }
    }
}
