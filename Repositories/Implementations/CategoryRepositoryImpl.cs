using WebCooking.Data;
using WebCooking.Models;
using WebCooking.Repositories.Interfaces;

namespace WebCooking.Repositories.Implementations;

public class CategoryRepositoryImpl : RepositoryImpl<Category>, ICategoryRepository
{
    public CategoryRepositoryImpl(ApplicationContext context) : base(context)
    {
        
    }
}