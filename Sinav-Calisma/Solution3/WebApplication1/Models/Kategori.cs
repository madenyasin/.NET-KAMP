namespace WebApplication1.Models
{
    public class Kategori
    {
        public int Id { get; set; }
        public string Ad { get; set; }


        public ICollection<KitapKategori>? Kitaplar { get; set; }
    }
}
