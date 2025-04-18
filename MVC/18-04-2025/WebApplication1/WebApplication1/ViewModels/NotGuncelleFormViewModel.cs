using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.ViewModels
{
    public class NotGuncelleFormViewModel
    {
        public NotGuncelleViewModel Not { get; set; }
        public SelectList Kategoriler { get; set; }
    }
}
