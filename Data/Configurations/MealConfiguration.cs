using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCooking.Models;

namespace WebCooking.Data.Configurations;

public class MealConfiguration : IEntityTypeConfiguration<Meal>
{
    public void Configure(EntityTypeBuilder<Meal> builder)
    {
        builder.ToTable("Meals");
        
        builder.HasKey(m => m.Id);
        
        builder.Property(m => m.Id)
            .HasColumnName("meal_id")
            .HasColumnType("BIGINT")
            .ValueGeneratedOnAdd();
        
        builder.Property(m => m.Name)
            .HasColumnName("meal_name")
            .HasColumnType("VARCHAR(255)")
            .HasMaxLength(255)
            .IsRequired();
        
        builder.Property(m=>m.CategoryId)
            .HasColumnName("category_id")
            .HasColumnType("BIGINT")
            .IsRequired();
        
        builder.Property(m => m.Description)
            .HasColumnName("meal_description")
            .HasColumnType("Text")
            .IsRequired();

        builder.HasMany(m => m.Recipes)
            .WithOne(r => r.Meal)
            .HasForeignKey(r => r.MealId);
    }
}