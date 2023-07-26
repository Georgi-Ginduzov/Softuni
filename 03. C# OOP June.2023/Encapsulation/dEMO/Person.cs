using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dEMO
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
                    Console.WriteLine(firstName.Length);
                    if (firstName.Length < 3)
                    {
                        throw new ArgumentException();
                    }
                    else
                    {
                        this.FirstName = value;
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("First name cannot contain fewer than 3 symbols!");
                }
            }
        }
        public string LastName
        {
            get
            {
                return this.LastName;
            }
            private set
            {
                try
                {
                    if (lastName.Length < 3)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        this.LastName = value;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Last name cannot contain fewer than 3 symbols!");
                }
            }
        }

        public int Age
        {
            get
            {
                return this.Age;
            }
            private set
            {
                try
                {
                    if (this.age <= 0)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        this.Age = value;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Age cannot be zero or a negative integer!");
                }
            }
        }
        public decimal Salary
        {
            get
            {
                return this.Salary;
            }
            private set
            {
                try
                {
                    if (this.salary < 650)
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Salary cannot be less than 650 leva!");
                }
            }
        }

        public decimal IncreaseSalary(decimal percentage)
        {
            if (Age < 30)
            {
                Salary += Salary * (percentage / 200);
            }
            else
            {
                Salary += Salary * (percentage / 100);
            }
            return Salary;
        }

        /* public override string ToString()
         {
             return ($"{FirstName} {LastName} receives {Salary:F2} leva.");
         }*/

    }
}
