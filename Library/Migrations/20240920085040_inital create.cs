using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class initalcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookGenre = table.Column<int>(type: "int", nullable: false),
                    RealeseYear = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "BookGenre", "RealeseYear", "Title" },
                values: new object[,]
                {
                    { -16, "J.R.R. Tolkien", 3, new DateTime(1937, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hobbit: En oväntad resa" },
                    { -15, "Margaret Mitchell", 2, new DateTime(1936, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Borta med vinden" },
                    { -14, "Andrew Roberts", 1, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Churchill: Walking with Destiny" },
                    { -13, "Edgar Allan Poe", 0, new DateTime(1841, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Morden på Rue Morgue" },
                    { -12, "Malala Yousafzai", 5, new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jag är Malala" },
                    { -11, "William Gibson", 4, new DateTime(1984, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Neuromancer" },
                    { -10, "J.K. Rowling", 3, new DateTime(1997, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter och De Vises Sten" },
                    { -9, "Leo Tolstoy", 2, new DateTime(1877, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anna Karenina" },
                    { -8, "Ron Chernow", 1, new DateTime(2004, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alexander Hamilton" },
                    { -7, "Fjodor Dostojevskij", 0, new DateTime(1866, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brott och straff" },
                    { -6, "Michelle Obama", 5, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Min historia" },
                    { -5, "Frank Herbert", 4, new DateTime(1965, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dune" },
                    { -4, "J.R.R. Tolkien", 3, new DateTime(1954, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sagan om ringen" },
                    { -3, "Jane Austen", 2, new DateTime(1813, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stolthet och fördom" },
                    { -2, "Walter Isaacson", 1, new DateTime(2011, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Steve Jobs" },
                    { -1, "Donna Tartt", 0, new DateTime(1992, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Den hemliga historien" }
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
