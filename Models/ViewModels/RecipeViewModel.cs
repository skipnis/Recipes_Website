namespace WebCooking.Models.ViewModels;

public class RecipeViewModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public long CategoryId { get; set; }
    public long MealId { get; set; }
    public IFormFile ImageFile { get; set; }
    
    // Initialize RecipeIngredients to avoid NullReferenceException
    public List<RecipeIngredientViewModel> RecipeIngredients { get; set; } = new List<RecipeIngredientViewModel>();
    
    // Initialize Instructions as well
    public List<InstructionViewModel> Instructions { get; set; } = new List<InstructionViewModel>();
}