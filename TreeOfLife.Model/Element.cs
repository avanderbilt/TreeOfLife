namespace TreeOfLife.Model
{
    public class Element : Entity
    {
        public string Name { get; set; }
        public string Symbol { get; set; }

        public Element(string id, int keyScale, string name, string symbol) : base(id, keyScale)
        {
            Name = name;
            Symbol = symbol;
        }
    }
}