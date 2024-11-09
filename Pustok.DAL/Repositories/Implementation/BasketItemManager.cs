using Pustok.DAL.DataContext;
using Pustok.DAL.Repositories.Abstraction;
using Pustok.DAL.Repositories.Implementation.Generic;

namespace Pustok.DAL.Repositories.Implementation;

public class BasketItemManager : EfCoreRepository<BasketItem>, IBasketItemRepository
{
    public BasketItemManager(AppDbContext dbContext) : base(dbContext)
    {
    }
}
