namespace WebCooking.Models;

public class Meal : BaseEnity
{
    public string? Description { get; set; }
    public long? CategoryId { get; set; }
    public Category? Category { get; set; }
    public virtual ICollection<Recipe>? Recipes { get; set; }
}