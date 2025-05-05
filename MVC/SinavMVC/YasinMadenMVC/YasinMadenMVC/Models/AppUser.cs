using Microsoft.AspNetCore.Identity;

namespace YasinMadenMVC.Models
{
    public class AppUser: IdentityUser<int>
    {
        public ICollection<Makale>? Makaleler { get; set; } = new List<Makale>();
    }
}
