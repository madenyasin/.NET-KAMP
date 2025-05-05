using System.ComponentModel.DataAnnotations;

namespace YasinMadenMVC.Models.ViewModels.MakaleViewModels
{
    public class MakaleGuncelle_VM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Makale başlığı boş olamaz!")]
        [Display(Name = "Makale Başlığı")]
        public string Baslik { get; set; }
        [Required(ErrorMessage = "Makale içeriği boş olamaz!")]
        [Display(Name = "Makale İçeriği")]
        public string Icerik { get; set; }
        [Display(Name = "Kategoriler")]
        [Required(ErrorMessage = "En az bir kategori seçilmelidir.")]
        public List<int> SecilenKategoriIdleri { get; set; }

    }
}
