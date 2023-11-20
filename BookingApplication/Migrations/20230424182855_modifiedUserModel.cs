﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingApplication.Migrations
{
    /// <inheritdoc />
    public partial class modifiedUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Users",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "ID");
        }
    }
}
