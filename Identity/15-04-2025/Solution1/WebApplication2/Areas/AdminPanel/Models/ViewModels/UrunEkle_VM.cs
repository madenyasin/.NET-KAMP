namespace WebApplication2.Areas.AdminPanel.Models.ViewModels
{
    public class UrunEkle_VM
    {
        public string UrunAdi { get; set; }
        public decimal Fiyat { get; set; }
        public string Resim { get; set; }
        public string Aciklama { get; set; }

        public int UyeId { get; set; }
        public int KategoriId { get; set; }
    }
}
