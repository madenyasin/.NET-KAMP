using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Kitap
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }
        public string Ozet { get; set; }
        public int SayfaSayisi { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public AppUser? User { get; set; }
        public ICollection<KitapKategori>? Kategoriler { get; set; }
    }
}
