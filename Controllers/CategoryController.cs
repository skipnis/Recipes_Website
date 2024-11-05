using Microsoft.AspNetCore.Mvc;
using WebCooking.Services.Interfaces;

namespace WebCooking.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    [HttpGet("/categories")]
    public async Task<IActionResult> Categories()
    {
        var categories = await _categoryService.GetAllAsync();
        return View(categories.ToList());
    }

}