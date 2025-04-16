using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication2.Areas.AdminPanel.Models.ViewModels
{
    public class UrunEkleForm_VM
    {
        public SelectList Kategoriler { get; set; }
        public UrunEkle_VM Urun { get; set; }
    }
}
