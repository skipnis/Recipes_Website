namespace WebCooking.Models;

public class FavouriteRecipe
{
    public  string? UserId { get; set; }
    public User? User { get; set; }
    
    public long RecipeId { get; set; }
    public Recipe? Recipe { get; set; }
}