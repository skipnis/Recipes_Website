using WebCooking.Models;
using WebCooking.Repositories.Interfaces;
using WebCooking.Services.Interfaces;

namespace WebCooking.Services.Implementations;

public class MealServiceImpl : ServiceImpl<Meal>, IMealService
{
    public MealServiceImpl(IRepository<Meal> repository) : base(repository)
    {
    }
}