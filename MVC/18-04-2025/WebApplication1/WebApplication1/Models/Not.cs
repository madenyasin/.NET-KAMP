namespace WebApplication1.Models
{
    public class Not
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public bool Durum { get; set; }
        public int KategoriId { get; set; }
        public int UyeId { get; set; }

        public Kategori? Kategori { get; set; }

        public Uye? Uye { get; set; }
    }
}
