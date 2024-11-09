using Microsoft.EntityFrameworkCore;
using WebCooking.Data;
using WebCooking.Models;
using WebCooking.Repositories.Interfaces;

namespace WebCooking.Repositories.Implementations;

public class MealRepositoryImpl : RepositoryImpl<Meal>, IMealRepository
{
    public MealRepositoryImpl(ApplicationContext context) : base(context)
    {
    }

    public override async Task<Meal> GetByIdAsync(long id)
    {
        return _dbSet
            .Include(m=>m.Recipes)
            .FirstOrDefault(m => m.Id == id);
    }
}