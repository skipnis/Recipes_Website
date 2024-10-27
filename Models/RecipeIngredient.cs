namespace WebCooking.Models;

public class RecipeIngredient
{
    public long RecipeId { get; set; }
    public virtual Recipe? Recipe { get; set; }
    
    public long IngredientId { get; set; }
    public virtual Ingredient? Ingredient { get; set; }
    
    public string? Quantity { get; set; }
}