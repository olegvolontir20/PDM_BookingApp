using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingApplication.Migrations
{
    /// <inheritdoc />
    public partial class testMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Hotels_HotelId",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_HotelId",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Hotels");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Hotels");

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "Hotels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_HotelId",
                table: "Hotels",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Hotels_HotelId",
                table: "Hotels",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id");
        }
    }
}
