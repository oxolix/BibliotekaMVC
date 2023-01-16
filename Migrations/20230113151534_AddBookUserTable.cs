using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotekaMvc.Migrations
{
    /// <inheritdoc />
    public partial class AddBookUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookUserId",
                table: "Book",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    BookId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookUser_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookUser_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_BookUserId",
                table: "Book",
                column: "BookUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookUser_BookId",
                table: "BookUser",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookUser_UserId",
                table: "BookUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_BookUser_BookUserId",
                table: "Book",
                column: "BookUserId",
                principalTable: "BookUser",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_BookUser_BookUserId",
                table: "Book");

            migrationBuilder.DropTable(
                name: "BookUser");

            migrationBuilder.DropIndex(
                name: "IX_Book_BookUserId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "BookUserId",
                table: "Book");
        }
    }
}
