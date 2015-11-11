namespace TreeOfLife.Model
{
    public class SephiraPair
    {
        public Sephira From { get; set; }
        public Sephira To { get; set; }

        public override string ToString()
        {
            return $"from {From.Name} to {To.Name}";
        }
    }
}