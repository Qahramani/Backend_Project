﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pustok.BLL.Services.Abstraction;
using Pustok.BLL.ViewModels;

namespace Pustok.MVC.Areas.Admin.Controllers;
[Area("Admin")]
public class SubscribeController : Controller
{

    private readonly ISubscribeService _subscribeService;
    private readonly IMapper _mapper;

    public SubscribeController(ISubscribeService subscribeService, IMapper mapper)
    {
        _subscribeService = subscribeService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var subscribes = await _subscribeService.GetAllAsync();

        return View(subscribes);
    }


    public IActionResult Create()
    {
        var vm = new SubscribeCreateViewModel()
        {
            IsActive = true
        };
        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Create(SubscribeCreateViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        await _subscribeService.CreateAsync(model);

        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Update(int id)
    {
        var subscribe = await _subscribeService.GetAsync(id);

        if (subscribe == null) return NotFound();

        var subscribeVm = _mapper.Map<SubscribeUpdateViewModel>(subscribe);

        return View(subscribeVm);
    }
    [HttpPost]
    public async Task<IActionResult> Update(SubscribeUpdateViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        await _subscribeService.UpdateAsync(model);

        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Delete(int id)
    {
        await _subscribeService.RemoveAsync(id);

        return RedirectToAction(nameof(Index));
    }
}
