using System.ComponentModel.DataAnnotations;

namespace GrandLabFixers.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}