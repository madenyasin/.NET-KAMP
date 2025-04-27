namespace KitapProje.Models
{
    public class KitapKategori
    {
        public int KitapId { get; set; }
        public int KategoriId { get; set; }

        public Kitap? Kitap { get; set; }
        public Kategori? Kategori { get; set; }
    }
}
