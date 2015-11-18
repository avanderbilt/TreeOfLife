using System.ComponentModel.DataAnnotations;

namespace TreeOfLife.Model
{
    public class Planet : Entity
    {
        public Planet(string id, int keyScale, string name, char glyph) : base(id, keyScale)
        {
            Glyph = glyph;
            Name = name;
        }

        [Display(Name = "Planetary Glyph")]
        public char Glyph { get; set; }
        [Display(Name = "Planet")]
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Glyph} {Name}";
        }
    }
}