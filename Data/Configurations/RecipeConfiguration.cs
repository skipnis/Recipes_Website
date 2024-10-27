using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCooking.Models;

namespace WebCooking.Data.Configurations;

public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
       builder.ToTable("Recipes");
       
       builder.HasKey(x => x.Id);
       
       builder.Property(x => x.Id)
           .HasColumnName("recipe_id")
           .HasColumnType("BIGINT")
           .ValueGeneratedOnAdd();
       
       builder.Property(x => x.Name)
           .HasColumnName("recipe_name")
           .HasColumnType("varchar(100)")
           .HasMaxLength(100)
           .IsRequired();
       
       builder
           .Property(x=>x.Cuisine)
           .HasColumnName("recipe_cuisine")
           .HasColumnType("varchar(20)")
           .HasMaxLength(20)
           .IsRequired();
       
       builder
           .Property(x=>x.CategoryId)
           .HasColumnName("category_id")
           .HasColumnType("BIGINT")
           .IsRequired();
       
       builder
           .Property(x => x.MealId)
           .HasColumnName("meal_id")
           .HasColumnType("BIGINT")
           .IsRequired();
    }
}