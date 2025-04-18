namespace WebApplication1.ViewModels
{
    public class KitapDetayViewModel
    {
        public string Ad { get; set; } = null!;

        public decimal Fiyat { get; set; }

        public string KapakResmi { get; set; } = null!;

        public string Ozet { get; set; } = null!;

        public int SayfaSayisi { get; set; }

        public string YayinEviAdi { get; set; }

        public string KategoriAdi { get; set; }

        public string YazarAdi { get; set; }
    }
}
