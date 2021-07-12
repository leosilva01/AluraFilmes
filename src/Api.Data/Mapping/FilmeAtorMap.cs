using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Api.Domain.Entities;
using System;

namespace Api.Data.Mapping
{
    public class FilmeAtorMap : IEntityTypeConfiguration<FilmeAtorEntity>
    {
        public void Configure(EntityTypeBuilder<FilmeAtorEntity> builder)
        {
            
            builder.ToTable("film_actor");

            builder.Property(a => a.AtorId)
            .HasColumnName("actor_id");

            builder.Property(a => a.FilmeId)
            .HasColumnName("film_id");


            builder.HasKey(fa => new {fa.AtorId, fa.FilmeId});

            // builder.Property<int>("film_id").IsRequired();
            // builder.Property<int>("actor_id").IsRequired();

            // builder.HasKey("film_id", "actor_id");

            // builder.HasOne(fa => fa.Filme)
            //        .WithMany(f => f.FilmesAtores)
            //        .HasForeignKey(f => f.FilmeId);

            // builder.HasOne(fa => fa.Ator)
            //        .WithMany(f => f.FilmesAtores)
            //        .HasForeignKey(f => f.AtorId);

            builder.Property<DateTime>("last_update")
                .HasColumnType("datetime")
                .HasDefaultValueSql("Now()")
                .IsRequired();

            var filmeAtor  = new FilmeAtorEntity{ AtorId = 1, FilmeId = 1 };
            var filmeAtor2 = new FilmeAtorEntity{ AtorId = 1, FilmeId = 2 };
            var filmeAtor3 = new FilmeAtorEntity{ AtorId = 2, FilmeId = 2 };

            builder.HasData(filmeAtor, filmeAtor2, filmeAtor3);

        }
    }
}