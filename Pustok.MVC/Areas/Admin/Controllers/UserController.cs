using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pustok.BLL.Services.Abstraction;

namespace Pustok.MVC.Areas.Admin.Controllers;
[Area("admin")]
[AutoValidateAntiforgeryToken]
public class UserController : Controller
{
    private readonly IAdminService  _adminService;

    public UserController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public async Task<IActionResult> Index()
    {
        var users = await _adminService.GetUsersAsync();

        return View(users);
    }

    [HttpPost]
    //[Authorize("Admin")]
    public async Task<IActionResult> ChangeRole(string userId, List<string> newRoles)
    {
       
        var success = await _adminService.UpdateUserRolesAsync(userId, newRoles);

        if (!success)
        {
            ModelState.AddModelError("", "Failed to update user roles.");
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> DeactivateUser(string userId)
    {
        if (string.IsNullOrEmpty(userId))
        {
            return BadRequest("User ID cannot be null or empty.");
        }

        var success = await _adminService.DeactivateUserAsync(userId);

        if (!success)
        {
            ModelState.AddModelError("", "Failed to deactivate user.");
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> ActivateUser(string userId)
    {
        if (string.IsNullOrEmpty(userId))
        {
            return BadRequest("User ID cannot be null or empty.");
        }

        var success = await _adminService.ActivateUserAsync(userId);

        if (!success)
        {
            ModelState.AddModelError("", "Failed to activate user.");
        }

        return RedirectToAction("Index");
    }

}
