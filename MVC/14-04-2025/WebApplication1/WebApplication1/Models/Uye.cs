namespace WebApplication1.Models
{
    public class Uye
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }

        public ICollection<Arac>? EkledigiAraclar { get; set; }
    }
}
