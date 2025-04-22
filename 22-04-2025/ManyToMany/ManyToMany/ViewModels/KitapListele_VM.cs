namespace ManyToMany.ViewModels
{
    public class KitapListele_VM
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Ozet { get; set; }
        public string ISBN { get; set; }
        public List<string> YazarAdlari { get; set; }
    }
}
