namespace WebCooking.Models;

public class Meal
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    
    public virtual ICollection<Recipe>? Recipes { get; set; }
}