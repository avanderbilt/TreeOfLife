namespace TreeOfLife.Model
{
    public class Path : Entity
    {
        public Path(string id, int keyScale, int number, int from, int to) : base(id, keyScale)
        {
            From = from;
            To = to;
            Number = number;
        }

        public int From { get; set; }
        public int To { get; set; }
        public int Number { get; }

        public override string ToString()
        {
            return $"{Number}. {From}-{To}";
        }
    }
}