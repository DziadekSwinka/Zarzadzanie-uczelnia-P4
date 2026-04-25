using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zarzadzanie_uczelnia.Migrations
{
    /// <inheritdoc />
    public partial class StudentOcena : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocena_Studenci_StudentID",
                table: "Ocena");

            migrationBuilder.AlterColumn<int>(
                name: "StudentID",
                table: "Ocena",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocena_Studenci_StudentID",
                table: "Ocena",
                column: "StudentID",
                principalTable: "Studenci",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocena_Studenci_StudentID",
                table: "Ocena");

            migrationBuilder.AlterColumn<int>(
                name: "StudentID",
                table: "Ocena",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocena_Studenci_StudentID",
                table: "Ocena",
                column: "StudentID",
                principalTable: "Studenci",
                principalColumn: "ID");
        }
    }
}
