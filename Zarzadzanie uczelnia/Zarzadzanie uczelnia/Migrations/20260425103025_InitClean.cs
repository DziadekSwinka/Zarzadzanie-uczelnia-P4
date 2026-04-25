using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zarzadzanie_uczelnia.Migrations
{
    /// <inheritdoc />
    public partial class InitClean : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kierunki",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kierunki", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Grupy",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KierunekID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupy", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Grupy_Kierunki_KierunekID",
                        column: x => x.KierunekID,
                        principalTable: "Kierunki",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Przedmiot",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ECTS = table.Column<int>(type: "int", nullable: false),
                    KierunekID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Przedmiot", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Przedmiot_Kierunki_KierunekID",
                        column: x => x.KierunekID,
                        principalTable: "Kierunki",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Studenci",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rocznik = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NrTelefonu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrupaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studenci", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Studenci_Grupy_GrupaID",
                        column: x => x.GrupaID,
                        principalTable: "Grupy",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Ocena",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WartoscOceny = table.Column<int>(type: "int", nullable: false),
                    DataWystawienia = table.Column<DateOnly>(type: "date", nullable: false),
                    PrzedmiotID = table.Column<int>(type: "int", nullable: false),
                    GrupaID = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocena", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ocena_Grupy_GrupaID",
                        column: x => x.GrupaID,
                        principalTable: "Grupy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ocena_Przedmiot_PrzedmiotID",
                        column: x => x.PrzedmiotID,
                        principalTable: "Przedmiot",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocena_Studenci_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Studenci",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grupy_KierunekID",
                table: "Grupy",
                column: "KierunekID");

            migrationBuilder.CreateIndex(
                name: "IX_Ocena_GrupaID",
                table: "Ocena",
                column: "GrupaID");

            migrationBuilder.CreateIndex(
                name: "IX_Ocena_PrzedmiotID",
                table: "Ocena",
                column: "PrzedmiotID");

            migrationBuilder.CreateIndex(
                name: "IX_Ocena_StudentID",
                table: "Ocena",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Przedmiot_KierunekID",
                table: "Przedmiot",
                column: "KierunekID");

            migrationBuilder.CreateIndex(
                name: "IX_Studenci_GrupaID",
                table: "Studenci",
                column: "GrupaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ocena");

            migrationBuilder.DropTable(
                name: "Przedmiot");

            migrationBuilder.DropTable(
                name: "Studenci");

            migrationBuilder.DropTable(
                name: "Grupy");

            migrationBuilder.DropTable(
                name: "Kierunki");
        }
    }
}
