namespace BattleManager
{
    public class PersonStats
    {
        public int Health { get; set; }
        public int Energy { get; set; }

        public PersonStats(int health, int energy)
        {
            Health = health;
            Energy = energy;
        }
    }
}
