using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCooking.Models;

namespace WebCooking.Data.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");
        
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("category_id")
            .HasColumnType("BIGINT")
            .ValueGeneratedOnAdd();
        
        builder.Property(c => c.Name)
            .HasColumnName("category_name")
            .HasColumnType("VARCHAR(50)")
            .IsRequired();
        
        builder.Property(c=>c.Description)
            .HasColumnName("category_description")
            .HasColumnType("Text")
            .IsRequired();

        builder.HasMany(c => c.Meals)
            .WithOne(m => m.Category)
            .HasForeignKey(m => m.CategoryId);

        builder.HasMany(c => c.Recipes)
            .WithOne(r => r.Category)
            .HasForeignKey(r => r.CategoryId);
    }
}