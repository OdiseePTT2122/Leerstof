namespace FrisdrankAutomaat
{
    public class Drink
    {
        double price;
        string name;

        public Drink(string name, double price)
        {
            this.Price = price;
            this.Name = name;
        }

        public double Price { get => price; private set => price = value; }
        public string Name { get => name; private set => name = value; }
    }
}
