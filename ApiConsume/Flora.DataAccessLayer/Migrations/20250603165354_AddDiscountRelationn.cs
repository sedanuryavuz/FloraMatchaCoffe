using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flora.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddDiscountRelationn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Discounts");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Discounts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Amount",
                table: "Discounts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Discounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Discounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Discounts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
