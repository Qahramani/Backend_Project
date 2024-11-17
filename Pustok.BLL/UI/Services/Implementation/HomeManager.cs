using Microsoft.EntityFrameworkCore;
using Pustok.BLL.Services.Abstraction;
using Pustok.BLL.UI.Services.Abstraction;
using Pustok.BLL.UI.ViewModels;

namespace Pustok.BLL.UI.Services.Implementation;

public class HomeManager : IHomeService
{
    private readonly ISliderService _sliderService;
    private readonly IServiceService _serviceService;
    private readonly ICategoryService _categoryService;
    private readonly IProductService _productService;
    public HomeManager(ISliderService sliderService, IServiceService serviceService, ICategoryService categoryService, IProductService productService)
    {
        _sliderService = sliderService;
        _serviceService = serviceService;
        _categoryService = categoryService;
        _productService = productService;
    }

    public async Task<HomeViewModel> GetHomeViewModel(int? categoryId)
    {
        var sliders = await _sliderService.GetPagesAsync(size: 3);
        var services = await _serviceService.GetPagesAsync(size: 4);
        var categories = await _categoryService.GetAllAsync(include: x => x.Include(x => x.Products).ThenInclude(x => x.Images));
        List<ProductViewModel> products = new List<ProductViewModel>();
        if (categoryId is not null)
            products = await _productService.GetProductsByCategoryIdAsync(categoryId.Value);
        else
            products = await _productService.GetAllAsync();

        HomeViewModel homeVM = new()
        {
            Sliders = sliders,
            Services = services,
            Categories = categories,
            Products = products
        };

        return homeVM;
    }

    public async Task<List<ProductViewModel>> GetProductsByCategory(int categoryId)
    {
        var products = await _productService.GetProductsByCategoryIdAsync(categoryId);

        return products;
    }

}
