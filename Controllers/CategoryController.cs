using Microsoft.AspNetCore.Mvc;
using WebCooking.Models.ViewModels;
using WebCooking.Services.Interfaces;

namespace WebCooking.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly IRecipeService _recipeService;

    public CategoryController(ICategoryService categoryService, IRecipeService recipeService)
    {
        _categoryService = categoryService;
        _recipeService = recipeService;
    }
    
    [HttpGet("/categories")]
    public async Task<IActionResult> Categories()
    {
        var categories = await _categoryService.GetAllAsync();
        return View(categories.ToList());
    }

    public async Task<IActionResult> Details(int categoryId)
    {
        var category = await _categoryService.GetByIdAsync(categoryId);
        return View(category);
    }
}