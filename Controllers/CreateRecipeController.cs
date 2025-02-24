using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebCooking.Models;
using WebCooking.Models.ViewModels;
using WebCooking.Services.Interfaces;

namespace WebCooking.Controllers;

public class CreateRecipeController : Controller
{
    private readonly IRecipeService _recipeService;
    private readonly ICategoryService _categoryService; 
    private readonly IMealService _mealService;        
    private readonly IIngredientService _ingredientService;

    public CreateRecipeController(IRecipeService recipeService, ICategoryService categoryService, IMealService mealService, IIngredientService ingredientService)
    {
        _recipeService = recipeService;
        _categoryService = categoryService;
        _mealService = mealService;
        _ingredientService = ingredientService;
    }
    
    public async Task<IActionResult> Create()
    {
        ViewBag.Categories = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
        ViewBag.Meals = new SelectList(await _mealService.GetAllAsync(), "Id", "Name");
        ViewBag.Ingredients = new SelectList(await _ingredientService.GetAllAsync(), "Id", "Name");
        var model = new RecipeViewModel
        {
            RecipeIngredients = new List<RecipeIngredientViewModel>()
        };
        return View(model);
    }
    
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
                Name = model.Name,
                ImagePath = imagePath,
                Description = model.Description,
                CategoryId = model.CategoryId,
                MealId = model.MealId,
                Instructions = model.Instructions.Select(i => new Instruction { Text = i.Text, Order = i.Order }).ToList(),
                RecipeIngredients = new List<RecipeIngredient>()
            };
            
            foreach (var ingredientModel in model.RecipeIngredients)
            {
                var existingIngredient = await _ingredientService.GetByNameAsync(ingredientModel.Name);

                long ingredientId;
                if (existingIngredient != null)
                {
                    ingredientId = existingIngredient.Id;
                }
                else
                {
                    var newIngredient = new Ingredient { Name = ingredientModel.Name };
                    await _ingredientService.AddAsync(newIngredient);
                    ingredientId = newIngredient.Id;
                }
                
                recipe.RecipeIngredients.Add(new RecipeIngredient
                {
                    IngredientId = ingredientId,
                    Quantity = ingredientModel.Quantity,
                    Unit = ingredientModel.Unit
                });
            }

            await _recipeService.AddAsync(recipe);
            return RedirectToAction("Recipes", "Recipe");
        }

        ViewBag.Categories = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
        ViewBag.Meals = new SelectList(await _mealService.GetAllAsync(), "Id", "Name");
        return View(model);
    }

}