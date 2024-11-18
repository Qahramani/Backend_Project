using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.BLL.Services.Abstraction;
using Pustok.BLL.UI.Services.Abstraction;
using Pustok.BLL.ViewModels;
using Pustok.DAL.DataContext.Entities;

namespace Pustok.MVC.Controllers;
[AutoValidateAntiforgeryToken]

public class HomeController : Controller
{
    private readonly IHomeService _homeService;
    private readonly ISubscribeService _subscribeService;
    public HomeController(IHomeService homeService, ISubscribeService subscribeService = null)
    {
        _homeService = homeService;
        _subscribeService = subscribeService;
    }

    public async Task<IActionResult> Index(int? id)
    {
        var vm = await _homeService.GetHomeViewModel(id);

        return View(vm);
    }
    public async Task<IActionResult> ProductDetails(int id)
    {
        var productVM = await _homeService.GetProductDetailsAsync(id);

        return View(productVM);
    }
    [HttpPost]
    public async Task<IActionResult> Subscribe(string Email)
    {
        if (string.IsNullOrEmpty(Email))
        {
            TempData["Error"] = "Email is required.";
            return RedirectToAction("Index");
        }

        if (await _subscribeService.GetAsync(s => s.Email == Email) != null)
        {
            TempData["Error"] = "You are already subscribed.";
            return RedirectToAction("Index");
        }

     
        var subscriber = new SubscribeCreateViewModel { Email = Email, IsActive = true };

        await _subscribeService.CreateAsync(subscriber);

        TempData["Success"] = "Thank you for subscribing!";
        return RedirectToAction("Index");
    }
}
