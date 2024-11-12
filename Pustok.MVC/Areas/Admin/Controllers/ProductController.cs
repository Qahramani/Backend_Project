using Microsoft.AspNetCore.Mvc;

namespace Pustok.MVC.Areas.Admin.Controllers;

public class ProductController : Controller
{
    [Area("Admin")]
    public IActionResult Index()
    {
        return View();
    }
}
