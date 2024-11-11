using WebCooking.Models;
using WebCooking.Repositories.Interfaces;
using WebCooking.Services.Interfaces;

namespace WebCooking.Services.Implementations;

public class IngredientServiceImpl : ServiceImpl<Ingredient>, IIngredientService
{
    private readonly IIngredientRepository _ingredientRepository;

    public IngredientServiceImpl(IIngredientRepository ingredientRepository) : base(ingredientRepository)
    {
        _ingredientRepository = ingredientRepository;
    }

    public async Task<Ingredient?> GetByNameAsync(string name)
    {
        return await _ingredientRepository.GetByNameAsync(name);
    }
}