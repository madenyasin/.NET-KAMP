using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.ViewModels.Kitap
{
    public class KitapListeViewModel
    {

        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Kitap Adı")]
        public string Ad { get; set; }

        [Display(Name = "Fiyat")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public decimal Fiyat { get; set; }

        [Display(Name = "Özet")]
        [DataType(DataType.MultilineText)]
        public string Ozet { get; set; }

        [Display(Name = "Sayfa Sayısı")]
        public int SayfaSayisi { get; set; }

        [Display(Name = "Ekleyen Kullanıcı")]
        public string KullaniciAdi { get; set; }

        [Display(Name = "Kategoriler")]
        public List<string> KategoriAdlari { get; set; } = new();
    }
}
