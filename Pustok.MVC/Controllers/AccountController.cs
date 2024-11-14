using Microsoft.AspNetCore.Mvc;

namespace Pustok.MVC.Controllers;

public class AccountController : Controller
{
    public IActionResult Login()
    {
        return View();
    }
    public IActionResult Register()
    {
        return View();
    }
}
