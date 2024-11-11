using WebCooking.Data;
using WebCooking.Models;
using WebCooking.Repositories.Interfaces;

namespace WebCooking.Repositories.Implementations;

public class IngredientRepositoryImpl : RepositoryImpl<Ingredient>, IIngredientRepository
{
    public IngredientRepositoryImpl(ApplicationContext context) : base(context)
    {
        
    }
}