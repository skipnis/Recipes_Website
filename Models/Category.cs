namespace WebCooking.Models;

public class Category
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public virtual ICollection<Recipe>? Recipes { get; set; }
    public virtual ICollection<Meal>? Meals { get; set; }
}