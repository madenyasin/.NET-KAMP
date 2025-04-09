using WebApplication1.CustomValidators;

namespace WebApplication1.Models
{
    public class Musteri
    {
        public int MusteriId { get; set; }

        [TcKimlikNoValidator(ErrorMessage = "TC kimlik numarası geçersiz.")]
        public string TcKimlikNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }

    }
}
