using Microsoft.EntityFrameworkCore;
using WebCooking.Data;
using WebCooking.Models;
using WebCooking.Repositories.Interfaces;

namespace WebCooking.Repositories.Implementations;

public class IngredientRepositoryImpl : RepositoryImpl<Ingredient>, IIngredientRepository
{
    public IngredientRepositoryImpl(ApplicationContext context) : base(context)
    {
        
    }

    public async Task<Ingredient> GetByNameAsync(string name)
    {
        return await _dbSet.FirstOrDefaultAsync(i => i.Name == name);
    }
}