using Microsoft.AspNetCore.Mvc;
using Pustok.BLL.UI.Services.Abstraction;
using Pustok.MVC.ViewModels;

namespace Pustok.MVC.ViewComponents;

public class FooterViewComponent : ViewComponent
{
    private readonly ILayoutService _layoutService;

    public FooterViewComponent(ILayoutService layoutService)
    {
        _layoutService = layoutService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        Dictionary<string,string> settings = await _layoutService.GetLayoutSettingsAsync();

        FooterViewModel vm = new()
        {
            Settings = settings
        };

        return View(vm);
    }
}

