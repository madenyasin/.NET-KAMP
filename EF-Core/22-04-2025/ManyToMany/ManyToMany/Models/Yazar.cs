using System.ComponentModel.DataAnnotations.Schema;

namespace ManyToMany.Models
{
    public class Yazar
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        
        [NotMapped]
        public string TamIsım => Ad + " " + Soyad;
        public DateTime DogumTarihi { get; set; }


        public ICollection<KitapYazar>? KitapYazar { get; set; }
    }
}
