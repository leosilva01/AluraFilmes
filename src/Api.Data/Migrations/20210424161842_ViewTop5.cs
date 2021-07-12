using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ViewTop5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"CREATE VIEW top5_most_starred_actors AS 
            select a.actor_id AS actor_id, a.first_name AS first_name, a.last_name AS last_name, count(fa.film_id) AS total
                from actor a join film_actor fa on (fa.actor_id = a.actor_id)
            group by a.actor_id, a.first_name, a.last_name 
            order by total
            desc limit 5;";

            migrationBuilder.Sql(sql);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW top5_most_starred_actors");
        }
    }
}
