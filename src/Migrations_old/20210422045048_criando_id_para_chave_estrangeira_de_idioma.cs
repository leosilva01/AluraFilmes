using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class criando_id_para_chave_estrangeira_de_idioma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_film_language_original_language_id",
                table: "film");

            migrationBuilder.AlterColumn<int>(
                name: "staff_id",
                table: "staff",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint unsigned")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "original_language_id",
                table: "film",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "customer_id",
                table: "customer",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint unsigned")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateTable(
                name: "AtoresPorCategoria",
                columns: table => new
                {
                    first_name = table.Column<string>(type: "longtext", nullable: true),
                    last_name = table.Column<string>(type: "longtext", nullable: true),
                    name = table.Column<string>(type: "longtext", nullable: true),
                    title = table.Column<string>(type: "longtext", nullable: true),
                    description = table.Column<string>(type: "longtext", nullable: true),
                    release_year = table.Column<string>(type: "longtext", nullable: true),
                    length = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    rating = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.AddForeignKey(
                name: "FK_film_language_original_language_id",
                table: "film",
                column: "original_language_id",
                principalTable: "language",
                principalColumn: "language_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_film_language_original_language_id",
                table: "film");

            migrationBuilder.DropTable(
                name: "AtoresPorCategoria");

            migrationBuilder.AlterColumn<byte>(
                name: "staff_id",
                table: "staff",
                type: "tinyint unsigned",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "original_language_id",
                table: "film",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte>(
                name: "customer_id",
                table: "customer",
                type: "tinyint unsigned",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_film_language_original_language_id",
                table: "film",
                column: "original_language_id",
                principalTable: "language",
                principalColumn: "language_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
