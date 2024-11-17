using Pustok.BLL.Services.Abstraction;
using Pustok.BLL.UI.Services.Abstraction;

namespace Pustok.BLL.UI.Services.Implementation;

public class LayoutManager : ILayoutService
{
    private readonly ISettingService _settingService;
    private readonly IBasketService _basketService;

    public LayoutManager(ISettingService settingService, IBasketItemService basketItemService, IBasketService basketService)
    {
        _settingService = settingService;
        _basketService = basketService;
    }

    public async Task<Dictionary<string, string>> GetLayoutSettingsAsync()
    {
        Dictionary<string,string> settings = await _settingService.GetLayoutSettingsAsync();

        return settings;
    }

  
}
