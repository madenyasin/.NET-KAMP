using System.ComponentModel.DataAnnotations.Schema;

namespace Kitap.Models
{
    public class Yazar
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Biyografi { get; set; }

        [NotMapped]
        public string TamIsim => Ad + " " + Soyad;

        public ICollection<Kitapp>? kitaplar { get; set; }
    }
}
