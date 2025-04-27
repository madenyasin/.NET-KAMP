namespace KitapProje.Models.ViewModels.KitapViewModels
{
    public class KitapListeleVM
    {
        public int Id { get; set; }

        public string Ad { get; set; }
        public decimal Fiyat { get; set; }
        public string Ozet { get; set; }
        public int SayfaSayisi { get; set; }
        public int UserId { get; set; }
        public string UserName{ get; set; }
        public List<string> Kategoriler{ get; set; }
    }
}
