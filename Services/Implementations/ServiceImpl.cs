using WebCooking.Repositories.Interfaces;
using WebCooking.Services.Interfaces;

namespace WebCooking.Services.Implementations;

public class ServiceImpl<T> : IService<T> where T : class
{
    protected readonly IRepository<T> _repository;

    protected ServiceImpl(IRepository<T> repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<T> GetByIdAsync(long id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await _repository.AddAsync(entity);
    }

    public async Task UpdateAsync(T entity)
    {
        await _repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}