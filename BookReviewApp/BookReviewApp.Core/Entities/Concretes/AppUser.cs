using BookReviewApp.Core.Entities.Abstracts;
using BookReviewApp.Core.Enums;
using Microsoft.AspNetCore.Identity;

namespace BookReviewApp.Core.Entities.Concretes
{
    public class AppUser : IdentityUser, IEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public RecordStatus RecordStatus { get; set; }

        public ICollection<Review>? Reviews { get; set; } = new List<Review>();
        public ICollection<Book>? AddedBooks { get; set; } = new List<Book>();
    }
}
