using YasinMadenMVC.Abstracts;
using YasinMadenMVC.Data;
using YasinMadenMVC.Models;

namespace YasinMadenMVC.Repositories
{
    public class KategoriRepository : BaseRepository<Kategori>
    {
        public KategoriRepository(MakaleDbContext dbContext) : base(dbContext)
        {
        }
    }
}
