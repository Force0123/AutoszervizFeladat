using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Autoszerviz.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ugyfelek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nev = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Telefon = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ugyfelek", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Ugyfelek",
                columns: new[] { "Id", "Email", "Nev", "Telefon" },
                values: new object[,]
                {
                    { 1, "nagy.peter@gmail.com", "Nagy Péter", "+36 30 123 4567" },
                    { 2, "szabo.anna@freemail.hu", "Szabó Anna", "+36 20 987 6543" },
                    { 3, null, "Tóth Gábor", "+36 70 555 1212" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ugyfelek");
        }
    }
}
