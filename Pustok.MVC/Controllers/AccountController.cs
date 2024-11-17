using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pustok.BLL.Services.Abstraction;
using Pustok.BLL.ViewModels.AccountViewModels;
using Pustok.DAL.DataContext.Entities;

namespace Pustok.MVC.Controllers;
[AutoValidateAntiforgeryToken]
public class AccountController : Controller
{
    private readonly IAccountService _accountService;
    private readonly UserManager<AppUser> _userManager;

    public AccountController(IAccountService accountService, UserManager<AppUser> userManager)
    {
        _accountService = accountService;
        _userManager = userManager;
    }

    public IActionResult Login()
    {
        
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        var result = await _accountService.LoginAsync(model, ModelState);

        if(!result)
            return View(model);

        //var reffererUrl = Request.Headers["Referer"].ToString();

        //return Redirect(reffererUrl);
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {

        if(!ModelState.IsValid)
        {
            return View(model);
        }

       var result = await _accountService.RegisetrAsync(model, ModelState);

        if (!result.Success)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error);
                return View(model);
            }
        }
        return RedirectToAction(nameof(Login));
    }
    public async Task<IActionResult> Logout()
    {
        await _accountService.LogoutAsync();

        return RedirectToAction("index", "home");
    }
    [HttpGet]
    public async Task<IActionResult> VerifyEmail(string userId, string token)
    {
        if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
        {
            return BadRequest("Invalid email verification request.");
        }

        // Retrieve the user from the database
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound("User not found.");
        }

        // Verify the token
        var result = await _userManager.ConfirmEmailAsync(user, token);
        if (!result.Succeeded)
        {
            return BadRequest("Email verification failed. The token may be invalid or expired.");
        }

        // Return a confirmation message or redirect to another page
        return Ok("Email verified successfully! You can now log in.");
    }
}
