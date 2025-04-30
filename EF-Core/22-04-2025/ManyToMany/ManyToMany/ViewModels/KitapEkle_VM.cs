using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManyToMany.ViewModels
{
    public class KitapEkle_VM
    {
        public string Ad { get; set; }
        public string Ozet { get; set; }
        public string ISBN { get; set; }
        public List<int> SecilenYazarIdleri { get; set; }
        public List<SelectListItem> DenemeYazarlar { get; set; }

    }
}
