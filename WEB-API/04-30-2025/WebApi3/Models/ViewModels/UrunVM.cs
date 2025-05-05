namespace WebApi3.Models.ViewModels
{
    public class UrunVM
    {
        public int UrunID { get; set; }
        public string? UrunAdi { get; set; }
        public decimal Fiyat { get; set; }
        public string? KategoriAdi { get; set; }
    }
}
