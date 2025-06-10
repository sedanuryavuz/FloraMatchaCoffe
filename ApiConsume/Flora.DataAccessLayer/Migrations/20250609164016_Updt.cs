using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flora.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Updt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TableNumber",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "MenuTableId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsOrdered",
                table: "Baskets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MenuTableId",
                table: "Orders",
                column: "MenuTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_MenuTables_MenuTableId",
                table: "Orders",
                column: "MenuTableId",
                principalTable: "MenuTables",
                principalColumn: "MenuTableId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_MenuTables_MenuTableId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_MenuTableId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "MenuTableId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsOrdered",
                table: "Baskets");

            migrationBuilder.AddColumn<string>(
                name: "TableNumber",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
