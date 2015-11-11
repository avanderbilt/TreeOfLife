namespace TreeOfLife.Model
{
    public abstract class Entity
    {
        protected Entity(string id, int keyScale, int number)
        {
            Id = id;
            KeyScale = keyScale;
            Number = number;
        }

        public string Id { get; }
        public int KeyScale { get; }
        public int Number { get; }
    }
}