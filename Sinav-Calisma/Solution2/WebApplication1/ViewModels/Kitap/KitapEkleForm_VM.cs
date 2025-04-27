using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.ViewModels.Kitap
{
    public class KitapEkleForm_VM
    {
        public KitapEkle_VM Kitap { get; set; }
        public SelectList Kategoriler { get; set; }
    }
}
