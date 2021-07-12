using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "actor",
                columns: table => new
                {
                    actor_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    first_name = table.Column<string>(type: "NVARCHAR(45)", nullable: false),
                    last_name = table.Column<string>(type: "NVARCHAR(45)", nullable: false),
                    last_update = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "Now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actor", x => x.actor_id);
                    table.UniqueConstraint("AK_actor_first_name_last_name", x => new { x.first_name, x.last_name });
                });

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "NVARCHAR(25)", nullable: false),
                    last_update = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "Now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    customer_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "Now()"),
                    last_update = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "Now()"),
                    first_name = table.Column<string>(type: "varchar(45)", nullable: true),
                    last_name = table.Column<string>(type: "varchar(45)", nullable: true),
                    email = table.Column<string>(type: "varchar(50)", nullable: true),
                    active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.customer_id);
                });

            migrationBuilder.CreateTable(
                name: "language",
                columns: table => new
                {
                    language_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "char(20)", nullable: false),
                    last_update = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "Now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_language", x => x.language_id);
                });

            migrationBuilder.CreateTable(
                name: "staff",
                columns: table => new
                {
                    staff_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(type: "varchar(16)", nullable: false),
                    password = table.Column<string>(type: "varchar(40)", nullable: true),
                    last_update = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "Now()"),
                    first_name = table.Column<string>(type: "varchar(45)", nullable: true),
                    last_name = table.Column<string>(type: "varchar(45)", nullable: true),
                    email = table.Column<string>(type: "varchar(50)", nullable: true),
                    active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staff", x => x.staff_id);
                });

            migrationBuilder.CreateTable(
                name: "film",
                columns: table => new
                {
                    film_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                    length = table.Column<short>(type: "smallint", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    release_year = table.Column<string>(type: "nvarchar(4)", nullable: true),
                    language_id = table.Column<int>(type: "int", nullable: false),
                    original_language_id = table.Column<int>(type: "int", nullable: true),
                    rating = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    last_update = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "Now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_film", x => x.film_id);
                    table.ForeignKey(
                        name: "FK_film_language_language_id",
                        column: x => x.language_id,
                        principalTable: "language",
                        principalColumn: "language_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_film_language_original_language_id",
                        column: x => x.original_language_id,
                        principalTable: "language",
                        principalColumn: "language_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "film_actor",
                columns: table => new
                {
                    film_id = table.Column<int>(type: "int", nullable: false),
                    actor_id = table.Column<int>(type: "int", nullable: false),
                    last_update = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "Now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_film_actor", x => new { x.actor_id, x.film_id });
                    table.ForeignKey(
                        name: "FK_film_actor_actor_film_id",
                        column: x => x.film_id,
                        principalTable: "actor",
                        principalColumn: "actor_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_film_actor_film_actor_id",
                        column: x => x.actor_id,
                        principalTable: "film",
                        principalColumn: "film_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "film_category",
                columns: table => new
                {
                    film_id = table.Column<int>(type: "int", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    last_update = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "Now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_film_category", x => new { x.film_id, x.category_id });
                    table.ForeignKey(
                        name: "FK_film_category_category_category_id",
                        column: x => x.category_id,
                        principalTable: "category",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_film_category_film_film_id",
                        column: x => x.film_id,
                        principalTable: "film",
                        principalColumn: "film_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_actor_first_name",
                table: "actor",
                column: "first_name");

            migrationBuilder.CreateIndex(
                name: "IX_film_language_id",
                table: "film",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_film_original_language_id",
                table: "film",
                column: "original_language_id");

            migrationBuilder.CreateIndex(
                name: "IX_film_title",
                table: "film",
                column: "title");

            migrationBuilder.CreateIndex(
                name: "IX_film_actor_film_id",
                table: "film_actor",
                column: "film_id");

            migrationBuilder.CreateIndex(
                name: "IX_film_category_category_id",
                table: "film_category",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_language_name",
                table: "language",
                column: "name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "film_actor");

            migrationBuilder.DropTable(
                name: "film_category");

            migrationBuilder.DropTable(
                name: "staff");

            migrationBuilder.DropTable(
                name: "actor");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "film");

            migrationBuilder.DropTable(
                name: "language");
        }
    }
}
