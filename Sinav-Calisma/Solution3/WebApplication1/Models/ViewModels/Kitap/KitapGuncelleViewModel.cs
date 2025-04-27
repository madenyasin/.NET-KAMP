namespace WebApplication1.Models.ViewModels.Kitap
{
    public class KitapGuncelleViewModel
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }
        public string Ozet { get; set; }
        public int SayfaSayisi { get; set; }

        public List<int> SeciliKategoriIdleri { get; set; } = new();
        public List<Kategori>? TumKategoriler { get; set; }
    }
}
