using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_film_language_original_language_id",
                table: "film");

            migrationBuilder.AlterColumn<int>(
                name: "original_language_id",
                table: "film",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_film_language_original_language_id",
                table: "film",
                column: "original_language_id",
                principalTable: "language",
                principalColumn: "language_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.DropTable(
                name: "AtoresPorCategoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_film_language_original_language_id",
                table: "film");

            migrationBuilder.AlterColumn<int>(
                name: "original_language_id",
                table: "film",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_film_language_original_language_id",
                table: "film",
                column: "original_language_id",
                principalTable: "language",
                principalColumn: "language_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
