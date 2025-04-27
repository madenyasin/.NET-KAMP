using Microsoft.AspNetCore.Mvc.Rendering;

namespace KitapProje.Models.ViewModels.KitapViewModels
{
    public class KitapGuncelleFormVM
    {
        public KitapGuncelleVM Kitap { get; set; }
        public SelectList Kategoriler { get; set; }
    }
}
