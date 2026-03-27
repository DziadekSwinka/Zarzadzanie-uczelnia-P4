using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zarzadzanie_uczelnia.Migrations
{
    /// <inheritdoc />
    public partial class _5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grupy_Kierunki_KierunekID",
                table: "Grupy");

            migrationBuilder.AlterColumn<int>(
                name: "KierunekID",
                table: "Grupy",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Grupy_Kierunki_KierunekID",
                table: "Grupy",
                column: "KierunekID",
                principalTable: "Kierunki",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grupy_Kierunki_KierunekID",
                table: "Grupy");

            migrationBuilder.AlterColumn<int>(
                name: "KierunekID",
                table: "Grupy",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Grupy_Kierunki_KierunekID",
                table: "Grupy",
                column: "KierunekID",
                principalTable: "Kierunki",
                principalColumn: "ID");
        }
    }
}
