using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class add_delete_cascade_ator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_film_actor_actor_actor_id",
                table: "film_actor");

            migrationBuilder.AddForeignKey(
                name: "FK_film_actor_actor_actor_id",
                table: "film_actor",
                column: "actor_id",
                principalTable: "actor",
                principalColumn: "actor_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_film_actor_actor_actor_id",
                table: "film_actor");

            migrationBuilder.AddForeignKey(
                name: "FK_film_actor_actor_actor_id",
                table: "film_actor",
                column: "actor_id",
                principalTable: "actor",
                principalColumn: "actor_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
