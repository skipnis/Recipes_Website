using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCooking.Migrations
{
    /// <inheritdoc />
    public partial class MealsCategory1toMrelationadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "category_id",
                table: "Meals",
                type: "BIGINT",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Meals_category_id",
                table: "Meals",
                column: "category_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Categories_category_id",
                table: "Meals",
                column: "category_id",
                principalTable: "Categories",
                principalColumn: "category_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Categories_category_id",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_category_id",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "category_id",
                table: "Meals");
        }
    }
}
