using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class procedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"CREATE PROCEDURE actors_from_given_category(IN category_name VARCHAR(25))
                        BEGIN
                            SELECT a.first_name, a.last_name, c.name, f.title, f.description, f.release_year, length, rating
                            from actor a
                                inner join film_actor fa on fa.actor_id = a.actor_id
                                inner join film f on f.film_id = fa.film_id
                                inner join film_category fc on fc.film_id = f.film_id
                                inner join category c on c.category_id = fc.category_id
                            where c.name = category_name;
                        END";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW actors_from_given_category");
        }
    }
}
