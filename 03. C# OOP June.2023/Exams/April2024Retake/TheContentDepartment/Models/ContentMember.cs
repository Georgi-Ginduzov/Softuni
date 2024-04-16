using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheContentDepartment.Models
{
    public class ContentMember : TeamMember
    {
        public ContentMember(string name, string path) : base(name, path)
        {
            switch (path)
            {
                case "CSharp":
                case "Java":
                case "JavaScript":
                case "Python":
                break;
                default:
                throw new ArgumentException($"{path} path is not valid.".Trim());
            }
        }

        public override string ToString()
        {
            return $"{Name} - {Path} path. Currently working on {InProgress.Count} tasks.".Trim();
        }
    }
}
