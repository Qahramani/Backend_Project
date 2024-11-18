using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.BLL.Services.Abstraction;
using Pustok.BLL.ViewModels;

namespace Pustok.MVC.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Moderator,Admin")]
[AutoValidateAntiforgeryToken]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

    public CategoryController(ICategoryService categoryService, IMapper mapper)
    {
        _categoryService = categoryService;
        _mapper = mapper;
    }
    [Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Index()
    {
        var categories = await _categoryService.GetPagesAsync();

        return View(categories);
    }

    [Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Create()
    {
        var parentCategories = await _categoryService.GetParentCategories();

        CategoryCreateViewModel vm = new() { ParentCategories = parentCategories };

        return View(vm);
    }

    [HttpPost]
    [Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Create(CategoryCreateViewModel model)
    {

        if (!ModelState.IsValid)
        {
            var parentCategories = await _categoryService.GetParentCategories();

            CategoryCreateViewModel vm = new() { ParentCategories = parentCategories };

            return View(vm);
        }

        await _categoryService.CreateAsync(model);

        return RedirectToAction(nameof(Index));
    }

    [Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Details(int id)
    {
        var category = await _categoryService.GetAsync(x => x.Id == id, include: x => x.Include(x => x.SubCategories).Include(x => x.Products));

        if (category == null) return NotFound();

        var subcategories = await _categoryService.GetSubCategories(id);

        category.SubCategories = subcategories;

        return View(category);
    }
    [Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Update(int id)
    {

        var category = await _categoryService.GetAsync(id);

        var parentCategories = await _categoryService.GetParentCategories();
        
        var vm = _mapper.Map<CategoryUpdateViewModel>(category);   

        vm.ParentCategories = parentCategories;

        return View(vm);
    }
    [HttpPost]
    [Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Update(CategoryUpdateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            var parentCategories = await _categoryService.GetParentCategories();

            CategoryUpdateViewModel vm = new() { ParentCategories = parentCategories };

            return View(vm);
        }

       await _categoryService.UpdateAsync(model);

        return RedirectToAction(nameof(Index));
    }
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var category = await _categoryService.GetAsync(id);

        if (category == null) return NotFound();

        
            await _categoryService.RemoveAsync(id);

        return RedirectToAction(nameof(Index));

    }
 
}
