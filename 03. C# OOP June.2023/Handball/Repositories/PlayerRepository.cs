using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private List<IPlayer> models;
        
        public IReadOnlyCollection<IPlayer> Models => models;

        public void AddModel(IPlayer model)
        {
            models.Add(model);
        }

        public bool ExistsModel(string name) 
        {
            foreach (var model in models)
            {
                if (model.Name == name) return true;
            }

            return false;        
        }

        public IPlayer GetModel(string name)
        {
            if (!ExistsModel(name)) return null;
            else
            {
                return this.models.FirstOrDefault(model => model.Name == name);
            }
        }

        public bool RemoveModel(string name)
        {
            var member = this.GetModel(name);
            return this.models.Remove(member);
        }
    }
}
