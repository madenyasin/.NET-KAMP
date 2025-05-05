namespace YasinMadenMVC.Models
{
    public class Makale
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public DateTime YayinlanmaTarihi { get; set; }
        public int UserId { get; set; }
        public AppUser? User { get; set; }

        public ICollection<KategoriMakale>? Kategoriler { get; set; } = new List<KategoriMakale>();

    }
}
