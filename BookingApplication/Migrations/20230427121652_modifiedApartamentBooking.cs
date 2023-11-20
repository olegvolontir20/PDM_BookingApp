using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingApplication.Migrations
{
    /// <inheritdoc />
    public partial class modifiedApartamentBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ap_Id",
                table: "ApartamentBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ApartamentBookings_Ap_Id",
                table: "ApartamentBookings",
                column: "Ap_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApartamentBookings_Apartaments_Ap_Id",
                table: "ApartamentBookings",
                column: "Ap_Id",
                principalTable: "Apartaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApartamentBookings_Apartaments_Ap_Id",
                table: "ApartamentBookings");

            migrationBuilder.DropIndex(
                name: "IX_ApartamentBookings_Ap_Id",
                table: "ApartamentBookings");

            migrationBuilder.DropColumn(
                name: "Ap_Id",
                table: "ApartamentBookings");
        }
    }
}
