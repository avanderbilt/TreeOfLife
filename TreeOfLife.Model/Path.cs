namespace TreeOfLife.Model
{
    public class Path : Entity
    {
        public Path(string id, int keyScale, int number, int from, int to) : base(id, keyScale, number)
        {
            From = from;
            To = to;
        }

        public int From { get; set; }
        public int To { get; set; }

        public override string ToString()
        {
            return $"{Number}. {From}-{To}";
        }
    }
}