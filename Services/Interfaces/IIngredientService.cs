using WebCooking.Models;

namespace WebCooking.Services.Interfaces;

public interface IIngredientService : IService<Ingredient>
{
    Task<Ingredient?> GetByNameAsync(string name);
}