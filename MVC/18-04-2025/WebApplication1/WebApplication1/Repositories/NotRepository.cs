using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class NotRepository : BaseRepository<Not>
    {
        public NotRepository(ToDoDbContext dbContext) : base(dbContext)
        {
        }
    }
}
