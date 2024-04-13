using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double increasedConsumption;
        protected Vehicle(double fuelQuantity, double fuelConsumption, int tankCapacity, double increasedConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;
            this.increasedConsumption = increasedConsumption;
        }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; private set; }
        public int TankCapacity { get; set; }

        public string Drive(double distance, bool isIncreasedConsumption = true)
        {
            double consumption = isIncreasedConsumption ? FuelConsumption + increasedConsumption : FuelConsumption;

            if (FuelQuantity < consumption * distance)
            {
                throw new ArgumentException($"{GetType().Name} needs refueling");
            }

            FuelQuantity -= consumption * distance;
            return $"{GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double amount) {
            if (amount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            else if (amount + FuelQuantity > TankCapacity)
            {
                if (GetType().Name == "Truck")
                {
                    amount /= 0.95;
                }
                throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
            }

            FuelQuantity += amount;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:F2}";
        }
    }
}
