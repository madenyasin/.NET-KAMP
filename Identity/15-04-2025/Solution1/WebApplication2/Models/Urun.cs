namespace WebApplication2.Models
{
    public class Urun
    {

        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public decimal Fiyat { get; set; }
        public string Resim { get; set; }
        public string Aciklama { get; set; }

        public int UyeId { get; set; }
        public int KategoriId { get; set; }

        public Kategori? Kategori { get; set; }
        public Uye? Uye { get; set; }
    }
}
