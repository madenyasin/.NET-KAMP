using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.Models.VM.Arac
{
    public class AracEkleForm_VM
    {
        public SelectList Markalar { get; set; }

        public AracEkle_VM Arac { get; set; }
    }
}
