using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class removendo_alternateKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_actor_first_name_last_name",
                table: "actor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_actor_first_name_last_name",
                table: "actor",
                columns: new[] { "first_name", "last_name" });
        }
    }
}
