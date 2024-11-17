using Microsoft.AspNetCore.Mvc;
using Pustok.BLL.Services.Abstraction;
using Pustok.BLL.ViewModels;

namespace Pustok.MVC.Controllers;

public class BasketController : Controller
{
    private readonly IBasketService _basketService;

    public BasketController(IBasketService basketService)
    {
        _basketService = basketService;
    }

    public async Task<IActionResult> AddToBasket(int id)
    {
        await _basketService.AddToBasketAsync(id);

        return RedirectToAction("Index","Home");
    }
    public async Task<IActionResult> ShoppingCard()
    {
        var basket = await _basketService.ShoppingCardAsync();

        return View(basket);
    }
}
