using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class TabelaFuncionarioECliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    customer_id = table.Column<byte>(type: "tinyint unsigned", nullable: false),
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
                name: "staff",
                columns: table => new
                {
                    staff_id = table.Column<byte>(type: "tinyint unsigned", nullable: false),
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "staff");
        }
    }
}
