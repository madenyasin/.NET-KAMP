using BookReviewApp.Core.Entities.Abstracts;

namespace BookReviewApp.Core.Entities.Concretes
{
    public class Category : BaseEntity
    {
        public string? Name { get; set; }
        public ICollection<Book>? Books { get; set; } = new List<Book>();
    }
}
