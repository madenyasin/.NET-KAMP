using Microsoft.AspNetCore.Identity;

namespace KitapProje.Models
{
    public class AppUser:IdentityUser<int>
    {
        public ICollection<Kitap>? Kitaplar { get; set; } = new List<Kitap>();
    }
}
