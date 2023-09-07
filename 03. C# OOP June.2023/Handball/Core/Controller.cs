using Handball.Core.Contracts;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IPlayer> players;
        private readonly IRepository<ITeam> teams;

        public Controller()
        {
            this.players = new PlayerRepository();
            this.teams = new TeamRepository();
        }
        public string LeagueStandings()
        {
            throw new NotImplementedException();
        }

        public string NewContract(string playerName, string teamName)
        {
            throw new NotImplementedException();
        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            throw new NotImplementedException();
        }

        public string NewPlayer(string typeName, string name)
        {
            if (typeName == "Goalkeeper")
            {
                if (players.ExistsModel(name))
                {
                    return $"{name} is already added to the {this.teams.GetModel(name)} as {players.GetModel(name)}";
                }
                goal
            }
            else if (typeName == "CenterBack")
            {

            }
            else if(typeName == "ForwardWing")
            {
                
            }
            else
            {
                return $"{typeName} is invalid position for the application.";
            }
        }

        public string NewTeam(string name)
        {
            if (teams.ExistsModel(name))
            {
                return $"{name} is already added to the {this.teams.GetModel(name)}.";
            }
            else
            {
                return $"{name} is successfully added to the {this.teams.GetModel(name)}.";
            }
        }

        public string PlayerStatistics(string teamName)
        {
            throw new NotImplementedException();
        }
    }
}
