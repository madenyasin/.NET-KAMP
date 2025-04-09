namespace WebApplication2.Models.ViewModels
{
    public class UrunEkleVM
    {
        public string UrunAdi { get; set; } = null!;

        public int KategoriId { get; set; }

        public decimal Fiyat { get; set; }

        public IFormFile ResimDosyasi { get; set; } = null!;

        public string Aciklama { get; set; } = null!;
    }
}
