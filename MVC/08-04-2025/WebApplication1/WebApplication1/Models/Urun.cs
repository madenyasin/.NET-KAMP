using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Urun
    {
        [Key]
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        
        [ForeignKey("Kategori")]
        public int KategoriID { get; set; }
        public double Fiyat { get; set; }
        public string Resim { get; set; }
        public string Aciklama { get; set; }


        public Kategori? Kategori { get; set; }

    }
}
