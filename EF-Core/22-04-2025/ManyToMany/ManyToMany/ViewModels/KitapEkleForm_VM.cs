using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManyToMany.ViewModels
{
    public class KitapEkleForm_VM
    {
        public KitapEkle_VM Kitap { get; set; }
        public SelectList Yazarlar { get; set; }

    }
}
