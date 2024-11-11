namespace WebCooking.Models.ViewModels;

public class RecipeIngredientViewModel
{
    public long IngredientId { get; set; }
    public float? Quantity { get; set; }
    public string? Unit { get; set; }
}