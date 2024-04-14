namespace BankLoan.Models
{
    public class MortgageLoan : Loan
    {
        private const int InterestRate = 3;
        private const double Amount = 50_000;
        public MortgageLoan() : base(InterestRate, Amount)
        {
        }
    }
}
