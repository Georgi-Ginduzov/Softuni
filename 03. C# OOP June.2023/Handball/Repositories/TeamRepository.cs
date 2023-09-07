using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private List<ITeam> teams;
        public IReadOnlyCollection<ITeam> Models => teams;

        public void AddModel(ITeam team)
        {
            this.teams.Add(team);
        }

        public bool ExistsModel(string name)
        {
            foreach (var team in teams)
            {
                if (team.Name == name) return true;
            }

            return false;
        }

        public ITeam GetModel(string name)
        {
            if (!ExistsModel(name)) return null;
            else
            {
                return this.teams.FirstOrDefault(model => model.Name == name);
            }
        }

        public bool RemoveModel(string name)
        {
            var team = this.GetModel(name);
            return this.teams.Remove(team);
        }
    }
}
