using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC_Client_3.Models.ViewModels
{
    public class UrunEkleFormVM
    {
        public UrunEkleVM Urun { get; set; }
        public SelectList Kategoriler { get; set; }
    }
}
