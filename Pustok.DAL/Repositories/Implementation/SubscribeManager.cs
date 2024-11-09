using Pustok.DAL.DataContext;
using Pustok.DAL.Repositories.Abstraction;
using Pustok.DAL.Repositories.Implementation.Generic;

namespace Pustok.DAL.Repositories.Implementation;

public class SubscribeManager : EfCoreRepository<Subscribe>, ISubscribeRepository
{
    public SubscribeManager(AppDbContext dbContext) : base(dbContext)
    {
    }
}