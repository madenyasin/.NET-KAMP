using KitapProje.Data;
using KitapProje.Models;


namespace KitapProje.Repositories.Implementations
{
    public class KategoriRepository : BaseRepository<Kategori>
    {
        public KategoriRepository(KutuphaneDbContext dbContext) : base(dbContext)
        {
        }
    }
}
