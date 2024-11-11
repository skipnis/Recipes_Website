namespace WebCooking.Models;

public class Recipe : BaseEnity
{
    public string? ImagePath { get; set; }
    public string? Description { get; set; }
    public long CategoryId { get; set; }
    public virtual Category? Category { get; set; }
    public long MealId { get; set; }
    public virtual Meal? Meal { get; set; }
    public virtual ICollection<Instruction>? Instructions { get; set; }
    public virtual ICollection<RecipeIngredient>? RecipeIngredients { get; set; }

}