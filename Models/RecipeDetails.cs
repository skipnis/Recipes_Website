namespace WebCooking.Models;

public class RecipeDetails
{
    public Recipe? Recipe { get; set; }
    public IEnumerable<Instruction>? Instructions { get; set; }
    public IEnumerable<Ingredient>?Ingredients { get; set; }
    public IEnumerable<RecipeIngredient>? RecipeIngredients { get; set; }
}