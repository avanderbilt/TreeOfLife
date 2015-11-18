using System.ComponentModel.DataAnnotations;

namespace TreeOfLife.Model
{
    public class HebrewLetter : Entity
    {
        public HebrewLetter(string id, int keyScale, char letter, int number, string name, string meaning) : base(id, keyScale)
        {
            Letter = letter;
            Name = name;
            Meaning = meaning;
            Number = number;
        }

        [Display(Name = "Hebrew Letter")]
        public char Letter { get; }
        [Display(Name = "Hebrew Letter Meaning")]
        public string Meaning { get; }
        [Display(Name = "Hebrew Letter Name")]
        public string Name { get; }
        [Display(Name = "Hebrew Letter Number")]
        public int Number { get; }

        public override string ToString()
        {
            return $"{Letter} {Name} ({Meaning})";
        }
    }
}