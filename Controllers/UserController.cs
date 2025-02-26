using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebCooking.Models.ViewModels;
using WebCooking.Services.Interfaces;

namespace WebCooking.Controllers;

[Authorize(Roles = "Admin")]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    public async Task<IActionResult> Index()
    {
        var users = await _userService.GetAllUsersAsync();
        return View(users);
    }
    
    public async Task<IActionResult> Details(string userId)
    {
        var user = await _userService.GetUserByIdAsync(userId);
        if (user == null)
        {
            return NotFound();
        }
        var roles = await _userService.GetUserRolesAsync(userId);
        var model = new UserRolesViewModel
        {
            User = user,
            Roles = roles
        };
        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddRole(string userId, string roleName)
    {
        try
        {
            await _userService.AddRoleToUserAsync(userId, roleName);
            return RedirectToAction("Details", new { userId });
        }
        catch (Exception ex)
        {
            TempData["Error"] = ex.Message;
            return RedirectToAction("Details", new { userId });
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> RemoveRole(string userId, string roleName)
    {
        try
        {
            await _userService.RemoveRoleFromUserAsync(userId, roleName);
            return RedirectToAction("Details", new { userId });
        }
        catch (Exception ex)
        {
            TempData["Error"] = ex.Message;
            return RedirectToAction("Details", new { userId });
        }
    }
}