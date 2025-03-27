namespace WebApplication.Models
{
    public class Urun
    {
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public float Fiyat { get; set; }
        public override string ToString()
        {
            return $"id: {UrunID}, ad: {UrunAdi}, fiyat: {Fiyat}";
        }
    }
}
