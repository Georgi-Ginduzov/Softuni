using Handball.Models.Contracts;
using System;
using System.Text;

namespace Handball.Models
{
    public abstract class Player : IPlayer
    {
        private string name;
        private double rating;
        private string team;

        public Player(string name, double rating)
        {
            this.name = name;
            this.rating = rating;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(name))
                {
                    throw new ArgumentException("Player name cannot be null or empty.");
                }
                name = value;
            }
        }

        public double Rating
        {
            get => rating;
            protected set
            {
                rating = value;
            }
        }

        public string Team
        {
            get => team;
            protected set
            {
                team = value;
            }
        }

        abstract public void DecreaseRating();
        abstract public void IncreaseRating();

        public void JoinTeam(string name)
        {
            this.Team = name;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{this.GetType}: {Name}");
            stringBuilder.AppendLine($"--Rating: {Rating}");
            return stringBuilder.ToString();
        }
    }
}
