using Pustok.BLL.Services.Abstraction;
using Pustok.BLL.Services.Implementation.Generic;
using Pustok.DAL.Repositories.Abstraction;
using Pustok.DAL.Repositories.Abstraction.Generic;

namespace Pustok.BLL.Services.Implementation;

public class SettingManager : CrudManager<Setting, SettingViewModel, SettingListViewModel, SettingCreateViewModel, SettingUpdateViewModel>, ISettingService 
{
    private readonly ISettingRepository _settingRepository;
    public SettingManager(IRepository<Setting> repository, IMapper mapper, ISettingRepository settingRepository) : base(repository, mapper)
    {
        _settingRepository = settingRepository;
    }

    public async Task<bool> DoesKeyAlreadyExistAsync(string key)
    {
        var setting = await _settingRepository.GetAsync(x=> x.Key == key);

        if (setting == null) return false;

        return true;
    }
     public async Task<Dictionary<string, string>> GetLayoutSettingsAsync()
    {
        Dictionary<string,string> settings = await _settingRepository.GetLayoutSettingsAsync();

        return settings;
    }
}