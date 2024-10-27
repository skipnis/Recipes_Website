namespace WebCooking.Models;

public class RecipeIngredient
{
    public long RecipeId { get; set; }
    public virtual Recipe? Recipe { get; set; }
    
    public long IngredientId { get; set; }
    public virtual Ingredient? Ingredient { get; set; }
    
    public int Quantity { get; set; }
    public string? UnitOfMeasure { get; set; }
}