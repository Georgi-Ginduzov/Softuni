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

        public double FuelQuantity { get; private set; }

        public double FuelConsumption { get; private set; }
        public int TankCapacity { get; set; }

        public string Drive(double distance)
        {
            double consumption = FuelConsumption + increasedConsumption;

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
                throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
            }
        }
    }
}
