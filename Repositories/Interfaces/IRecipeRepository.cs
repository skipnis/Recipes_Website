using WebCooking.Models;
using WebCooking.Models.ViewModels;

namespace WebCooking.Repositories.Interfaces;

public interface IRecipeRepository : IRepository<Recipe>
{
    Task<IEnumerable<Recipe>> GetByCategoryAsync(int categoryId);
    
    Task AddToFavoritesAsync(string userId, long recipeId);
    
    Task RemoveFromFavoritesAsync(string userId, long recipeId);
    
    Task<IEnumerable<Recipe>> GetFavouriteRecipes(string userId);
}