using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Person
    {
        public string name;
        public uint age;

        public string Name { get; set; }
        public uint Age { get; set; }

        public Person()
        {
            this.Name = name;
            this.Age = age;
        }
        public Person(string name, uint ages) : this()
        {
            Name = name;
            Age = ages;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }

    }
}
