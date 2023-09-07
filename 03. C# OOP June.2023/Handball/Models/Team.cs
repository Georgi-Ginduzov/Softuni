using Handball.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class Team : ITeam
    {
        private string name;
        private int pointsEarned;
        private double overallRating;

        public Team(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(name))
                {
                    throw new ArgumentException("Team name cannot be null or empty.");
                }
                name = value;
            }
        }

        public int PointsEarned
        {
            get => pointsEarned;
            private set => pointsEarned = value;
        }


        public double OverallRating
        {
            get => overallRating;
            protected set {
            
                if (!Players.Any())
                {
                    return;
                }
                else
                {
                    double totalRating = Players.Sum(player => player.Rating);
                    overallRating = totalRating / Players.Count;
                    OverallRating = overallRating;
                }            
            }

        }

        public IReadOnlyCollection<IPlayer> Players { get; private set; }

        public void Draw()
        {
            this.PointsEarned++;
            foreach (Goalkeeper player in Players)
            {
                player.IncreaseRating();
            }
        }

        public void Lose()
        {
            foreach (var player in Players)
            {
                player.DecreaseRating();
            }
        }

        public void SignContract(IPlayer player)
        {
            Players = Players.Append(player).ToList();
        }

        public void Win()
        {
            this.PointsEarned += 3;
            foreach (var player in Players)
            {
                player.IncreaseRating();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Team: {Name} Points: {PointsEarned}");
            sb.AppendLine($"--Overall rating: {OverallRating}");
            sb.AppendLine($"--Players: {string.Join(", ", Players)}");

            return sb.ToString();
        }
    }
}
