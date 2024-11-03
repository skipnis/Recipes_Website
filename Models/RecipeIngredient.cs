namespace WebCooking.Models;

public class RecipeIngredient
{
    public long RecipeId { get; set; }
    public Recipe? Recipe { get; set; }
    
    public long IngredientId { get; set; }
    public Ingredient? Ingredient { get; set; }
    
    public float? Quantity { get; set; }
    public string? Unit { get; set; }
}