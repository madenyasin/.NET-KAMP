using System.ComponentModel.DataAnnotations;

namespace YasinMadenMVC.Models.ViewModels.MakaleViewModels
{
    public class MakaleListele_VM
    {
        public int Id { get; set; }
        [Display(Name = "Makale Başlığı")]
        public string Baslik { get; set; }
        [Display(Name = "Makale İçeriği")]
        public string Icerik { get; set; }
        [Display(Name = "Yayınlanma Tarihi")]
        public DateTime YayinlanmaTarihi { get; set; }
        public int UserId { get; set; }
        [Display(Name = "Yazar")]
        public string UserName { get; set; }
        [Display(Name = "Kategoriler")]
        public List<string> Kategoriler { get; set; }
    }
}
