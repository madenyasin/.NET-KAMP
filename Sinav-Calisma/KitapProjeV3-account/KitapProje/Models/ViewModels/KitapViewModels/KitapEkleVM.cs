using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace KitapProje.Models.ViewModels.KitapViewModels
{
    public class KitapEkleVM
    {
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }
        public string Ozet { get; set; }
        public int SayfaSayisi { get; set; }
        public List<int> KategoriIdleri { get; set; }
    }
}
