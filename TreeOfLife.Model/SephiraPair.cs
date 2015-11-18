using System.ComponentModel.DataAnnotations;

namespace TreeOfLife.Model
{
    public class SephiraPair
    {
        [Display(Name = "Sephira From")]
        public Sephira From { get; set; }
        [Display(Name = "Sephira To")]
        public Sephira To { get; set; }

        public override string ToString()
        {
            return $"from {From.Name} to {To.Name}";
        }
    }
}