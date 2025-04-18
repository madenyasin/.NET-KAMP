using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.ViewModels
{
    public class NotEkleFormViewModel
    {
        public NotEkleViewModel Not { get; set; }
        public SelectList Kategoriler { get; set; }

    }
}
