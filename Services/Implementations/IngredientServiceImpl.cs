using WebCooking.Models;
using WebCooking.Repositories.Interfaces;
using WebCooking.Services.Interfaces;

namespace WebCooking.Services.Implementations;

public class IngredientServiceImpl : ServiceImpl<Ingredient>, IIngredientService
{
    public IngredientServiceImpl(IRepository<Ingredient> repository) : base(repository)
    {
    }
}