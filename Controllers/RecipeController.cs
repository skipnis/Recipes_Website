using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebCooking.Models.ViewModels;
using WebCooking.Services.Interfaces;

namespace WebCooking.Controllers;

public class RecipeController : Controller
{
    private readonly IRecipeService _recipeService;
    public RecipeController(IRecipeService recipeService)
    {
        _recipeService = recipeService;
    }

    [HttpGet("/recipes")]
    public async Task<IActionResult> Recipes()
    {
        var recipes = await _recipeService.GetAllAsync();
        return View(recipes.ToList());
    }
    
    public async Task<IActionResult> Details(int recipeId)
    {
        /*var recipeDetails = await _recipeService.GetRecipeDetails(recipeId);
        return  View(recipeDetails);*/
        
        var recipe = await _recipeService.GetByIdAsync(recipeId);
        return View(recipe);
    }
    
    
}