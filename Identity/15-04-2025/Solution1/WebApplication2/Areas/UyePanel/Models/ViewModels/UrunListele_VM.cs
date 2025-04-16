using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Areas.UyePanel.Models.ViewModels
{
    public class UrunListele_VM
    {
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public decimal Fiyat { get; set; }
        public string Resim { get; set; }
        public string Aciklama { get; set; }

        public int UyeId { get; set; }
        
        [Display(Name = "Ekleyen Üye")]
        public string UyeAdi { get; set; }
        public int KategoriId { get; set; }

        [Display(Name = "Kategori")]
        public string KategoriAdi{ get; set; }


    }
}
