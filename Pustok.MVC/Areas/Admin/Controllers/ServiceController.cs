using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pustok.BLL.Services.Abstraction;
using Pustok.BLL.ViewModels;

namespace Pustok.MVC.Areas.Admin.Controllers;

[Area("Admin")]
[AutoValidateAntiforgeryToken]
public class ServiceController : Controller
{
    private readonly IServiceService _serviceService;
    private readonly IMapper _mapper;

    public ServiceController(IServiceService serviceService, IMapper mapper)
    {
        _serviceService = serviceService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var services = await _serviceService.GetAllAsync();

        return View(services);
    }

    public IActionResult Create()
    {
        return View();  
    }
    [HttpPost]
    public async Task<IActionResult> Create(ServiceCreateViewModel model)
    {
        if(!ModelState.IsValid) return View(model);

        await _serviceService.CreateAsync(model);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int id)
    {
        var service = await _serviceService.GetAsync(id);

        if(service == null) return NotFound();

        var serviceVm = _mapper.Map<ServiceUpdateViewModel>(service);

        return View(serviceVm);
    }
    [HttpPost]
    public async Task<IActionResult> Update(ServiceUpdateViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        await _serviceService.UpdateAsync(model);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
         await _serviceService.RemoveAsync(id);

        return RedirectToAction(nameof(Index));
    }
}
