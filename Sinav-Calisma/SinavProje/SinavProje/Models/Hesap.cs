using System.Reflection.Metadata.Ecma335;

namespace SinavProje.Models
{
    public class Hesap
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AppUser? User { get; set; }
    }
}
