namespace ManyToMany.ViewModels
{
    public class KitapGuncelle_VM
    {
        public int KitapId { get; set; }
        public string Ad { get; set; }
        public string Ozet { get; set; }
        public List<int> SecilenYazarIdleri { get; set; }
    }
}
