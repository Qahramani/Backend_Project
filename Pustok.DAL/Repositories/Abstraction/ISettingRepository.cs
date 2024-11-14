namespace Pustok.DAL.Repositories.Abstraction;

public interface ISettingRepository : IRepository<Setting>
{
    Task<Dictionary<string, string>> GetLayoutSettingsAsync();
}

