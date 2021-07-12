using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class AtoresPorCategoriaMap : IEntityTypeConfiguration<AtoresPorCategoriaResult>
    {
        public void Configure(EntityTypeBuilder<AtoresPorCategoriaResult> builder)
        {
            
            builder.ToSqlQuery("actors_from_given_category");

            builder.HasNoKey();

            builder.Property(a => a.AnoLancamento)
            .HasColumnName("release_year");
            
            builder.Property(a => a.Categoria)
            .HasColumnName("name");

            builder.Property(a => a.Classificacao)
            .HasColumnName("rating");

            builder.Property(a => a.DescricaoFilme)
            .HasColumnName("description");
            
            builder.Property(a => a.Duracao)
            .HasColumnName("length");

            builder.Property(a => a.NomeFilme)
            .HasColumnName("title");

            builder.Property(a => a.PrimeiroNome)
            .HasColumnName("first_name");

            builder.Property(a => a.UltimoNome)
            .HasColumnName("last_name");
        }
    }
}