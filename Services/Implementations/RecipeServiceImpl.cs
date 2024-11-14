using WebCooking.Models;
using WebCooking.Models.ViewModels;
using WebCooking.Repositories.Interfaces;
using WebCooking.Services.Interfaces;

namespace WebCooking.Services.Implementations;

public class RecipeServiceImpl : ServiceImpl<Recipe>, IRecipeService
{
    private readonly IRecipeRepository _recipeRepository;
    
    public RecipeServiceImpl(IRecipeRepository recipeRepository) : base(recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }
    
    public async Task<IEnumerable<Recipe>> GetByCategoryAsync(int categoryId)
    {
        return await _recipeRepository.GetByCategoryAsync(categoryId);
    }

    public async Task AddToFavoritesAsync(string userId, long recipeId)
    {
        await _recipeRepository.AddToFavoritesAsync(userId, recipeId);
    }

    public async Task RemoveFromFavouritesAsync(string userId, long recipeId)
    { 
        await _recipeRepository.RemoveFromFavoritesAsync(userId, recipeId);
    }

    public Task<IEnumerable<Recipe>> GetFavouriteRecipes(string userId)
    {
        return _recipeRepository.GetFavouriteRecipes(userId);
    }
}