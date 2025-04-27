using KitapProje.Data;
using KitapProje.Models;

namespace KitapProje.Repositories.Implementations
{
    public class KitapRepository : BaseRepository<Kitap>
    {
        public KitapRepository(KutuphaneDbContext dbContext) : base(dbContext)
        {
        }
    }
}
