using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCooking.Models;

namespace WebCooking.Data.Configurations;

public class MealConfiguration : IEntityTypeConfiguration<Meal>
{
    public void Configure(EntityTypeBuilder<Meal> builder)
    {
        builder.ToTable("Meals");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("meal_id")
            .HasColumnType("BIGINT")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasColumnName("meal_name")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasColumnName("meal_description")
            .HasColumnType("TEXT")
            .IsRequired(false);

        builder
            .HasMany(m => m.Recipes)
            .WithOne(r => r.Meal)
            .HasForeignKey(r => r.MealId);
    }
}