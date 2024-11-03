namespace WebCooking.Models;

public class Instruction
{
    public long Id { get; set; }
    public string? Text { get; set; }
    public int Order { get; set; }
    public long RecipeId { get; set; }
    public virtual Recipe? Recipe { get; set; }
}