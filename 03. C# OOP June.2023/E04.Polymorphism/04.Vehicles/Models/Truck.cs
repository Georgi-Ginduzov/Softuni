﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double IncreasedConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, int tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity, IncreasedConsumption)
        {
        }

        public override void Refuel(double amount)
        {
            if (amount <= 0)
            {
                base.Refuel(amount);
            }
            base.Refuel(amount * 0.95);
        
        }
    }
}