using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebCooking.Models.ViewModels;
using WebCooking.Services.Interfaces;

namespace WebCooking.Controllers;

[Controller]
public class HomeController : Controller
{
    private readonly ICategoryService _categoryService;
    
    public HomeController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public IActionResult Home()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet("/recipes")]
    public IActionResult Recipes()
    {
        return View();
    }
    
    [HttpGet]
    public async Task<IActionResult> Categories()
    {
        var categories = await _categoryService.GetAllAsync();
        return View(categories.ToList());
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}