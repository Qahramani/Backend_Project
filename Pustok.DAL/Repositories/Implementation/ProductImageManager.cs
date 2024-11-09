using Pustok.DAL.DataContext;
using Pustok.DAL.Repositories.Abstraction;
using Pustok.DAL.Repositories.Implementation.Generic;

namespace Pustok.DAL.Repositories.Implementation;

public class ProductImageManager : EfCoreRepository<ProductImage>, IProductImageRepository
{
    public ProductImageManager(AppDbContext dbContext) : base(dbContext)
    {
    }
}
