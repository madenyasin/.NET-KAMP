using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Areas.Admin.Models.ViewModels
{
    public class HaberEkle_VM
    {
        [Required]
        public string Baslik { get; set; }
        [Required]
        public string Detay { get; set; }
        public string ResimYolu { get; set; }
        [Required]
        public IFormFile KapakResmiDosyasi { get; set; }
        [Required]
        public int KategoriId { get; set; }

    }
}
