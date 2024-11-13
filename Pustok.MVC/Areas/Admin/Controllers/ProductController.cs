using Microsoft.AspNetCore.Mvc;
using Pustok.BLL.Services.Abstraction;
using Pustok.BLL.ViewModels;

namespace Pustok.MVC.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index(int page = 0)
    {
        var products = await _productService.GetPagesAsync(index : page, size : 2);

        return View(products);
    }

    public async Task<IActionResult> Create()
    {
        var vm = await _productService.GetProductCreateViewModelAsync();

        return View(vm);
    }
}
