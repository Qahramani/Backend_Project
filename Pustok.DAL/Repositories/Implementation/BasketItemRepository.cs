using Pustok.DAL.DataContext;
using Pustok.DAL.Repositories.Abstraction;
using Pustok.DAL.Repositories.Implementation.Generic;

namespace Pustok.DAL.Repositories.Implementation;

public class BasketItemRepository : EfCoreRepository<BasketItem>, IBasketItemRepository
{
    public BasketItemRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
