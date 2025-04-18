using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class KitapEkleViewModel
    {

        public string Ad { get; set; } = null!;

        public decimal Fiyat { get; set; }

        public string KapakResmi { get; set; } = null!;

        public string Ozet { get; set; } = null!;

        public int SayfaSayisi { get; set; }

        public int YayinEviId { get; set; }

        public int KategoriId { get; set; }

        public int YazarId { get; set; }

    }
}
