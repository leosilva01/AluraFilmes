using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class CategoriaMap : IEntityTypeConfiguration<CategoriaEntity>
    {
        
        public void Configure(EntityTypeBuilder<CategoriaEntity> builder)
        {
            builder.ToTable("category");
            
            builder.HasKey(c => c.Id);

            builder.Property(a => a.Id)
            .HasColumnName("category_id");
            
            builder.Property(a => a.Nome)
            .HasColumnName("name")
            .HasColumnType("NVARCHAR(25)")
            .IsRequired();

            builder.Property<DateTime>("last_update")
                   .HasColumnType("datetime")
                   .HasDefaultValueSql("Now()")
                   .IsRequired();


            var acao   = new CategoriaEntity{ Id = 1, Nome = "Drama" };
            var comedy = new CategoriaEntity{ Id = 2, Nome = "Comedy" };

            builder.HasData(acao, comedy);

            // Mapeando o many to many e incluindo a tabela(entidade) que auxiliar.
            // Cascade é para apagar o filme/categoria e excluir os registros da tabela de relacionamento
            builder.HasMany(s => s.Filmes).WithMany(s => s.Categorias)
                .UsingEntity<CategoriaFilmeEntity>(
                    x => x.HasOne(x => x.Filme)
                        .WithMany().HasForeignKey(x => x.FilmeId).OnDelete(DeleteBehavior.Cascade),
                    x => x.HasOne(x => x.Categoria)
                        .WithMany().HasForeignKey(x => x.CategoriaId).OnDelete(DeleteBehavior.Cascade));

        }
    }
}