using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels.Login
{
    public class Register_VM
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string KullaniciAdi { get; set; }
        public string Eposta { get; set; }
        public string Sifre { get; set; }
        [Compare(nameof(Sifre))]
        public string SifreTekrar { get; set; }
    }
}
