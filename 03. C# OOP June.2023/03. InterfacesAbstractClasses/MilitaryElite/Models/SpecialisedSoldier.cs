using MilitaryElite.Enums;
using MilitaryElite.Models.Interfaces;
using System.Text;

namespace MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, Corps corps) 
            : base(id, firstName, lastName, salary)
        {
            Corps = corps;
        }

        public Corps Corps { get; private set; }

        public override string ToString()
        {
            StringBuilder stringBuilder= new StringBuilder();
            
            stringBuilder.AppendLine(base.ToString());

            //stringBuilder.AppendLine()

            return stringBuilder.ToString();
        }
    }
}
