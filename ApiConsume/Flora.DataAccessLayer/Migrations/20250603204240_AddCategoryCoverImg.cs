using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flora.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryCoverImg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryCoverImg",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryCoverImg",
                table: "Categories");
        }
    }
}
