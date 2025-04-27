using System.ComponentModel.DataAnnotations.Schema;

namespace Sinav_MVC.Models
{
    public class Yazar
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        public ICollection<Kitap>? Kitaplar { get; set; }
    }
}
