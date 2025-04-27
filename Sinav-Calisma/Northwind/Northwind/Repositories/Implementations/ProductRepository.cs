using Northwind.Data;
using Northwind.Models;
using WebApplication1.Repositories.Implementations;

namespace Northwind.Repositories.Implementations
{
    public class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository(DenemeNorthwindContext dbContext) : base(dbContext)
        {
        }
    }
}
