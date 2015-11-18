using System.ComponentModel.DataAnnotations;

namespace TreeOfLife.Model
{
    public abstract class Entity
    {
        protected Entity(string id, int keyScale)
        {
            Id = id;
            KeyScale = keyScale;
        }

        public string Id { get; }

        [Display(Name = "Key Scale")]
        public int KeyScale { get; }
    }
}