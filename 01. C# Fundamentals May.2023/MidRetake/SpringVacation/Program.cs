namespace SpringVacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int daysOfTrip = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());
            double pricePerKilometer = double.Parse(Console.ReadLine());
            double foodExpenses = double.Parse(Console.ReadLine()) * people;
            double roomsPricePerNight = double.Parse(Console.ReadLine()) * people;
            double currentExpenses = 0;

            if (people > 10)
            {
                currentExpenses += ((foodExpenses * daysOfTrip) + (roomsPricePerNight * daysOfTrip * 0.75));
            }
            else
            {
                currentExpenses += (foodExpenses * daysOfTrip) + roomsPricePerNight * daysOfTrip;
            }

            for (int i = 1; i <= daysOfTrip; i++)
            {
                int traveledKilometers = int.Parse(Console.ReadLine());
                currentExpenses += traveledKilometers * pricePerKilometer;
                if (i % 3 == 0 || i % 5 == 0)
                {
                    currentExpenses *= 1.4;
                }

                if (i % 7 == 0)
                {
                    currentExpenses -= (currentExpenses / people);
                }

                if (currentExpenses > budget)
                {
                    Console.WriteLine($"Not enough money to continue the trip. You need {(currentExpenses- budget):F2}$ more.");
                }
                
            }

            if (currentExpenses < budget)
            {
                Console.WriteLine($"You have reached the destination. You have {(budget - currentExpenses):F2}$ budget left.");
            }
        }
    }
}