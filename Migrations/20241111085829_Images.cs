using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCooking.Migrations
{
    /// <inheritdoc />
    public partial class Images : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "recipe_image_path",
                table: "Recipes",
                type: "VARCHAR(255)",
                maxLength: 255,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "recipe_image_path",
                table: "Recipes");
        }
    }
}
