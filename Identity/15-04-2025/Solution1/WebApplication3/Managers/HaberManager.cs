using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Managers
{
    public class HaberManager
    {
        private readonly HaberDbContext _dbContext;

        public HaberManager(HaberDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> HaberEkleAsync(Haber haber)
        {
            try
            {
                await _dbContext.Haberler.AddAsync(haber);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
