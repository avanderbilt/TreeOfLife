using System.ComponentModel.DataAnnotations;

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

        [Display(Name = "Sephira")]
        public string Name { get; set; }
        [Display(Name = "Sephira Meaning")]
        public string Meaning { get; set; }
        [Display(Name = "Sephira Number")]
        public int Number { get; }

        public override string ToString()
        {
            return $"{Number}. {Name} ({Meaning})";
        }
    }
}