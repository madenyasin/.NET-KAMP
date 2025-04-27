using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KitapProje.Models.ViewModels.KitapViewModels
{
    public class KitapEkleFormVM
    {
        public KitapEkleVM Kitap { get; set; }
        public SelectList Kategoriler { get; set; }
        public List<Kategori> KategorilerList { get; set; }
    }
}
