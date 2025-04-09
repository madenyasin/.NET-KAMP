namespace Kitap.Models
{
    public class Kitapp
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }
        public string KapakResmi { get; set; }
        public string Ozet { get; set; }
        public int SayfaSayisi { get; set; }

        public int YayinEviId { get; set; }
        public int KategoriId { get; set; }
        public int YazarId { get; set; }



        public YayinEvi? YayinEvi { get; set; }
        public Kategori? Kategori { get; set; }
        public Yazar? Yazar { get; set; }
    }
}
