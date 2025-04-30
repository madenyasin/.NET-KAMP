namespace ManyToMany.Models
{
    public class Kitap
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Ozet { get; set; }
        public string ISBN { get; set; }


        public ICollection<KitapYazar>? KitapYazar { get; set; }

    }
}
