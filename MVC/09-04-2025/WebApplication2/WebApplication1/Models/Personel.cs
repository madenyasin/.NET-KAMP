using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace WebApplication1.Models
{
    public class Personel
    {
        public int PersonelId { get; set; }
        [Required, StringLength(10)]
        public string Ad { get; set; }
        [Required]
        [MinLength(3), MaxLength(10)]
        public string Soyad { get; set; }
        public string EPostaAdresi { get; set; }
        public string Adres { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        [Range(12,99)]
        public int Yas { get; set; }
        public decimal Maas { get; set; }
        public string Telefon { get; set; }
        public string TcKimlikNo { get; set; }

        public Bolum? Bolum { get; set; }
    }
}
