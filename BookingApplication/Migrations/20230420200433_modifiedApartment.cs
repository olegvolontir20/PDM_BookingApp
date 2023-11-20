using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingApplication.Migrations
{
    /// <inheritdoc />
    public partial class modifiedApartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartaments_Apartaments_ApartamentId",
                table: "Apartaments");

            migrationBuilder.DropIndex(
                name: "IX_Apartaments_ApartamentId",
                table: "Apartaments");

            migrationBuilder.DropColumn(
                name: "ApartamentId",
                table: "Apartaments");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Apartaments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Apartaments");

            migrationBuilder.AddColumn<int>(
                name: "ApartamentId",
                table: "Apartaments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apartaments_ApartamentId",
                table: "Apartaments",
                column: "ApartamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartaments_Apartaments_ApartamentId",
                table: "Apartaments",
                column: "ApartamentId",
                principalTable: "Apartaments",
                principalColumn: "Id");
        }
    }
}
