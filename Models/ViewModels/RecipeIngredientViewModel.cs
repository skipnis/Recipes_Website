namespace WebCooking.Models.ViewModels;

public class RecipeIngredientViewModel
{
    public string? Name { get; set; } 
    public long IngredientId { get; set; }
    public float? Quantity { get; set; }
    public string? Unit { get; set; }
}