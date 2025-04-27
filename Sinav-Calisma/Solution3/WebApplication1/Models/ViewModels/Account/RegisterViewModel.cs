using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Ad")]
        public string Ad { get; set; }

        [Required]
        [Display(Name = "Soyad")]
        public string Soyad { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-posta")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Şifre (Tekrar)")]
        public string ConfirmPassword { get; set; }
    }
}
