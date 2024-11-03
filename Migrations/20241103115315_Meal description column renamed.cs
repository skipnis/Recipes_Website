using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCooking.Migrations
{
    /// <inheritdoc />
    public partial class Mealdescriptioncolumnrenamed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Meals",
                newName: "meal_description");

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "meal_description",
                keyValue: null,
                column: "meal_description",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "meal_description",
                table: "Meals",
                type: "Text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "meal_description",
                table: "Meals",
                newName: "Description");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Meals",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Text")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
