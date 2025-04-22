namespace ManyToMany.Models
{
    public class KitapYazar
    {
        public int Id { get; set; }

        public int YazarId { get; set; }
        public Yazar? Yazar { get; set; }

        public int KitapId { get; set; }
        public Kitap? Kitap { get; set; }
    }
}
