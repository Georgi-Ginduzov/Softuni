using BankLoan.Core.Contracts;
using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories;
using BankLoan.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;

namespace BankLoan.Core
{
    public class Controller : IController
    {
        private LoanRepository loans;
        private BankRepository banks;

        public Controller()
        {
            this.loans = new();
            this.banks = new();
        }

        public string AddBank(string bankTypeName, string name)
        {
            switch (bankTypeName)
            {
                case "CentralBank":
                    banks.AddModel(new CentralBank(name));
                    return $"{bankTypeName} is successfully added.";
                case "BranchBank":
                    banks.AddModel(new BranchBank(name));
                    return $"{bankTypeName} is successfully added.";
                default:
                    return "Invalid bank type";
            }
        }

        public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
        {
            IBank bank = banks.FirstModel(bankName);
            
            switch (clientTypeName)
            {
                case "Student":
                    if (bank.GetType().Name != "BranchBank")
                    {
                        return "Unsuitable bank.";
                    }
                    
                    bank.AddClient(new Student(clientName, id, income));
                    
                    return $"{clientTypeName} successfully added to {bankName}.";
                case "Adult":
                    if (bank.GetType().Name != "CentralBank")
                    {
                        return "Unsuitable bank.";
                    }

                    bank.AddClient(new Student(clientName, id, income));

                    return $"{clientTypeName} successfully added to {bankName}.";
                default:
                    throw new ArgumentException($"Invalid client type.");
            }
        }

        public string AddLoan(string loanTypeName)
        {
            switch (loanTypeName)
            {
                case "StudentLoan":
                    loans.AddModel(new StudentLoan());
                    return $"{loanTypeName} is successfully added.";
                case "MortgageLoan":
                    loans.AddModel(new MortgageLoan());
                    return $"{loanTypeName} is successfully added.";
                default:
                    return $"Invalid loan type.";
            }
        }

        public string FinalCalculation(string bankName)
        {
            IBank bank = banks.FirstModel(bankName);
            
            double totalIncome = bank.Clients.Sum(c => c.Income);
            double totalLoans = bank.Loans.Sum(l => l.Amount);
            double funds = totalIncome + totalLoans;
            
            return $"The funds of bank {bankName} are {funds:F2}.";
        }

        public string ReturnLoan(string bankName, string loanTypeName)
        {
            ILoan loan= loans.FirstModel(loanTypeName);

            if (loan == null)
            {
                throw new ArgumentException($"Loan of type {loanTypeName} is missing.");
            }

            IBank bank = banks.FirstModel(bankName);

            try
            {
                bank.AddLoan(loan);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            loans.RemoveModel(loan);


            return $"{loanTypeName} successfully added to {bankName}.";
        }

        public string Statistics()
        {
            StringBuilder output = new StringBuilder();

            foreach (IBank bank in banks.Models)
            {
                output.AppendLine(bank.GetStatistics().Trim());
            }

            return output.ToString().Trim();
        }
    }
}
