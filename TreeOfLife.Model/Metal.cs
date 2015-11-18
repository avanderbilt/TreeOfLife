using System.ComponentModel.DataAnnotations;

namespace TreeOfLife.Model
{
    public class Metal : Entity
    {
        [Display(Name = "Metal")]
        public string Name { get; set; }

        public Metal(string id, int keyScale, string name) : base(id, keyScale)
        {
            Name = name;
        }
    }
}