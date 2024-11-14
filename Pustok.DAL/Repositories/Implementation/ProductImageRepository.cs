using Pustok.DAL.DataContext;
using Pustok.DAL.Repositories.Abstraction;
using Pustok.DAL.Repositories.Implementation.Generic;

namespace Pustok.DAL.Repositories.Implementation;

public class ProductImageRepository : EfCoreRepository<ProductImage>, IProductImageRepository
{
    public ProductImageRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
