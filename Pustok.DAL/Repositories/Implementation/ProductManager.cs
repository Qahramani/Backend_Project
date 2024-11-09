using Pustok.DAL.DataContext;
using Pustok.DAL.Repositories.Abstraction;
using Pustok.DAL.Repositories.Implementation.Generic;

namespace Pustok.DAL.Repositories.Implementation;

public class ProductManager : EfCoreRepository<Product>, IProductRepository
{
    public ProductManager(AppDbContext dbContext) : base(dbContext)
    {
    }
}
