using System.ComponentModel.DataAnnotations;

namespace TreeOfLife.Model
{
    public class ZodiacSign : Entity
    {
        public ZodiacSign(string id, int keyScale, string name, char glyph) : base(id, keyScale)
        {
            Glyph = glyph;
            Name = name;
        }

        [Display(Name = "Zodiacal Glyph")]
        public char Glyph { get; set; }
        [Display(Name = "Zodiac Sign")]
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Glyph} {Name}";
        }
    }
}