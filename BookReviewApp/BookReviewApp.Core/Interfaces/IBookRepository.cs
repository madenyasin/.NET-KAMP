using BookReviewApp.Core.Entities.Concretes;

namespace BookReviewApp.Core.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<IEnumerable<Book>> GetBooksWithAuthorsAsync();
        Task<IEnumerable<Book>> GetBooksByCategoryIdAsync(int categoryId);
    }
}
