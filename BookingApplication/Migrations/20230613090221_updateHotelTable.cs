using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingApplication.Migrations
{
    /// <inheritdoc />
    public partial class updateHotelTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "RoomBookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomBookings_HotelId",
                table: "RoomBookings",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBookings_Hotels_HotelId",
                table: "RoomBookings",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomBookings_Hotels_HotelId",
                table: "RoomBookings");

            migrationBuilder.DropIndex(
                name: "IX_RoomBookings_HotelId",
                table: "RoomBookings");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "RoomBookings");
        }
    }
}
