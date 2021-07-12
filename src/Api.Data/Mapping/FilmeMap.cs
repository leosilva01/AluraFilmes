using System;
using Api.Domain.Entities;
using Api.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class FilmeMap : IEntityTypeConfiguration<FilmeEntity>
    {
        public void Configure(EntityTypeBuilder<FilmeEntity> builder)
        {
            builder.ToTable("film");
            
            builder.HasKey(c => c.Id);

            builder.Property(a => a.Id)
            .HasColumnName("film_id");
            
            builder.Property(a => a.Titulo)
            .HasColumnName("title")
            .HasColumnType("NVARCHAR(255)")
            .IsRequired();

            builder.Property(a => a.Descricao)
            .HasColumnName("description")
            .HasColumnType("text");

            builder.Property(a => a.AnoLancamento)
            .HasColumnName("release_year")
            .HasColumnType("nvarchar(4)");

            builder.Property(a => a.Duracao)
            .HasColumnName("length");

            builder.Property(a => a.Classificacao)
            .HasColumnName("rating")
            .HasColumnType("nvarchar(10)")
            .HasConversion(
                v => v.ToString(),
                v => (ClassificacaoIndicativa)Enum.Parse(typeof(ClassificacaoIndicativa), v));

            builder.HasIndex(c => c.Titulo);

            builder.Property<DateTime>("last_update")
                   .HasColumnType("datetime")
                   .HasDefaultValueSql("Now()")
                   .IsRequired();

            builder.Property<int>("language_id");
            builder.Property<int?>("original_language_id");


            builder.HasOne(f => f.IdiomaFalado)
                   .WithMany(i => i.FilmesFalados)
                   .HasForeignKey("language_id");

            builder.HasOne(f => f.IdiomaOriginal)
                   .WithMany(i => i.FilmesOriginais)
                   .HasForeignKey("original_language_id");


            var filme = new { 
                Id = 1,
                Titulo = "Forrest Gump",
                AnoLancamento = "1999",
                Classificacao = ClassificacaoIndicativa.G,
                Descricao = "Descrição Filme Drama",
                Duracao = Convert.ToInt16(120),
                language_id = 1
            };

            var filme2 = new { 
                Id = 2,
                Titulo = "Norbit",
                AnoLancamento = "1999",
                Classificacao = ClassificacaoIndicativa.R,
                Descricao = "Filme Comédia",
                Duracao = Convert.ToInt16(220),
                language_id = 1,
                original_language_id = 2
            };

            builder.HasData(filme, filme2);

            // builder.Property(a => a.IdiomaFaladoId)
            //     .HasColumnName("language_id");
                
            // builder.Property(a => a.IdiomaOriginalFaladoId)
            //     .HasColumnName("original_language_id");

            // builder.HasOne(f => f.IdiomaFalado)
            //        .WithMany(i => i.FilmesFalados)
            //        .HasForeignKey(f => f.IdiomaFaladoId);

            // builder.HasOne(f => f.IdiomaOriginal)
            //        .WithMany(i => i.FilmesOriginais)
            //        .HasForeignKey(f => f.IdiomaOriginalFaladoId);
        }
    }
}