namespace BankLoan.Models
{
    public class StudentLoan : Loan
    {
        private const int InterestRate = 1;
        private const double Amount = 10_000;
        public StudentLoan() : base(InterestRate, Amount)
        {
        }
    }
}
