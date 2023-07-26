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
                try
                {
                    if (value.Length < 3)
                    {
                        throw new StackOverflowException();
                    }
                    else
                    {
                        firstName = value;
                    }
                }
                catch (StackOverflowException)
                {
                    Console.WriteLine("First name cannot contain fewer than 3 symbols!");
                }                
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
                try
                {
                    if (value.Length < 3)
                    {
                        throw new StackOverflowException();
                    }
                    else
                    {
                        lastName = value;
                    }
                }
                catch (StackOverflowException)
                {
                    Console.WriteLine("Last name cannot contain fewer than 3 symbols!");
                }
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
                try
                {
                    if (value <= 0)
                    {
                        throw new StackOverflowException();
                    }
                    else
                    {
                        age = value;
                    }
                }
                catch (StackOverflowException)
                {
                    Console.WriteLine("Age cannot be zero or a negative integer!");
                }
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
                try
                {
                    if (value < 650)
                    {
                        throw new StackOverflowException();
                    }
                    else
                    {
                        salary = value;
                    }
                }
                catch (StackOverflowException)
                {
                    Console.WriteLine("Salary cannot be less than 650 leva!");
                }
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
