namespace WebApplication1.ViewModels.Kitap
{
    public class KitapEkle_VM
    {
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }
        public string Ozet { get; set; }
        public int SayfaSayisi { get; set; }
        public List<int> SecilenKategoriIdleri { get; set; }

    }
}
