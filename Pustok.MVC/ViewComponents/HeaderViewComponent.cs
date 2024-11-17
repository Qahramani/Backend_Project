using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.BLL.Services.Abstraction;
using Pustok.BLL.UI.Services.Abstraction;
using Pustok.MVC.ViewModels;

namespace Pustok.MVC.ViewComponents;

public class HeaderViewComponent : ViewComponent
{
    private readonly ILayoutService _layoutService;
    private readonly ICategoryService _categoryService;
    private readonly IBasketService _basketService;

    public HeaderViewComponent(ILayoutService layoutService, ICategoryService categoryService, IBasketService basketService)
    {
        _layoutService = layoutService;
        _categoryService = categoryService;
        _basketService = basketService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        Dictionary<string, string> settings = await _layoutService.GetLayoutSettingsAsync();
        var categories = await _categoryService.GetAllAsync(include : x => x.Include(x => x.SubCategories));
        var basket = await _basketService.ShoppingCardAsync();


        HeaderViewModel vm = new()
        {
            Settings = settings,
            Categories = categories,
            Basket = basket
        };

        return View(vm);
    }
}

