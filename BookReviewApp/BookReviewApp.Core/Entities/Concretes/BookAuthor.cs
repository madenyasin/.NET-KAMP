using BookReviewApp.Core.Entities.Abstracts;

namespace BookReviewApp.Core.Entities.Concretes
{
    public class BookAuthor: BaseEntity
    {
        public string BookId { get; set; }
        public string AuthorId { get; set; }

        public Book? Book { get; set; }
        public Author? Author { get; set; }
    }
}
