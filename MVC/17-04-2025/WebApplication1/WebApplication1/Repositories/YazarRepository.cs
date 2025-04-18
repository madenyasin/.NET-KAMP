using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class YazarRepository : BaseRepository<Yazar>
    {
        public YazarRepository(KitapDbbContext dbContext) : base(dbContext)
        {
        }
    }
}
