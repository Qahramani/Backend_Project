using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pustok.BLL.Services.Abstraction;
using Pustok.BLL.ViewModels;

namespace Pustok.MVC.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = "Moderator,Admin")]
[AutoValidateAntiforgeryToken]
public class SubscribeController : Controller
{

    private readonly ISubscribeService _subscribeService;
    private readonly IMapper _mapper;

    public SubscribeController(ISubscribeService subscribeService, IMapper mapper)
    {
        _subscribeService = subscribeService;
        _mapper = mapper;
    }
    [Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Index(int page = 0)
    {
        var subscribes = await _subscribeService.GetPagesAsync(index : page,size:2);

        return View(subscribes);
    }

    [Authorize(Roles = "Moderator,Admin")]
    public IActionResult Create()
    {
        var vm = new SubscribeCreateViewModel()
        {
            IsActive = true
        };
        return View(vm);
    }

    [HttpPost]
    [Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Create(SubscribeCreateViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        await _subscribeService.CreateAsync(model);

        return RedirectToAction(nameof(Index));
    }
    [Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Update(int id)
    {
        var subscribe = await _subscribeService.GetAsync(id);

        if (subscribe == null) return NotFound();

        var subscribeVm = _mapper.Map<SubscribeUpdateViewModel>(subscribe);

        return View(subscribeVm);
    }
    [HttpPost]
    [Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> Update(SubscribeUpdateViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        await _subscribeService.UpdateAsync(model);

        return RedirectToAction(nameof(Index));
    }
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        await _subscribeService.RemoveAsync(id);

        return RedirectToAction(nameof(Index));
    }
}
