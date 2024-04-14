namespace BankLoan.Models
{
    public class Adult : Client // 
    {
        private const int InitialInterest = 4;
        public Adult(string name, string id, double income) : base(name, id, InitialInterest, income)
        {
        }

        // This class will be only accepted in combination with BranchBank. For more clarity, see the AddClient command in the business logic section of this document.

        public override void IncreaseInterest() => this.Interest += 2;
    }
}
