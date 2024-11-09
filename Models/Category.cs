namespace WebCooking.Models;

public class Category : BaseEnity
{
    public string? Description { get; set; }
    public virtual ICollection<Meal>? Meals { get; set; }
    public virtual ICollection<Recipe>? Recipes { get; set; }
}