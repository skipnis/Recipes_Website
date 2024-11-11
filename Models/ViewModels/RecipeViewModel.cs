namespace WebCooking.Models.ViewModels;

public class RecipeViewModel
{
    public string Name { get; set; } = string.Empty;
    public IFormFile? ImageFile { get; set; }
    public string? Description { get; set; }
    public long CategoryId { get; set; }
    public long MealId { get; set; }
    public List<InstructionViewModel> Instructions { get; set; } = new();
    public List<RecipeIngredientViewModel> RecipeIngredients { get; set; } = new();
}
