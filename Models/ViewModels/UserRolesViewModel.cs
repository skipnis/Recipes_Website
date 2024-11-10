namespace WebCooking.Models.ViewModels;

public class UserRolesViewModel
{
    public User? User { get; set; }
    public IEnumerable<string>? Roles { get; set; }
}