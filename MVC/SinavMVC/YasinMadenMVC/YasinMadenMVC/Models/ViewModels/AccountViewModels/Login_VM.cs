using System.ComponentModel.DataAnnotations;

namespace YasinMadenMVC.Models.ViewModels.AccountViewModels
{
    public class Login_VM
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
