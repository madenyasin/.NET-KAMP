namespace Sinav_MVC.Models
{
    public class Kategori
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<KitapKategori>? Kitaplar { get; set; }
    }
}
