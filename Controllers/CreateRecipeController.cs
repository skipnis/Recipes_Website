using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebCooking.Models;
using WebCooking.Models.ViewModels;
using WebCooking.Services.Interfaces;

namespace WebCooking.Controllers;

public class CreateRecipeController : Controller
{
    private readonly IRecipeService _recipeService;
    private readonly ICategoryService _categoryService; // предположим, что у вас есть ICategoryService для категорий
    private readonly IMealService _mealService;         // предположим, что у вас есть IMealService для типов блюд
    private readonly IIngredientService _ingredientService; // предположим, что у вас есть IIngredientService для ингредиентов

    public CreateRecipeController(IRecipeService recipeService, ICategoryService categoryService, IMealService mealService, IIngredientService ingredientService)
    {
        _recipeService = recipeService;
        _categoryService = categoryService;
        _mealService = mealService;
        _ingredientService = ingredientService;
    }

    // GET: Recipe/Create
    public async Task<IActionResult> Create()
    {
        ViewBag.Categories = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
        ViewBag.Meals = new SelectList(await _mealService.GetAllAsync(), "Id", "Name");
        ViewBag.Ingredients = new SelectList(await _ingredientService.GetAllAsync(), "Id", "Name");
        return View();
    }

    // POST: Recipe/Create
    [HttpPost]
    public async Task<IActionResult> Create(RecipeViewModel model)
{
    if (ModelState.IsValid)
    {
        string imagePath = null;

        if (model.ImageFile != null)
        {
            var uploadsFolder = Path.Combine("wwwroot", "images", "recipes");
            Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageFile.FileName;
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await model.ImageFile.CopyToAsync(fileStream);
            }

            imagePath = Path.Combine("images", "recipes", uniqueFileName);
        }

        var recipe = new Recipe
        {
            Name = model.Name, // Установка названия рецепта
            ImagePath = imagePath,
            Description = model.Description,
            CategoryId = model.CategoryId,
            MealId = model.MealId,
            Instructions = model.Instructions.Select(i => new Instruction { Text = i.Text, Order = i.Order }).ToList(),
            RecipeIngredients = new List<RecipeIngredient>()
        };

        foreach (var ingredient in model.RecipeIngredients)
        {
            var existingIngredient = await _ingredientService.GetByIdAsync(ingredient.IngredientId);
            if (existingIngredient != null)
            {
                recipe.RecipeIngredients.Add(new RecipeIngredient
                {
                    IngredientId = existingIngredient.Id,
                    Quantity = ingredient.Quantity,
                    Unit = ingredient.Unit
                });
            }
        }

        await _recipeService.AddAsync(recipe);
        return RedirectToAction("Index");
    }

    ViewBag.Categories = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
    ViewBag.Meals = new SelectList(await _mealService.GetAllAsync(), "Id", "Name");
    ViewBag.Ingredients = new SelectList(await _ingredientService.GetAllAsync(), "Id", "Name");
    return View(model);
}

}