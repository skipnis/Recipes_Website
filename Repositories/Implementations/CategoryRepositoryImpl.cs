using Microsoft.EntityFrameworkCore;
using WebCooking.Data;
using WebCooking.Models;
using WebCooking.Repositories.Interfaces;

namespace WebCooking.Repositories.Implementations;

public class CategoryRepositoryImpl : RepositoryImpl<Category>, ICategoryRepository
{
    public CategoryRepositoryImpl(ApplicationContext context) : base(context)
    {
        
    }
    
    public override async Task<Category> GetByIdAsync(long id)
    {
        return await _dbSet
            .Include(c => c.Recipes) 
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}