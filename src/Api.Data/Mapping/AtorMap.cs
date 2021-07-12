using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class AtorMap : IEntityTypeConfiguration<AtorEntity>
    {
        public void Configure(EntityTypeBuilder<AtorEntity> builder)
        {

            builder.ToTable("actor");
            
            builder.HasKey(c => c.Id);

            builder.Property(a => a.Id)
            .HasColumnName("actor_id");
            
            builder.Property(a => a.PrimeiroNome)
            .HasColumnName("first_name")
            .HasColumnType("NVARCHAR(45)")
            .IsRequired();

            builder.Property(a => a.UltimoNome)
            .HasColumnName("last_name")
            .HasColumnType("NVARCHAR(45)")
            .IsRequired();

            builder.HasIndex(c => c.PrimeiroNome);

            // Shadow property
            builder.Property<DateTime>("last_update")
                   .HasColumnType("datetime")
                   .HasDefaultValueSql("Now()")
                   .IsRequired();

            // builder.HasAlternateKey(a => new {a.PrimeiroNome, a.UltimoNome});

            var ator = new AtorEntity { Id = 1, PrimeiroNome = "Tom", UltimoNome = "Hanks" };
            var ator2 = new AtorEntity { Id = 2, PrimeiroNome = "Ed", UltimoNome = "Murphy" };

            builder.HasData(ator, ator2);


            // Mapeando o many to many e incluindo a tabela(entidade) que auxiliar.
            // Cascade é para apagar o filme/ator e excluir os registros da tabela de relacionamento
            builder.HasMany(s => s.Filmes).WithMany(s => s.Atores)
                .UsingEntity<FilmeAtorEntity>(
                    x => x.HasOne(x => x.Filme)
                        .WithMany().HasForeignKey(x => x.FilmeId).OnDelete(DeleteBehavior.Cascade),
                    x => x.HasOne(x => x.Ator)
                        .WithMany().HasForeignKey(x => x.AtorId).OnDelete(DeleteBehavior.Cascade));
        }
    }
}