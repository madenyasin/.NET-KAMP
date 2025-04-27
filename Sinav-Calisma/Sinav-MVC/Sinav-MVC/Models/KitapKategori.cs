using System.ComponentModel.DataAnnotations;

namespace Sinav_MVC.Models
{
    public class KitapKategori
    {
        [Key]
        public int KitapId { get; set; }
        [Key]
        public int KategoriId { get; set; }

        public Kategori? Kategori { get; set; }
        public Kitap? Kitap { get; set; }
    }
}
