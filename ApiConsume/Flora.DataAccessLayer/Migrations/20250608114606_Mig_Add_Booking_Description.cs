using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flora.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Mig_Add_Booking_Description : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Bookings");
        }
    }
}
