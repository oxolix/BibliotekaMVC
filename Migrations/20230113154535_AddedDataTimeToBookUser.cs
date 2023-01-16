using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotekaMvc.Migrations
{
    /// <inheritdoc />
    public partial class AddedDataTimeToBookUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataOd",
                table: "BookUser",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataWyp",
                table: "BookUser",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataOd",
                table: "BookUser");

            migrationBuilder.DropColumn(
                name: "DataWyp",
                table: "BookUser");
        }
    }
}
