using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;

namespace TheContentDepartment.Models
{
    public abstract class Resource : IResource
    {
        private string name;
        private string creator;
        private int priority;
        private bool isTested;
        private bool isApproved;

        protected Resource(string name, string creator, int priority)
        {
            Name = name;
            Creator = creator;
            Priority = priority;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace.");
                }
                name = value;
            }
        }
        public string Creator { get => creator; private set => creator = value; }

        public int Priority { get => priority; private set => priority = value; }

        public bool IsTested { get => isTested; private set => isTested = value; }

        public bool IsApproved { get => isApproved; private set => isApproved = value; }

        public void Approve()
        {
            IsApproved = true;
        }

        public void Test()
        {
            IsTested = !IsTested;
        }

        public override string ToString()
        {
            return $"{Name} ({GetType().Name}), Created By: {Creator}".Trim();
        }
    }
}
