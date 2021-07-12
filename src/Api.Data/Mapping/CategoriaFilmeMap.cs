using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Api.Domain.Entities;
using System;

namespace Api.Data.Mapping
{
    public class CategoriaFilmeMap : IEntityTypeConfiguration<CategoriaFilmeEntity>
    {
        public void Configure(EntityTypeBuilder<CategoriaFilmeEntity> builder)
        {
            
            builder.ToTable("film_category");

            builder.Property(a => a.CategoriaId)
            .HasColumnName("category_id");

            builder.Property(a => a.FilmeId)
            .HasColumnName("film_id");


            builder.HasKey(fa => new {fa.CategoriaId, fa.FilmeId});

            builder.Property<DateTime>("last_update")
                   .HasColumnType("datetime")
                   .HasDefaultValueSql("Now()")
                   .IsRequired();

            var filmeCategoria  = new CategoriaFilmeEntity { FilmeId = 1, CategoriaId = 1 };
            var filmeCategoria2 = new CategoriaFilmeEntity { FilmeId = 1, CategoriaId = 2 };
            var filmeCategoria3 = new CategoriaFilmeEntity { FilmeId = 2, CategoriaId = 2 };
            
            builder.HasData(filmeCategoria, filmeCategoria2, filmeCategoria3);
        }
    }
}