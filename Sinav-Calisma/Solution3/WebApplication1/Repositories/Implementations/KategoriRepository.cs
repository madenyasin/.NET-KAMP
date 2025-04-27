using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories.Implementations
{
    public class KategoriRepository : BaseRepository<Kategori>
    {
        public KategoriRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
