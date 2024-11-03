using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCooking.Migrations
{
    /// <inheritdoc />
    public partial class Recipecolumnnamechanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Categories_CategoryId",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Meals_MealId",
                table: "Recipes");

            migrationBuilder.RenameColumn(
                name: "MealId",
                table: "Recipes",
                newName: "meal_id");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Recipes",
                newName: "category_id");

            migrationBuilder.RenameIndex(
                name: "IX_Recipes_MealId",
                table: "Recipes",
                newName: "IX_Recipes_meal_id");

            migrationBuilder.RenameIndex(
                name: "IX_Recipes_CategoryId",
                table: "Recipes",
                newName: "IX_Recipes_category_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Categories_category_id",
                table: "Recipes",
                column: "category_id",
                principalTable: "Categories",
                principalColumn: "category_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Meals_meal_id",
                table: "Recipes",
                column: "meal_id",
                principalTable: "Meals",
                principalColumn: "meal_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Categories_category_id",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Meals_meal_id",
                table: "Recipes");

            migrationBuilder.RenameColumn(
                name: "meal_id",
                table: "Recipes",
                newName: "MealId");

            migrationBuilder.RenameColumn(
                name: "category_id",
                table: "Recipes",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Recipes_meal_id",
                table: "Recipes",
                newName: "IX_Recipes_MealId");

            migrationBuilder.RenameIndex(
                name: "IX_Recipes_category_id",
                table: "Recipes",
                newName: "IX_Recipes_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Categories_CategoryId",
                table: "Recipes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "category_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Meals_MealId",
                table: "Recipes",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "meal_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
