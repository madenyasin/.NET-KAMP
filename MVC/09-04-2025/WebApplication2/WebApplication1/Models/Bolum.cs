namespace WebApplication1.Models
{
    public class Bolum
    {
        public int BolumId { get; set; }
        public int BolumAdi { get; set; }

        public ICollection<Personel>? Personeller { get; set; }
    }
}
