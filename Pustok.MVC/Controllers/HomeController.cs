using Microsoft.AspNetCore.Mvc;
using Pustok.MVC.Models;
using System.Diagnostics;

namespace Pustok.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
