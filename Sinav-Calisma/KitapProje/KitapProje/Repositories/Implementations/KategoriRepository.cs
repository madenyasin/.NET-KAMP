using KitapProje.Data;
using KitapProje.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KitapProje.Repositories.Implementations
{
    public class KategoriRepository : BaseRepository<Kategori>
    {
        public KategoriRepository(KutuphaneDbContext dbContext) : base(dbContext)
        {
        }
    }
}
