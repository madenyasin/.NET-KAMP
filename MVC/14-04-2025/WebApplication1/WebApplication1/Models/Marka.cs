namespace WebApplication1.Models
{
    public class Marka
    {
        public int Id { get; set; }
        public string Ad { get; set; }

        public ICollection<Arac>? Araclar { get; set; }
    }
}
