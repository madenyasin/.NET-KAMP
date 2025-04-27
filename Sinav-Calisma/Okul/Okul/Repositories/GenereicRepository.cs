
using Microsoft.EntityFrameworkCore;
using Okul.Data;

namespace Okul.Repositories
{
    public class GenereicRepository<Tentity> : IRepository<Tentity> where Tentity : class
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<Tentity> _dbSet;

        public GenereicRepository(AppDbContext context)
        {
            _context = context;
            _dbSet= context.Set<Tentity>();
        }

        public async Task AddAsync(Tentity entity)
        {
            await _dbSet.AddAsync(entity);
        }


        public void Delete(Tentity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<Tentity>> GetAllAsync()
        {

            return await _dbSet.ToListAsync();
        }

        public async Task<Tentity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Tentity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
