using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCooking.Models;

namespace WebCooking.Data.Configurations;

public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.ToTable("Recipes");
        
        builder.HasKey(r => r.Id);
        
        builder.Property(r => r.Id)
            .HasColumnName("recipe_id")
            .HasColumnType("BIGINT")
            .ValueGeneratedOnAdd();
        
        builder.Property(r => r.Name)
            .HasColumnName("recipe_name")
            .HasColumnType("VARCHAR(255)")
            .HasMaxLength(255)
            .IsRequired();
        
        builder.Property(r => r.ImagePath)
            .HasColumnName("recipe_image_path")
            .HasColumnType("VARCHAR(255)")
            .HasMaxLength(255)
            .IsRequired(false);
        
        builder.Property(r => r.CategoryId)
            .HasColumnName("category_id")
            .HasColumnType("BIGINT")
            .IsRequired();
        
        builder.Property(r=>r.MealId)
            .HasColumnName("meal_id")
            .HasColumnType("BIGINT")
            .IsRequired();
        
        builder.Property(r => r.Description)
            .HasColumnName("recipe_description")
            .HasColumnType("Text")
            .IsRequired();
    }
}