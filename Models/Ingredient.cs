namespace WebCooking.Models;

public class Ingredient : BaseEnity
{
    public virtual ICollection<RecipeIngredient>? RecipeIngredients { get; set; }
}