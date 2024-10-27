using System.ComponentModel.DataAnnotations.Schema;

namespace WebCooking.Models;

public class User
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? PasswordHash { get; set; }
    public string? Email { get; set; }
}