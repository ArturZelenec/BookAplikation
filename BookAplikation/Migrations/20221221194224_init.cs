using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookAplikation.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ISBN = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Author = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ECoverType = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PublishYear = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AvailableBooksInLibrary = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ISBN);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TakenLibraryBooks = table.Column<int>(type: "INTEGER", nullable: false),
                    BooksNotReturnedInTime = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalDebt = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LibraryBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookISBN = table.Column<string>(type: "TEXT", nullable: false),
                    IsTaken = table.Column<bool>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibraryBooks_Books_BookISBN",
                        column: x => x.BookISBN,
                        principalTable: "Books",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    LibraryBookId = table.Column<int>(type: "INTEGER", nullable: false),
                    BookTaken = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BookReturned = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DaysLate = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBooks_LibraryBooks_LibraryBookId",
                        column: x => x.LibraryBookId,
                        principalTable: "LibraryBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBooks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ISBN", "Author", "AvailableBooksInLibrary", "Created", "ECoverType", "PublishYear", "Title", "Updated" },
                values: new object[,]
                {
                    { "0020198817", "F. Scott Fitzgerald", 0, new DateTime(2022, 12, 21, 21, 42, 24, 40, DateTimeKind.Local).AddTicks(2592), "Paperback", 1992, "The Great Gatsby", new DateTime(2022, 12, 21, 21, 42, 24, 40, DateTimeKind.Local).AddTicks(2595) },
                    { "0439136350", "Rowling, J. K.", 0, new DateTime(2022, 12, 21, 21, 42, 24, 40, DateTimeKind.Local).AddTicks(2614), "Hardcover", 1999, "Harry Potter And The Prisoner Of Azkaban", new DateTime(2022, 12, 21, 21, 42, 24, 40, DateTimeKind.Local).AddTicks(2616) },
                    { "0451526929", "William Shakespeare", 0, new DateTime(2022, 12, 21, 21, 42, 24, 40, DateTimeKind.Local).AddTicks(2608), "Paperback", 1998, "Hamlet", new DateTime(2022, 12, 21, 21, 42, 24, 40, DateTimeKind.Local).AddTicks(2611) },
                    { "0451528905", "Miguel de Cervantes", 0, new DateTime(2022, 12, 21, 21, 42, 24, 40, DateTimeKind.Local).AddTicks(2582), "Paperback", 2003, "Don Quixote", new DateTime(2022, 12, 21, 21, 42, 24, 40, DateTimeKind.Local).AddTicks(2584) },
                    { "0553211765", "Charles Dickens", 0, new DateTime(2022, 12, 21, 21, 42, 24, 40, DateTimeKind.Local).AddTicks(2521), "Hardcover", 1989, "A Tale of Two Cities", new DateTime(2022, 12, 21, 21, 42, 24, 40, DateTimeKind.Local).AddTicks(2567) },
                    { "0553213113", "Herman Melville", 0, new DateTime(2022, 12, 21, 21, 42, 24, 40, DateTimeKind.Local).AddTicks(2598), "Paperback", 1981, "Moby Dick", new DateTime(2022, 12, 21, 21, 42, 24, 40, DateTimeKind.Local).AddTicks(2600) },
                    { "0786275391", "Antoine de Saint-Exupery", 0, new DateTime(2022, 12, 21, 21, 42, 24, 40, DateTimeKind.Local).AddTicks(2571), "Hardcover", 2005, "The Little Prince", new DateTime(2022, 12, 21, 21, 42, 24, 40, DateTimeKind.Local).AddTicks(2573) },
                    { "0847980790", "Agatha Christie", 0, new DateTime(2022, 12, 21, 21, 42, 24, 40, DateTimeKind.Local).AddTicks(2587), "Paperback", 1939, "And Then There Were None", new DateTime(2022, 12, 21, 21, 42, 24, 40, DateTimeKind.Local).AddTicks(2589) },
                    { "1400079985", "Leo Tolstoy", 0, new DateTime(2022, 12, 21, 21, 42, 24, 40, DateTimeKind.Local).AddTicks(2603), "Paperback", 2008, "War and Peace", new DateTime(2022, 12, 21, 21, 42, 24, 40, DateTimeKind.Local).AddTicks(2605) },
                    { "1856134032", "Rowling, J. K.", 0, new DateTime(2022, 12, 21, 21, 42, 24, 40, DateTimeKind.Local).AddTicks(2576), "Hardcover", 1997, "Harry Potter and The Philosopher's Stone", new DateTime(2022, 12, 21, 21, 42, 24, 40, DateTimeKind.Local).AddTicks(2579) },
                    { "1856136124", "Rowling, J. K.", 0, new DateTime(2022, 12, 21, 21, 42, 24, 40, DateTimeKind.Local).AddTicks(2619), "Paperback", 1998, "Harry Potter and the Chamber of Secrets", new DateTime(2022, 12, 21, 21, 42, 24, 40, DateTimeKind.Local).AddTicks(2621) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LibraryBooks_BookISBN",
                table: "LibraryBooks",
                column: "BookISBN");

            migrationBuilder.CreateIndex(
                name: "IX_UserBooks_LibraryBookId",
                table: "UserBooks",
                column: "LibraryBookId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBooks_UserId",
                table: "UserBooks",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserBooks");

            migrationBuilder.DropTable(
                name: "LibraryBooks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
