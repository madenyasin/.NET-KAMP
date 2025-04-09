namespace Kitap.Models
{
    public class Yazar
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Biyografi { get; set; }

        public ICollection<Kitapp>? kitaplar { get; set; }
    }
}
