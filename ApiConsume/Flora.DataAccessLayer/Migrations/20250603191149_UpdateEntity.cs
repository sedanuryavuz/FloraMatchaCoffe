using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flora.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl2",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl3",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl4",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title2",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ImageUrl2",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "ImageUrl3",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "ImageUrl4",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "Title2",
                table: "Abouts");
        }
    }
}
