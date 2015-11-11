namespace TreeOfLife.Model
{
    public class Sephira : Entity
    {
        public Sephira(string id, int keyScale, int number, string name, string meaning) : base(id, keyScale, number)
        {
            Name = name;
            Meaning = meaning;
        }

        public string Name { get; set; }
        public string Meaning { get; set; }

        public override string ToString()
        {
            return $"{Number}. {Name} ({Meaning})";
        }
    }
}