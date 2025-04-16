using System.ComponentModel.DataAnnotations;

namespace WebApplication3.ViewModels
{
    public class HaberDetay_VM
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Detay { get; set; }
        public string ResimYolu { get; set; }
        public DateTime EklendigiTarih { get; set; }
        public int UyeId { get; set; }
        public string EkleyenUyeAdi { get; set; }
        public int KategoriId { get; set; }

        public string KategoriAdi { get; set; }

    }
}
