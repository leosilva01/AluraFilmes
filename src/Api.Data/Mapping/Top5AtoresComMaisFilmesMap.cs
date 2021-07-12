using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class Top5AtoresComMaisFilmesMap : IEntityTypeConfiguration<Top5AtoresComMaisFilmesResult>
    {
        public void Configure(EntityTypeBuilder<Top5AtoresComMaisFilmesResult> builder)
        {

            builder.ToView("top5_most_starred_actors");
            
            builder.HasNoKey();

            builder.Property(a => a.Id)
            .HasColumnName("actor_id");
            
            builder.Property(a => a.PrimeiroNome)
            .HasColumnName("first_name")
            .HasColumnType("NVARCHAR(45)");

            builder.Property(a => a.UltimoNome)
            .HasColumnName("last_name")
            .HasColumnType("NVARCHAR(45)");

            builder.Property(a => a.TotalDeFilmes)
            .HasColumnName("total");
        }
    }
}