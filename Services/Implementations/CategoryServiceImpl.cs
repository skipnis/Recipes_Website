using WebCooking.Models;
using WebCooking.Repositories.Interfaces;
using WebCooking.Services.Interfaces;

namespace WebCooking.Services.Implementations;

public class CategoryServiceImpl : ServiceImpl<Category>, ICategoryService
{
    private readonly IRepository<Category> _repository;
    
    public CategoryServiceImpl(IRepository<Category> repository) : base(repository)
    {
        _repository = repository;
    }
}