using System;
using BankLoan.Models.Contracts;

namespace BankLoan.Models
{
    public abstract class Client : IClient
    {
        private string name;
        private string id;
        private int interest;
        private double income;

        public Client(string name, string id, int interest, double income)
        {
            Name = name;
            Id = id;
            Interest = interest;
            Income = income;
        }

        public string Name 
        { 
            get => name; 
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Client name cannot be null or empty.");
                }
                name = value;
            } 
        }

        public string Id 
        { 
            get => id;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Client’s ID cannot be null or empty.");
                }
                id = value;
            }
        }

        public int Interest 
        { 
            get => interest; 
            protected set => interest = value;
        }

        public double Income
        {
            get => income;
            private set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Income cannot be below or equal to 0.");
                }
                income = value;
            } 
        }

        public abstract void IncreaseInterest();
    }
}
