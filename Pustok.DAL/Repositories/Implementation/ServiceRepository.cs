using Pustok.DAL.DataContext;
using Pustok.DAL.Repositories.Abstraction;
using Pustok.DAL.Repositories.Implementation.Generic;

namespace Pustok.DAL.Repositories.Implementation;

public class ServiceRepository : EfCoreRepository<Service>, IServiceRepository
{
    public ServiceRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
