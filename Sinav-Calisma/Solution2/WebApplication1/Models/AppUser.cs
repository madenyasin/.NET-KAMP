using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models
{
    public class AppUser: IdentityUser
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        [NotMapped]
        public string TamIsım => Ad + " " + Soyad;

    }
}
