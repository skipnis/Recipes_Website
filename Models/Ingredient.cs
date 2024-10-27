namespace WebCooking.Models;

public class Ingredient
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public virtual ICollection<RecipeIngredient>? RecipeIngredients { get; set; }
}