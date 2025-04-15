using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ViewModels
{
    public class Register_VM
    {
        public string EPosta { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }

        [Compare("Sifre")]
        public string SifreTekrari { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Adres { get; set; }

    }
}
