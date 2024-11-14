using Pustok.BLL.Services.Abstraction;
using Pustok.BLL.UI.Services.Abstraction;
using Pustok.BLL.UI.ViewModels;

namespace Pustok.BLL.UI.Services.Implementation;

public class HomeManager : IHomeService
{
    private readonly ISliderService _sliderService;
    private readonly IServiceService _serviceService;
    public HomeManager(ISliderService sliderService, IServiceService serviceService)
    {
        _sliderService = sliderService;
        _serviceService = serviceService;
    }

    public async Task<HomeViewModel> GetHomeViewModel()
    {
        var sliders = await _sliderService.GetPagesAsync(size: 3);
        var services = await _serviceService.GetPagesAsync(size: 4);

        HomeViewModel homeVM = new()
        {
            Sliders = sliders,
            Services = services
        };

        return homeVM;
    }
}
