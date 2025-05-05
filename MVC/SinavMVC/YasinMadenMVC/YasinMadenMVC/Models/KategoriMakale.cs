namespace YasinMadenMVC.Models
{
    public class KategoriMakale
    {
        public int MakaleId { get; set; }
        public int KategoriId { get; set; }

        public Makale? Makale { get; set; }
        public Kategori? Kategori { get; set; }
    }
}
