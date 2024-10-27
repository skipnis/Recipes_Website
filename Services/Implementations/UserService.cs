using WebCooking.Models;
using WebCooking.Services.Interfaces;

namespace WebCooking.Services.Implementations;

public class UserService : IUserService
{
    private readonly IUserRepository? _userRepository;
    
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _userRepository.GetAllUsersAsync();
    }

    public async Task<User> GetUserByIdAsync(long id)
    {
        return await _userRepository.GetUserByIdAsync(id);
    }

    public async Task AddUserAsync(User user)
    {
        await _userRepository.AddUserAsync(user);
    }

    public async Task UpdateUserAsync(User user)
    {
        await _userRepository.UpdateUserAsync(user);
    }

    public async Task DeleteUserAsync(long id)
    {
        await _userRepository.DeleteUserAsync(id);
    }
}