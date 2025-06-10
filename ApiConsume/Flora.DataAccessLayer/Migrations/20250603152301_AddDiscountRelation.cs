using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flora.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddDiscountRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiscountId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Rate",
                table: "Discounts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Products_DiscountId",
                table: "Products",
                column: "DiscountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Discounts_DiscountId",
                table: "Products",
                column: "DiscountId",
                principalTable: "Discounts",
                principalColumn: "DiscountId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Discounts_DiscountId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_DiscountId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DiscountId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Discounts");
        }
    }
}
