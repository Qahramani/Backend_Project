using Pustok.DAL.DataContext;
using Pustok.DAL.Repositories.Abstraction;
using Pustok.DAL.Repositories.Implementation.Generic;

namespace Pustok.DAL.Repositories.Implementation;

public class CategoryManager : EfCoreRepository<Category>, ICategoryRepository
{
    public CategoryManager(AppDbContext dbContext) : base(dbContext)
    {
    }
}