using Pustok.DAL.DataContext;
using Pustok.DAL.Repositories.Abstraction;
using Pustok.DAL.Repositories.Implementation.Generic;

namespace Pustok.DAL.Repositories.Implementation;

public class SubscribeRepository : EfCoreRepository<Subscribe>, ISubscribeRepository
{
    public SubscribeRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}