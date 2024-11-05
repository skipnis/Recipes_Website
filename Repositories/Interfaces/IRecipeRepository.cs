using WebCooking.Models;
using WebCooking.Models.ViewModels;

namespace WebCooking.Repositories.Interfaces;

public interface IRecipeRepository : IRepository<Recipe>
{
    Task<IEnumerable<Recipe>> GetByCategoryAsync(int categoryId);
    
    Task<RecipeDetails> GetRecipeDetails(int id);
}