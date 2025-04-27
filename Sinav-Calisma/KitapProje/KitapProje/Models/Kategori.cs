namespace KitapProje.Models
{
    public class Kategori
    {
        public int Id { get; set; }
        public string Ad { get; set; }

        public ICollection<KitapKategori>? Kitaplar { get; set; } = new List<KitapKategori>();
    }
}
