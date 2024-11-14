using Pustok.DAL.DataContext;
using Pustok.DAL.Repositories.Abstraction;
using Pustok.DAL.Repositories.Implementation.Generic;

namespace Pustok.DAL.Repositories.Implementation;

public class SettingRepository : EfCoreRepository<Setting>, ISettingRepository
{
    private readonly AppDbContext _appDbContext;
    public SettingRepository(AppDbContext dbContext) : base(dbContext)
    {
        _appDbContext = dbContext;
    }
    public async Task<Dictionary<string, string>> GetLayoutSettingsAsync()
    {
        Dictionary<string, string> settings = await _appDbContext.Settings.ToDictionaryAsync(x => x.Key, x => x.Value);

        return settings;
    }
}
