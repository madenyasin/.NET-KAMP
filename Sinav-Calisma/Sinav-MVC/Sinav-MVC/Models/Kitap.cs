namespace Sinav_MVC.Models
{
    public class Kitap
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string?  Description { get; set; }

        public int YazarId { get; set; }
        public int YaynieviId { get; set; }
        public string UserId { get; set; }

        public Yazar? Yazar { get; set; }
        public Yayinevi? Yayinevi { get; set; }
        public ApplicationUser? User { get; set; }

        public ICollection<KitapKategori>? Kategoriler { get; set; }

    }
}
