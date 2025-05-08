using BookReviewApp.Core.Entities.Abstracts;

namespace BookReviewApp.Core.Entities.Concretes
{
    public class Review:BaseEntity
    {
        public string? Content { get; set; }
        public int Rating { get; set; }

        public string BookId { get; set; }
        public Book? Book { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
