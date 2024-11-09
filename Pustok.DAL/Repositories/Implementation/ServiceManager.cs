using Pustok.DAL.DataContext;
using Pustok.DAL.Repositories.Abstraction;
using Pustok.DAL.Repositories.Implementation.Generic;

namespace Pustok.DAL.Repositories.Implementation;

public class ServiceManager : EfCoreRepository<Service>, IServiceRepository
{
    public ServiceManager(AppDbContext dbContext) : base(dbContext)
    {
    }
}
