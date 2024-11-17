using Microsoft.AspNetCore.Mvc;
using Pustok.BLL.Services.Abstraction;

namespace Pustok.MVC.Controllers;

public class BasketController : Controller
{
    private readonly IBasketService _basketService;

    public BasketController(IBasketService basketService)
    {
        _basketService = basketService;
    }

    public async Task<IActionResult> Index()
    {
        return View();
    }

    public async Task<IActionResult> AddToBasket(int id)
    {
        await _basketService.AddToBasketAsync(id);

        return RedirectToAction("Index");
    }
}
