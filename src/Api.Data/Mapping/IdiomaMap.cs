using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class IdiomaMap : IEntityTypeConfiguration<IdiomaEntity>
    {
        public void Configure(EntityTypeBuilder<IdiomaEntity> builder)
        {

            builder.ToTable("language");
            
            builder.HasKey(c => c.Id);

            builder.Property(a => a.Id)
            .HasColumnName("language_id");
            
            builder.Property(a => a.Nome)
            .HasColumnName("name")
            .HasColumnType("char(20)")
            .IsRequired();

            builder.HasIndex(c => c.Nome);

            builder.Property<DateTime>("last_update")
                   .HasColumnType("datetime")
                   .HasDefaultValueSql("Now()")
                   .IsRequired();

            var portugues = new IdiomaEntity { Id = 1, Nome  = "Português"};
            var ingles = new IdiomaEntity { Id  = 2, Nome  = "Inglês"};

            builder.HasData(portugues, ingles);
        }
    }
}