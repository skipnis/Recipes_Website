using Microsoft.AspNetCore.Mvc;
using WebCooking.Services.Interfaces;

namespace WebCooking.Controllers;

public class MealController : Controller
{
    private readonly IMealService _mealService;

    public MealController(IMealService mealService)
    {
        _mealService = mealService;
    }
    
    [HttpGet("/meals")]
    public async Task<IActionResult> Meals()
    {
        var meals = await _mealService.GetAllAsync();
        return View(meals.ToList());
    }
    
    public async Task<IActionResult> Details(int categoryId)
    {
        var category = await _mealService.GetByIdAsync(categoryId);
        return View(category);
    }
}