using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Autoszerviz.Migrations
{
    /// <inheritdoc />
    public partial class Javitasok : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Javitasok",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UgyfelId = table.Column<int>(type: "INTEGER", nullable: false),
                    Rendszam = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Leiras = table.Column<string>(type: "TEXT", maxLength: 300, nullable: true),
                    Koltseg = table.Column<decimal>(type: "TEXT", nullable: true),
                    Allapot = table.Column<string>(type: "TEXT", nullable: false),
                    FelvetelDatuma = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Javitasok", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Javitasok_Ugyfelek_UgyfelId",
                        column: x => x.UgyfelId,
                        principalTable: "Ugyfelek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Javitasok",
                columns: new[] { "Id", "Allapot", "FelvetelDatuma", "Koltseg", "Leiras", "Rendszam", "UgyfelId" },
                values: new object[,]
                {
                    { 1, "Kész", new DateTime(2026, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 38000m, "Fékbetét csere elöl", "MKR-421", 1 },
                    { 2, "Folyamatban", new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 29500m, "Olajcsere és szűrők", "MKR-421", 1 },
                    { 3, "Felvéve", new DateTime(2026, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Klíma töltés", "PLT-708", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Javitasok_UgyfelId",
                table: "Javitasok",
                column: "UgyfelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Javitasok");
        }
    }
}
