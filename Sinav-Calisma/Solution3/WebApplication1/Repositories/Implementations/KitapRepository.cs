using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories.Implementations
{
    public class KitapRepository : BaseRepository<Kitap>
    {
        public KitapRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
