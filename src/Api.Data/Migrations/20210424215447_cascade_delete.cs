using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class cascade_delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_film_actor_actor_film_id",
                table: "film_actor");

            migrationBuilder.DropForeignKey(
                name: "FK_film_actor_film_actor_id",
                table: "film_actor");

            migrationBuilder.AddForeignKey(
                name: "FK_film_actor_actor_actor_id",
                table: "film_actor",
                column: "actor_id",
                principalTable: "actor",
                principalColumn: "actor_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_film_actor_film_film_id",
                table: "film_actor",
                column: "film_id",
                principalTable: "film",
                principalColumn: "film_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_film_actor_actor_actor_id",
                table: "film_actor");

            migrationBuilder.DropForeignKey(
                name: "FK_film_actor_film_film_id",
                table: "film_actor");

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
    }
}
