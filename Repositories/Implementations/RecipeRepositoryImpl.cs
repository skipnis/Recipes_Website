using Microsoft.EntityFrameworkCore;
using WebCooking.Data;
using WebCooking.Models;
using WebCooking.Models.ViewModels;
using WebCooking.Repositories.Interfaces;

namespace WebCooking.Repositories.Implementations;

public class RecipeRepositoryImpl : RepositoryImpl<Recipe>, IRecipeRepository
{
    public RecipeRepositoryImpl(ApplicationContext context) : base(context)
    {
    }
    
    public override async Task<Recipe> GetByIdAsync(long id)
    {
        return await _dbSet
            .Include(r => r.RecipeIngredients) 
            .ThenInclude(ri => ri.Ingredient)
            .Include(r => r.Instructions)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    
    
    public async Task<IEnumerable<Recipe>> GetPagedRecipesAsync(int skip, int take)
    {
        return await _dbSet
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Recipe>> GetByCategoryAsync(int categoryId)
    {
        return await _context.Recipes
            .Where(r => r.CategoryId == categoryId) // Предполагается, что у вас есть поле CategoryId в Recipe
            .ToListAsync();
    }
}