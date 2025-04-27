using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace KitapProje.Models
{
    public class Kitap
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }
        public string Ozet { get; set; }
        public int SayfaSayisi { get; set; }
        public int UserId { get; set; }
        public AppUser? User { get; set; }

        public ICollection<KitapKategori>? Kategoriler { get; set; } = new List<KitapKategori>();
    }
}
