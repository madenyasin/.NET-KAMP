using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication2.Models.ViewModels
{
    public class UrunEklemeFormuVM
    {
        public SelectList Kategoriler { get; set; }
        public UrunEkleVM Urun { get; set; }
    }
}
