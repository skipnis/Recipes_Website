using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCooking.Models;

namespace WebCooking.Data.Configurations;

public class FavouriteRecipeConfiguration : IEntityTypeConfiguration<FavouriteRecipe>
{
    public void Configure(EntityTypeBuilder<FavouriteRecipe> builder)
    {
        builder.ToTable("FavouriteRecipes");

        builder.HasKey(fr => new { fr.UserId, fr.RecipeId });
        
        builder.Property(fr => fr.UserId)
            .HasColumnName("user_id")
            .HasColumnType("varchar(255)")
            .IsRequired();
        
        builder.Property(fr => fr.RecipeId)
            .HasColumnName("recipe_id")
            .HasColumnType("BIGINT")
            .IsRequired();

        builder.HasOne(fr => fr.User)
            .WithMany(u => u.FavouriteRecipes)
            .HasForeignKey(fr => fr.UserId);
        
        builder.HasOne(fr => fr.Recipe)
            .WithMany(r => r.FavouriteRecipes)
            .HasForeignKey(fr => fr.RecipeId);
    }
}