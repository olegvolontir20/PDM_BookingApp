using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingApplication.Migrations
{
    /// <inheritdoc />
    public partial class deletedAdnotation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelReviews_Hotels_Hotel_Id",
                table: "HotelReviews");

            migrationBuilder.DropIndex(
                name: "IX_HotelReviews_Hotel_Id",
                table: "HotelReviews");

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "HotelReviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HotelReviews_HotelId",
                table: "HotelReviews",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelReviews_Hotels_HotelId",
                table: "HotelReviews",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelReviews_Hotels_HotelId",
                table: "HotelReviews");

            migrationBuilder.DropIndex(
                name: "IX_HotelReviews_HotelId",
                table: "HotelReviews");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "HotelReviews");

            migrationBuilder.CreateIndex(
                name: "IX_HotelReviews_Hotel_Id",
                table: "HotelReviews",
                column: "Hotel_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelReviews_Hotels_Hotel_Id",
                table: "HotelReviews",
                column: "Hotel_Id",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
