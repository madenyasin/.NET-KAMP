namespace WebApplication2.Models.ViewModels
{
    public class UrunGuncelleVM
    {
        public int UrunId { get; set; }

        public string UrunAdi { get; set; } = null!;

        public int KategoriId { get; set; }

        public decimal Fiyat { get; set; }

        public string Resim { get; set; } = null!;
        public IFormFile ResimDosyasi { get; set; } = null!;

        public string Aciklama { get; set; } = null!;

    }
}
