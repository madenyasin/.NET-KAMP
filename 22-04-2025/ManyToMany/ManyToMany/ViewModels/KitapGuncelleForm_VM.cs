using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManyToMany.ViewModels
{
    public class KitapGuncelleForm_VM
    {
        public SelectList Yazarlar { get; set; }
        public KitapGuncelle_VM Kitap { get; set; }
    }
}
