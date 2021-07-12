using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class filme_ator_alteracoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_film_actor_actor_actor_id",
                table: "film_actor");

            migrationBuilder.DropForeignKey(
                name: "FK_film_actor_film_film_id",
                table: "film_actor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_film_actor",
                table: "film_actor");

            migrationBuilder.DropIndex(
                name: "IX_film_actor_actor_id",
                table: "film_actor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_film_actor",
                table: "film_actor",
                columns: new[] { "actor_id", "film_id" });

            migrationBuilder.CreateIndex(
                name: "IX_film_actor_film_id",
                table: "film_actor",
                column: "film_id");

            migrationBuilder.AddForeignKey(
                name: "FK_film_actor_actor_film_id",
                table: "film_actor",
                column: "film_id",
                principalTable: "actor",
                principalColumn: "actor_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_film_actor_film_actor_id",
                table: "film_actor",
                column: "actor_id",
                principalTable: "film",
                principalColumn: "film_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_film_actor_actor_film_id",
                table: "film_actor");

            migrationBuilder.DropForeignKey(
                name: "FK_film_actor_film_actor_id",
                table: "film_actor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_film_actor",
                table: "film_actor");

            migrationBuilder.DropIndex(
                name: "IX_film_actor_film_id",
                table: "film_actor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_film_actor",
                table: "film_actor",
                columns: new[] { "film_id", "actor_id" });

            migrationBuilder.CreateIndex(
                name: "IX_film_actor_actor_id",
                table: "film_actor",
                column: "actor_id");

            migrationBuilder.AddForeignKey(
                name: "FK_film_actor_actor_actor_id",
                table: "film_actor",
                column: "actor_id",
                principalTable: "actor",
                principalColumn: "actor_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_film_actor_film_film_id",
                table: "film_actor",
                column: "film_id",
                principalTable: "film",
                principalColumn: "film_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
