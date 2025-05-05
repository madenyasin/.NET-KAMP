using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace YasinMadenMVC.Models.ViewModels.MakaleViewModels
{
    public class MakaleDetay_VM
    {
        [Display(Name = "Makale ID")]
        public int Id { get; set; }
        [Display(Name = "Makale Başlığı")]
        public string Baslik { get; set; }
        [Display(Name = "Makale İçeriği")]
        public string Icerik { get; set; }
        [ValidateNever] 
        public DateTime YayinlanmaTarihi { get; set; }
        [Display(Name = "Yazar")]
        public string UserName { get; set; }
        [Display(Name = "Kategoriler")]
        public List<string> Kategoriler { get; set; }
    }
}
