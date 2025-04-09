namespace Kitap.Models
{
    public class YayinEvi
    {
        public int Id { get; set; }
        public string Ad { get; set; }

        public ICollection<Kitapp>? Kitaplar { get; set; }
    }
}
