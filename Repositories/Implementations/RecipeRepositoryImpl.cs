using Microsoft.EntityFrameworkCore;
using WebCooking.Data;
using WebCooking.Models;
using WebCooking.Models.ViewModels;
using WebCooking.Repositories.Interfaces;

namespace WebCooking.Repositories.Implementations;

public class RecipeRepositoryImpl : RepositoryImpl<Recipe>, IRecipeRepository
{
    public RecipeRepositoryImpl(ApplicationContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<Recipe>> GetPagedRecipesAsync(int skip, int take)
    {
        return await _dbSet
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Recipe>> GetByCategoryAsync(int categoryId)
    {
        return await _context.Recipes
            .Where(r => r.CategoryId == categoryId) // Предполагается, что у вас есть поле CategoryId в Recipe
            .ToListAsync();
    }

    public async Task<RecipeDetails> GetRecipeDetails(int id)
    {
        var recipeDetails = await (
            from r in _context.Recipes
            join ri in _context.RecipeIngredients on r.Id equals ri.RecipeId
            join i in _context.Ingredients on ri.IngredientId equals i.Id
            join ins in _context.Instructions on r.Id equals ins.RecipeId into instructions
            where r.Id == id
            select new
            {
                Recipe = r,
                RecipeIngredient = ri,
                IngredientName = i.Name, // Получаем название ингредиента
                Instructions = instructions
            }).ToListAsync();

        var recipeDetail = recipeDetails.First();
        return new RecipeDetails
        {
            Recipe = recipeDetail.Recipe,
            RecipeIngredients = recipeDetails.Select(rd => new RecipeIngredient
            {
                RecipeId = rd.RecipeIngredient.RecipeId,
                IngredientId = rd.RecipeIngredient.IngredientId,
                Quantity = rd.RecipeIngredient.Quantity,
                Unit = rd.RecipeIngredient.Unit
            }).ToList(),
            Instructions = recipeDetail.Instructions.ToList(),
            Ingredients = recipeDetails.Select(rd => new Ingredient
            {
                Id = rd.RecipeIngredient.IngredientId,
                Name = rd.IngredientName
            }).ToList() 
        };
    }

}