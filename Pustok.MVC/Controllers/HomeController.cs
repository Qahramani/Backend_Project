using Microsoft.AspNetCore.Mvc;
using Pustok.BLL.UI.Services.Abstraction;
using Pustok.MVC.Models;
using System.Diagnostics;

namespace Pustok.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        public async Task<IActionResult> Index()
        {
            var homeVm = await _homeService.GetHomeViewModel();

            return View(homeVm);
        }
    }
}
