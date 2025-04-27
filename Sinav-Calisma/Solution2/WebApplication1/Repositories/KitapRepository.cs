using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.ViewModels.Kitap;

namespace WebApplication1.Repositories
{
    public class KitapRepository : BaseRepository<Kitap>
    {
        public KitapRepository(KutuphaneDbContext dbContext) : base(dbContext)
        {
        }
    }
}
