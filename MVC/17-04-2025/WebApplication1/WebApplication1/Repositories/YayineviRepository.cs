using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class YayineviRepository : BaseRepository<YayinEvi>
    {
        public YayineviRepository(KitapDbbContext dbContext) : base(dbContext)
        {
        }
    }
}
