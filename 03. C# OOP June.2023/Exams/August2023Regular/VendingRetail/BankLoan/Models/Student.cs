using System.Diagnostics;

namespace BankLoan.Models
{
    public class Student : Client
    {
        private const int InitialInterest = 2;
        public Student(string name, string id, double income) : base(name, id, InitialInterest, income)
        {
        }

        // This class will be only accepted in combination with BranchBank. For more clarity, see the AddClient command in the business logic section of this document.

        public override void IncreaseInterest() => this.Interest += 1;
        
    }
}
