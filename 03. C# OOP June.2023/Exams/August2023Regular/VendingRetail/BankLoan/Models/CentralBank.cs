namespace BankLoan.Models
{
    public class CentralBank : Bank
    {
        private const int Capacity = 50;
        public CentralBank(string name) : base(name, Capacity)
        {
        }
    }
}
