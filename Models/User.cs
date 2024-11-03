using Microsoft.AspNetCore.Identity;

namespace WebCooking.Models;

public class User : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}