using Microsoft.AspNetCore.Mvc;
using Pustok.BLL.Services.Abstraction;

namespace Pustok.MVC.Controllers;
[AutoValidateAntiforgeryToken]
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

        var reffererurl = Request.Headers["referer"].ToString();

        return Redirect(reffererurl);

    }
    public async Task<IActionResult> ShoppingCard()
    {
        var basket = await _basketService.ShoppingCardAsync();

        return View(basket);
    }
}
