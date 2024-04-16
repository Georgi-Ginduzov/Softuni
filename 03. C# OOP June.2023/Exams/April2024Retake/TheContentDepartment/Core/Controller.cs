using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Core.Contracts;
using TheContentDepartment.Models;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories;

namespace TheContentDepartment.Core
{
    public class Controller : IController
    {
        private ResourceRepository resources;
        private MemberRepository members;

        public Controller()
        {
            resources = new ResourceRepository();
            members = new MemberRepository();
        }

        public string ApproveResource(string resourceName, bool isApprovedByTeamLead)
        {
            IResource resource = resources.TakeOne(resourceName);

            if (resource.IsTested == false)
            {
                return $"{resourceName} cannot be approved without being tested.";
            }

            ITeamMember teamLead = members.Models.First(t => t.GetType().Name == "TeamLead");
            if (isApprovedByTeamLead)
            {
                resource.Approve();
                teamLead.FinishTask(resourceName);
                return $"{teamLead.Name} approved {resourceName}.";
            }
            else
            {
                resource.Test();
                return $"{teamLead.Name} returned {resourceName} for a re-test.";
            }
        }

        public string CreateResource(string resourceType, string resourceName, string path)
        {
            switch (resourceType)
            {
                case "Exam":
                case "Workshop":
                case "Presentation":
                    break;
                default:
                    return $"{resourceType} type is not handled by Content Department.";
            }

            ITeamMember memberToBeAssignedTask = members.Models.First(); // Create a default member
            foreach (ITeamMember member in members.Models)
            {
                if (member.Path == path)
                {
                    memberToBeAssignedTask = member;
                }
            }

            if (memberToBeAssignedTask == null || memberToBeAssignedTask.GetType().Name == "TeamLead")
            {
                return $"No content member is able to create the {resourceName} resource.";
            }
            else
            {
                if (memberToBeAssignedTask.InProgress.Contains(resourceName))
                {
                    return $"The {resourceName} resource is being created.";
                }
            }

            switch (resourceType)
            {
                case "Exam":
                    IResource exam = new Exam(resourceName, memberToBeAssignedTask.Name);
                    memberToBeAssignedTask.WorkOnTask(resourceName);
                    resources.Add(exam);
                    break;
                case "Workshop":
                    IResource workshop = new Workshop(resourceName, memberToBeAssignedTask.Name);
                    memberToBeAssignedTask.WorkOnTask(resourceName);
                    resources.Add(workshop); 
                    break;
                case "Presentation":
                    IResource presentation = new Presentation(resourceName, memberToBeAssignedTask.Name);
                    memberToBeAssignedTask.WorkOnTask(resourceName);
                    resources.Add(presentation);
                    break;
                default:
                    break;
            }

            return $"{memberToBeAssignedTask.Name} created {resourceType} - {resourceName}.";
        }

        public string DepartmentReport()
        {
            StringBuilder report = new StringBuilder();

            report.AppendLine("Finished Tasks:");
            foreach (IResource resource in resources.Models.Where(r => r.IsApproved))
            {
                report.AppendLine("--" + resource.ToString());
            }

            report.AppendLine("Team Report:".Trim());
            ITeamMember teamLead = members.Models.First(t => t.GetType().Name == "TeamLead");
            report.AppendLine("--" + teamLead.ToString());
            foreach (ITeamMember member in members.Models.Where(m => m.GetType().Name == "ContentMember"))
            {
                report.AppendLine(member.ToString());
            }

            return report.ToString().Trim();
        }

        public string JoinTeam(string memberType, string memberName, string path)
        {
            switch (memberType)
            {
                case "TeamLead":
                case "ContentMember":
                    break;
                default:
                    return$"{memberType} is not a valid member type.";
            }

            foreach (ITeamMember member in members.Models)
            {
                if (member.Path == path)
                {
                    return "Position is occupied.";
                }
            }

            if (members.TakeOne(memberName) != null)
            {
                return $"{memberName} has already joined the team.";
            }

            if (memberType == "TeamLead")
            {
                members.Add(new TeamLead(memberName, path));
            }
            else
            {
                members.Add(new ContentMember(memberName, path));
            }

            return $"{memberName} has joined the team. Welcome!";
        }

        public string LogTesting(string memberName)
        {
            ITeamMember member = members.TakeOne(memberName);
            
            if (member == null)
            {
                return "Provide the correct member name.";
            }

            IResource highestPriorityNotTestedResource = new Presentation("da", "da");
            foreach (IResource resource in resources.Models)
            {
                if (resource.IsTested == false && resource.Priority < highestPriorityNotTestedResource.Priority && resource.Creator == memberName)
                {
                    highestPriorityNotTestedResource = resource;
                }
            }

            if (highestPriorityNotTestedResource.Creator != memberName || highestPriorityNotTestedResource.IsTested != false)
            {
                return $"{memberName} has no resources for testing.";                
            }

            ITeamMember teamLead = members.Models.First(t => t.GetType().Name == "TeamLead");
            member.FinishTask(highestPriorityNotTestedResource.Name);

            teamLead.WorkOnTask(highestPriorityNotTestedResource.Name);
            highestPriorityNotTestedResource.Test();

            return $"{highestPriorityNotTestedResource.Name} is tested and ready for approval.";
        }
    }
}
