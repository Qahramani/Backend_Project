using Microsoft.AspNetCore.Mvc;
using Pustok.BLL.UI.Services.Abstraction;

namespace Pustok.MVC.Controllers;
[AutoValidateAntiforgeryToken]

public class HomeController : Controller
{
    private readonly IHomeService _homeService;

    public HomeController(IHomeService homeService)
    {
        _homeService = homeService;
    }

    public async Task<IActionResult> Index(int? id)
    {
        var vm = await _homeService.GetHomeViewModel(id);

        return View(vm);
    }
}
