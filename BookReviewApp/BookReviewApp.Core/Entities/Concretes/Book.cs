using BookReviewApp.Core.Entities.Abstracts;

namespace BookReviewApp.Core.Entities.Concretes
{
    public class Book : BaseEntity
    {
        public string? Title { get; set; }
        public string? ISBN { get; set; }

        public string? CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<Review>? Reviews { get; set; } = new List<Review>();
        public ICollection<BookAuthor>? BookAuthors { get; set; } = new List<BookAuthor>();
    }
}
