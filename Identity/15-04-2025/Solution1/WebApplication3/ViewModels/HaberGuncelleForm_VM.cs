using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication3.ViewModels
{
    public class HaberGuncelleForm_VM
    {
        public SelectList Kategoriler { get; set; }
        public HaberGuncelle_VM Haber { get; set; }
    }
}
