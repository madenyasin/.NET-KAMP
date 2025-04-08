namespace WebApplication2.Models.ViewModels
{
    public class UrunDetayVM
    {
        public int UrunId { get; set; }

        public string UrunAdi { get; set; } = null!;

        public string KategoriAdi { get; set; }

        public decimal Fiyat { get; set; }

        public string Resim { get; set; } = null!;

        public string Aciklama { get; set; } = null!;
    }
}
