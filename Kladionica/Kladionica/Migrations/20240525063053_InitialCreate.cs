using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kladionica.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Korisniks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datum_rođenja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisniks", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Okladas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ulog = table.Column<int>(type: "int", nullable: false),
                    TipOklade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ID_korisnik = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Okladas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Okladas_Korisniks_ID_korisnik",
                        column: x => x.ID_korisnik,
                        principalTable: "Korisniks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Utakmicas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tim1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tim2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID_oklada = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utakmicas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Utakmicas_Okladas_ID_oklada",
                        column: x => x.ID_oklada,
                        principalTable: "Okladas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Okladas_ID_korisnik",
                table: "Okladas",
                column: "ID_korisnik");

            migrationBuilder.CreateIndex(
                name: "IX_Utakmicas_ID_oklada",
                table: "Utakmicas",
                column: "ID_oklada");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Utakmicas");

            migrationBuilder.DropTable(
                name: "Okladas");

            migrationBuilder.DropTable(
                name: "Korisniks");
        }
    }
}
