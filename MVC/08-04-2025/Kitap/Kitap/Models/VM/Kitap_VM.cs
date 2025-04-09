namespace Kitap.Models.VM
{
    public class Kitap_VM
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }
        public string KapakResmi { get; set; }
        public string Ozet { get; set; }
        public int SayfaSayisi { get; set; }

        public string YayinEviAdi { get; set; }
        public string KategoriAdi { get; set; }
        public string YazarAdi { get; set; }

    }
}
