using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ComputerStoreReceipts
{
    internal class ComputerStoreReceipts
    {
        static void Main()
        {
            string input = Console.ReadLine();
            double sumWithoutTaxes = 0, totalTaxes = 0, total = 0;
            List<double> taxes = new List<double>();
         
            while (input != "special" || input != "regular")
            {
                double number = double.Parse(input);
                if (number > 0)
                {
                    sumWithoutTaxes += number;
                    totalTaxes += number * 0.2;
                    taxes.Add(number * 0.2);
                    total += (number + (number * 0.2));
                    
                    
                }
                else
                {
                    Console.WriteLine("Invalid price!");
                }
                input = Console.ReadLine();
            }
            
            if (input == "special")
            {
                totalTaxes = 0;
                total = sumWithoutTaxes;
                for (int i = 0; i < taxes.Count; i++)
                {
                    taxes[i] = taxes[i] - taxes[i] * 0.1;
                    totalTaxes += taxes[i];
                    total += totalTaxes;
                }
            }

            Console.WriteLine("Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {sumWithoutTaxes}$");
            Console.WriteLine($"Taxes: {totalTaxes}$");
            Console.WriteLine("-----------");
            Console.WriteLine($"Total price: {total}$");
        }
    }
}