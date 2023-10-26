using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        public RaceMotorcycle() : base()
        {
            DefaultFuelConsumption = 8;
            FuelConsumption = DefaultFuelConsumption;
        }
    }
}
