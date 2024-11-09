using Pustok.DAL.DataContext;
using Pustok.DAL.Repositories.Abstraction;
using Pustok.DAL.Repositories.Implementation.Generic;

namespace Pustok.DAL.Repositories.Implementation;

public class SettingManager : EfCoreRepository<Setting>, ISettingRepository
{
    public SettingManager(AppDbContext dbContext) : base(dbContext)
    {
    }
}
