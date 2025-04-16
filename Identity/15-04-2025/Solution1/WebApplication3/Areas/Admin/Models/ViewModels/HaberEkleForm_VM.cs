using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication3.Areas.Admin.Models.ViewModels
{
    public class HaberEkleForm_VM
    {
        public SelectList Kategoriler { get; set; }
        public HaberEkle_VM Haber { get; set; }
    }
}
