using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.Models.VM
{
    public class OtomobilEkleForm_VM
    {
        public SelectList Markalar { get; set; }
        public OtomobilEkle_VM Otomobil { get; set; }
    }
}
