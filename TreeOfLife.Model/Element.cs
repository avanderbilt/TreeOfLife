using System.ComponentModel.DataAnnotations;

namespace TreeOfLife.Model
{
    public class Element : Entity
    {
        [Display(Name = "Element")]
        public string Name { get; set; }
        [Display(Name = "Element Symbol")]
        public string Symbol { get; set; }

        public Element(string id, int keyScale, string name, string symbol) : base(id, keyScale)
        {
            Name = name;
            Symbol = symbol;
        }
        public override string ToString()
        {
            return $"{Symbol} {Name}";
        }
    }
}