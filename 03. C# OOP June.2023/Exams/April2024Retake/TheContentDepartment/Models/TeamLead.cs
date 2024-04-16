using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheContentDepartment.Models
{
    public class TeamLead : TeamMember
    {
        public TeamLead(string name, string path) : base(name, path)
        {
            if (path != "Master")
            {
                throw new ArgumentException($"{path} path is not valid.".Trim());
            }
        }

        public override string ToString()
        {
            return $"{Name} ({GetType().Name}) - Currently working on {InProgress.Count} tasks.".Trim();
        }
    }
}
