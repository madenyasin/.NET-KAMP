namespace WebApplication3.Models
{
    public class Kategori
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }

        public ICollection<Haber>? Haberler { get; set; }
    }
}
