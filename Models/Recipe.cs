namespace WebCooking.Models;

public class Recipe
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public long CategoryId { get; set; }
    public virtual Category? Category { get; set; }
    public long MealId { get; set; }
    public virtual Meal? Meal { get; set; }
    
    public virtual ICollection<RecipeIngredient>? RecipeIngredients { get; set; }
}