using Microsoft.AspNetCore.Identity;
using WebCooking.Data;
using WebCooking.Models;
using WebCooking.Repositories.Interfaces;

namespace WebCooking.Repositories.Implementations;

public class UserRepositoryImpl : RepositoryImpl<User>, IUserRepository
{
    private readonly UserManager<User> _userManager;

    public UserRepositoryImpl(ApplicationContext context, UserManager<User> userManager) 
        : base(context)
    {
        _userManager = userManager;
    }
    
    public async Task<User> GetByIdAsync(string userId)
    {
        return await _dbSet.FindAsync(userId);  // Используем FindAsync с ID типа string
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
        if (user != null)
        {
            var result = await _userManager.AddToRoleAsync(user, roleName);
            if (!result.Succeeded)
            {
                throw new Exception($"Failed to add role {roleName} to user {userId}");
            }
        }
    }

    public async Task RemoveRoleFromUserAsync(string userId, string roleName)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user != null)
        {
            var result = await _userManager.RemoveFromRoleAsync(user, roleName);
            if (!result.Succeeded)
            {
                throw new Exception($"Failed to remove role {roleName} from user {userId}");
            }
        }
    }
}