namespace WebApplication2.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Kategoriye ait ürünlerin listesi
        public ICollection<Product>? Products { get; set; }
    }
}
