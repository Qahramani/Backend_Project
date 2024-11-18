using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pustok.BLL.Services.Abstraction;
using Pustok.BLL.ViewModels;

namespace Pustok.MVC.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = "Moderator,Admin")]
[AutoValidateAntiforgeryToken]
public class SettingController : Controller
{
    private readonly ISettingService _settingService;
    private readonly IMapper _mapper;

    public SettingController(ISettingService settingService, IMapper mapper)
    {
        _settingService = settingService;
        _mapper = mapper;
    }
    [Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Index()
    {
        var settings = await _settingService.GetAllAsync();

        return View(settings);
    }

    [Authorize(Roles = "Moderator,Admin")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Create(SettingCreateViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        await _settingService.CreateAsync(model);

        return RedirectToAction(nameof(Index));
    }
    [Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Update(int id)
    {
        var setting = await _settingService.GetAsync(id);

        if (setting == null) return NotFound();

        var settingVm = _mapper.Map<SettingUpdateViewModel>(setting);

        return View(settingVm);
    }
    [HttpPost]
    [Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Update(SettingUpdateViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        await _settingService.UpdateAsync(model);

        return RedirectToAction(nameof(Index));
    }

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        await _settingService.RemoveAsync(id);

        return RedirectToAction(nameof(Index));
    }
}
