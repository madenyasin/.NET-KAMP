using System.ComponentModel.DataAnnotations;

namespace YasinMadenMVC.Models.ViewModels.MakaleViewModels
{
    public class MakaleEkle_VM
    {
        [Required(ErrorMessage = "Makale başlığı boş olamaz.")]
        [Display(Name = "Makale Başlığı")]
        public string Baslik { get; set; }
        [Required(ErrorMessage = "Makale içeriği boş olamaz.")]
        [Display(Name = "Makale İçeriği")]
        public string Icerik { get; set; }
        [Display(Name = "Yayınlanma Tarihi")]
        [DataType(DataType.Date)]
        public DateTime YayinlanmaTarihi { get; set; }
        [Display(Name = "Kategoriler")]
        [Required(ErrorMessage = "En az bir kategori seçilmelidir.")]
        public List<int> SecilenKategoriIdleri { get; set; }

    }
}
