using Pustok.BLL.Services.Abstraction;
using Pustok.BLL.UI.Services.Abstraction;

namespace Pustok.BLL.UI.Services.Implementation;

public class LayoutManager : ILayoutervice
{
    private readonly ISettingService _settingService;

    public LayoutManager(ISettingService settingService)
    {
        _settingService = settingService;
    }

    public async Task<Dictionary<string, string>> GetLayoutSettingsAsync()
    {
        Dictionary<string,string> settings = await _settingService.GetLayoutSettingsAsync();

        return settings;
    }
}
