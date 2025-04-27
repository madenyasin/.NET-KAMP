namespace Sinav_MVC.Models
{
    public class Yayinevi
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }

        public ICollection<Kitap>? Kitaplar { get; set; }
    }
}
