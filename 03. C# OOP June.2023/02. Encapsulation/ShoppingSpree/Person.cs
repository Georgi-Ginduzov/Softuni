namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private int money;
        public List<Products> BagOfProducts = new List<Products>();

        public Person(string name, int money)
        {
            this.Name = name;
            this.Money = money;
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
        public int Money 
        { 
            get
                => money;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative.");
                }
                money = value;
            }
        }

        public void AddProduct(Products product, Person person)
        {
            if (product.Cost > person.Money)
            {
                Console.WriteLine($"{person.Name} can't afford {product.Name}");
            }
            else
            {
                BagOfProducts.Add(product);
                person.Money -= product.Cost;
            }
        }

    }
}
