using Microsoft.AspNetCore.Identity;
using WebCooking.Models;

namespace WebCooking.Repositories.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetByIdAsync(string userId); 
    Task<IEnumerable<string>> GetUserRolesAsync(string userId);
    Task AddRoleToUserAsync(string userId, string roleName);
    Task RemoveRoleFromUserAsync(string userId, string roleName);
}