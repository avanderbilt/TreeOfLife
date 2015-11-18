using System.ComponentModel.DataAnnotations;

namespace TreeOfLife.Web.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}