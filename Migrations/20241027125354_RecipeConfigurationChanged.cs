using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCooking.Migrations
{
    /// <inheritdoc />
    public partial class RecipeConfigurationChanged : Migration
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
                name: "Name",
                table: "Recipes",
                newName: "recipe_name");

            migrationBuilder.RenameColumn(
                name: "MealId",
                table: "Recipes",
                newName: "meal_id");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Recipes",
                newName: "category_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Recipes",
                newName: "recipe_id");

            migrationBuilder.RenameIndex(
                name: "IX_Recipes_MealId",
                table: "Recipes",
                newName: "IX_Recipes_meal_id");

            migrationBuilder.RenameIndex(
                name: "IX_Recipes_CategoryId",
                table: "Recipes",
                newName: "IX_Recipes_category_id");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "recipe_name",
                keyValue: null,
                column: "recipe_name",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "recipe_name",
                table: "Recipes",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<long>(
                name: "recipe_id",
                table: "Recipes",
                type: "BIGINT",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<long>(
                name: "recipe_id",
                table: "RecipeIngredient",
                type: "BIGINT",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

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
                name: "recipe_name",
                table: "Recipes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "meal_id",
                table: "Recipes",
                newName: "MealId");

            migrationBuilder.RenameColumn(
                name: "category_id",
                table: "Recipes",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "recipe_id",
                table: "Recipes",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Recipes_meal_id",
                table: "Recipes",
                newName: "IX_Recipes_MealId");

            migrationBuilder.RenameIndex(
                name: "IX_Recipes_category_id",
                table: "Recipes",
                newName: "IX_Recipes_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Recipes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Recipes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "BIGINT")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<long>(
                name: "recipe_id",
                table: "RecipeIngredient",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "BIGINT");

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
