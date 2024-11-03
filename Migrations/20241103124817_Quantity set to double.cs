using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCooking.Migrations
{
    /// <inheritdoc />
    public partial class Quantitysettodouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "quantity",
                table: "RecipeIngredients",
                type: "FLOAT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INT",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "quantity",
                table: "RecipeIngredients",
                type: "INT",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "FLOAT",
                oldNullable: true);
        }
    }
}
