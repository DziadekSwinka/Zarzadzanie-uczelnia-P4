using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zarzadzanie_uczelnia.Migrations
{
    /// <inheritdoc />
    public partial class OcenaPrzedmiotFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Przedmiot_Ocena_OcenyID",
                table: "Przedmiot");

            migrationBuilder.DropIndex(
                name: "IX_Przedmiot_OcenyID",
                table: "Przedmiot");

            migrationBuilder.DropColumn(
                name: "OcenyID",
                table: "Przedmiot");

            migrationBuilder.AddColumn<int>(
                name: "PrzedmiotID",
                table: "Ocena",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ocena_PrzedmiotID",
                table: "Ocena",
                column: "PrzedmiotID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocena_Przedmiot_PrzedmiotID",
                table: "Ocena",
                column: "PrzedmiotID",
                principalTable: "Przedmiot",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocena_Przedmiot_PrzedmiotID",
                table: "Ocena");

            migrationBuilder.DropIndex(
                name: "IX_Ocena_PrzedmiotID",
                table: "Ocena");

            migrationBuilder.DropColumn(
                name: "PrzedmiotID",
                table: "Ocena");

            migrationBuilder.AddColumn<int>(
                name: "OcenyID",
                table: "Przedmiot",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Przedmiot_OcenyID",
                table: "Przedmiot",
                column: "OcenyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Przedmiot_Ocena_OcenyID",
                table: "Przedmiot",
                column: "OcenyID",
                principalTable: "Ocena",
                principalColumn: "ID");
        }
    }
}
