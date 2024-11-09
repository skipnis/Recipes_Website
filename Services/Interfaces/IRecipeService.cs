using WebCooking.Models;
using WebCooking.Models.ViewModels;

namespace WebCooking.Services.Interfaces;

public interface IRecipeService : IService<Recipe>
{
    Task<IEnumerable<Recipe>> GetByCategoryAsync(int categoryId);
}