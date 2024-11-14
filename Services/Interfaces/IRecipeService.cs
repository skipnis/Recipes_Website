using WebCooking.Models;
using WebCooking.Models.ViewModels;

namespace WebCooking.Services.Interfaces;

public interface IRecipeService : IService<Recipe>
{
    Task<IEnumerable<Recipe>> GetByCategoryAsync(int categoryId);
    
    Task AddToFavoritesAsync(string userId, long recipeId);
    Task RemoveFromFavouritesAsync(string userId, long recipeId);
    
    Task<IEnumerable<Recipe>> GetFavouriteRecipes(string userId);
}