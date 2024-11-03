using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCooking.Models;

namespace WebCooking.Data.Configurations;

public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
{
    public void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder.ToTable("Ingredients");
        
        builder.HasKey(i => i.Id);
        
        builder.Property(i => i.Id)
            .HasColumnName("ingredient_id")
            .HasColumnType("BIGINT")
            .ValueGeneratedOnAdd();
        
        builder.Property(i => i.Name)
            .HasColumnName("ingredient_name")
            .HasColumnType("VARCHAR(50")
            .HasMaxLength(50);
    }
}