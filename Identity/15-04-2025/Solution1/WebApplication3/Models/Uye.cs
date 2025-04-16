using Microsoft.AspNetCore.Identity;

namespace WebApplication3.Models
{
    public class Uye: IdentityUser<int>
    {
        public string Ad { get; set; }
        public  string Soyad { get; set; }

        public ICollection<Haber>? Haberler { get; set; }

    }
}
