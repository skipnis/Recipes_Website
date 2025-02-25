using Microsoft.AspNetCore.Identity;
using WebCooking.Models;
using WebCooking.Repositories.Interfaces;
using WebCooking.Services.Interfaces;

namespace WebCooking.Services.Implementations;

public class UserServiceImpl : ServiceImpl<User>, IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly UserManager<User> _userManager;

    public UserServiceImpl(IUserRepository userRepository, UserManager<User> userManager) : base(userRepository)
    {
        _userRepository = userRepository;
        _userManager = userManager;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task<User> GetUserByIdAsync(string userId)
    {
        return await _userRepository.GetByIdAsync(userId);
    }

    public async Task<IEnumerable<string>> GetUserRolesAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId); 
        if (user == null)
        {
            return new List<string>(); 
        }

        return await _userManager.GetRolesAsync(user);
    }

    public async Task AddRoleToUserAsync(string userId, string roleName)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            throw new Exception($"User with ID {userId} not found.");
        }

        var result = await _userManager.AddToRoleAsync(user, roleName);
        if (!result.Succeeded)
        {
            throw new Exception($"Failed to add role {roleName} to user {userId}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }
    }

    public async Task RemoveRoleFromUserAsync(string userId, string roleName)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            throw new Exception($"User with ID {userId} not found.");
        }

        var result = await _userManager.RemoveFromRoleAsync(user, roleName);
        if (!result.Succeeded)
        {
            throw new Exception($"Failed to remove role {roleName} from user {userId}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }
    }
}