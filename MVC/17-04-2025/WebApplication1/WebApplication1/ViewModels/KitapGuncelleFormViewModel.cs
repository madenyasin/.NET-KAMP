using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.ViewModels
{
    public class KitapGuncelleFormViewModel
    {
        public SelectList Kategoriler { get; set; }
        public SelectList Yazarlar { get; set; }
        public SelectList Yayinevleri { get; set; }
        public KitapGuncelleViewModel Kitap { get; set; }
    }
}
