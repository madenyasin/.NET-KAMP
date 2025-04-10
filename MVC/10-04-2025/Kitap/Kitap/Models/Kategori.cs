namespace Kitap.Models
{
    public class Kategori
    {
        public int Id { get; set; }
        public string Ad { get; set; }

        public ICollection<Kitapp>? Kitaplar { get; set; }

    }
}
