using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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
        var products = await _productService.GetPagesAsync(predicate: x => x.IsDeleted == false,index: page, size: 2);

        return View(products);
    }

    public async Task<IActionResult> Details(int id)
    {
        var vm = await _productService.GetProductDetailsViewModel(id);

        return View(vm);
    }

    public async Task<IActionResult> Create()
    {
        var vm = await _productService.GetProductCreateViewModelAsync();

        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            var vm = await _productService.GetProductCreateViewModelAsync();
            return View(vm);
        }

        await _productService.CreateAsync(model);

        return RedirectToAction(nameof(Index));
    }

    //[HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _productService.GetAsync(id);

        if (product == null) return NotFound();

        await _productService.ProductSoftDeleteAsync(id);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int id)
    {
        var vm = await _productService.GetProductUpdateViewModelAsync(id);

        return View(vm);
    }
    [HttpPost]
    public async Task<IActionResult> Update(ProductUpdateViewModel model)
    {
        if(!ModelState.IsValid)
        {
            var vm = await _productService.GetProductUpdateViewModelAsync(model.Id);

            return View(vm);
        }
        

        return RedirectToAction(nameof(Index));
    }
}
