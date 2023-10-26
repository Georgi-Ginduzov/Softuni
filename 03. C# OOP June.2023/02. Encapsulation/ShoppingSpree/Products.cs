namespace ShoppingSpree
{
    public class Products
    {
        private string name;
        private int cost;

        public Products(string name, int cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name 
        {
            get
                => name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty.");
                }
                name = value;
            }
        }
        public int Cost 
        {
            get
                => cost;
            set
            {
                if (cost < 0)
                {
                    throw new ArgumentException("Cost cannot be negative.");
                }
                cost = value;
            }
        }
    }
}
