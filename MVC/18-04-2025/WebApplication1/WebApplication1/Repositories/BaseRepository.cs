
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using WebApplication1.Data;

namespace WebApplication1.Repositories
{
    public abstract class BaseRepository<TEntity> : ICrud<TEntity> where TEntity : class
    {
        protected readonly ToDoDbContext _dbContext;
        protected readonly DbSet<TEntity> _table;

        protected BaseRepository(ToDoDbContext dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<TEntity>();
        }

        public TEntity Bul(int id)
        {
            return _table.Find(id);
        }

        public void Ekle(TEntity entity)
        {
            _table.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Guncelle(TEntity entity)
        {
            _table.Update(entity);
            _dbContext.SaveChanges();
        }

        public List<TEntity> Listele()
        {
            return _table.ToList();
        }

        public IQueryable<TEntity> ListeleQueryable()
        {
            return _table;
        }

        public void Sil(int id)
        {
            _table.Remove(Bul(id));
            _dbContext.SaveChanges();

        }
    }
}
