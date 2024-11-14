using System.Collections;
using Microsoft.AspNetCore.Identity;

namespace WebCooking.Models;

public class User : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    
    public virtual ICollection<FavouriteRecipe>? FavouriteRecipes { get; set; }
}