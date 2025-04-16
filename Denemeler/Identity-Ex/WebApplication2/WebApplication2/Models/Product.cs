namespace WebApplication2.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        // Kategori ilişkisi için foreign key
        public int CategoryId { get; set; }

        // Navigation property (İlişkili kategoriye erişim)
        public Category? Category { get; set; }
    }
}
