namespace YasinMadenMVC.Models
{
    public class Kategori
    {
        public int Id { get; set; }
        public string Ad { get; set; }

        public ICollection<KategoriMakale>? Makaleler { get; set; } = new List<KategoriMakale>();
    }
}
