using Microsoft.AspNetCore.Identity;

namespace WebApplication3.Models
{
    public class Haber
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Detay { get; set; }
        public string ResimYolu { get; set; }
        public DateTime EklendigiTarih { get; set; }
        public int UyeId { get; set; }
        public int KategoriId { get; set; }

        public Uye? Uye { get; set; }
        public Kategori? Kategori { get; set; }

    }
}
