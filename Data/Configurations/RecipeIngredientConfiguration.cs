using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCooking.Models;

namespace WebCooking.Data.Configurations;

public class RecipeIngredientConfiguration : IEntityTypeConfiguration<RecipeIngredient>
{
    public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
    {
        builder.ToTable("RecipeIngredient", t=>t.HasCheckConstraint("Valid_Quantity", "Quantity > 0"));
        
        builder.HasKey(ri => new { ri.RecipeId, ri.IngredientId });

        builder.Property(ri => ri.RecipeId)
            .HasColumnName("recipe_id");
        
        builder.Property(ri => ri.IngredientId)
            .HasColumnName("ingredient_id");

        builder.Property(ri => ri.Quantity)
            .HasColumnName("quantity")
            .HasColumnType("INT");
        
        builder.Property(ri => ri.UnitOfMeasure)
            .HasColumnName("unit_of_measure")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255)
            .IsRequired();

        builder.HasOne(ri => ri.Recipe)
            .WithMany(r => r.RecipeIngredients)
            .HasForeignKey(ri => ri.RecipeId);
        
        builder.HasOne(ri => ri.Ingredient)
            .WithMany(i => i.RecipeIngredients)
            .HasForeignKey(ri => ri.IngredientId);
    }
}