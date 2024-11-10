using WebCooking.Models;

namespace WebCooking.Services.Interfaces;

public interface IUserService : IService<User>
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User> GetUserByIdAsync(string userId);
    Task<IEnumerable<string>> GetUserRolesAsync(string userId);
    Task AddRoleToUserAsync(string userId, string roleName);
    Task RemoveRoleFromUserAsync(string userId, string roleName);
}