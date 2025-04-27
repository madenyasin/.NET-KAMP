using System.ComponentModel.DataAnnotations;

namespace KitapProje.Models.ViewModels.Account
{

    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "E-posta")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
    }

}
