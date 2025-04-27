using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Sinav_MVC.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        public ICollection<Kitap>? Kitaplar { get; set; }
    }
}
