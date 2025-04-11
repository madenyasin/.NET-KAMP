namespace Kitap.Models.VM
{
    public class KitapEkle_VM
    {
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }
        public IFormFile KapakResmiDosyasi { get; set; }
        public string Ozet { get; set; }
        public int SayfaSayisi { get; set; }

        public int YayinEviId { get; set; }
        public int KategoriId { get; set; }
        public int YazarId { get; set; }

    }
}
