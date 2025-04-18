using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.ViewModels
{
    public class KitapEkleFormViewModel
    {
        public SelectList Kategoriler { get; set; }
        public SelectList Yazarlar { get; set; }
        public SelectList Yayinevleri { get; set; }
        public KitapEkleViewModel Kitap { get; set; }
    }
}
