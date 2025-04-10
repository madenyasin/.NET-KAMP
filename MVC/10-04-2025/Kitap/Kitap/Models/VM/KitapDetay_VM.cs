using System.ComponentModel.DataAnnotations;

namespace Kitap.Models.VM
{
    public class KitapDetay_VM
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }

        [Display(Name = "Kapak Resmi")]
        public string KapakResmi { get; set; }
        public string Ozet { get; set; }

        [Display(Name = "Sayfa Sayisi")]
        public int SayfaSayisi { get; set; }

        public int YayinEviId { get; set; }
        public int KategoriId { get; set; }
        public int YazarId { get; set; }

        [Display(Name = "Yayinevi")]
        public string YayinEviAdi { get; set; }

        [Display(Name = "Kategori")]
        public string KategoriAdi { get; set; }

        [Display(Name = "Yazar")]
        public string YazarAdi { get; set; }
    }
}
