using WebCooking.Models;

namespace WebCooking.Repositories.Interfaces;

public interface IIngredientRepository : IRepository<Ingredient>
{
    public Task<Ingredient> GetByNameAsync(string name);
}