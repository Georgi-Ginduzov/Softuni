using System.Diagnostics;

namespace Cars
{
    public interface IElectricCar : ICar
    {
        public int Battery { get; set; }
    }
}
