using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName 
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }
                
                this.firstName = value;                     
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }

                this.lastName = value;
            }
        }
            
        public int Age 
        {
            get
            {
                return this.age;
            } 
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }
                this.age = value;

            }
        }
        public decimal Salary 
        {
            get
            {
                return this.salary;
            }
            private set
            {
                if (value < 0)
                    {
                        throw new ArgumentException("Salary cannot be less than 650 leva!");
                    }
                this.salary = value;
            }
        }

        public decimal IncreaseSalary(decimal percentage)
        {
            if ( Age < 30)
            {
                Salary += Salary * (percentage / 200);
            }
            else
            {
                Salary += Salary * (percentage / 100);
            }
            return Salary;
        }

        public override string ToString()
        {
            return ($"{FirstName} {LastName} receives {Salary:F2} leva.");
        }

    }
}
