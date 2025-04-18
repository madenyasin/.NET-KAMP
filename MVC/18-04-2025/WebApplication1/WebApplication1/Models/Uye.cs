using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models
{
    public class Uye : IdentityUser<int>
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }

        public ICollection<Not>? Notlar { get; set; }

    }
}
