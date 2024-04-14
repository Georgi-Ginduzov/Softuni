using BankLoan.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankLoan.Models
{
    public abstract class Bank : IBank
    {
        private string name;
        private int capacity;
        private List<ILoan> loans;
        private List<IClient> clients;
        
        public Bank(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            loans = new List<ILoan>();
            clients = new List<IClient>();
        }

        public string Name 
        { 
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    System.Console.WriteLine("Bank name cannot be null or empty.");
                }

                name = value;
            }
        }

        public int Capacity 
        { 
            get => capacity; 
            private set => capacity = value; 
        }

        public IReadOnlyCollection<ILoan> Loans => loans; // ;

        public IReadOnlyCollection<IClient> Clients => clients; // ;

        public void AddClient(IClient Client)
        {
            if (Clients.Count < Capacity)
            {
                clients.Add(Client);
            }
            else
            {
                throw new ArgumentException("Not enough capacity for this client.");
            }
        }

        public void AddLoan(ILoan loan)
        {
            loans.Add(loan);
        }

        public string GetStatistics()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Name: {Name}, Type: {GetType().Name}".Trim());
            output.AppendLine($"Clients: {String.Join(", ", Clients)}".Trim());
            output.AppendLine($"Loans: {Loans.Count}, Sum of Rates: {SumRates()}".Trim());
            return output.ToString();
        }

        public void RemoveClient(IClient Client)
        {
            IClient clientToRemove = Clients.FirstOrDefault(c => c == Client);
            clients.Remove(clientToRemove);            
        }

        public double SumRates()
        {
            return Loans.Sum(l => l.InterestRate);
        }
    }
}
