using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Identity;

namespace SinavProje.Models
{
    public class AppUser:IdentityUser<int>
    {
        public Hesap? Hesap { get; set; }
    }
}
