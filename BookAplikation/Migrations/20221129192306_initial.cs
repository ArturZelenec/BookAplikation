using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookAplikation.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: false),
                    CoverType = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PublishYear = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CoverType", "PublishYear", "Title" },
                values: new object[,]
                {
                    { 1, "Robert Jordan", "Paperback", 1976, "The Eye of the World" },
                    { 2, "George R.R. Martin", "Hardcover", 1988, "A Game of Thrones" },
                    { 3, "Brandon Sanderson", "Hardcover", 1981, "The Way of Kings" },
                    { 4, "J.R.R. Tolkien", "Paperback", 1965, "The Fellowship of the Ring" },
                    { 5, "Terry Pratchett", "Hardcover", 1990, "Sourcery" },
                    { 6, "Frank Herbert", "Electronic", 1975, "Dune" },
                    { 8, "Scott Lynch", "Paperback", 1981, "The Name of the Wind" },
                    { 9, "Scott Lynch", "Hardcover", 1975, "The Lies of Locke Lamora" },
                    { 10, "Scott Lynch", "Electronic", 1977, "Assassin's Apprentice" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
