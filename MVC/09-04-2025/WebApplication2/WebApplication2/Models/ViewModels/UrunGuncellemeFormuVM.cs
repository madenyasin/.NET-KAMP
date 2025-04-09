using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication2.Models.ViewModels
{
    public class UrunGuncellemeFormuVM
    {
        public SelectList Kategoriler { get; set; }
        public UrunGuncelleVM Urun { get; set; }
    }
}
