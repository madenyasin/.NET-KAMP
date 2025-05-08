using BookReviewApp.Core.Entities.Abstracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookReviewApp.Core.Entities.Concretes
{
    public class Author : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [NotMapped]
        public string FullName => FirstName + " " + LastName;

        public ICollection<BookAuthor>? BookAuthors { get; set; } = new List<BookAuthor>();
    }

}
