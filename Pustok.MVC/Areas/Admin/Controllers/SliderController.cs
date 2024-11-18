using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pustok.BLL.Services.Abstraction;
using Pustok.BLL.ViewModels;

namespace Pustok.MVC.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = "Moderator,Admin")]
[AutoValidateAntiforgeryToken]
public class SliderController : Controller
{ 
    private readonly ISliderService _sliderService;
    private readonly IMapper _mapper;

    public SliderController(ISliderService sliderService, IMapper mapper)
    {
        _sliderService = sliderService;
        _mapper = mapper;
    }
    [Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Index()
    {
        var sliders = await _sliderService.GetAllAsync();

        return View(sliders);
    }
    [Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Details(int id)
    {
        var slider = await _sliderService.GetAsync(id);

        if(slider == null) return NotFound();

        return View(slider);
    }
    [Authorize(Roles = "Moderator,Admin")]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Create(SliderCreateViewModel model)
    {
        if (!ModelState.IsValid) 
            return View(model);

        await _sliderService.CreateAsync(model);

        return RedirectToAction(nameof(Index));
    }
    [Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Update(int id)
    {
        var slider = await _sliderService.GetAsync(id);

        if(slider == null) return NotFound();

        var sliderUpdate = _mapper.Map<SliderUpdateViewModel>(slider);

        return View(sliderUpdate);
    }
    [HttpPost]
    [Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Update(SliderUpdateViewModel model)
    {
        await _sliderService.UpdateAsync(model);

        return RedirectToAction(nameof(Index));
    }
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var slider = await _sliderService.GetAsync(id);

        if (slider == null) return NotFound();

        await _sliderService.RemoveAsync(id);

        return RedirectToAction(nameof(Index));
    }
}

