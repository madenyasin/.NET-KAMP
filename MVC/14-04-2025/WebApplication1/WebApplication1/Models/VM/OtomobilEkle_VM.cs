namespace WebApplication1.Models.VM
{
    public class OtomobilEkle_VM
    {
        public string Plaka { get; set; }
        public string Model { get; set; }
        public decimal Fiyat { get; set; }
        public string Renk { get; set; }
        public string Aciklama { get; set; }

        public int MarkaId { get; set; }
        public int EkleyenUyeId { get; set; }
    }
}
