using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCooking.Models;

namespace WebCooking.Data.Configurations;

public class RecipeIngredientConfiguration : IEntityTypeConfiguration<RecipeIngredient>
{
    public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
    {
        builder.ToTable("RecipeIngredients");
        
        builder.HasKey(ri => new { ri.RecipeId, ri.IngredientId });
        
        builder.Property(ri => ri.RecipeId)
            .HasColumnName("recipe_id")
            .HasColumnType("BIGINT")
            .IsRequired();
        
        builder.Property(ri=>ri.IngredientId)
            .HasColumnName("ingredient_id")
            .HasColumnType("BIGINT")
            .IsRequired();
        
        builder.Property(ri=>ri.Quantity)
            .HasColumnName("quantity")
            .HasColumnType("FLOAT")
            .IsRequired(false);
        
        builder.Property(ri=>ri.Unit)
            .HasColumnName("unit")
            .HasColumnType("VARCHAR(20)")
            .IsRequired();

        builder.HasOne(ri => ri.Recipe)
            .WithMany(r => r.RecipeIngredients)
            .HasForeignKey(ri => ri.RecipeId);
        
        builder.HasOne(ri => ri.Ingredient)
            .WithMany(i => i.RecipeIngredients)
            .HasForeignKey(ri => ri.IngredientId);
    }
}