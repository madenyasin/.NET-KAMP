using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Kategori
    {
        [Key]
        public int KategoriID { get; set; }
        public string KategoriAdi { get; set; }


        public ICollection<Urun>? Urunler { get; set; }
    }
}
