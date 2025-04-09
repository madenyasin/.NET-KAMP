using System.ComponentModel.DataAnnotations;
using WebApplication1.CustomValidators;

namespace WebApplication1.Models
{
    public class KullaniciEkleVM
    {
        [Required(ErrorMessage = "Boş geçilemez..."), StringLength(20)]
        public string Ad { get; set; }

        [Required, MaxLength(20)]
        public string Soyad { get; set; }

        [RazorKarakteriOlamaz(ErrorMessage = "@ Karakteri Olamaz")]
        [Required, MaxLength(20), MinLength(5, ErrorMessage = "kullanıcı adı en az 5 karakter olmalı")]
        public string KullaniciAdi { get; set; }

        [Required, MaxLength(12), MinLength(8, ErrorMessage = "şifre en az 8 karakter olmalı")]
        public string Sifre { get; set; }

        [Required, MaxLength(12), MinLength(8), Compare("Sifre")]
        public string SifreTekrari { get; set; }

    }
}
