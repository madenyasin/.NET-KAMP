using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.VM.Login
{
    public class Login_VM
    {
        [Required(ErrorMessage = "Kullanıcı adı boş olamaz!")]
        public string KullaniciAdi { get; set; }
        [Required(ErrorMessage = "Kullanıcı adı boş olamaz!")]

        public string Sifre { get; set; }
        [Required(ErrorMessage = "Kullanıcı adı boş olamaz!")]

        public string SifreTekrar { get; set; }
    }
}
