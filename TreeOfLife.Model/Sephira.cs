namespace TreeOfLife.Model
{
    public class Sephira : Entity
    {
        public Sephira(string id, int keyScale, int number, string name, string meaning) : base(id, keyScale)
        {
            Name = name;
            Meaning = meaning;
            Number = number;
        }

        public string Name { get; set; }
        public string Meaning { get; set; }
        public int Number { get; }

        public override string ToString()
        {
            return $"{Number}. {Name} ({Meaning})";
        }
    }
}