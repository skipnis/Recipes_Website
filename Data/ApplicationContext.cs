using Microsoft.EntityFrameworkCore;
using WebCooking.Data.Configurations;
using WebCooking.Models;

namespace WebCooking.Data;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {

    }

    DbSet<Category> Categories { get; set; }
    DbSet<Ingredient> Ingredients { get; set; }
    DbSet<Meal> Meals { get; set; }
    DbSet<Recipe> Recipes { get; set; }
    DbSet<RecipeIngredient> RecipeIngredients { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new IngredientConfiguration());
        modelBuilder.ApplyConfiguration(new MealConfiguration());
        modelBuilder.ApplyConfiguration(new RecipeConfiguration());
        modelBuilder.ApplyConfiguration(new RecipeIngredientConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseMySql("name=ConnectionStrings:DefaultConnection",
                new MySqlServerVersion(new Version(8, 4, 3)));
    }
}