using Microsoft.AspNetCore.Mvc;
using WebCooking.Services.Interfaces;

namespace WebCooking.Controllers;

public class UserController : Controller
{
    private readonly IUserService? _userService;

    public UserController(IUserService? userService)
    {
        _userService = userService;
    }
    
    // GET
    public async Task<IActionResult> Users()
    {
        var users = (await _userService.GetAllUsersAsync()).ToList();
        return View(users);
    }
}