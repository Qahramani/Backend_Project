using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pustok.BLL.Services.Abstraction;
using Pustok.BLL.ViewModels;

namespace Pustok.MVC.Areas.Admin.Controllers;
[Area("Admin")]
[AutoValidateAntiforgeryToken]
public class TagController : Controller
{
    private readonly ITagService _tagService;
    private readonly IMapper _mapper;

    public TagController(ITagService tagService, IMapper mapper)
    {
        _tagService = tagService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var tags = await _tagService.GetAllAsync();

        return View(tags);
    }

    
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(TagCreateViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        await _tagService.CreateAsync(model);

        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Update(int id)
    {
        var tag = await _tagService.GetAsync(id);

        if (tag == null) return NotFound();

        var tagVm = _mapper.Map<TagUpdateViewModel>(tag);

        return View(tagVm);
    }
    [HttpPost]
    public async Task<IActionResult> Update(TagUpdateViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        await _tagService.UpdateAsync(model);

        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Delete(int id)
    {
       await _tagService.RemoveAsync(id);

        return RedirectToAction(nameof(Index));
    }
}

