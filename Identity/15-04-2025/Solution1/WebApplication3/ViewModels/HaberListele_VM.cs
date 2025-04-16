using System.ComponentModel.DataAnnotations;

namespace WebApplication3.ViewModels
{
    public class HaberListele_VM
    {
        public int Id { get; set; }

        [Display(Name = "Başlık")]
        public string Baslik { get; set; }

        [Display(Name = "Resim")]
        public string ResimYolu { get; set; }

        [Display(Name = "Yayınlandığı Tarih")]
        public DateTime EklendigiTarih { get; set; }
        public int UyeId { get; set; }

        [Display(Name = "Ekleyen Üye")]
        public string EkleyenUyeAdi { get; set; }
        public int KategoriId { get; set; }

        [Display(Name = "Kategori")]
        public string KategoriAdi { get; set; }

    }
}
