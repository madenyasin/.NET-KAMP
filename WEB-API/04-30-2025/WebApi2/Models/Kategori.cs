using System.Reflection.Metadata.Ecma335;

namespace WebApi2.Models
{
    public class Kategori
    {
        public int KategoriID { get; set; }
        public string? KategoriAdi { get; set; }
        public ICollection<Urun>? Urunler { get; set; }
    }
}
