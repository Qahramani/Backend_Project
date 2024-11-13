using Microsoft.AspNetCore.Mvc;
using Pustok.BLL.Services.Abstraction;

namespace Pustok.MVC.Areas.Admin.Controllers;
[Area("Admin")]
public class SliderController : Controller
{ 
    private readonly ISliderService _sliderService;

    public SliderController(ISliderService sliderService)
    {
        _sliderService = sliderService;
    }

    public IActionResult Index()
    {

        return View();
    }
}
