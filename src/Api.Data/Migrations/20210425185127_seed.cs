using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "actor",
                columns: new[] { "actor_id", "first_name", "last_name" },
                values: new object[,]
                {
                    { 1, "Tom", "Hanks" },
                    { 2, "Ed", "Murphy" }
                });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "category_id", "name" },
                values: new object[,]
                {
                    { 1, "Drama" },
                    { 2, "Comedy" }
                });

            migrationBuilder.InsertData(
                table: "language",
                columns: new[] { "language_id", "name" },
                values: new object[,]
                {
                    { 1, "Português" },
                    { 2, "Inglês" }
                });

            migrationBuilder.InsertData(
                table: "film",
                columns: new[] { "film_id", "release_year", "rating", "description", "length", "title", "language_id", "original_language_id" },
                values: new object[] { 1, "1999", "G", "Descrição Filme Drama", (short)120, "Forrest Gump", 1, null });

            migrationBuilder.InsertData(
                table: "film",
                columns: new[] { "film_id", "release_year", "rating", "description", "length", "title", "language_id", "original_language_id" },
                values: new object[] { 2, "1999", "R", "Filme Comédia", (short)220, "Norbit", 1, 2 });

            migrationBuilder.InsertData(
                table: "film_actor",
                columns: new[] { "actor_id", "film_id" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "film_category",
                columns: new[] { "category_id", "film_id" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "film_actor",
                keyColumns: new[] { "actor_id", "film_id" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "film_actor",
                keyColumns: new[] { "actor_id", "film_id" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "film_actor",
                keyColumns: new[] { "actor_id", "film_id" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "film_category",
                keyColumns: new[] { "category_id", "film_id" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "film_category",
                keyColumns: new[] { "category_id", "film_id" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "film_category",
                keyColumns: new[] { "category_id", "film_id" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "actor",
                keyColumn: "actor_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "actor",
                keyColumn: "actor_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "category_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "category_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "film",
                keyColumn: "film_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "film",
                keyColumn: "film_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "language",
                keyColumn: "language_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "language",
                keyColumn: "language_id",
                keyValue: 2);
        }
    }
}
