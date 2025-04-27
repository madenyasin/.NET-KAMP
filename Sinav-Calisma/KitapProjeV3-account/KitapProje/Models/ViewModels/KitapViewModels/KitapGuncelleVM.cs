namespace KitapProje.Models.ViewModels.KitapViewModels
{
    public class KitapGuncelleVM
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }
        public string Ozet { get; set; }
        public int SayfaSayisi { get; set; }
        public List<int> KategoriIdleri { get; set; }
    }
}
